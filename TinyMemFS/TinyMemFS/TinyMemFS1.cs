using System.Text;
using System.Security.Cryptography;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression;



class TinyMemFS1
{
    List<fileMeta> list;
    Mutex mutex;
    //Dictionary<string, byte[]> dictFile;
    //Dictionary<string, FileStream> dictFile;

    public TinyMemFS1()
    {
        // constructor
        list = new List<fileMeta>();
        mutex = new Mutex();
        //dictFile = new Dictionary<string, byte[] >();
        //dictFile = new Dictionary<string, FileStream>();
    }

    public bool add(String fileName, String fileToAdd)
    {
        // fileName - The name of the file to be added to the file system
        // fileToAdd - The file path on the computer that we add to the system
        // return false if operation failed for any reason
        // Example:
        // add("name1.pdf", "C:\\Users\\user\Desktop\\report.pdf")
        // note that fileToAdd isn't the same as the fileName
        if (fileName == null || fileToAdd == null)
            return false;
        if (File.Exists(fileToAdd))
        {
            if(fileExist(fileName) >= 0)
            {
                //if file with same name already exist
                return false;
            }
            if (fileName == Path.GetFileName(fileToAdd))
            {//add this fileMeta + file to the Memory
                mutex.WaitOne();
                fileMeta fMeta = new fileMeta(fileName, fileToAdd);
                list.Add(fMeta);
                mutex.ReleaseMutex();
                return true;
            }
        }
        return false;
    }
    public bool remove(String fileName)
    {
        // fileName - remove fileName from the system
        // this operation releases all allocated memory for this file
        // return false if operation failed for any reason
        // Example:
        // remove("name1.pdf")

        /*for (int i = 0; i < list.Count; i++)
        {
            if(list[i].getFileName() == fileName)          
                list.RemoveAt(i);        
        }*/
        if (fileName == null)
            return false;
        int index = fileExist(fileName);
        if (index >= 0)
        {
            mutex.WaitOne();
            list.RemoveAt(index);
            mutex.ReleaseMutex();
            return true;
        }
        return false;

    }
    public List<String> listFiles()
    {
        // The function returns a list of strings with the file information in the system
        // Each string holds details of one file as following: "fileName,size,creation time"
        // Example:{
        // "report.pdf,630KB,Friday, ‎May ‎13, ‎2022, ‏‎12:16:32 PM",
        // "table1.csv,220KB,Monday, ‎February ‎14, ‎2022, ‏‎8:38:24 PM" }
        // You can use any format for the creation time and date

        List<String> files = new List<string>();
        mutex.WaitOne();
        for (int i = 0; i < list.Count; i++)
        {
            if(list[i].getHidden().Equals(false))
            {
                string details = list[i].getFileName() + ", " + list[i].getFileSizeString() + ", " + list[i].getdtCreationString();
                files.Add(details);
            }

        }
        mutex.ReleaseMutex();
        return files;

    }
    public bool save(String fileName, String fileToAdd)
    {
        // this function saves file from the TinyMemFS file system into a file in the physical disk
        // fileName - file name from TinyMemFS to save in the computer
        // fileToAdd - The file path to be saved on the computer
        // return false if operation failed for any reason
        // Example:
        // save("name1.pdf", "C:\\tmp\\fileName.pdf")

        int index = fileExist(fileName);
        if (index >= 0)
        {
            mutex.WaitOne();
            File.WriteAllBytes(fileToAdd, list[index].getFileData());
            mutex.ReleaseMutex();
            return true;
        }
        return false;
    }
    public bool encrypt(String key)
    {
        // key - Encryption key to encrypt the contents of all files in the system 
        // You can use an encryption algorithm of your choice
        // return false if operation failed for any reason
        // Example:
        // encrypt("myFSpassword")
        mutex.WaitOne();
        try
        {
            key = completeString(key);
            if(key.Length > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {

                    string data = Encoding.Default.GetString(list[i].getFileData());
                    list[i].setFileData(Encoding.Default.GetBytes(AesEncrypt(data, key)));
                    list[i].encryptUp();

                }
                mutex.ReleaseMutex();
                return true;
            }
            return false;
        }

        catch (Exception e)
        {
            mutex.ReleaseMutex();
            return false;
        }

    }


    public static string AesEncrypt(string value, string key, string iv = "")
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;
        if (key == null) throw new Exception("The object reference is not set to the instance of the object. ");
        if (key.Length < 16) throw new Exception("specified key length cannot be less than 16 bits. ");
        if (key.Length > 32) throw new Exception("specified key length cannot be more than 32 bits. ");
        if (key.Length != 16 && key.Length != 24 && key.Length != 32) throw new Exception("specified key length is ambiguous. ");
        if (!string.IsNullOrEmpty(iv))
        {
            if (iv.Length < 16) throw new Exception("The length of the specified vector cannot be less than 16 bits. ");
        }

        var _keyByte = Encoding.UTF8.GetBytes(key);
        var _valueByte = Encoding.UTF8.GetBytes(value);
        using (var aes = new RijndaelManaged())
        {
            aes.IV = !string.IsNullOrEmpty(iv) ? Encoding.UTF8.GetBytes(iv) : Encoding.UTF8.GetBytes(key.Substring(0, 16));
            aes.Key = _keyByte;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            var cryptoTransform = aes.CreateEncryptor();
            var resultArray = cryptoTransform.TransformFinalBlock(_valueByte, 0, _valueByte.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }



    public bool decrypt(String key)
    {
        //byte[] password = Encoding.ASCII.GetBytes(key);
        // fileName - Decryption key to decrypt the contents of all files in the system 
        // return false if operation failed for any reason
        // Example:
        // decrypt("myFSpassword")
        mutex.WaitOne();
        try
        {
            key = completeString(key);
            int total = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].getencrypt() > 0)
                {
                    string data = Encoding.Default.GetString(list[i].getFileData());
                    list[i].setFileData(Encoding.Default.GetBytes(AesDecrypt(data, key)));
                    list[i].encryptDown();
                    total += list[i].getencrypt();
                }

            }
            mutex.ReleaseMutex();
            if (total == 0)
                return true;
            else
                return false;
        }
        catch (Exception e)
        {
            mutex.ReleaseMutex();
            return false;
        }
    }


    public static string AesDecrypt(string value, string key, string iv = "")
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;
        if (key == null) throw new Exception("The object reference is not set to the instance of the object. ");
        if (key.Length < 16) throw new Exception("specified key length cannot be less than 16 bits. ");
        if (key.Length > 32) throw new Exception("specified key length cannot be more than 32 bits. ");
        if (key.Length != 16 && key.Length != 24 && key.Length != 32) throw new Exception("specified key length is ambiguous. ");
        if (!string.IsNullOrEmpty(iv))
        {
            if (iv.Length < 16) throw new Exception("The length of the specified vector cannot be less than 16 bits. ");
        }

        var _keyByte = Encoding.UTF8.GetBytes(key);
        var _valueByte = Convert.FromBase64String(value);
        using (var aes = new RijndaelManaged())
        {
            aes.IV = !string.IsNullOrEmpty(iv) ? Encoding.UTF8.GetBytes(iv) : Encoding.UTF8.GetBytes(key.Substring(0, 16));
            aes.Key = _keyByte;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            var cryptoTransform = aes.CreateDecryptor();
            var resultArray = cryptoTransform.TransformFinalBlock(_valueByte, 0, _valueByte.Length);
            return Encoding.UTF8.GetString(resultArray);
        }
    }



    // ************** NOT MANDATORY ********************************************
    // ********** Extended features of TinyMemFS ********************************
    public bool saveToDisk(String fileName)
    {
        /*
         * Save the FS to a single file in disk
         * return false if operation failed for any reason
         * You should store the entire FS (metadata and files) from memory to a single file.
         * You can decide how to save the FS in a single file (format, etc.) 
         * Example:
         * SaveToDisk("MYTINYFS.DAT")
         */
        return false;
    }


    public bool loadFromDisk(String fileName)
    {
        /*
         * Load a saved FS from a file  
         * return false if operation failed for any reason
         * You should clear all the files in the current TinyMemFS if exist, before loading the filenName
         * Example:
         * LoadFromDisk("MYTINYFS.DAT")
         */
        return false;
    }

    public bool compressFile(String fileName)
    {
        /* Compress file fileName
         * return false if operation failed for any reason
         * You can use an compression/uncompression algorithm of your choice
         * Note that the file size might be changed due to this operation, update it accordingly
         * Example:
         * compressFile ("name1.pdf");
         */
        List<byte> byteList = new List<byte>();
        try
        {
            Deflater compressor = new Deflater(Deflater.BEST_COMPRESSION);
            int index = fileExist(fileName);
            byte[] data = list[index].getFileData();
            compressor.SetInput(data);
            compressor.Finish();

            // Try to read the compressed data 1024 bytes at a time 
            byte[] readBuffer = new byte[16];
            int readCount = 0;

            while (!compressor.IsFinished)
            {
                readCount = compressor.Deflate(readBuffer);
                foreach (byte b in readBuffer)
                {
                    byteList.Add(b);
                }
            }
            compressor.Flush();
            byte[] compressedFile = byteList.ToArray();
            list[index].setFileData(compressedFile);
            list[index].updateFileSize();
            return true;
        }catch(Exception ex)
        {
            return false;
        }
        
    }

    public bool uncompressFile(String fileName)
    {
        /* uncompress file fileName
         * return false if operation failed for any reason
         * You can use an compression/uncompression algorithm of your choice
         * Note that the file size might be changed due to this operation, update it accordingly
         * Example:
         * uncompressFile ("name1.pdf");
         */
        try
        {
            List<byte> byteList = new List<byte>();
            int index = fileExist(fileName);
            byte[] data = list[index].getFileData();

            Inflater decompressor = new Inflater();
            decompressor.SetInput(data);

            byte[] readBuffer = new byte[16];
            int readCount = 0;

            while (!decompressor.IsFinished)
            {
                readCount = decompressor.Inflate(readBuffer);
                foreach (byte b in readBuffer)
                {
                    byteList.Add(b);
                }
            }
            //decompressor
            byte[] compressedFile = byteList.ToArray();
            list[index].setFileData(compressedFile);
            list[index].updateFileSize();
            return true;
        }catch(Exception ex)
        {
            return false;
        }

    }

    public bool setHidden(String fileName, bool hidden)
    {
        /* set the hidden property of fileName
         * If file is hidden, it will not appear in the listFiles() results
         * return false if operation failed for any reason
         * Example:
         * setHidden ("name1.pdf", true);
         */
        mutex.WaitOne();
        try
        {
            int index = fileExist(fileName);
            if (index >= 0)
            {
                list[index].setHidden(hidden);
                mutex.ReleaseMutex();
                return true;
            }
        }
        catch (Exception e)
        {
            mutex.ReleaseMutex();
            return false;
        }
        return false;
    }


    public bool rename(String fileName, String newFileName)
    {
        /* Rename filename to newFileName
         * Return false if operation failed for any reason (E.g., newFileName already exists)
         * Example:
         * rename ("name1.pdf", "name2.pdf");
         */
        mutex.WaitOne();
        try
        {
            int index = fileExist(fileName);
            if(index >= 0)
            {
                if(fileExist(newFileName) < 0)
                {
                    list[index].setName(newFileName);
                    mutex.ReleaseMutex();
                    return true;
                }

            }
        }
        catch (Exception e)
        {
            mutex.ReleaseMutex();
            return false;
        }
        return false;
    }


    //check code!
    public bool copy(String fileName1, String fileName2)
    {
        /* Rename filename1 to a new filename2
         * Return false if operation failed for any reason (E.g., fileName1 doesn't exist or filename2 already exists)
         * Example:
         * rename ("name1.pdf", "name2.pdf");
         */
        mutex.WaitOne();
        try
        {

            int index = fileExist(fileName1);
            if (index >= 0)
            {
                fileMeta clone = new fileMeta(fileName2, list[index].getFileSize(), list[index].getFileData(), list[index].getCreationDate());
                list.Add(clone);
                mutex.ReleaseMutex();
                return true;
            }
        }
        catch (Exception e)
        {
            mutex.ReleaseMutex();
            return false;
        }
        return false;
    }


    public void sortByName()
    {
        /* Sort the files in the FS by their names (alphabetical order)
         * This should affect the order the files appear in the listFiles 
         * if two names are equal you can sort them arbitrarily
         */
        mutex.WaitOne();
        list.Sort((x, y) => x.getFileName().CompareTo(y.getFileName()));
        mutex.ReleaseMutex();
        return;
    }

    public void sortByDate()
    {
        /* Sort the files in the FS by their date (new to old)
         * This should affect the order the files appear in the listFiles  
         * if two dates are equal you can sort them arbitrarily
         */
        mutex.WaitOne();
        list.Sort((x, y) => x.getCreationDate().CompareTo(y.getCreationDate()));
        list.Reverse();
        mutex.ReleaseMutex();
        return;
    }

    public void sortBySize()
    {
        /* Sort the files in the FS by their sizes (large to small)
         * This should affect the order the files appear in the listFiles  
         * if two sizes are equal you can sort them arbitrarily
         */
        mutex.WaitOne();
        list.Sort((x, y) => x.getFileSize().CompareTo(y.getFileSize()));
        list.Reverse();
        mutex.ReleaseMutex();
        return;
    }


    public bool compare(String fileName1, String fileName2)
    {
        /* compare fileName1 and fileName2
         * files considered equal if their content is equal 
         * Return false if the two files are not equal, or if operation failed for any reason (E.g., fileName1 or fileName2 not exist)
         * Example:
         * compare ("name1.pdf", "name2.pdf");
         */
        mutex.WaitOne();
        try
        {
            int index1 = fileExist(fileName1);
            int index2 = fileExist(fileName2);
            if (index1 >= 0 && index2 >= 0)
            {             
                bool ans =list[index1].getFileData().Equals(list[index2].getFileData());
                mutex.ReleaseMutex();
                return ans;
            }
        }

        catch (Exception e)
        {
            mutex.ReleaseMutex();
            return false;
        }
        return false;
    }

    public Int64 getSize()
    {
        /* return the size of all files in the FS (sum of all sizes)
         */
        Int64 allSize = 0;
        for (int i = 0; i < list.Count; i++)
        {
            allSize += list[i].getFileSize();
        }
            return allSize;
    }


    ///OUR
    public bool GetFileHiddenProperty(int i)
    {
        return this.list[i].getHidden();
    }

    public byte[] getData(int i)
    {
        return list[i].getFileData();

    }

    
    public  string completeString(string key)
    {
        if (key.Length == 16 || key.Length == 24 || key.Length == 32)
        {
            return key;
        }
        else if(key.Length == 0)
        {
            return "";
        }
        else if(key.Length < 16)
        {
            for (int i=key.Length; i<16; i++)
            {
                key = key + "c";
            }
            return key;
        }
        else if (key.Length < 24)
        {
            for (int i = key.Length; i < 24; i++)
            {
                key = key + "c";
            }
            return key;
        }
        else if (key.Length < 32)
        {
            for (int i = key.Length; i < 32; i++)
            {
                key = key + "c";
            }
            return key;
        }
        else
        {
            key = key.Remove(0, 32);
            return key;
        }
        
    }






    public void printFileInfo()
    {
        List<String> listSTR = listFiles();
        for (int i = 0; i < listSTR.Count; i++)
        {
            Console.WriteLine(listSTR[i]);
        }
    }

    public int fileExist(String fileName)
    {
        for (int i = 0; i < list.Count; i++)
        {
            //list[i].getFileName().Equals(fileName)
            if (String.Equals(list[i].getFileName(), fileName, StringComparison.InvariantCultureIgnoreCase))
                return i;
        }
        return -1;
    }





    public List<ListViewItem> getListViewItems()
    {
        List<ListViewItem> items = new List<ListViewItem>();
        //string[,] items = new string[list.Count, 3];
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].getHidden().Equals(false))
            {
                string[] details = { list[i].getFileName(), list[i].getFileSizeString(), list[i].getdtCreationString() };
                items.Add(new ListViewItem(details));
            }

        }
        return items;




    }


    class fileMeta
    {
        String fileName;
        long fileSize;
        DateTime dtCreation;
        byte[] fileData;
        bool hidden = false;
        int encryptNumber;

        public fileMeta(String fileName, String path)
        {
            this.fileName = fileName;
            this.fileSize = new FileInfo(path).Length;
            this.dtCreation = File.GetCreationTime(path);
            this.fileData = File.ReadAllBytes(path);
            this.encryptNumber = 0;
        }

        public fileMeta(String fileName, long fileSize, byte[] fileData, DateTime dtCreation)
        {
            this.fileName = fileName;
            this.fileSize = fileSize;
            this.dtCreation = dtCreation;
            this.fileData = fileData;
        }

        public String getFileName()
        {
            return this.fileName;
        }
        public String getdtCreationString()
        {
            return this.dtCreation.ToString();
        }

        public DateTime getCreationDate()
        {
            return dtCreation;
        }
        public String getFileSizeString()
        {
            return this.fileSize.ToString();
        }

        public long getFileSize()
        {
            return this.fileSize;
        }

        public byte[] getFileData()
        {
            return this.fileData;
        }

        public void setName(String newName)
        {
            fileName = newName;
        }

        public void setHidden(bool h)
        {
            hidden = h;
        }

        public bool getHidden()
        {
            return hidden;
        }

        public void setFileData(byte[] data)
        {
            this.fileData = data;
        }



        public void encryptUp()
        {
            this.encryptNumber++;
        }

        public void encryptDown()
        {
            this.encryptNumber--;
        }




        public int getencrypt()
        {
            return encryptNumber;
        }


        public void updateFileSize()
        {
            this.fileSize = this.getFileData().Length;
        }
    }
}

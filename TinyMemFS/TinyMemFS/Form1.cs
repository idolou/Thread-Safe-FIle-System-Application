using System.Text;

namespace TinyMemFS
{
    public partial class Form1 : Form
    {
        TinyMemFS1 fileSystem;
        public Form1()
        {
            fileSystem = new TinyMemFS1();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(Hidden, "if check box is selected the file will be hidden, otherwise it will apear in the file sysyem");
            toolTip1.SetToolTip(SaveToFile, "save file content to existing file in your sysytem");
            toolTip1.SetToolTip(CreateNewFIle, "save selected file content to a new File");

            
        }

        //add file browser
        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (fileSystem.add(Path.GetFileName(ofd.FileName), ofd.FileName))
                {
                    updateList();
                    //MessageBox.Show(Path.GetFileName(ofd.FileName) + "\nWas added successfully to the system");
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (fileSystem.remove(Path.GetFileName(ofd.FileName)))
                {
                    updateList();
                    MessageBox.Show(Path.GetFileName(ofd.FileName) + "\nWas removed successfully from the system");
                }
                else
                {
                    MessageBox.Show(Path.GetFileName(ofd.FileName) + "\nWas not found in the file system");

                }
            }


        }

        private void RemoveByName_Click(object sender, EventArgs e)
        {
            String fileName = textBox1.Text;
            if(fileSystem.remove(textBox1.Text))
            {
                updateList();
                MessageBox.Show(fileName + "\nWas removed successfully from the system");
            }
            else
            {
                MessageBox.Show(fileName + "\nWas not found in the file system");

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<String> allFiles = fileSystem.listFiles();
            foreach(string s in allFiles)
            {
                MessageBox.Show(s);
            }
            updateList();
            MessageBox.Show("All files in system are up to date");

        }
        private void updateList()
        {
            //List<String> allFiles = fileSystem.listFiles();
            List<ListViewItem> items = fileSystem.getListViewItems();
            listView1.Items.Clear();
            string size = fileSystem.getSize().ToString();
            label1.Text = "Size =" + size;

            foreach (ListViewItem it in items)
            {
                listView1.Items.Add(it);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
            
            if (fileSystem.encrypt(encryptkey.Text))
            {
                MessageBox.Show("All files encrypted");
            }
            else
            {
                MessageBox.Show("Something went wrong...");

            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                int i = listView1.SelectedIndices[0];
                MessageBox.Show(Encoding.ASCII.GetString(fileSystem.getData(i)));
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fileSystem.decrypt(encryptkey.Text))
            {
                MessageBox.Show("All files decrypted");
            }
            else
            {
                MessageBox.Show("Some files are still encrypted");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fileSystem.setHidden(textBox2.Text, checkBox1.Checked);
            updateList();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int i = listView1.SelectedIndices[0];
                string fName = listView1.SelectedItems[0].SubItems[0].Text;
                if (fileSystem.remove(fName))
                {
                    updateList();
                    MessageBox.Show(Path.GetFileName(fName) + "\nWas removed successfully from the system");
                }
                else
                {
                    MessageBox.Show(Path.GetFileName(fName) + "\nWas not found in the file system");

                }
            }
        }

        private void SaveToFile_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int i = listView1.SelectedIndices[0];
                string fName = listView1.SelectedItems[0].SubItems[0].Text;

                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                    if (fileSystem.save(fName, ofd.FileName))
                    {
                        updateList();
                        MessageBox.Show(fName + "\nWas saved successfully");
                    }


                }







            }
            

        }

        private void CreateNewFIle_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int i = listView1.SelectedIndices[0];
                string fName = listView1.SelectedItems[0].SubItems[0].Text;

                SaveFileDialog sdf = new SaveFileDialog();
                if (sdf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show(fName + "\nWas saved successfully to the file " + sdf.FileName);

                }


            }
        }

        private void HideFile_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int i = listView1.SelectedIndices[0];
                string fName = listView1.SelectedItems[0].SubItems[0].Text;

                if (fileSystem.GetFileHiddenProperty(i) == false)
                {
                    fileSystem.setHidden(fName, true);
                    updateList();
                }
                else
                {
                    fileSystem.setHidden(fName, false);
                    updateList();
                }
            }
        }

        private void getSize_Click(object sender, EventArgs e)
        {
            string size = fileSystem.getSize().ToString();
            label1.Text = "Size =" + size;
            MessageBox.Show("Size =" + size);

        }

        private void sortDate_Click(object sender, EventArgs e)
        {
            fileSystem.sortByDate();
            updateList();
        }

        private void sortNmae_Click(object sender, EventArgs e)
        {
            fileSystem.sortByName();
            updateList();
        }

        private void sortSize_Click(object sender, EventArgs e)
        {
            fileSystem.sortBySize();
            updateList();
        }

        private void rename_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int i = listView1.SelectedIndices[0];
                string fName = listView1.SelectedItems[0].SubItems[0].Text;
                fileSystem.rename(fName, textBox3.Text);
                updateList();
            }
            }




        private void compress_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int i = listView1.SelectedIndices[0];
                string fName = listView1.SelectedItems[0].SubItems[0].Text;
                if (fileSystem.compressFile(fName))
                {
                    updateList();
                    MessageBox.Show("File Compressed");
                }
                else
                {
                    MessageBox.Show("Something went wrong...");

                }

            }
        }

        private void decompress_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int i = listView1.SelectedIndices[0];
                string fName = listView1.SelectedItems[0].SubItems[0].Text;
                if (fileSystem.uncompressFile(fName))
                {
                    updateList();
                    MessageBox.Show("File UN-Compressed");
                }
                else
                {
                    MessageBox.Show("Something went wrong...");

                }

            }
        }
    }
    }
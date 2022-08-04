namespace TinyMemFS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BrowseFiletoAdd = new System.Windows.Forms.Button();
            this.BrowseFiletoRemove = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RemoveByName = new System.Windows.Forms.Button();
            this.ListAllFiles = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.size = new System.Windows.Forms.ColumnHeader();
            this.creation = new System.Windows.Forms.ColumnHeader();
            this.Encrypt = new System.Windows.Forms.Button();
            this.Decrypt = new System.Windows.Forms.Button();
            this.showData = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Hidden = new System.Windows.Forms.Button();
            this.removeSelected = new System.Windows.Forms.Button();
            this.SaveToFile = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CreateNewFIle = new System.Windows.Forms.Button();
            this.HideFile = new System.Windows.Forms.Button();
            this.encryptkey = new System.Windows.Forms.TextBox();
            this.getSize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sortSize = new System.Windows.Forms.Button();
            this.sortNmae = new System.Windows.Forms.Button();
            this.sortDate = new System.Windows.Forms.Button();
            this.rename = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.compress = new System.Windows.Forms.Button();
            this.decompress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BrowseFiletoAdd
            // 
            this.BrowseFiletoAdd.BackColor = System.Drawing.Color.OliveDrab;
            this.BrowseFiletoAdd.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BrowseFiletoAdd.Location = new System.Drawing.Point(9, 21);
            this.BrowseFiletoAdd.Name = "BrowseFiletoAdd";
            this.BrowseFiletoAdd.Size = new System.Drawing.Size(212, 42);
            this.BrowseFiletoAdd.TabIndex = 0;
            this.BrowseFiletoAdd.Text = "Browse File to Add";
            this.BrowseFiletoAdd.UseVisualStyleBackColor = false;
            this.BrowseFiletoAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // BrowseFiletoRemove
            // 
            this.BrowseFiletoRemove.BackColor = System.Drawing.Color.OliveDrab;
            this.BrowseFiletoRemove.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BrowseFiletoRemove.Location = new System.Drawing.Point(9, 69);
            this.BrowseFiletoRemove.Name = "BrowseFiletoRemove";
            this.BrowseFiletoRemove.Size = new System.Drawing.Size(212, 42);
            this.BrowseFiletoRemove.TabIndex = 1;
            this.BrowseFiletoRemove.Text = "Browse FIle to Remove";
            this.BrowseFiletoRemove.UseVisualStyleBackColor = false;
            this.BrowseFiletoRemove.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(9, 155);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "File Name";
            this.textBox1.Size = new System.Drawing.Size(186, 30);
            this.textBox1.TabIndex = 2;
            // 
            // RemoveByName
            // 
            this.RemoveByName.BackColor = System.Drawing.Color.OliveDrab;
            this.RemoveByName.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RemoveByName.Location = new System.Drawing.Point(9, 191);
            this.RemoveByName.Name = "RemoveByName";
            this.RemoveByName.Size = new System.Drawing.Size(186, 53);
            this.RemoveByName.TabIndex = 3;
            this.RemoveByName.Text = "Remove By Name";
            this.RemoveByName.UseVisualStyleBackColor = false;
            this.RemoveByName.Click += new System.EventHandler(this.RemoveByName_Click);
            // 
            // ListAllFiles
            // 
            this.ListAllFiles.BackColor = System.Drawing.Color.OliveDrab;
            this.ListAllFiles.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ListAllFiles.Location = new System.Drawing.Point(1190, 27);
            this.ListAllFiles.Name = "ListAllFiles";
            this.ListAllFiles.Size = new System.Drawing.Size(145, 35);
            this.ListAllFiles.TabIndex = 4;
            this.ListAllFiles.Text = "List All Files";
            this.ListAllFiles.UseVisualStyleBackColor = false;
            this.ListAllFiles.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.SlateGray;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.size,
            this.creation});
            this.listView1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(679, 69);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(656, 769);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "File Name";
            this.name.Width = 205;
            // 
            // size
            // 
            this.size.Text = "Size";
            this.size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.size.Width = 205;
            // 
            // creation
            // 
            this.creation.Text = "Creation Time";
            this.creation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.creation.Width = 240;
            // 
            // Encrypt
            // 
            this.Encrypt.BackColor = System.Drawing.Color.RosyBrown;
            this.Encrypt.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Encrypt.Location = new System.Drawing.Point(208, 343);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(161, 36);
            this.Encrypt.TabIndex = 6;
            this.Encrypt.Text = "Encrypt all files";
            this.Encrypt.UseVisualStyleBackColor = false;
            this.Encrypt.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Decrypt
            // 
            this.Decrypt.BackColor = System.Drawing.Color.RosyBrown;
            this.Decrypt.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Decrypt.Location = new System.Drawing.Point(208, 385);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(161, 38);
            this.Decrypt.TabIndex = 7;
            this.Decrypt.Text = "Decrypt all files";
            this.Decrypt.UseVisualStyleBackColor = false;
            this.Decrypt.Click += new System.EventHandler(this.button3_Click);
            // 
            // showData
            // 
            this.showData.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.showData.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.showData.Location = new System.Drawing.Point(456, 74);
            this.showData.Name = "showData";
            this.showData.Size = new System.Drawing.Size(208, 35);
            this.showData.TabIndex = 11;
            this.showData.Text = "Show Selcted File Content";
            this.showData.UseVisualStyleBackColor = false;
            this.showData.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(959, 878);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(22, 21);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(987, 869);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "File Name";
            this.textBox2.Size = new System.Drawing.Size(151, 41);
            this.textBox2.TabIndex = 13;
            // 
            // Hidden
            // 
            this.Hidden.BackColor = System.Drawing.Color.OliveDrab;
            this.Hidden.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Hidden.Location = new System.Drawing.Point(1144, 865);
            this.Hidden.Name = "Hidden";
            this.Hidden.Size = new System.Drawing.Size(191, 45);
            this.Hidden.TabIndex = 14;
            this.Hidden.Text = "Hidden/Unhidden";
            this.Hidden.UseVisualStyleBackColor = false;
            this.Hidden.Click += new System.EventHandler(this.button5_Click);
            // 
            // removeSelected
            // 
            this.removeSelected.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.removeSelected.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeSelected.Location = new System.Drawing.Point(456, 115);
            this.removeSelected.Name = "removeSelected";
            this.removeSelected.Size = new System.Drawing.Size(208, 35);
            this.removeSelected.TabIndex = 15;
            this.removeSelected.Text = "Remove Selected File";
            this.removeSelected.UseVisualStyleBackColor = false;
            this.removeSelected.Click += new System.EventHandler(this.button6_Click);
            // 
            // SaveToFile
            // 
            this.SaveToFile.BackColor = System.Drawing.Color.LightGreen;
            this.SaveToFile.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveToFile.Location = new System.Drawing.Point(456, 156);
            this.SaveToFile.Name = "SaveToFile";
            this.SaveToFile.Size = new System.Drawing.Size(181, 35);
            this.SaveToFile.TabIndex = 16;
            this.SaveToFile.Text = "Save To File";
            this.SaveToFile.UseVisualStyleBackColor = false;
            this.SaveToFile.Click += new System.EventHandler(this.SaveToFile_Click);
            // 
            // CreateNewFIle
            // 
            this.CreateNewFIle.BackColor = System.Drawing.Color.LightGreen;
            this.CreateNewFIle.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateNewFIle.Location = new System.Drawing.Point(456, 197);
            this.CreateNewFIle.Name = "CreateNewFIle";
            this.CreateNewFIle.Size = new System.Drawing.Size(181, 35);
            this.CreateNewFIle.TabIndex = 17;
            this.CreateNewFIle.Text = "Create New FIle";
            this.CreateNewFIle.UseVisualStyleBackColor = false;
            this.CreateNewFIle.Click += new System.EventHandler(this.CreateNewFIle_Click);
            // 
            // HideFile
            // 
            this.HideFile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.HideFile.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HideFile.Location = new System.Drawing.Point(456, 238);
            this.HideFile.Name = "HideFile";
            this.HideFile.Size = new System.Drawing.Size(181, 35);
            this.HideFile.TabIndex = 18;
            this.HideFile.Text = "Hide Selected File";
            this.HideFile.UseVisualStyleBackColor = false;
            this.HideFile.Click += new System.EventHandler(this.HideFile_Click);
            // 
            // encryptkey
            // 
            this.encryptkey.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.encryptkey.Location = new System.Drawing.Point(9, 331);
            this.encryptkey.Multiline = true;
            this.encryptkey.Name = "encryptkey";
            this.encryptkey.PlaceholderText = "Key";
            this.encryptkey.Size = new System.Drawing.Size(170, 92);
            this.encryptkey.TabIndex = 10;
            // 
            // getSize
            // 
            this.getSize.BackColor = System.Drawing.Color.OliveDrab;
            this.getSize.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.getSize.Location = new System.Drawing.Point(679, 27);
            this.getSize.Name = "getSize";
            this.getSize.Size = new System.Drawing.Size(181, 36);
            this.getSize.TabIndex = 19;
            this.getSize.Text = "Get All Files Size";
            this.getSize.UseVisualStyleBackColor = false;
            this.getSize.Click += new System.EventHandler(this.getSize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(877, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 30);
            this.label1.TabIndex = 20;
            this.label1.Text = "Size = 0";
            // 
            // sortSize
            // 
            this.sortSize.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.sortSize.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sortSize.Location = new System.Drawing.Point(456, 577);
            this.sortSize.Name = "sortSize";
            this.sortSize.Size = new System.Drawing.Size(181, 35);
            this.sortSize.TabIndex = 21;
            this.sortSize.Text = "Sort By Size";
            this.sortSize.UseVisualStyleBackColor = false;
            this.sortSize.Click += new System.EventHandler(this.sortSize_Click);
            // 
            // sortNmae
            // 
            this.sortNmae.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.sortNmae.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sortNmae.Location = new System.Drawing.Point(456, 536);
            this.sortNmae.Name = "sortNmae";
            this.sortNmae.Size = new System.Drawing.Size(181, 35);
            this.sortNmae.TabIndex = 22;
            this.sortNmae.Text = "Sort By Name";
            this.sortNmae.UseVisualStyleBackColor = false;
            this.sortNmae.Click += new System.EventHandler(this.sortNmae_Click);
            // 
            // sortDate
            // 
            this.sortDate.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.sortDate.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sortDate.Location = new System.Drawing.Point(456, 495);
            this.sortDate.Name = "sortDate";
            this.sortDate.Size = new System.Drawing.Size(181, 35);
            this.sortDate.TabIndex = 23;
            this.sortDate.Text = "Sort By Date";
            this.sortDate.UseVisualStyleBackColor = false;
            this.sortDate.Click += new System.EventHandler(this.sortDate_Click);
            // 
            // rename
            // 
            this.rename.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rename.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rename.Location = new System.Drawing.Point(456, 348);
            this.rename.Name = "rename";
            this.rename.Size = new System.Drawing.Size(181, 75);
            this.rename.TabIndex = 24;
            this.rename.Text = "Rename Selected File";
            this.rename.UseVisualStyleBackColor = false;
            this.rename.Click += new System.EventHandler(this.rename_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.Location = new System.Drawing.Point(456, 308);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.PlaceholderText = "New Name";
            this.textBox3.Size = new System.Drawing.Size(181, 34);
            this.textBox3.TabIndex = 25;
            // 
            // compress
            // 
            this.compress.BackColor = System.Drawing.Color.OliveDrab;
            this.compress.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.compress.Location = new System.Drawing.Point(435, 748);
            this.compress.Name = "compress";
            this.compress.Size = new System.Drawing.Size(238, 42);
            this.compress.TabIndex = 26;
            this.compress.Text = "Compress Selected File";
            this.compress.UseVisualStyleBackColor = false;
            this.compress.Click += new System.EventHandler(this.compress_Click);
            // 
            // decompress
            // 
            this.decompress.BackColor = System.Drawing.Color.OliveDrab;
            this.decompress.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.decompress.Location = new System.Drawing.Point(435, 796);
            this.decompress.Name = "decompress";
            this.decompress.Size = new System.Drawing.Size(238, 42);
            this.decompress.TabIndex = 27;
            this.decompress.Text = "Deompress Selected File";
            this.decompress.UseVisualStyleBackColor = false;
            this.decompress.Click += new System.EventHandler(this.decompress_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1399, 954);
            this.Controls.Add(this.decompress);
            this.Controls.Add(this.compress);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.rename);
            this.Controls.Add(this.sortDate);
            this.Controls.Add(this.sortNmae);
            this.Controls.Add(this.sortSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getSize);
            this.Controls.Add(this.HideFile);
            this.Controls.Add(this.CreateNewFIle);
            this.Controls.Add(this.SaveToFile);
            this.Controls.Add(this.removeSelected);
            this.Controls.Add(this.Hidden);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.showData);
            this.Controls.Add(this.encryptkey);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ListAllFiles);
            this.Controls.Add(this.RemoveByName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BrowseFiletoRemove);
            this.Controls.Add(this.BrowseFiletoAdd);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "File System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BrowseFiletoAdd;
        private Button BrowseFiletoRemove;
        private TextBox textBox1;
        private Button RemoveByName;
        private Button ListAllFiles;
        private ListView listView1;
        private ColumnHeader name;
        private ColumnHeader size;
        private ColumnHeader creation;
        private Button Encrypt;
        private Button Decrypt;
        private Button showData;
        private CheckBox checkBox1;
        private TextBox textBox2;
        private Button Hidden;
        private Button removeSelected;
        private Button SaveToFile;
        private ToolTip toolTip1;
        private Button CreateNewFIle;
        private Button HideFile;
        private TextBox encryptkey;
        private Button getSize;
        private Label label1;
        private Button sortSize;
        private Button sortNmae;
        private Button sortDate;
        private Button rename;
        private TextBox textBox3;
        private Button compress;
        private Button decompress;
    }
}
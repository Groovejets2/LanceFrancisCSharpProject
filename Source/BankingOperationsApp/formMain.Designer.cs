namespace BankingOperationsApp
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTest = new System.Windows.Forms.Button();
            this.menuMainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuBankingOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.importCustomerDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankingOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountDepositToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountWithdrawlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxBalanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youngestCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leapYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgCustomerData = new System.Windows.Forms.DataGridView();
            this.menuMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomerData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(580, 373);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(108, 28);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Quit";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // menuMainMenu
            // 
            this.menuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBankingOperations,
            this.bankingOperationsToolStripMenuItem});
            this.menuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.menuMainMenu.Name = "menuMainMenu";
            this.menuMainMenu.Size = new System.Drawing.Size(700, 24);
            this.menuMainMenu.TabIndex = 1;
            this.menuMainMenu.Text = "menuStrip1";
            // 
            // mnuBankingOperations
            // 
            this.mnuBankingOperations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importCustomerDataToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.mnuBankingOperations.Name = "mnuBankingOperations";
            this.mnuBankingOperations.Size = new System.Drawing.Size(37, 20);
            this.mnuBankingOperations.Text = "File";
            // 
            // importCustomerDataToolStripMenuItem
            // 
            this.importCustomerDataToolStripMenuItem.Name = "importCustomerDataToolStripMenuItem";
            this.importCustomerDataToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.importCustomerDataToolStripMenuItem.Text = "Import Customer Data";
            this.importCustomerDataToolStripMenuItem.Click += new System.EventHandler(this.importCustomerDataToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // bankingOperationsToolStripMenuItem
            // 
            this.bankingOperationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountDepositToolStripMenuItem,
            this.accountWithdrawlToolStripMenuItem,
            this.maxBalanceToolStripMenuItem,
            this.mostActiveToolStripMenuItem,
            this.youngestCustomerToolStripMenuItem,
            this.leapYearToolStripMenuItem});
            this.bankingOperationsToolStripMenuItem.Name = "bankingOperationsToolStripMenuItem";
            this.bankingOperationsToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.bankingOperationsToolStripMenuItem.Text = "Banking Operations";
            // 
            // accountDepositToolStripMenuItem
            // 
            this.accountDepositToolStripMenuItem.Name = "accountDepositToolStripMenuItem";
            this.accountDepositToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.accountDepositToolStripMenuItem.Text = "Deposit";
            this.accountDepositToolStripMenuItem.Click += new System.EventHandler(this.depositToolStripMenuItem_Click);
            // 
            // accountWithdrawlToolStripMenuItem
            // 
            this.accountWithdrawlToolStripMenuItem.Name = "accountWithdrawlToolStripMenuItem";
            this.accountWithdrawlToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.accountWithdrawlToolStripMenuItem.Text = "Withdraw";
            this.accountWithdrawlToolStripMenuItem.Click += new System.EventHandler(this.withdrawlToolStripMenuItem_Click);
            // 
            // maxBalanceToolStripMenuItem
            // 
            this.maxBalanceToolStripMenuItem.Name = "maxBalanceToolStripMenuItem";
            this.maxBalanceToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.maxBalanceToolStripMenuItem.Text = "Max Balance";
            this.maxBalanceToolStripMenuItem.Click += new System.EventHandler(this.maxBalanceToolStripMenuItem_Click);
            // 
            // mostActiveToolStripMenuItem
            // 
            this.mostActiveToolStripMenuItem.Name = "mostActiveToolStripMenuItem";
            this.mostActiveToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.mostActiveToolStripMenuItem.Text = "Most Active";
            this.mostActiveToolStripMenuItem.Click += new System.EventHandler(this.mostActiveToolStripMenuItem_Click);
            // 
            // youngestCustomerToolStripMenuItem
            // 
            this.youngestCustomerToolStripMenuItem.Name = "youngestCustomerToolStripMenuItem";
            this.youngestCustomerToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.youngestCustomerToolStripMenuItem.Text = "Youngest Customer";
            this.youngestCustomerToolStripMenuItem.Click += new System.EventHandler(this.youngestCustomerToolStripMenuItem_Click);
            // 
            // leapYearToolStripMenuItem
            // 
            this.leapYearToolStripMenuItem.Name = "leapYearToolStripMenuItem";
            this.leapYearToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.leapYearToolStripMenuItem.Text = "Leap Year";
            this.leapYearToolStripMenuItem.Click += new System.EventHandler(this.leapYearToolStripMenuItem_Click);
            // 
            // dgCustomerData
            // 
            this.dgCustomerData.AllowUserToDeleteRows = false;
            this.dgCustomerData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCustomerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomerData.Location = new System.Drawing.Point(13, 28);
            this.dgCustomerData.Name = "dgCustomerData";
            this.dgCustomerData.ReadOnly = true;
            this.dgCustomerData.Size = new System.Drawing.Size(675, 329);
            this.dgCustomerData.TabIndex = 2;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 413);
            this.Controls.Add(this.dgCustomerData);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.menuMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuMainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banking Operations Application";
            this.menuMainMenu.ResumeLayout(false);
            this.menuMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomerData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.MenuStrip menuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuBankingOperations;
        private System.Windows.Forms.ToolStripMenuItem importCustomerDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankingOperationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountWithdrawlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountDepositToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxBalanceToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgCustomerData;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostActiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem youngestCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leapYearToolStripMenuItem;
    }
}


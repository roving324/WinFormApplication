namespace MainForms
{
    partial class M03_Main
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.M_Test = new System.Windows.Forms.ToolStripMenuItem();
            this.Form01_MDITest = new System.Windows.Forms.ToolStripMenuItem();
            this.Form02_MDITest = new System.Windows.Forms.ToolStripMenuItem();
            this.B_MENU = new System.Windows.Forms.ToolStripMenuItem();
            this.Form03_ItemMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.Form04_userMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSaveB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stsFormName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsNowDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.myTabControlr = new Assambl.MyTabControlr();
            this.Form05_UserMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.M_Test,
            this.B_MENU});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1034, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // M_Test
            // 
            this.M_Test.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Form01_MDITest,
            this.Form02_MDITest});
            this.M_Test.Name = "M_Test";
            this.M_Test.Size = new System.Drawing.Size(83, 20);
            this.M_Test.Text = "테스트 매뉴";
            this.M_Test.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.M_Test_DropDownItemClicked);
            // 
            // Form01_MDITest
            // 
            this.Form01_MDITest.Name = "Form01_MDITest";
            this.Form01_MDITest.Size = new System.Drawing.Size(137, 22);
            this.Form01_MDITest.Text = "MDI_Test";
            // 
            // Form02_MDITest
            // 
            this.Form02_MDITest.Name = "Form02_MDITest";
            this.Form02_MDITest.Size = new System.Drawing.Size(137, 22);
            this.Form02_MDITest.Text = "MDI_Test02";
            // 
            // B_MENU
            // 
            this.B_MENU.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Form03_ItemMaster,
            this.Form04_userMaster,
            this.Form05_UserMaster});
            this.B_MENU.Name = "B_MENU";
            this.B_MENU.Size = new System.Drawing.Size(91, 20);
            this.B_MENU.Text = "기준정보관리";
            this.B_MENU.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.M_Test_DropDownItemClicked);
            // 
            // Form03_ItemMaster
            // 
            this.Form03_ItemMaster.Name = "Form03_ItemMaster";
            this.Form03_ItemMaster.Size = new System.Drawing.Size(180, 22);
            this.Form03_ItemMaster.Text = "품목마스터";
            // 
            // Form04_userMaster
            // 
            this.Form04_userMaster.Name = "Form04_userMaster";
            this.Form04_userMaster.Size = new System.Drawing.Size(180, 22);
            this.Form04_userMaster.Text = "사용자관리";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearch,
            this.btnAdd,
            this.btnDelete,
            this.btnSaveB,
            this.toolStripSeparator1,
            this.btnClose,
            this.btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1034, 100);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::MainForms.Properties.Resources.BtnSearch;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(54, 97);
            this.btnSearch.Text = "조회";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSearch.Click += new System.EventHandler(this.btnFunction_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::MainForms.Properties.Resources.BtnAdd;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 97);
            this.btnAdd.Text = "추가";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnFunction_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::MainForms.Properties.Resources.BtnDelete;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(54, 97);
            this.btnDelete.Text = "삭제";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnFunction_Click);
            // 
            // btnSaveB
            // 
            this.btnSaveB.Image = global::MainForms.Properties.Resources.BtnSaveB;
            this.btnSaveB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSaveB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveB.Name = "btnSaveB";
            this.btnSaveB.Size = new System.Drawing.Size(54, 97);
            this.btnSaveB.Text = "저장";
            this.btnSaveB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveB.Click += new System.EventHandler(this.btnFunction_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 100);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::MainForms.Properties.Resources.BtnClose;
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 97);
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::MainForms.Properties.Resources.BtnExit;
            this.btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(54, 97);
            this.btnExit.Text = "종료";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsFormName,
            this.toolStripStatusLabel2,
            this.stsUserName,
            this.stsNowDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1034, 29);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stsFormName
            // 
            this.stsFormName.AutoSize = false;
            this.stsFormName.Name = "stsFormName";
            this.stsFormName.Size = new System.Drawing.Size(200, 24);
            this.stsFormName.Text = "HomeName";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(469, 24);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // stsUserName
            // 
            this.stsUserName.AutoSize = false;
            this.stsUserName.Name = "stsUserName";
            this.stsUserName.Size = new System.Drawing.Size(150, 24);
            this.stsUserName.Text = "UserName";
            // 
            // stsNowDateTime
            // 
            this.stsNowDateTime.AutoSize = false;
            this.stsNowDateTime.Name = "stsNowDateTime";
            this.stsNowDateTime.Size = new System.Drawing.Size(200, 24);
            this.stsNowDateTime.Text = "NowDateTime";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // myTabControlr
            // 
            this.myTabControlr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTabControlr.Location = new System.Drawing.Point(0, 124);
            this.myTabControlr.Name = "myTabControlr";
            this.myTabControlr.SelectedIndex = 0;
            this.myTabControlr.Size = new System.Drawing.Size(1034, 395);
            this.myTabControlr.TabIndex = 4;
            // 
            // Form05_UserMaster
            // 
            this.Form05_UserMaster.Name = "Form05_UserMaster";
            this.Form05_UserMaster.Size = new System.Drawing.Size(180, 22);
            this.Form05_UserMaster.Text = "사용자관리2";
            // 
            // M03_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 548);
            this.Controls.Add(this.myTabControlr);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "M03_Main";
            this.Text = "EZ_Dev 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.M03_Main_FormClosing);
            this.Load += new System.EventHandler(this.M03_Main_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSaveB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stsFormName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel stsUserName;
        private System.Windows.Forms.ToolStripStatusLabel stsNowDateTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem M_Test;
        private System.Windows.Forms.ToolStripMenuItem Form01_MDITest;
        private System.Windows.Forms.ToolStripMenuItem Form02_MDITest;
        private Assambl.MyTabControlr myTabControlr;
        private System.Windows.Forms.ToolStripMenuItem B_MENU;
        private System.Windows.Forms.ToolStripMenuItem Form03_ItemMaster;
        private System.Windows.Forms.ToolStripMenuItem Form04_userMaster;
        private System.Windows.Forms.ToolStripMenuItem Form05_UserMaster;
    }
}
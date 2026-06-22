namespace Video_Program
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            파일ToolStripMenuItem = new ToolStripMenuItem();
            Tm_AllOpen = new ToolStripMenuItem();
            Tm_Close = new ToolStripMenuItem();
            Tm_AllClose = new ToolStripMenuItem();
            Tm_Exit = new ToolStripMenuItem();
            비디오대여반납ToolStripMenuItem = new ToolStripMenuItem();
            Tm_RentalManage = new ToolStripMenuItem();
            비디오관리ToolStripMenuItem = new ToolStripMenuItem();
            Tm_VideoInfo = new ToolStripMenuItem();
            고객관리ToolStripMenuItem = new ToolStripMenuItem();
            Tm_Customer = new ToolStripMenuItem();
            정보조회ToolStripMenuItem = new ToolStripMenuItem();
            Tm_VideoSelect = new ToolStripMenuItem();
            환경설정ToolStripMenuItem = new ToolStripMenuItem();
            Tm_VideoRentalSetting = new ToolStripMenuItem();
            Tm_Excel_Info = new ToolStripMenuItem();
            Tm_Help = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            Tool_leaseNreturn = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            Tool_Video = new ToolStripButton();
            Tool_User = new ToolStripButton();
            Tool_Info = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            Tool_Setting = new ToolStripButton();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 파일ToolStripMenuItem, 비디오대여반납ToolStripMenuItem, 비디오관리ToolStripMenuItem, 고객관리ToolStripMenuItem, 정보조회ToolStripMenuItem, 환경설정ToolStripMenuItem, Tm_Help });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            파일ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Tm_AllOpen, Tm_Close, Tm_AllClose, Tm_Exit });
            파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            파일ToolStripMenuItem.Size = new Size(43, 20);
            파일ToolStripMenuItem.Text = "파일";
            // 
            // Tm_AllOpen
            // 
            Tm_AllOpen.Name = "Tm_AllOpen";
            Tm_AllOpen.Size = new Size(150, 22);
            Tm_AllOpen.Text = "모두 열기(O)";
            Tm_AllOpen.Click += Tool_AllOpen_Click;
            // 
            // Tm_Close
            // 
            Tm_Close.Name = "Tm_Close";
            Tm_Close.Size = new Size(150, 22);
            Tm_Close.Text = "닫기(C)";
            Tm_Close.Click += Tool_Close_Click;
            // 
            // Tm_AllClose
            // 
            Tm_AllClose.Name = "Tm_AllClose";
            Tm_AllClose.Size = new Size(150, 22);
            Tm_AllClose.Text = "모두닫기(A)";
            Tm_AllClose.Click += Tool_AllClose_Click;
            // 
            // Tm_Exit
            // 
            Tm_Exit.Name = "Tm_Exit";
            Tm_Exit.Size = new Size(150, 22);
            Tm_Exit.Text = "프로그램 종료";
            Tm_Exit.Click += Tm_Exit_Click;
            // 
            // 비디오대여반납ToolStripMenuItem
            // 
            비디오대여반납ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Tm_RentalManage });
            비디오대여반납ToolStripMenuItem.Name = "비디오대여반납ToolStripMenuItem";
            비디오대여반납ToolStripMenuItem.Size = new Size(112, 20);
            비디오대여반납ToolStripMenuItem.Text = "비디오 대여/반납";
            // 
            // Tm_RentalManage
            // 
            Tm_RentalManage.Name = "Tm_RentalManage";
            Tm_RentalManage.Size = new Size(126, 22);
            Tm_RentalManage.Text = "대여 관리";
            Tm_RentalManage.Click += Tool_RentalManage_Click;
            // 
            // 비디오관리ToolStripMenuItem
            // 
            비디오관리ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Tm_VideoInfo });
            비디오관리ToolStripMenuItem.Name = "비디오관리ToolStripMenuItem";
            비디오관리ToolStripMenuItem.Size = new Size(83, 20);
            비디오관리ToolStripMenuItem.Text = "비디오 관리";
            // 
            // Tm_VideoInfo
            // 
            Tm_VideoInfo.Name = "Tm_VideoInfo";
            Tm_VideoInfo.Size = new Size(138, 22);
            Tm_VideoInfo.Text = "비디오 정보";
            Tm_VideoInfo.Click += Tool_VideoInfo_Click;
            // 
            // 고객관리ToolStripMenuItem
            // 
            고객관리ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Tm_Customer });
            고객관리ToolStripMenuItem.Name = "고객관리ToolStripMenuItem";
            고객관리ToolStripMenuItem.Size = new Size(71, 20);
            고객관리ToolStripMenuItem.Text = "고객 관리";
            // 
            // Tm_Customer
            // 
            Tm_Customer.Name = "Tm_Customer";
            Tm_Customer.Size = new Size(126, 22);
            Tm_Customer.Text = "고객 정보";
            Tm_Customer.Click += Tool_Customer_Click;
            // 
            // 정보조회ToolStripMenuItem
            // 
            정보조회ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Tm_VideoSelect });
            정보조회ToolStripMenuItem.Name = "정보조회ToolStripMenuItem";
            정보조회ToolStripMenuItem.Size = new Size(71, 20);
            정보조회ToolStripMenuItem.Text = "정보 조회";
            // 
            // Tm_VideoSelect
            // 
            Tm_VideoSelect.Name = "Tm_VideoSelect";
            Tm_VideoSelect.Size = new Size(166, 22);
            Tm_VideoSelect.Text = "비디오 조회 관리";
            Tm_VideoSelect.Click += Tool_VideoSelect_Click;
            // 
            // 환경설정ToolStripMenuItem
            // 
            환경설정ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Tm_VideoRentalSetting, Tm_Excel_Info });
            환경설정ToolStripMenuItem.Name = "환경설정ToolStripMenuItem";
            환경설정ToolStripMenuItem.Size = new Size(67, 20);
            환경설정ToolStripMenuItem.Text = "환경설정";
            // 
            // Tm_VideoRentalSetting
            // 
            Tm_VideoRentalSetting.Name = "Tm_VideoRentalSetting";
            Tm_VideoRentalSetting.Size = new Size(166, 22);
            Tm_VideoRentalSetting.Text = "비디오 대여 설정";
            Tm_VideoRentalSetting.Click += Tool_VideoRentalSetting_Click;
            // 
            // Tm_Excel_Info
            // 
            Tm_Excel_Info.Name = "Tm_Excel_Info";
            Tm_Excel_Info.Size = new Size(166, 22);
            Tm_Excel_Info.Text = "비디오 정보";
            Tm_Excel_Info.Click += Tm_Excel_Info_Click;
            // 
            // Tm_Help
            // 
            Tm_Help.Name = "Tm_Help";
            Tm_Help.Size = new Size(55, 20);
            Tm_Help.Text = "도움말";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(48, 48);
            toolStrip1.Items.AddRange(new ToolStripItem[] { Tool_leaseNreturn, toolStripSeparator1, Tool_Video, Tool_User, Tool_Info, toolStripSeparator2, Tool_Setting });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 72);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // Tool_leaseNreturn
            // 
            Tool_leaseNreturn.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            Tool_leaseNreturn.Image = (Image)resources.GetObject("Tool_leaseNreturn.Image");
            Tool_leaseNreturn.ImageTransparentColor = Color.Magenta;
            Tool_leaseNreturn.Name = "Tool_leaseNreturn";
            Tool_leaseNreturn.Size = new Size(70, 69);
            Tool_leaseNreturn.Text = "대여/반납";
            Tool_leaseNreturn.TextImageRelation = TextImageRelation.ImageAboveText;
            Tool_leaseNreturn.Click += Tool_RentalManage_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 72);
            // 
            // Tool_Video
            // 
            Tool_Video.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            Tool_Video.Image = (Image)resources.GetObject("Tool_Video.Image");
            Tool_Video.ImageTransparentColor = Color.Magenta;
            Tool_Video.Name = "Tool_Video";
            Tool_Video.Size = new Size(77, 69);
            Tool_Video.Text = "비디오관리";
            Tool_Video.TextImageRelation = TextImageRelation.ImageAboveText;
            Tool_Video.Click += Tool_Video_Click;
            // 
            // Tool_User
            // 
            Tool_User.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            Tool_User.Image = (Image)resources.GetObject("Tool_User.Image");
            Tool_User.ImageTransparentColor = Color.Magenta;
            Tool_User.Name = "Tool_User";
            Tool_User.Size = new Size(64, 69);
            Tool_User.Text = "고객관리";
            Tool_User.TextImageRelation = TextImageRelation.ImageAboveText;
            Tool_User.Click += Tool_User_Click;
            // 
            // Tool_Info
            // 
            Tool_Info.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            Tool_Info.Image = (Image)resources.GetObject("Tool_Info.Image");
            Tool_Info.ImageTransparentColor = Color.Magenta;
            Tool_Info.Name = "Tool_Info";
            Tool_Info.Size = new Size(64, 69);
            Tool_Info.Text = "정보조회";
            Tool_Info.TextImageRelation = TextImageRelation.ImageAboveText;
            Tool_Info.Click += Tool_Info_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 72);
            // 
            // Tool_Setting
            // 
            Tool_Setting.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            Tool_Setting.Image = (Image)resources.GetObject("Tool_Setting.Image");
            Tool_Setting.ImageTransparentColor = Color.Magenta;
            Tool_Setting.Name = "Tool_Setting";
            Tool_Setting.Size = new Size(64, 69);
            Tool_Setting.Text = "환경설정";
            Tool_Setting.TextImageRelation = TextImageRelation.ImageAboveText;
            Tool_Setting.Click += Tool_Setting_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "비디오 관리 프로그램";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 파일ToolStripMenuItem;
        private ToolStripMenuItem 비디오대여반납ToolStripMenuItem;
        private ToolStripMenuItem 비디오관리ToolStripMenuItem;
        private ToolStripMenuItem 고객관리ToolStripMenuItem;
        private ToolStripMenuItem 정보조회ToolStripMenuItem;
        private ToolStripMenuItem 환경설정ToolStripMenuItem;
        private ToolStripMenuItem Tm_Help;
        private ToolStrip toolStrip1;
        private ToolStripButton Tool_leaseNreturn;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton Tool_Video;
        private ToolStripButton Tool_User;
        private ToolStripButton Tool_Info;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton Tool_Setting;
        private ToolStripMenuItem Tm_Close;
        private ToolStripMenuItem Tm_AllClose;
        private ToolStripMenuItem Tm_Exit;
        private ToolStripMenuItem Tm_RentalManage;
        private ToolStripMenuItem Tm_VideoInfo;
        private ToolStripMenuItem Tm_AllOpen;
        private ToolStripMenuItem Tm_Customer;
        private ToolStripMenuItem Tm_VideoSelect;
        private ToolStripMenuItem Tm_VideoRentalSetting;
        private ToolStripMenuItem Tm_Excel_Info;
    }
}

namespace Video_Program
{
    partial class Rental_management
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
            Gb_User_Info = new GroupBox();
            Tb_Mobile = new TextBox();
            label12 = new Label();
            Tb_CustomerType = new TextBox();
            label11 = new Label();
            Tb_CustomerName = new TextBox();
            label10 = new Label();
            Tb_Address = new TextBox();
            label9 = new Label();
            Tb_PostNumber = new TextBox();
            Tb_Tel = new TextBox();
            Tb_SSN = new TextBox();
            Tb_CustomerCode = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            User_control = new TabControl();
            User_Insert = new TabPage();
            Btn_FindUser = new Button();
            Tb_Phone = new TextBox();
            Tb_HP = new TextBox();
            Tb_UserCode = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            Tb_UserName = new TextBox();
            label1 = new Label();
            User_Choice = new TabPage();
            Lb_CustomerSelect = new ListView();
            label23 = new Label();
            Gb_VideoInsert = new GroupBox();
            Lb_ReturnDate = new Label();
            Lb_Overdue_Money = new Label();
            Lb_Release_Money = new Label();
            Dt_video_Rent = new DateTimePicker();
            Btn_VideoUpload = new Button();
            Tb_VideoCode = new TextBox();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            Tb_VideoTitle = new TextBox();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label17 = new Label();
            label16 = new Label();
            label21 = new Label();
            Btn_VideoRetrieve = new Button();
            Lb_Every_Realse_Count = new Label();
            Lb_Every_Realse_Money = new Label();
            Lb_Every_Overdue_Money = new Label();
            GV_VideoList = new DataGridView();
            RentalNo = new DataGridViewTextBoxColumn();
            VideoCode = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            RentalDate = new DataGridViewTextBoxColumn();
            DueDate = new DataGridViewTextBoxColumn();
            Gb_User_Info.SuspendLayout();
            User_control.SuspendLayout();
            User_Insert.SuspendLayout();
            User_Choice.SuspendLayout();
            Gb_VideoInsert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GV_VideoList).BeginInit();
            SuspendLayout();
            // 
            // Gb_User_Info
            // 
            Gb_User_Info.Controls.Add(Tb_Mobile);
            Gb_User_Info.Controls.Add(label12);
            Gb_User_Info.Controls.Add(Tb_CustomerType);
            Gb_User_Info.Controls.Add(label11);
            Gb_User_Info.Controls.Add(Tb_CustomerName);
            Gb_User_Info.Controls.Add(label10);
            Gb_User_Info.Controls.Add(Tb_Address);
            Gb_User_Info.Controls.Add(label9);
            Gb_User_Info.Controls.Add(Tb_PostNumber);
            Gb_User_Info.Controls.Add(Tb_Tel);
            Gb_User_Info.Controls.Add(Tb_SSN);
            Gb_User_Info.Controls.Add(Tb_CustomerCode);
            Gb_User_Info.Controls.Add(label5);
            Gb_User_Info.Controls.Add(label4);
            Gb_User_Info.Controls.Add(label3);
            Gb_User_Info.Controls.Add(label2);
            Gb_User_Info.Location = new Point(238, 12);
            Gb_User_Info.Name = "Gb_User_Info";
            Gb_User_Info.Size = new Size(550, 213);
            Gb_User_Info.TabIndex = 16;
            Gb_User_Info.TabStop = false;
            Gb_User_Info.Text = "고객 정보";
            // 
            // Tb_Mobile
            // 
            Tb_Mobile.Location = new Point(363, 92);
            Tb_Mobile.Name = "Tb_Mobile";
            Tb_Mobile.Size = new Size(169, 23);
            Tb_Mobile.TabIndex = 35;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(307, 100);
            label12.Name = "label12";
            label12.Size = new Size(50, 15);
            label12.TabIndex = 34;
            label12.Text = "휴대폰 :";
            // 
            // Tb_CustomerType
            // 
            Tb_CustomerType.Location = new Point(363, 63);
            Tb_CustomerType.Name = "Tb_CustomerType";
            Tb_CustomerType.Size = new Size(169, 23);
            Tb_CustomerType.TabIndex = 33;
            // 
            // label11
            // 
            label11.AutoEllipsis = true;
            label11.AutoSize = true;
            label11.Location = new Point(295, 71);
            label11.Name = "label11";
            label11.Size = new Size(62, 15);
            label11.TabIndex = 32;
            label11.Text = "고객신분 :";
            // 
            // Tb_CustomerName
            // 
            Tb_CustomerName.Location = new Point(363, 34);
            Tb_CustomerName.Name = "Tb_CustomerName";
            Tb_CustomerName.Size = new Size(169, 23);
            Tb_CustomerName.TabIndex = 31;
            // 
            // label10
            // 
            label10.AutoEllipsis = true;
            label10.AutoSize = true;
            label10.Location = new Point(307, 42);
            label10.Name = "label10";
            label10.Size = new Size(50, 15);
            label10.TabIndex = 30;
            label10.Text = "고객명 :";
            // 
            // Tb_Address
            // 
            Tb_Address.Location = new Point(88, 150);
            Tb_Address.Name = "Tb_Address";
            Tb_Address.Size = new Size(444, 23);
            Tb_Address.TabIndex = 29;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(44, 158);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 28;
            label9.Text = "주소 :";
            // 
            // Tb_PostNumber
            // 
            Tb_PostNumber.Location = new Point(88, 121);
            Tb_PostNumber.Name = "Tb_PostNumber";
            Tb_PostNumber.Size = new Size(169, 23);
            Tb_PostNumber.TabIndex = 27;
            // 
            // Tb_Tel
            // 
            Tb_Tel.Location = new Point(88, 92);
            Tb_Tel.Name = "Tb_Tel";
            Tb_Tel.Size = new Size(169, 23);
            Tb_Tel.TabIndex = 26;
            // 
            // Tb_SSN
            // 
            Tb_SSN.Location = new Point(88, 63);
            Tb_SSN.Name = "Tb_SSN";
            Tb_SSN.Size = new Size(169, 23);
            Tb_SSN.TabIndex = 24;
            // 
            // Tb_CustomerCode
            // 
            Tb_CustomerCode.Location = new Point(88, 34);
            Tb_CustomerCode.Name = "Tb_CustomerCode";
            Tb_CustomerCode.Size = new Size(169, 23);
            Tb_CustomerCode.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 129);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 18;
            label5.Text = "우편번호 :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 100);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 17;
            label4.Text = "전화번호 :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 71);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 16;
            label3.Text = "주민번호 :";
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.AutoSize = true;
            label2.Location = new Point(16, 42);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 15;
            label2.Text = "고객 코드 :";
            // 
            // User_control
            // 
            User_control.Controls.Add(User_Insert);
            User_control.Controls.Add(User_Choice);
            User_control.Location = new Point(12, 12);
            User_control.Name = "User_control";
            User_control.SelectedIndex = 0;
            User_control.Size = new Size(220, 217);
            User_control.TabIndex = 18;
            // 
            // User_Insert
            // 
            User_Insert.Controls.Add(Btn_FindUser);
            User_Insert.Controls.Add(Tb_Phone);
            User_Insert.Controls.Add(Tb_HP);
            User_Insert.Controls.Add(Tb_UserCode);
            User_Insert.Controls.Add(label8);
            User_Insert.Controls.Add(label7);
            User_Insert.Controls.Add(label6);
            User_Insert.Controls.Add(Tb_UserName);
            User_Insert.Controls.Add(label1);
            User_Insert.Location = new Point(4, 24);
            User_Insert.Name = "User_Insert";
            User_Insert.Padding = new Padding(3);
            User_Insert.Size = new Size(212, 189);
            User_Insert.TabIndex = 0;
            User_Insert.Text = "고객 입력";
            User_Insert.UseVisualStyleBackColor = true;
            // 
            // Btn_FindUser
            // 
            Btn_FindUser.Location = new Point(40, 134);
            Btn_FindUser.Name = "Btn_FindUser";
            Btn_FindUser.Size = new Size(129, 37);
            Btn_FindUser.TabIndex = 37;
            Btn_FindUser.Text = "찾기";
            Btn_FindUser.UseVisualStyleBackColor = true;
            Btn_FindUser.Click += Btn_FindUser_Click;
            // 
            // Tb_Phone
            // 
            Tb_Phone.Location = new Point(84, 97);
            Tb_Phone.Name = "Tb_Phone";
            Tb_Phone.Size = new Size(112, 23);
            Tb_Phone.TabIndex = 35;
            // 
            // Tb_HP
            // 
            Tb_HP.Location = new Point(84, 68);
            Tb_HP.Name = "Tb_HP";
            Tb_HP.Size = new Size(112, 23);
            Tb_HP.TabIndex = 34;
            // 
            // Tb_UserCode
            // 
            Tb_UserCode.Location = new Point(84, 39);
            Tb_UserCode.Name = "Tb_UserCode";
            Tb_UserCode.Size = new Size(112, 23);
            Tb_UserCode.TabIndex = 33;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 105);
            label8.Name = "label8";
            label8.Size = new Size(50, 15);
            label8.TabIndex = 32;
            label8.Text = "휴대폰 :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 76);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 31;
            label7.Text = "전화번호 :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 47);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 30;
            label6.Text = "고객코드 :";
            // 
            // Tb_UserName
            // 
            Tb_UserName.Location = new Point(84, 10);
            Tb_UserName.Name = "Tb_UserName";
            Tb_UserName.Size = new Size(112, 23);
            Tb_UserName.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 18);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 28;
            label1.Text = "고객명 :";
            // 
            // User_Choice
            // 
            User_Choice.Controls.Add(Lb_CustomerSelect);
            User_Choice.Controls.Add(label23);
            User_Choice.Location = new Point(4, 24);
            User_Choice.Name = "User_Choice";
            User_Choice.Padding = new Padding(3);
            User_Choice.Size = new Size(212, 189);
            User_Choice.TabIndex = 1;
            User_Choice.Text = "고객 선택";
            User_Choice.UseVisualStyleBackColor = true;
            // 
            // Lb_CustomerSelect
            // 
            Lb_CustomerSelect.Location = new Point(16, 27);
            Lb_CustomerSelect.Name = "Lb_CustomerSelect";
            Lb_CustomerSelect.Size = new Size(180, 145);
            Lb_CustomerSelect.TabIndex = 1;
            Lb_CustomerSelect.UseCompatibleStateImageBehavior = false;
            Lb_CustomerSelect.SelectedIndexChanged += Lb_CustomerSelect_SelectedIndexChanged;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(16, 3);
            label23.Name = "label23";
            label23.Size = new Size(178, 15);
            label23.TabIndex = 0;
            label23.Text = "같은 이름의 사용자가 있습니다!";
            // 
            // Gb_VideoInsert
            // 
            Gb_VideoInsert.Controls.Add(Lb_ReturnDate);
            Gb_VideoInsert.Controls.Add(Lb_Overdue_Money);
            Gb_VideoInsert.Controls.Add(Lb_Release_Money);
            Gb_VideoInsert.Controls.Add(Dt_video_Rent);
            Gb_VideoInsert.Controls.Add(Btn_VideoUpload);
            Gb_VideoInsert.Controls.Add(Tb_VideoCode);
            Gb_VideoInsert.Controls.Add(label13);
            Gb_VideoInsert.Controls.Add(label14);
            Gb_VideoInsert.Controls.Add(label15);
            Gb_VideoInsert.Controls.Add(Tb_VideoTitle);
            Gb_VideoInsert.Controls.Add(label18);
            Gb_VideoInsert.Controls.Add(label19);
            Gb_VideoInsert.Controls.Add(label20);
            Gb_VideoInsert.Location = new Point(16, 231);
            Gb_VideoInsert.Name = "Gb_VideoInsert";
            Gb_VideoInsert.Size = new Size(772, 103);
            Gb_VideoInsert.TabIndex = 36;
            Gb_VideoInsert.TabStop = false;
            Gb_VideoInsert.Text = "대여 비디오 입력";
            // 
            // Lb_ReturnDate
            // 
            Lb_ReturnDate.AutoSize = true;
            Lb_ReturnDate.BorderStyle = BorderStyle.FixedSingle;
            Lb_ReturnDate.Location = new Point(613, 71);
            Lb_ReturnDate.Name = "Lb_ReturnDate";
            Lb_ReturnDate.Size = new Size(75, 17);
            Lb_ReturnDate.TabIndex = 46;
            Lb_ReturnDate.Text = "2000-01-01";
            // 
            // Lb_Overdue_Money
            // 
            Lb_Overdue_Money.AutoSize = true;
            Lb_Overdue_Money.BorderStyle = BorderStyle.FixedSingle;
            Lb_Overdue_Money.Location = new Point(202, 71);
            Lb_Overdue_Money.Name = "Lb_Overdue_Money";
            Lb_Overdue_Money.Size = new Size(49, 17);
            Lb_Overdue_Money.TabIndex = 45;
            Lb_Overdue_Money.Text = "0000원";
            // 
            // Lb_Release_Money
            // 
            Lb_Release_Money.AutoSize = true;
            Lb_Release_Money.BorderStyle = BorderStyle.FixedSingle;
            Lb_Release_Money.Location = new Point(76, 71);
            Lb_Release_Money.Name = "Lb_Release_Money";
            Lb_Release_Money.Size = new Size(49, 17);
            Lb_Release_Money.TabIndex = 44;
            Lb_Release_Money.Text = "0000원";
            // 
            // Dt_video_Rent
            // 
            Dt_video_Rent.Location = new Point(315, 65);
            Dt_video_Rent.Name = "Dt_video_Rent";
            Dt_video_Rent.Size = new Size(200, 23);
            Dt_video_Rent.TabIndex = 40;
            // 
            // Btn_VideoUpload
            // 
            Btn_VideoUpload.Location = new Point(666, 34);
            Btn_VideoUpload.Name = "Btn_VideoUpload";
            Btn_VideoUpload.Size = new Size(88, 23);
            Btn_VideoUpload.TabIndex = 38;
            Btn_VideoUpload.Text = "등록";
            Btn_VideoUpload.UseVisualStyleBackColor = true;
            Btn_VideoUpload.Click += Btn_VideoUpload_Click;
            // 
            // Tb_VideoCode
            // 
            Tb_VideoCode.Location = new Point(100, 34);
            Tb_VideoCode.Name = "Tb_VideoCode";
            Tb_VideoCode.Size = new Size(69, 23);
            Tb_VideoCode.TabIndex = 38;
            Tb_VideoCode.Leave += Tb_VideoCode_Leave;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(259, 71);
            label13.Name = "label13";
            label13.Size = new Size(50, 15);
            label13.TabIndex = 34;
            label13.Text = "대여일 :";
            // 
            // label14
            // 
            label14.AutoEllipsis = true;
            label14.AutoSize = true;
            label14.Location = new Point(146, 71);
            label14.Name = "label14";
            label14.Size = new Size(50, 15);
            label14.TabIndex = 32;
            label14.Text = "연체료 :";
            // 
            // label15
            // 
            label15.AutoEllipsis = true;
            label15.AutoSize = true;
            label15.Location = new Point(175, 42);
            label15.Name = "label15";
            label15.Size = new Size(78, 15);
            label15.TabIndex = 30;
            label15.Text = "비디오 제목 :";
            // 
            // Tb_VideoTitle
            // 
            Tb_VideoTitle.Location = new Point(259, 34);
            Tb_VideoTitle.Name = "Tb_VideoTitle";
            Tb_VideoTitle.Size = new Size(394, 23);
            Tb_VideoTitle.TabIndex = 29;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(529, 71);
            label18.Name = "label18";
            label18.Size = new Size(78, 15);
            label18.TabIndex = 17;
            label18.Text = "반납 예정일 :";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(20, 71);
            label19.Name = "label19";
            label19.Size = new Size(50, 15);
            label19.TabIndex = 16;
            label19.Text = "대여료 :";
            // 
            // label20
            // 
            label20.AutoEllipsis = true;
            label20.AutoSize = true;
            label20.Location = new Point(16, 42);
            label20.Name = "label20";
            label20.Size = new Size(78, 15);
            label20.TabIndex = 15;
            label20.Text = "비디오 코드 :";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(36, 351);
            label17.Name = "label17";
            label17.Size = new Size(82, 15);
            label17.TabIndex = 37;
            label17.Text = "총 대여 개수 :";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(187, 351);
            label16.Name = "label16";
            label16.Size = new Size(66, 15);
            label16.TabIndex = 38;
            label16.Text = "총 대여료 :";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(326, 351);
            label21.Name = "label21";
            label21.Size = new Size(66, 15);
            label21.TabIndex = 39;
            label21.Text = "총 연체료 :";
            // 
            // Btn_VideoRetrieve
            // 
            Btn_VideoRetrieve.Location = new Point(683, 343);
            Btn_VideoRetrieve.Name = "Btn_VideoRetrieve";
            Btn_VideoRetrieve.Size = new Size(87, 23);
            Btn_VideoRetrieve.TabIndex = 38;
            Btn_VideoRetrieve.Text = "비디오 회수";
            Btn_VideoRetrieve.UseVisualStyleBackColor = true;
            Btn_VideoRetrieve.Click += Btn_VideoRetrieve_Click;
            // 
            // Lb_Every_Realse_Count
            // 
            Lb_Every_Realse_Count.AutoSize = true;
            Lb_Every_Realse_Count.BackColor = SystemColors.ButtonFace;
            Lb_Every_Realse_Count.BorderStyle = BorderStyle.FixedSingle;
            Lb_Every_Realse_Count.Location = new Point(124, 351);
            Lb_Every_Realse_Count.Name = "Lb_Every_Realse_Count";
            Lb_Every_Realse_Count.Size = new Size(35, 17);
            Lb_Every_Realse_Count.TabIndex = 41;
            Lb_Every_Realse_Count.Text = "00개";
            // 
            // Lb_Every_Realse_Money
            // 
            Lb_Every_Realse_Money.AutoSize = true;
            Lb_Every_Realse_Money.BorderStyle = BorderStyle.FixedSingle;
            Lb_Every_Realse_Money.Location = new Point(259, 351);
            Lb_Every_Realse_Money.Name = "Lb_Every_Realse_Money";
            Lb_Every_Realse_Money.Size = new Size(56, 17);
            Lb_Every_Realse_Money.TabIndex = 42;
            Lb_Every_Realse_Money.Text = "00000원";
            // 
            // Lb_Every_Overdue_Money
            // 
            Lb_Every_Overdue_Money.AutoSize = true;
            Lb_Every_Overdue_Money.BorderStyle = BorderStyle.FixedSingle;
            Lb_Every_Overdue_Money.Location = new Point(398, 351);
            Lb_Every_Overdue_Money.Name = "Lb_Every_Overdue_Money";
            Lb_Every_Overdue_Money.Size = new Size(56, 17);
            Lb_Every_Overdue_Money.TabIndex = 43;
            Lb_Every_Overdue_Money.Text = "00000원";
            // 
            // GV_VideoList
            // 
            GV_VideoList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GV_VideoList.Columns.AddRange(new DataGridViewColumn[] { RentalNo, VideoCode, Title, RentalDate, DueDate });
            GV_VideoList.Location = new Point(12, 372);
            GV_VideoList.Name = "GV_VideoList";
            GV_VideoList.Size = new Size(776, 216);
            GV_VideoList.TabIndex = 44;
            // 
            // RentalNo
            // 
            RentalNo.HeaderText = "대여 번호";
            RentalNo.Name = "RentalNo";
            // 
            // VideoCode
            // 
            VideoCode.HeaderText = "비디오 코드";
            VideoCode.Name = "VideoCode";
            // 
            // Title
            // 
            Title.HeaderText = "제목";
            Title.Name = "Title";
            // 
            // RentalDate
            // 
            RentalDate.HeaderText = "대여일";
            RentalDate.Name = "RentalDate";
            // 
            // DueDate
            // 
            DueDate.HeaderText = "반납일";
            DueDate.Name = "DueDate";
            // 
            // Rental_management
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(GV_VideoList);
            Controls.Add(Lb_Every_Overdue_Money);
            Controls.Add(Lb_Every_Realse_Money);
            Controls.Add(Lb_Every_Realse_Count);
            Controls.Add(Btn_VideoRetrieve);
            Controls.Add(label21);
            Controls.Add(label16);
            Controls.Add(label17);
            Controls.Add(Gb_VideoInsert);
            Controls.Add(User_control);
            Controls.Add(Gb_User_Info);
            Name = "Rental_management";
            Text = "비디오 대여 관리";
            Gb_User_Info.ResumeLayout(false);
            Gb_User_Info.PerformLayout();
            User_control.ResumeLayout(false);
            User_Insert.ResumeLayout(false);
            User_Insert.PerformLayout();
            User_Choice.ResumeLayout(false);
            User_Choice.PerformLayout();
            Gb_VideoInsert.ResumeLayout(false);
            Gb_VideoInsert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GV_VideoList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox Gb_User_Info;
        private TextBox Tb_PostNumber;
        private TextBox Tb_Tel;
        private TextBox Tb_SSN;
        private TextBox Tb_CustomerCode;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TabControl User_control;
        private TabPage User_Insert;
        private TabPage User_Choice;
        private Button Btn_FindUser;
        private TextBox Tb_Phone;
        private TextBox Tb_HP;
        private TextBox Tb_UserCode;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox Tb_UserName;
        private Label label1;
        private TextBox Tb_Address;
        private Label label9;
        private TextBox Tb_Mobile;
        private Label label12;
        private TextBox Tb_CustomerType;
        private Label label11;
        private TextBox Tb_CustomerName;
        private Label label10;
        private GroupBox Gb_VideoInsert;
        private TextBox textBox9;
        private Label label13;
        private TextBox textBox10;
        private Label label14;
        private TextBox textBox11;
        private Label label15;
        private TextBox Tb_VideoTitle;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private Label label18;
        private Label label19;
        private Label label20;
        private Button Btn_VideoSave;
        private Button Btn_VideoUpload;
        private TextBox Tb_VideoCode;
        private DateTimePicker Dt_video_Rent;
        private Label label17;
        private Label label16;
        private Label label21;
        private Button Btn_VideoRetrieve;
        private Label Every_Realse_Count;
        private Label Every_Realse_Money;
        private Label Every_Overdue_Money;
        private Label Overdue_Money;
        private Label Lb_Release_Money;
        private Label Lb_ReturnDate;
        private Label Lb_Overdue_Money;
        private Label Lb_Every_Realse_Count;
        private Label Lb_Every_Realse_Money;
        private Label Lb_Every_Overdue_Money;
        private DataGridView GV_VideoList;
        private Label label23;
        private ListView Lb_CustomerSelect;
        private DataGridViewTextBoxColumn RentalNo;
        private DataGridViewTextBoxColumn VideoCode;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn RentalDate;
        private DataGridViewTextBoxColumn DueDate;
    }
}
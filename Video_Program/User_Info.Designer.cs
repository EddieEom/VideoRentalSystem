namespace Video_Program
{
    partial class User_Info
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
            Gb_CustomerInfo = new GroupBox();
            Tb_Mobile = new TextBox();
            Tb_Gender = new TextBox();
            Tb_SSN = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            Tb_Address = new TextBox();
            Tb_PostNumber = new TextBox();
            Tb_Tel = new TextBox();
            Tb_CustomerType = new TextBox();
            Tb_CustomerName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            Tb_CustomerCode = new TextBox();
            label13 = new Label();
            label18 = new Label();
            label19 = new Label();
            Customer_Number = new Label();
            Btn_Insert = new Button();
            Btn_Update = new Button();
            Btn_Delete = new Button();
            Btn_Close = new Button();
            Gv_Customer = new DataGridView();
            CustomerCode = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            SSN = new DataGridViewTextBoxColumn();
            CustomerType = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            Tel = new DataGridViewTextBoxColumn();
            Mobile = new DataGridViewTextBoxColumn();
            PostNumber = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            label6 = new Label();
            Lb_Customer_Count = new Label();
            Gb_CustomerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Gv_Customer).BeginInit();
            SuspendLayout();
            // 
            // Gb_CustomerInfo
            // 
            Gb_CustomerInfo.Controls.Add(Tb_Mobile);
            Gb_CustomerInfo.Controls.Add(Tb_Gender);
            Gb_CustomerInfo.Controls.Add(Tb_SSN);
            Gb_CustomerInfo.Controls.Add(label5);
            Gb_CustomerInfo.Controls.Add(label4);
            Gb_CustomerInfo.Controls.Add(label3);
            Gb_CustomerInfo.Controls.Add(Tb_Address);
            Gb_CustomerInfo.Controls.Add(Tb_PostNumber);
            Gb_CustomerInfo.Controls.Add(Tb_Tel);
            Gb_CustomerInfo.Controls.Add(Tb_CustomerType);
            Gb_CustomerInfo.Controls.Add(Tb_CustomerName);
            Gb_CustomerInfo.Controls.Add(label2);
            Gb_CustomerInfo.Controls.Add(label1);
            Gb_CustomerInfo.Controls.Add(Tb_CustomerCode);
            Gb_CustomerInfo.Controls.Add(label13);
            Gb_CustomerInfo.Controls.Add(label18);
            Gb_CustomerInfo.Controls.Add(label19);
            Gb_CustomerInfo.Controls.Add(Customer_Number);
            Gb_CustomerInfo.Location = new Point(12, 12);
            Gb_CustomerInfo.Name = "Gb_CustomerInfo";
            Gb_CustomerInfo.Size = new Size(588, 273);
            Gb_CustomerInfo.TabIndex = 37;
            Gb_CustomerInfo.TabStop = false;
            Gb_CustomerInfo.Text = "고객 정보";
            // 
            // Tb_Mobile
            // 
            Tb_Mobile.Location = new Point(391, 145);
            Tb_Mobile.Name = "Tb_Mobile";
            Tb_Mobile.Size = new Size(167, 23);
            Tb_Mobile.TabIndex = 59;
            // 
            // Tb_Gender
            // 
            Tb_Gender.Location = new Point(391, 107);
            Tb_Gender.Name = "Tb_Gender";
            Tb_Gender.Size = new Size(167, 23);
            Tb_Gender.TabIndex = 58;
            // 
            // Tb_SSN
            // 
            Tb_SSN.Location = new Point(391, 69);
            Tb_SSN.Name = "Tb_SSN";
            Tb_SSN.Size = new Size(167, 23);
            Tb_SSN.TabIndex = 57;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(335, 148);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 56;
            label5.Text = "휴대폰 :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(347, 110);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 55;
            label4.Text = "성별 :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(299, 72);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 54;
            label3.Text = "주민등록번호 :";
            // 
            // Tb_Address
            // 
            Tb_Address.Location = new Point(85, 216);
            Tb_Address.Name = "Tb_Address";
            Tb_Address.Size = new Size(473, 23);
            Tb_Address.TabIndex = 53;
            // 
            // Tb_PostNumber
            // 
            Tb_PostNumber.Location = new Point(85, 178);
            Tb_PostNumber.Name = "Tb_PostNumber";
            Tb_PostNumber.Size = new Size(167, 23);
            Tb_PostNumber.TabIndex = 52;
            // 
            // Tb_Tel
            // 
            Tb_Tel.Location = new Point(85, 140);
            Tb_Tel.Name = "Tb_Tel";
            Tb_Tel.Size = new Size(167, 23);
            Tb_Tel.TabIndex = 51;
            // 
            // Tb_CustomerType
            // 
            Tb_CustomerType.Location = new Point(85, 102);
            Tb_CustomerType.Name = "Tb_CustomerType";
            Tb_CustomerType.Size = new Size(167, 23);
            Tb_CustomerType.TabIndex = 50;
            // 
            // Tb_CustomerName
            // 
            Tb_CustomerName.Location = new Point(85, 64);
            Tb_CustomerName.Name = "Tb_CustomerName";
            Tb_CustomerName.Size = new Size(167, 23);
            Tb_CustomerName.TabIndex = 49;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 224);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 48;
            label2.Text = "주소 :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 186);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 47;
            label1.Text = "우편번호 :";
            // 
            // Tb_CustomerCode
            // 
            Tb_CustomerCode.Location = new Point(85, 26);
            Tb_CustomerCode.Name = "Tb_CustomerCode";
            Tb_CustomerCode.Size = new Size(119, 23);
            Tb_CustomerCode.TabIndex = 38;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(13, 110);
            label13.Name = "label13";
            label13.Size = new Size(66, 15);
            label13.TabIndex = 34;
            label13.Text = "고객 신분 :";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(17, 148);
            label18.Name = "label18";
            label18.Size = new Size(62, 15);
            label18.TabIndex = 17;
            label18.Text = "전화번호 :";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(29, 72);
            label19.Name = "label19";
            label19.Size = new Size(50, 15);
            label19.TabIndex = 16;
            label19.Text = "고객명 :";
            // 
            // Customer_Number
            // 
            Customer_Number.AutoEllipsis = true;
            Customer_Number.AutoSize = true;
            Customer_Number.Location = new Point(17, 34);
            Customer_Number.Name = "Customer_Number";
            Customer_Number.Size = new Size(62, 15);
            Customer_Number.TabIndex = 15;
            Customer_Number.Text = "고객번호 :";
            // 
            // Btn_Insert
            // 
            Btn_Insert.Location = new Point(12, 291);
            Btn_Insert.Name = "Btn_Insert";
            Btn_Insert.Size = new Size(88, 23);
            Btn_Insert.TabIndex = 38;
            Btn_Insert.Text = "추가";
            Btn_Insert.UseVisualStyleBackColor = true;
            Btn_Insert.Click += Btn_Insert_Click;
            // 
            // Btn_Update
            // 
            Btn_Update.Location = new Point(106, 291);
            Btn_Update.Name = "Btn_Update";
            Btn_Update.Size = new Size(88, 23);
            Btn_Update.TabIndex = 39;
            Btn_Update.Text = "저장";
            Btn_Update.UseVisualStyleBackColor = true;
            Btn_Update.Click += Btn_Update_Click;
            // 
            // Btn_Delete
            // 
            Btn_Delete.Location = new Point(200, 291);
            Btn_Delete.Name = "Btn_Delete";
            Btn_Delete.Size = new Size(88, 23);
            Btn_Delete.TabIndex = 40;
            Btn_Delete.Text = "삭제";
            Btn_Delete.UseVisualStyleBackColor = true;
            Btn_Delete.Click += Btn_Delete_Click;
            // 
            // Btn_Close
            // 
            Btn_Close.Location = new Point(512, 291);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(88, 23);
            Btn_Close.TabIndex = 42;
            Btn_Close.Text = "나가기";
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // Gv_Customer
            // 
            Gv_Customer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Gv_Customer.Columns.AddRange(new DataGridViewColumn[] { CustomerCode, CustomerName, SSN, CustomerType, Gender, Tel, Mobile, PostNumber, Address });
            Gv_Customer.Location = new Point(12, 352);
            Gv_Customer.Name = "Gv_Customer";
            Gv_Customer.Size = new Size(588, 159);
            Gv_Customer.TabIndex = 43;
            Gv_Customer.CellClick += Gv_Customer_CellClick;
            // 
            // CustomerCode
            // 
            CustomerCode.HeaderText = "코드";
            CustomerCode.Name = "CustomerCode";
            // 
            // CustomerName
            // 
            CustomerName.HeaderText = "성명";
            CustomerName.Name = "CustomerName";
            // 
            // SSN
            // 
            SSN.HeaderText = "주민등록번호";
            SSN.Name = "SSN";
            // 
            // CustomerType
            // 
            CustomerType.HeaderText = "신분";
            CustomerType.Name = "CustomerType";
            // 
            // Gender
            // 
            Gender.HeaderText = "성별";
            Gender.Name = "Gender";
            // 
            // Tel
            // 
            Tel.HeaderText = "연락처";
            Tel.Name = "Tel";
            // 
            // Mobile
            // 
            Mobile.HeaderText = "휴대폰";
            Mobile.Name = "Mobile";
            // 
            // PostNumber
            // 
            PostNumber.HeaderText = "우편번호";
            PostNumber.Name = "PostNumber";
            // 
            // Address
            // 
            Address.HeaderText = "주소";
            Address.Name = "Address";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 334);
            label6.Name = "label6";
            label6.Size = new Size(82, 15);
            label6.TabIndex = 44;
            label6.Text = "현재 고객 수 :";
            // 
            // Lb_Customer_Count
            // 
            Lb_Customer_Count.AutoSize = true;
            Lb_Customer_Count.BackColor = SystemColors.ControlDarkDark;
            Lb_Customer_Count.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Lb_Customer_Count.ForeColor = SystemColors.Control;
            Lb_Customer_Count.Location = new Point(100, 329);
            Lb_Customer_Count.Name = "Lb_Customer_Count";
            Lb_Customer_Count.Size = new Size(35, 21);
            Lb_Customer_Count.TabIndex = 45;
            Lb_Customer_Count.Text = "0개";
            // 
            // User_Info
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 533);
            Controls.Add(Lb_Customer_Count);
            Controls.Add(label6);
            Controls.Add(Gv_Customer);
            Controls.Add(Btn_Close);
            Controls.Add(Btn_Delete);
            Controls.Add(Btn_Update);
            Controls.Add(Gb_CustomerInfo);
            Controls.Add(Btn_Insert);
            Name = "User_Info";
            Text = "고객 관리";
            Load += User_Info_Load;
            Gb_CustomerInfo.ResumeLayout(false);
            Gb_CustomerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Gv_Customer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox Gb_CustomerInfo;
        private Button Btn_Insert;
        private TextBox Tb_CustomerCode;
        private Label label13;
        private Label label18;
        private Label label19;
        private Label Customer_Number;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox Tb_Address;
        private TextBox Tb_PostNumber;
        private TextBox Tb_Tel;
        private TextBox Tb_CustomerType;
        private TextBox Tb_CustomerName;
        private Button Btn_Update;
        private Button Btn_Delete;
        private TextBox Tb_Mobile;
        private TextBox Tb_Gender;
        private TextBox Tb_SSN;
        private Label label5;
        private Label label4;
        private Button Btn_Close;
        private DataGridView Gv_Customer;
        private Label label6;
        private Label Lb_Customer_Count;
        private DataGridViewTextBoxColumn CustomerCode;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn SSN;
        private DataGridViewTextBoxColumn CustomerType;
        private DataGridViewTextBoxColumn Gender;
        private DataGridViewTextBoxColumn Tel;
        private DataGridViewTextBoxColumn Mobile;
        private DataGridViewTextBoxColumn PostNumber;
        private DataGridViewTextBoxColumn Address;
    }
}
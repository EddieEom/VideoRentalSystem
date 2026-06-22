namespace Video_Program
{
    partial class Information_Select
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
            Gb_VideoAttribute = new GroupBox();
            Btn_Exit = new Button();
            Btn_Search = new Button();
            Tb_CustomerType = new TextBox();
            Tb_Genre = new TextBox();
            label2 = new Label();
            label1 = new Label();
            Rbt_CustomerRank = new RadioButton();
            Rbt_RentingRank = new RadioButton();
            Rbt_RentalRank = new RadioButton();
            GV_Select = new DataGridView();
            RentalCount = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            CustomerType = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            Tel = new DataGridViewTextBoxColumn();
            Mobile = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            PostNumber = new DataGridViewTextBoxColumn();
            Gb_VideoAttribute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GV_Select).BeginInit();
            SuspendLayout();
            // 
            // Gb_VideoAttribute
            // 
            Gb_VideoAttribute.Controls.Add(Btn_Exit);
            Gb_VideoAttribute.Controls.Add(Btn_Search);
            Gb_VideoAttribute.Controls.Add(Tb_CustomerType);
            Gb_VideoAttribute.Controls.Add(Tb_Genre);
            Gb_VideoAttribute.Controls.Add(label2);
            Gb_VideoAttribute.Controls.Add(label1);
            Gb_VideoAttribute.Controls.Add(Rbt_CustomerRank);
            Gb_VideoAttribute.Controls.Add(Rbt_RentingRank);
            Gb_VideoAttribute.Controls.Add(Rbt_RentalRank);
            Gb_VideoAttribute.Location = new Point(12, 12);
            Gb_VideoAttribute.Name = "Gb_VideoAttribute";
            Gb_VideoAttribute.Size = new Size(678, 79);
            Gb_VideoAttribute.TabIndex = 16;
            Gb_VideoAttribute.TabStop = false;
            Gb_VideoAttribute.Text = "조회 정보";
            // 
            // Btn_Exit
            // 
            Btn_Exit.Location = new Point(593, 17);
            Btn_Exit.Name = "Btn_Exit";
            Btn_Exit.Size = new Size(75, 52);
            Btn_Exit.TabIndex = 8;
            Btn_Exit.Text = "나가기";
            Btn_Exit.UseVisualStyleBackColor = true;
            Btn_Exit.Click += Btn_Exit_Click;
            // 
            // Btn_Search
            // 
            Btn_Search.Location = new Point(512, 18);
            Btn_Search.Name = "Btn_Search";
            Btn_Search.Size = new Size(75, 52);
            Btn_Search.TabIndex = 7;
            Btn_Search.Text = "검색";
            Btn_Search.UseVisualStyleBackColor = true;
            Btn_Search.Click += Btn_Search_Click;
            // 
            // Tb_CustomerType
            // 
            Tb_CustomerType.Location = new Point(372, 46);
            Tb_CustomerType.Name = "Tb_CustomerType";
            Tb_CustomerType.Size = new Size(100, 23);
            Tb_CustomerType.TabIndex = 6;
            // 
            // Tb_Genre
            // 
            Tb_Genre.Location = new Point(372, 18);
            Tb_Genre.Name = "Tb_Genre";
            Tb_Genre.Size = new Size(100, 23);
            Tb_Genre.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(300, 49);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 4;
            label2.Text = "고객 신분 :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(328, 24);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "장르 :";
            // 
            // Rbt_CustomerRank
            // 
            Rbt_CustomerRank.AutoSize = true;
            Rbt_CustomerRank.Location = new Point(6, 47);
            Rbt_CustomerRank.Name = "Rbt_CustomerRank";
            Rbt_CustomerRank.Size = new Size(105, 19);
            Rbt_CustomerRank.TabIndex = 2;
            Rbt_CustomerRank.TabStop = true;
            Rbt_CustomerRank.Text = "고객 대여 순위";
            Rbt_CustomerRank.UseVisualStyleBackColor = true;
            Rbt_CustomerRank.CheckedChanged += Rbt_CustomerRank_CheckedChanged;
            // 
            // Rbt_RentingRank
            // 
            Rbt_RentingRank.AutoSize = true;
            Rbt_RentingRank.Location = new Point(138, 22);
            Rbt_RentingRank.Name = "Rbt_RentingRank";
            Rbt_RentingRank.Size = new Size(113, 19);
            Rbt_RentingRank.TabIndex = 1;
            Rbt_RentingRank.TabStop = true;
            Rbt_RentingRank.Text = "대여중인 비디오";
            Rbt_RentingRank.UseVisualStyleBackColor = true;
            Rbt_RentingRank.CheckedChanged += Rbt_RentingRank_CheckedChanged;
            // 
            // Rbt_RentalRank
            // 
            Rbt_RentalRank.AutoSize = true;
            Rbt_RentalRank.Location = new Point(6, 22);
            Rbt_RentalRank.Name = "Rbt_RentalRank";
            Rbt_RentalRank.Size = new Size(117, 19);
            Rbt_RentalRank.TabIndex = 0;
            Rbt_RentalRank.TabStop = true;
            Rbt_RentalRank.Text = "비디오 대여 순위";
            Rbt_RentalRank.UseVisualStyleBackColor = true;
            Rbt_RentalRank.CheckedChanged += Rbt_RentalRank_CheckedChanged;
            // 
            // GV_Select
            // 
            GV_Select.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GV_Select.Columns.AddRange(new DataGridViewColumn[] { RentalCount, CustomerName, CustomerType, Gender, Tel, Mobile, Address, PostNumber });
            GV_Select.Location = new Point(12, 123);
            GV_Select.Name = "GV_Select";
            GV_Select.Size = new Size(678, 315);
            GV_Select.TabIndex = 17;
            // 
            // RentalCount
            // 
            RentalCount.HeaderText = "대여횟수";
            RentalCount.Name = "RentalCount";
            // 
            // CustomerName
            // 
            CustomerName.HeaderText = "고객 이름";
            CustomerName.Name = "CustomerName";
            // 
            // CustomerType
            // 
            CustomerType.HeaderText = "등급";
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
            // Address
            // 
            Address.HeaderText = "주소";
            Address.Name = "Address";
            // 
            // PostNumber
            // 
            PostNumber.HeaderText = "우편번호";
            PostNumber.Name = "PostNumber";
            // 
            // Information_Select
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 450);
            Controls.Add(GV_Select);
            Controls.Add(Gb_VideoAttribute);
            Name = "Information_Select";
            Text = "정보 조회";
            FormClosing += Information_Select_FormClosing;
            Gb_VideoAttribute.ResumeLayout(false);
            Gb_VideoAttribute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GV_Select).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox Gb_VideoAttribute;
        private RadioButton Rbt_CustomerRank;
        private RadioButton Rbt_RentingRank;
        private RadioButton Rbt_RentalRank;
        private Label label2;
        private Label label1;
        private Button Btn_Exit;
        private Button Btn_Search;
        private TextBox Tb_CustomerType;
        private TextBox Tb_Genre;
        private DataGridView GV_Select;
        private DataGridViewTextBoxColumn RentalCount;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn CustomerType;
        private DataGridViewTextBoxColumn Gender;
        private DataGridViewTextBoxColumn Tel;
        private DataGridViewTextBoxColumn Mobile;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn PostNumber;
    }
}
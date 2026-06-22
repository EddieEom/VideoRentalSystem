namespace Video_Program
{
    partial class Video_Excel_Setting
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
            Btn_RentalStatus = new Button();
            Btn_VideoList = new Button();
            label1 = new Label();
            Cb_VideoGenre = new ComboBox();
            Gb_CustomerInfo.SuspendLayout();
            SuspendLayout();
            // 
            // Gb_CustomerInfo
            // 
            Gb_CustomerInfo.Controls.Add(Btn_RentalStatus);
            Gb_CustomerInfo.Controls.Add(Btn_VideoList);
            Gb_CustomerInfo.Location = new Point(12, 45);
            Gb_CustomerInfo.Name = "Gb_CustomerInfo";
            Gb_CustomerInfo.Size = new Size(285, 84);
            Gb_CustomerInfo.TabIndex = 38;
            Gb_CustomerInfo.TabStop = false;
            Gb_CustomerInfo.Text = "엑셀로 출력";
            // 
            // Btn_RentalStatus
            // 
            Btn_RentalStatus.Location = new Point(143, 22);
            Btn_RentalStatus.Name = "Btn_RentalStatus";
            Btn_RentalStatus.Size = new Size(136, 44);
            Btn_RentalStatus.TabIndex = 1;
            Btn_RentalStatus.Text = "대여 현황";
            Btn_RentalStatus.UseVisualStyleBackColor = true;
            Btn_RentalStatus.Click += Btn_RentalStatus_Click;
            // 
            // Btn_VideoList
            // 
            Btn_VideoList.Location = new Point(6, 22);
            Btn_VideoList.Name = "Btn_VideoList";
            Btn_VideoList.Size = new Size(131, 44);
            Btn_VideoList.TabIndex = 0;
            Btn_VideoList.Text = "비디오 목록";
            Btn_VideoList.UseVisualStyleBackColor = true;
            Btn_VideoList.Click += Btn_VideoList_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 39;
            label1.Text = "비디오 장르 :";
            // 
            // Cb_VideoGenre
            // 
            Cb_VideoGenre.FormattingEnabled = true;
            Cb_VideoGenre.Location = new Point(96, 12);
            Cb_VideoGenre.Name = "Cb_VideoGenre";
            Cb_VideoGenre.Size = new Size(121, 23);
            Cb_VideoGenre.TabIndex = 40;
            // 
            // Video_Excel_Setting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 141);
            Controls.Add(Cb_VideoGenre);
            Controls.Add(label1);
            Controls.Add(Gb_CustomerInfo);
            Name = "Video_Excel_Setting";
            Text = "비디오 정보 출력";
            Load += Video_Excel_Setting_Load;
            Gb_CustomerInfo.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox Gb_CustomerInfo;
        private Button Btn_RentalStatus;
        private Button Btn_VideoList;
        private Label label1;
        private ComboBox Cb_VideoGenre;
    }
}
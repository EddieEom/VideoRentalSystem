namespace Video_Program
{
    partial class Video_Info
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
            Tb_Director = new TextBox();
            Tb_Distributor = new TextBox();
            Tb_MainActor = new TextBox();
            Tb_Genre = new TextBox();
            Tb_Title = new TextBox();
            Tb_VideoCode = new TextBox();
            label8 = new Label();
            Dt_Video_Info = new DateTimePicker();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            Btn_Video_Insert = new Button();
            Btn_Video_Save = new Button();
            Btn_Video_Delete = new Button();
            Btn_Video_Exit = new Button();
            label1 = new Label();
            Video_Count = new Label();
            Btn_VideoList_Save = new Button();
            GV_Video = new DataGridView();
            VideoCode = new DataGridViewTextBoxColumn();
            Genre = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            MainActor = new DataGridViewTextBoxColumn();
            Director = new DataGridViewTextBoxColumn();
            Distrubtion = new DataGridViewTextBoxColumn();
            ReleaseDate = new DataGridViewTextBoxColumn();
            Gb_VideoAttribute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GV_Video).BeginInit();
            SuspendLayout();
            // 
            // Gb_VideoAttribute
            // 
            Gb_VideoAttribute.Controls.Add(Tb_Director);
            Gb_VideoAttribute.Controls.Add(Tb_Distributor);
            Gb_VideoAttribute.Controls.Add(Tb_MainActor);
            Gb_VideoAttribute.Controls.Add(Tb_Genre);
            Gb_VideoAttribute.Controls.Add(Tb_Title);
            Gb_VideoAttribute.Controls.Add(Tb_VideoCode);
            Gb_VideoAttribute.Controls.Add(label8);
            Gb_VideoAttribute.Controls.Add(Dt_Video_Info);
            Gb_VideoAttribute.Controls.Add(label7);
            Gb_VideoAttribute.Controls.Add(label6);
            Gb_VideoAttribute.Controls.Add(label5);
            Gb_VideoAttribute.Controls.Add(label4);
            Gb_VideoAttribute.Controls.Add(label3);
            Gb_VideoAttribute.Controls.Add(label2);
            Gb_VideoAttribute.Location = new Point(12, 12);
            Gb_VideoAttribute.Name = "Gb_VideoAttribute";
            Gb_VideoAttribute.Size = new Size(736, 211);
            Gb_VideoAttribute.TabIndex = 15;
            Gb_VideoAttribute.TabStop = false;
            Gb_VideoAttribute.Text = "비디오 속성";
            // 
            // Tb_Director
            // 
            Tb_Director.Location = new Point(416, 125);
            Tb_Director.Name = "Tb_Director";
            Tb_Director.Size = new Size(249, 23);
            Tb_Director.TabIndex = 28;
            // 
            // Tb_Distributor
            // 
            Tb_Distributor.Location = new Point(101, 163);
            Tb_Distributor.Name = "Tb_Distributor";
            Tb_Distributor.Size = new Size(218, 23);
            Tb_Distributor.TabIndex = 27;
            // 
            // Tb_MainActor
            // 
            Tb_MainActor.Location = new Point(101, 117);
            Tb_MainActor.Name = "Tb_MainActor";
            Tb_MainActor.Size = new Size(218, 23);
            Tb_MainActor.TabIndex = 26;
            // 
            // Tb_Genre
            // 
            Tb_Genre.Location = new Point(416, 24);
            Tb_Genre.Name = "Tb_Genre";
            Tb_Genre.Size = new Size(249, 23);
            Tb_Genre.TabIndex = 25;
            // 
            // Tb_Title
            // 
            Tb_Title.AcceptsReturn = true;
            Tb_Title.Location = new Point(101, 69);
            Tb_Title.Name = "Tb_Title";
            Tb_Title.Size = new Size(564, 23);
            Tb_Title.TabIndex = 24;
            // 
            // Tb_VideoCode
            // 
            Tb_VideoCode.Location = new Point(101, 24);
            Tb_VideoCode.Name = "Tb_VideoCode";
            Tb_VideoCode.Size = new Size(218, 23);
            Tb_VideoCode.TabIndex = 23;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(360, 171);
            label8.Name = "label8";
            label8.Size = new Size(50, 15);
            label8.TabIndex = 22;
            label8.Text = "출시일 :";
            // 
            // Dt_Video_Info
            // 
            Dt_Video_Info.Location = new Point(416, 165);
            Dt_Video_Info.Name = "Dt_Video_Info";
            Dt_Video_Info.Size = new Size(249, 23);
            Dt_Video_Info.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(372, 130);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 20;
            label7.Text = "감독 :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(372, 32);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 19;
            label6.Text = "장르 :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 171);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 18;
            label5.Text = "제작 및 배급 :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 125);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 17;
            label4.Text = "주연 배우 :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 77);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 16;
            label3.Text = "제목 :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 32);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 15;
            label2.Text = "비디오 코드 :";
            // 
            // Btn_Video_Insert
            // 
            Btn_Video_Insert.Location = new Point(15, 229);
            Btn_Video_Insert.Name = "Btn_Video_Insert";
            Btn_Video_Insert.Size = new Size(64, 34);
            Btn_Video_Insert.TabIndex = 16;
            Btn_Video_Insert.Text = "추가";
            Btn_Video_Insert.UseVisualStyleBackColor = true;
            Btn_Video_Insert.Click += Btn_Video_Insert_Click;
            // 
            // Btn_Video_Save
            // 
            Btn_Video_Save.Location = new Point(95, 229);
            Btn_Video_Save.Name = "Btn_Video_Save";
            Btn_Video_Save.Size = new Size(64, 34);
            Btn_Video_Save.TabIndex = 17;
            Btn_Video_Save.Text = "저장";
            Btn_Video_Save.UseVisualStyleBackColor = true;
            Btn_Video_Save.Click += Btn_Video_Save_Click;
            // 
            // Btn_Video_Delete
            // 
            Btn_Video_Delete.Location = new Point(176, 229);
            Btn_Video_Delete.Name = "Btn_Video_Delete";
            Btn_Video_Delete.Size = new Size(64, 34);
            Btn_Video_Delete.TabIndex = 18;
            Btn_Video_Delete.Text = "삭제";
            Btn_Video_Delete.UseVisualStyleBackColor = true;
            Btn_Video_Delete.Click += Btn_Video_Delete_Click;
            // 
            // Btn_Video_Exit
            // 
            Btn_Video_Exit.Location = new Point(634, 229);
            Btn_Video_Exit.Name = "Btn_Video_Exit";
            Btn_Video_Exit.Size = new Size(114, 55);
            Btn_Video_Exit.TabIndex = 20;
            Btn_Video_Exit.Text = "나가기";
            Btn_Video_Exit.UseVisualStyleBackColor = true;
            Btn_Video_Exit.Click += Btn_Video_Exit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 282);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 29;
            label1.Text = "전체 비디오 수 :";
            // 
            // Video_Count
            // 
            Video_Count.AutoSize = true;
            Video_Count.BorderStyle = BorderStyle.FixedSingle;
            Video_Count.Location = new Point(113, 282);
            Video_Count.Name = "Video_Count";
            Video_Count.Size = new Size(35, 17);
            Video_Count.TabIndex = 30;
            Video_Count.Text = "00개";
            // 
            // Btn_VideoList_Save
            // 
            Btn_VideoList_Save.Location = new Point(152, 278);
            Btn_VideoList_Save.Name = "Btn_VideoList_Save";
            Btn_VideoList_Save.Size = new Size(75, 23);
            Btn_VideoList_Save.TabIndex = 31;
            Btn_VideoList_Save.Text = "목록 저장";
            Btn_VideoList_Save.UseVisualStyleBackColor = true;
            Btn_VideoList_Save.Click += Btn_VideoList_Save_Click;
            // 
            // GV_Video
            // 
            GV_Video.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GV_Video.Columns.AddRange(new DataGridViewColumn[] { VideoCode, Genre, Title, MainActor, Director, Distrubtion, ReleaseDate });
            GV_Video.Location = new Point(12, 307);
            GV_Video.Name = "GV_Video";
            GV_Video.Size = new Size(736, 217);
            GV_Video.TabIndex = 32;
            GV_Video.CellClick += GV_Video_CellClick;
            // 
            // VideoCode
            // 
            VideoCode.HeaderText = "코드";
            VideoCode.Name = "VideoCode";
            // 
            // Genre
            // 
            Genre.HeaderText = "장르";
            Genre.Name = "Genre";
            // 
            // Title
            // 
            Title.HeaderText = "제목";
            Title.Name = "Title";
            // 
            // MainActor
            // 
            MainActor.HeaderText = "주연 배우";
            MainActor.Name = "MainActor";
            // 
            // Director
            // 
            Director.HeaderText = "감독";
            Director.Name = "Director";
            // 
            // Distrubtion
            // 
            Distrubtion.HeaderText = "제작 및 배급";
            Distrubtion.Name = "Distrubtion";
            // 
            // ReleaseDate
            // 
            ReleaseDate.HeaderText = "출시일";
            ReleaseDate.Name = "ReleaseDate";
            // 
            // Video_Info
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 576);
            Controls.Add(GV_Video);
            Controls.Add(Btn_VideoList_Save);
            Controls.Add(Video_Count);
            Controls.Add(label1);
            Controls.Add(Btn_Video_Exit);
            Controls.Add(Btn_Video_Delete);
            Controls.Add(Btn_Video_Save);
            Controls.Add(Btn_Video_Insert);
            Controls.Add(Gb_VideoAttribute);
            Name = "Video_Info";
            Text = "비디오 정보 관리";
            Load += Video_Info_Load;
            Gb_VideoAttribute.ResumeLayout(false);
            Gb_VideoAttribute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GV_Video).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox Gb_VideoAttribute;
        private TextBox Tb_Director;
        private TextBox Tb_Distributor;
        private TextBox Tb_MainActor;
        private TextBox Tb_Genre;
        private TextBox Tb_Title;
        private TextBox Tb_VideoCode;
        private Label label8;
        private DateTimePicker Dt_Video_Info;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button Btn_Video_Insert;
        private Button Btn_Video_Save;
        private Button Btn_Video_Delete;
        private Button Btn_Video_Exit;
        private Label label1;
        private Label Video_Count;
        private Button Btn_VideoList_Save;
        private DataGridView GV_Video;
        private DataGridViewTextBoxColumn VideoCode;
        private DataGridViewTextBoxColumn Genre;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn MainActor;
        private DataGridViewTextBoxColumn Director;
        private DataGridViewTextBoxColumn Distrubtion;
        private DataGridViewTextBoxColumn ReleaseDate;
    }
}
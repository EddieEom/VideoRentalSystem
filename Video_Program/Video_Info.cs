using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Video_Program
{
    public partial class Video_Info : Form
    {

        // DB 연결
        private string connStr = @"Server=localhost;Database=VideoRentalDB;Trusted_Connection=True;TrustServerCertificate=True";
        private SqlConnection conn;

        // 폼 수정 여부 확인 변수
        public bool IsModified = false;

        // 비디오 정보관리 폼 생성자
        public Video_Info()
        {
            InitializeComponent();
        }

        // 현재 등록된 비디오 개수 조회 메서드
        private void LoadVideoCount()
        {
            try
            {
                conn = new SqlConnection(connStr);

                conn.Open();

                // 비디오 개수 조회
                SqlCommand cmd =
                    new SqlCommand(
                    "SELECT COUNT(*) FROM VIDEO",
                    conn);

                int count = (int)cmd.ExecuteScalar();

                // 화면에 비디오 개수 출력
                Video_Count.Text = count + "개";

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 비디오 전체 목록 조회 메서드
        private void LoadVideo()
        {
            try
            {
                // 기존 목록 초기화
                GV_Video.Rows.Clear();

                // DB 연결
                conn = new SqlConnection(connStr);

                conn.Open();

                // 전체 비디오 조회 저장 프로시저 실행
                SqlCommand cmd = new SqlCommand("Select_All_Video",conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                // DataGridView에 데이터 출력
                while (dr.Read())
                {
                    GV_Video.Rows.Add(

                        dr["VideoCode"],

                        dr["Genre"],

                        dr["Title"],

                        dr["MainActor"],

                        dr["Director"],

                        dr["Distributor"],

                        dr["ReleaseDate"]
                    );
                }

                dr.Close();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 비디오 등록 버튼 이벤트
        private void Btn_Video_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connStr);

                conn.Open();

                // 비디오 추가 저장 프로시저 실행
                SqlCommand cmd = new SqlCommand("Insert_Video", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VideoCode",Convert.ToInt32(Tb_VideoCode.Text));

                cmd.Parameters.AddWithValue("@Title",Tb_Title.Text);

                cmd.Parameters.AddWithValue("@Genre",Tb_Genre.Text);

                cmd.Parameters.AddWithValue("@MainActor",Tb_MainActor.Text);

                cmd.Parameters.AddWithValue("@Director",Tb_Director.Text);

                cmd.Parameters.AddWithValue("@Distributor",Tb_Distributor.Text);

                cmd.Parameters.AddWithValue("@ReleaseDate",Dt_Video_Info.Value);

                cmd.ExecuteNonQuery();

                MessageBox.Show("추가 완료");

                // 화면 새로고침
                LoadVideo();

                // 비디오 개수 새로고침
                LoadVideoCount();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 비디오 수정 버튼 이벤트
        private void Btn_Video_Save_Click(object sender, EventArgs e)
        {
            try
            {
                conn =
                    new SqlConnection(connStr);

                conn.Open();

                // 비디오 수정 저장 프로시저 실행
                SqlCommand cmd = new SqlCommand("Update_Video",conn);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@VideoCode",
                    Convert.ToInt32(
                    Tb_VideoCode.Text));

                cmd.Parameters.AddWithValue(
                    "@Title",
                    Tb_Title.Text);

                cmd.Parameters.AddWithValue(
                    "@Genre",
                    Tb_Genre.Text);

                cmd.Parameters.AddWithValue(
                    "@MainActor",
                    Tb_MainActor.Text);

                cmd.Parameters.AddWithValue(
                    "@Director",
                    Tb_Director.Text);

                cmd.Parameters.AddWithValue(
                    "@Distributor",
                    Tb_Distributor.Text);

                cmd.Parameters.AddWithValue(
                    "@ReleaseDate",
                    Dt_Video_Info.Value);

                cmd.ExecuteNonQuery();

                MessageBox.Show("저장 완료");

                // 화면 새로고침
                LoadVideo();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 비디오 삭제 버튼 이벤트
        private void Btn_Video_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connStr);

                conn.Open();

                // 비디오 삭제 저장 프로시저 실행
                SqlCommand cmd = new SqlCommand("Delete_Video",conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VideoCode",Convert.ToInt32(Tb_VideoCode.Text));

                cmd.ExecuteNonQuery();

                MessageBox.Show("삭제 완료");

                // 화면 새로고침
                LoadVideo();

                // 비디오 개수 새로고침
                LoadVideoCount();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 선택한 비디오 정보를 입력창에 출력
        private void GV_Video_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Tb_VideoCode.Text =
                GV_Video.Rows[e.RowIndex]
                .Cells[0]
                .Value?.ToString();

            Tb_Genre.Text =
                GV_Video.Rows[e.RowIndex]
                .Cells[1]
                .Value?.ToString();

            Tb_Title.Text =
                GV_Video.Rows[e.RowIndex]
                .Cells[2]
                .Value?.ToString();

            Tb_MainActor.Text =
                GV_Video.Rows[e.RowIndex]
                .Cells[3]
                .Value?.ToString();

            Tb_Director.Text =
                GV_Video.Rows[e.RowIndex]
                .Cells[4]
                .Value?.ToString();

            Tb_Distributor.Text =
                GV_Video.Rows[e.RowIndex]
                .Cells[5]
                .Value?.ToString();

            Dt_Video_Info.Value =
                Convert.ToDateTime(

                GV_Video.Rows[e.RowIndex]
                .Cells[6]
                .Value
                );
        }

        // 폼 로드 시 비디오 목록 조회
        private void Video_Info_Load(object sender, EventArgs e)
        {
            LoadVideo();

            LoadVideoCount();
        }

        // 비디오 목록 CSV 저장 버튼 이벤트
        private void Btn_VideoList_Save_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save =
                    new SaveFileDialog();

                save.Filter =
                    "CSV 파일 (*.csv)|*.csv";

                save.FileName =
                    "비디오목록.csv";

                if (save.ShowDialog()
                    != DialogResult.OK)
                {
                    return;
                }

                StreamWriter sw =
                    new StreamWriter(
                    save.FileName,
                    false,
                    Encoding.UTF8);

                // 헤더 저장

                for (int i = 0;
                    i < GV_Video.Columns.Count;
                    i++)
                {
                    sw.Write(
                    GV_Video.Columns[i]
                    .HeaderText);

                    if (i <
                    GV_Video.Columns.Count - 1)

                        sw.Write(",");
                }

                sw.WriteLine();

                // 데이터 저장

                foreach (DataGridViewRow row
                    in GV_Video.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    for (int i = 0;
                        i < GV_Video.Columns.Count;
                        i++)
                    {
                        sw.Write(
                        row.Cells[i]
                        .Value);

                        if (i <
                        GV_Video.Columns.Count - 1)

                            sw.Write(",");
                    }

                    sw.WriteLine();
                }

                sw.Close();

                MessageBox.Show(
                "목록 저장 완료");
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message);
            }
        }

        // 종료 버튼 클릭 시 현재 폼 닫기
        private void Btn_Video_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

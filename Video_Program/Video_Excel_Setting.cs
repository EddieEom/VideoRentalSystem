using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Video_Program
{
    public partial class Video_Excel_Setting : Form
    {

        // 폼 수정 여부 확인 변수
        public bool IsModified = false;

        // DB 연결
        private string connStr = @"Server=localhost;Database=VideoRentalDB;Trusted_Connection=True;TrustServerCertificate=True";
        private SqlConnection conn;

        // 엑셀 출력 폼 생성자
        public Video_Excel_Setting()
        {
            InitializeComponent();
        }


        // 폼 로드 시 장르 목록 조회
        private void Video_Excel_Setting_Load(object sender, EventArgs e)
        {
            LoadGenre();
        }

        // 비디오 장르 목록 조회 메서드
        private void LoadGenre()
        {
            try
            {
                // ComboBox 초기화
                Cb_VideoGenre.Items.Clear();

                // 전체 항목 추가
                Cb_VideoGenre.Items.Add("전체");

                conn = new SqlConnection(connStr);

                conn.Open();

                // 중복 없는 장르 조회
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Genre FROM VIDEO", conn);

                SqlDataReader dr = cmd.ExecuteReader();

                // ComboBox에 장르 추가
                while (dr.Read())
                {
                    Cb_VideoGenre.Items.Add( dr["Genre"].ToString() ?? "");
                }

                dr.Close();

                conn.Close();

                // 기본값 설정
                Cb_VideoGenre.SelectedIndex = 0;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // DataReader 데이터를 Excel 파일로 저장하는 메서드
        private void SaveExcel(SqlDataReader dr, string fileName)
        {
            // 저장 위치 선택 창 생성
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "Excel 파일 (*.xlsx)|*.xlsx";

            save.FileName =fileName;

            // 저장 취소 시 종료
            if (save.ShowDialog()!= DialogResult.OK)
            {
                return;
            }

            // Excel 파일 생성
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("목록");

                // 헤더 저장
                for (int i = 0;i < dr.FieldCount; i++)
                {
                    worksheet.Cell(1,i + 1).Value = dr.GetName(i);
                }

                // 데이터 저장
                int row = 2;

                while (dr.Read())
                {
                    for (int col = 0; col < dr.FieldCount; col++)
                    {
                        worksheet.Cell(row, col + 1).Value = dr[col].ToString();
                    }
                    row++;
                }
                // 열 너비 자동 조절
                worksheet.Columns().AdjustToContents();
                // Excel 파일 저장
                workbook.SaveAs(save.FileName);
            }
        }

        // 비디오 목록 Excel 저장 버튼 이벤트
        private void Btn_VideoList_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connStr);

                conn.Open();

                string sql;

                // 장르 선택에 따라 SQL문 생성
                if (Cb_VideoGenre.Text == "전체")
                {
                    sql = @"SELECT * FROM VIDEO ORDER BY VideoCode";
                }

                else
                {
                    sql = @"SELECT * FROM VIDEO WHERE Genre=@Genre ORDER BY VideoCode";
                }

                SqlCommand cmd = new SqlCommand(sql,conn);

                // 장르 조건 적용
                if (Cb_VideoGenre.Text!= "전체")
                {
                    cmd.Parameters.AddWithValue("@Genre",Cb_VideoGenre.Text);
                }

                SqlDataReader dr =
                cmd.ExecuteReader();

                // 비디오 목록 Excel 저장
                SaveExcel(dr,"비디오목록.xlsx");

                dr.Close();

                conn.Close();

                MessageBox.Show("저장 완료");
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message);
            }
        }

        // 대여 현황 Excel 저장 버튼 이벤트
        private void Btn_RentalStatus_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connStr);

                conn.Open();

                // 전체 대여 현황 조회
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM RENTAL ORDER BY RentalNo", conn);

                SqlDataReader dr = cmd.ExecuteReader();

                // 대여 현황 Excel 저장
                SaveExcel(dr,"대여현황.xlsx");

                dr.Close();

                conn.Close();

                MessageBox.Show("저장 완료");
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message);
            }
        }
    }
}

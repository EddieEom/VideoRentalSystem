using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Video_Program
{
    public partial class Video_Excel_Setting : Form
    {
        // 폼 수정 여부 확인 변수
        public bool IsModified = false;

        // DB 연결 문자열
        private readonly string connStr =
            @"Server=localhost;Database=VideoRentalDB;Trusted_Connection=True;TrustServerCertificate=True";


        // 엑셀 출력 폼 생성자
        public Video_Excel_Setting()
        {
            InitializeComponent();
        }


        // ============================================
        // 폼 로드 시 장르 목록 조회
        // ============================================

        private async void Video_Excel_Setting_Load(
            object sender,
            EventArgs e)
        {
            await LoadGenreAsync();
        }


        // ============================================
        // 비디오 장르 목록 조회
        // ============================================

        private async Task LoadGenreAsync()
        {
            try
            {
                // ComboBox 초기화
                Cb_VideoGenre.Items.Clear();

                // 전체 항목 추가
                Cb_VideoGenre.Items.Add("전체");

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                // 중복 없는 장르 조회
                using SqlCommand cmd =
                    new SqlCommand(
                        "SELECT DISTINCT Genre FROM VIDEO",
                        conn
                    );

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                // ComboBox에 장르 추가
                while (await dr.ReadAsync())
                {
                    Cb_VideoGenre.Items.Add(
                        dr["Genre"]
                        .ToString() ?? ""
                    );
                }

                // 기본값 설정
                Cb_VideoGenre.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }


        // ============================================
        // DataReader 데이터를 Excel 파일로 저장
        // ============================================

        private async Task<bool> SaveExcelAsync(
            SqlDataReader dr,
            string fileName)
        {
            using SaveFileDialog save =
                new SaveFileDialog();

            save.Filter =
                "Excel 파일 (*.xlsx)|*.xlsx";

            save.FileName =
                fileName;

            // 저장 취소
            if (save.ShowDialog()
                != DialogResult.OK)
            {
                return false;
            }


            // ========================================
            // DataReader 데이터를 먼저 메모리에 저장
            // ========================================

            List<string> headers =
                new List<string>();

            List<string[]> rows =
                new List<string[]>();


            // 헤더 저장
            for (int i = 0;
                i < dr.FieldCount;
                i++)
            {
                headers.Add(
                    dr.GetName(i));
            }


            // 데이터 비동기 읽기
            while (await dr.ReadAsync())
            {
                string[] row =
                    new string[dr.FieldCount];

                for (int col = 0;
                    col < dr.FieldCount;
                    col++)
                {
                    row[col] =
                        dr[col]?.ToString()
                        ?? "";
                }

                rows.Add(row);
            }


            string savePath =
                save.FileName;


            // ========================================
            // Excel 파일 생성
            // ClosedXML에는 비동기 SaveAs가 없으므로
            // Task.Run으로 UI 스레드와 분리
            // ========================================

            await Task.Run(() =>
            {
                using XLWorkbook workbook =
                    new XLWorkbook();

                var worksheet =
                    workbook.Worksheets.Add(
                        "목록"
                    );


                // 헤더 저장
                for (int i = 0;
                    i < headers.Count;
                    i++)
                {
                    worksheet
                        .Cell(1, i + 1)
                        .Value = headers[i];
                }


                // 데이터 저장
                for (int row = 0;
                    row < rows.Count;
                    row++)
                {
                    for (int col = 0;
                        col < rows[row].Length;
                        col++)
                    {
                        worksheet
                            .Cell(row + 2, col + 1)
                            .Value = rows[row][col];
                    }
                }


                // 열 너비 자동 조절
                worksheet
                    .Columns()
                    .AdjustToContents();


                // Excel 파일 저장
                workbook.SaveAs(
                    savePath
                );
            });


            return true;
        }


        // ============================================
        // 비디오 목록 Excel 저장
        // ============================================

        private async void Btn_VideoList_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();


                string sql;


                // 장르 선택에 따라 SQL 생성
                if (Cb_VideoGenre.Text == "전체")
                {
                    sql =
                        @"SELECT *
                          FROM VIDEO
                          ORDER BY VideoCode";
                }
                else
                {
                    sql =
                        @"SELECT *
                          FROM VIDEO
                          WHERE Genre = @Genre
                          ORDER BY VideoCode";
                }


                using SqlCommand cmd =
                    new SqlCommand(
                        sql,
                        conn
                    );


                // 장르 조건 적용
                if (Cb_VideoGenre.Text != "전체")
                {
                    cmd.Parameters.AddWithValue(
                        "@Genre",
                        Cb_VideoGenre.Text
                    );
                }


                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();


                // 비디오 목록 Excel 저장
                bool saved =
                    await SaveExcelAsync(
                        dr,
                        "비디오목록.xlsx"
                    );


                // 저장 취소한 경우
                if (!saved)
                {
                    return;
                }


                MessageBox.Show(
                    "저장 완료");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }


        // ============================================
        // 대여 현황 Excel 저장
        // ============================================

        private async void Btn_RentalStatus_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                // 전체 대여 현황 저장 프로시저
                using SqlCommand cmd =
                    new SqlCommand(
                        "Select_All_Rental",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                bool saved =
                    await SaveExcelAsync(
                        dr,
                        "대여현황.xlsx"
                    );

                if (!saved)
                {
                    return;
                }

                MessageBox.Show(
                    "저장 완료");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
    }
}
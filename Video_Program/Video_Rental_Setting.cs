using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Program
{
    public partial class Video_Rental_Setting : Form
    {
        // 폼 수정 여부 확인 변수
        public bool IsModified = false;

        // DB 연결 문자열
        private readonly string connStr =
            @"Server=localhost;Database=VideoRentalDB;Trusted_Connection=True;TrustServerCertificate=True";

        // 대여 환경설정 폼 생성자
        public Video_Rental_Setting()
        {
            InitializeComponent();
        }


        // ============================================
        // 환경설정 정보 조회
        // ============================================

        private async Task LoadConfigAsync()
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                // 환경설정 조회 저장 프로시저 실행
                using SqlCommand cmd =
                    new SqlCommand(
                        "Select_Config",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    string type =
                        dr["ProgramType"]
                        .ToString() ?? "";

                    // 신작 환경설정 출력
                    if (type == "신작")
                    {
                        Tb_New_ChangeTime.Text =
                            dr["ChangeDays"]
                            .ToString();

                        Tb_New_RentalDays.Text =
                            dr["RentalDays"]
                            .ToString();

                        Tb_New_RentalFee.Text =
                            dr["RentalFee"]
                            .ToString();

                        Tb_New_LateFee.Text =
                            dr["LateFee"]
                            .ToString();
                    }

                    // 구작 환경설정 출력
                    else if (type == "구작")
                    {
                        Tb_Old_RentalDays.Text =
                            dr["RentalDays"]
                            .ToString();

                        Tb_Old_RentalFee.Text =
                            dr["RentalFee"]
                            .ToString();

                        Tb_Old_LateFee.Text =
                            dr["LateFee"]
                            .ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }


        // ============================================
        // 폼 로드
        // ============================================

        private async void Video_Rental_Setting_Load(
            object sender,
            EventArgs e)
        {
            await LoadConfigAsync();
        }


        // ============================================
        // 환경설정 등록
        // ============================================

        private async Task InsertConfigAsync(
            SqlConnection conn,
            int id,
            string type,
            string? changeDay,
            string day,
            string fee,
            string late)
        {
            using SqlCommand cmd =
                new SqlCommand(
                    "Insert_Config",
                    conn
                );

            cmd.CommandType =
                CommandType.StoredProcedure;

            // 환경설정 번호
            cmd.Parameters.AddWithValue(
                "@ConfigID",
                id
            );

            // 신작 / 구작
            cmd.Parameters.AddWithValue(
                "@ProgramType",
                type
            );

            // 신작 전환기간
            if (string.IsNullOrWhiteSpace(
                changeDay))
            {
                cmd.Parameters.AddWithValue(
                    "@ChangeDays",
                    DBNull.Value
                );
            }
            else
            {
                cmd.Parameters.AddWithValue(
                    "@ChangeDays",
                    Convert.ToInt32(
                        changeDay)
                );
            }

            // 대여기간
            cmd.Parameters.AddWithValue(
                "@RentalDays",
                Convert.ToInt32(day)
            );

            // 대여료
            cmd.Parameters.AddWithValue(
                "@RentalFee",
                Convert.ToInt32(fee)
            );

            // 연체료
            cmd.Parameters.AddWithValue(
                "@LateFee",
                Convert.ToInt32(late)
            );

            // 환경설정 등록 실행
            await cmd.ExecuteNonQueryAsync();
        }


        // ============================================
        // 환경설정 등록 버튼
        // ============================================

        private async void Btn_Insert_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                // 신작 환경설정 등록
                await InsertConfigAsync(
                    conn,
                    1,
                    "신작",
                    Tb_New_ChangeTime.Text,
                    Tb_New_RentalDays.Text,
                    Tb_New_RentalFee.Text,
                    Tb_New_LateFee.Text
                );

                // 구작 환경설정 등록
                await InsertConfigAsync(
                    conn,
                    2,
                    "구작",
                    null,
                    Tb_Old_RentalDays.Text,
                    Tb_Old_RentalFee.Text,
                    Tb_Old_LateFee.Text
                );

                MessageBox.Show(
                    "등록 완료");

                // 화면 새로고침
                await LoadConfigAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }


        // ============================================
        // 환경설정 수정
        // ============================================

        private async Task UpdateConfigAsync(
            SqlConnection conn,
            int id,
            string type,
            string? changeDay,
            string day,
            string fee,
            string late)
        {
            using SqlCommand cmd =
                new SqlCommand(
                    "Update_Config",
                    conn
                );

            cmd.CommandType =
                CommandType.StoredProcedure;

            // 환경설정 번호
            cmd.Parameters.AddWithValue(
                "@ConfigID",
                id
            );

            // 신작 / 구작
            cmd.Parameters.AddWithValue(
                "@ProgramType",
                type
            );

            // 신작 전환기간
            if (string.IsNullOrWhiteSpace(
                changeDay))
            {
                cmd.Parameters.AddWithValue(
                    "@ChangeDays",
                    DBNull.Value
                );
            }
            else
            {
                cmd.Parameters.AddWithValue(
                    "@ChangeDays",
                    Convert.ToInt32(
                        changeDay)
                );
            }

            // 대여기간
            cmd.Parameters.AddWithValue(
                "@RentalDays",
                Convert.ToInt32(day)
            );

            // 대여료
            cmd.Parameters.AddWithValue(
                "@RentalFee",
                Convert.ToInt32(fee)
            );

            // 연체료
            cmd.Parameters.AddWithValue(
                "@LateFee",
                Convert.ToInt32(late)
            );

            // 환경설정 수정 실행
            await cmd.ExecuteNonQueryAsync();
        }


        // ============================================
        // 환경설정 수정 버튼
        // ============================================

        private async void Btn_Update_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                // 신작 환경설정 수정
                await UpdateConfigAsync(
                    conn,
                    1,
                    "신작",
                    Tb_New_ChangeTime.Text,
                    Tb_New_RentalDays.Text,
                    Tb_New_RentalFee.Text,
                    Tb_New_LateFee.Text
                );

                // 구작 환경설정 수정
                await UpdateConfigAsync(
                    conn,
                    2,
                    "구작",
                    null,
                    Tb_Old_RentalDays.Text,
                    Tb_Old_RentalFee.Text,
                    Tb_Old_LateFee.Text
                );

                MessageBox.Show(
                    "수정 완료");

                // 화면 새로고침
                await LoadConfigAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }


        // ============================================
        // 종료 버튼
        // ============================================

        private void Btn_Exit_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}
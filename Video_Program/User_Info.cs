using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Video_Program
{
    public partial class User_Info : Form
    {
        // 고객관리 폼 생성자
        public User_Info()
        {
            InitializeComponent();
        }

        // DB 연결 문자열
        private readonly string connStr =
            @"Server=localhost;Database=VideoRentalDB;Trusted_Connection=True;TrustServerCertificate=True";

        // 폼 수정 여부 확인 변수
        public bool IsModified = false;


        // ============================================
        // 고객 정보 저장
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

                using SqlCommand cmd =
                    new SqlCommand(
                        "Update_Customer",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@CustomerCode",
                    Convert.ToInt32(
                        Tb_CustomerCode.Text)
                );

                cmd.Parameters.AddWithValue(
                    "@CustomerName",
                    Tb_CustomerName.Text
                );

                cmd.Parameters.AddWithValue(
                    "@SSN",
                    Tb_SSN.Text
                );

                cmd.Parameters.AddWithValue(
                    "@CustomerType",
                    Tb_CustomerType.Text
                );

                cmd.Parameters.AddWithValue(
                    "@Gender",
                    Tb_Gender.Text
                );

                cmd.Parameters.AddWithValue(
                    "@Tel",
                    Tb_Tel.Text
                );

                cmd.Parameters.AddWithValue(
                    "@Mobile",
                    Tb_Mobile.Text
                );

                cmd.Parameters.AddWithValue(
                    "@Address",
                    Tb_Address.Text
                );

                cmd.Parameters.AddWithValue(
                    "@PostNumber",
                    Tb_PostNumber.Text
                );

                await cmd.ExecuteNonQueryAsync();

                MessageBox.Show(
                    "저장 완료");

                // 고객 목록 새로고침
                await LoadCustomerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "오류 발생: " + ex.Message);
            }
        }


        // ============================================
        // 고객 정보 추가
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

                using SqlCommand cmd =
                    new SqlCommand(
                        "Insert_Customer",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@CustomerCode",
                    Convert.ToInt32(
                        Tb_CustomerCode.Text)
                );

                cmd.Parameters.AddWithValue(
                    "@CustomerName",
                    Tb_CustomerName.Text
                );

                cmd.Parameters.AddWithValue(
                    "@SSN",
                    Tb_SSN.Text
                );

                cmd.Parameters.AddWithValue(
                    "@CustomerType",
                    Tb_CustomerType.Text
                );

                cmd.Parameters.AddWithValue(
                    "@Gender",
                    Tb_Gender.Text
                );

                cmd.Parameters.AddWithValue(
                    "@Tel",
                    Tb_Tel.Text
                );

                cmd.Parameters.AddWithValue(
                    "@Mobile",
                    Tb_Mobile.Text
                );

                cmd.Parameters.AddWithValue(
                    "@Address",
                    Tb_Address.Text
                );

                cmd.Parameters.AddWithValue(
                    "@PostNumber",
                    Tb_PostNumber.Text
                );

                await cmd.ExecuteNonQueryAsync();

                MessageBox.Show(
                    "추가 완료");

                // 고객 목록 새로고침
                await LoadCustomerAsync();

                // 고객 수 새로고침
                await LoadCustomerCountAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "오류 발생: " + ex.Message);
            }
        }


        // ============================================
        // 고객 정보 삭제
        // ============================================

        private async void Btn_Delete_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        "Delete_Customer",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.Add(
                    new SqlParameter(
                        "@CustomerCode",
                        SqlDbType.Int)
                    {
                        Value =
                            Convert.ToInt32(
                                Tb_CustomerCode.Text)
                    }
                );

                int rowEffect =
                    await cmd.ExecuteNonQueryAsync();

                MessageBox.Show(
                    "데이터 삭제 완료");

                // 고객 목록 새로고침
                await LoadCustomerAsync();

                // 고객 수 새로고침
                await LoadCustomerCountAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "오류 발생: " + ex.Message);
            }
        }


        // ============================================
        // 닫기 버튼
        // ============================================

        private void Btn_Close_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }


        // ============================================
        // 현재 등록된 고객 수 조회
        // ============================================

        private async Task LoadCustomerCountAsync()
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM CUSTOMER",
                        conn
                    );

                object? result =
                    await cmd.ExecuteScalarAsync();

                int count =
                    Convert.ToInt32(result);

                Lb_Customer_Count.Text =
                    count + "명";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "오류 발생: " + ex.Message);
            }
        }


        // ============================================
        // 고객관리 폼 로드
        // ============================================

        private async void User_Info_Load(
            object sender,
            EventArgs e)
        {
            // 현재 고객 수 조회
            await LoadCustomerCountAsync();

            // 고객 목록 조회
            await LoadCustomerAsync();
        }


        // ============================================
        // 고객 전체 목록 조회
        // ============================================

        private async Task LoadCustomerAsync()
        {
            try
            {
                // 기존 목록 초기화
                Gv_Customer.Rows.Clear();

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                // 전체 고객 조회 저장 프로시저
                using SqlCommand cmd =
                    new SqlCommand(
                        "Select_All_Customer",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                // 조회 결과 읽기
                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    Gv_Customer.Rows.Add(
                        dr["CustomerCode"],
                        dr["CustomerName"],
                        dr["SSN"],
                        dr["CustomerType"],
                        dr["Gender"],
                        dr["Tel"],
                        dr["Mobile"],
                        dr["PostNumber"],
                        dr["Address"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "오류 발생: " + ex.Message);
            }
        }


        // ============================================
        // DataGridView 선택 시 고객 정보 출력
        // ============================================

        private void Gv_Customer_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                Gv_Customer.Rows[e.RowIndex];

            Tb_CustomerCode.Text =
                row.Cells[0].Value?.ToString() ?? "";

            Tb_CustomerName.Text =
                row.Cells[1].Value?.ToString() ?? "";

            Tb_SSN.Text =
                row.Cells[2].Value?.ToString() ?? "";

            Tb_CustomerType.Text =
                row.Cells[3].Value?.ToString() ?? "";

            Tb_Gender.Text =
                row.Cells[4].Value?.ToString() ?? "";

            Tb_Tel.Text =
                row.Cells[5].Value?.ToString() ?? "";

            Tb_Mobile.Text =
                row.Cells[6].Value?.ToString() ?? "";

            Tb_PostNumber.Text =
                row.Cells[7].Value?.ToString() ?? "";

            Tb_Address.Text =
                row.Cells[8].Value?.ToString() ?? "";
        }
    }
}
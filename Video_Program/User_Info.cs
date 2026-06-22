using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
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

        // DB 연결
        private string connStr = @"Server=localhost;Database=VideoRentalDB;Trusted_Connection=True;TrustServerCertificate=True";
        private SqlConnection conn;

        // 폼 수정 여부 확인 변수
        public bool IsModified = false;



        // 고객 정보 저장 버튼
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connStr);

                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_Customer", conn);


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerCode",
                     Convert.ToInt32(Tb_CustomerCode.Text));

                cmd.Parameters.AddWithValue("@CustomerName",Tb_CustomerName.Text);

                cmd.Parameters.AddWithValue("@SSN",Tb_SSN.Text);

                cmd.Parameters.AddWithValue("@CustomerType",Tb_CustomerType.Text);

                cmd.Parameters.AddWithValue("@Gender",Tb_Gender.Text);

                cmd.Parameters.AddWithValue("@Tel",Tb_Tel.Text);

                cmd.Parameters.AddWithValue("@Mobile",Tb_Mobile.Text);

                cmd.Parameters.AddWithValue("@Address",Tb_Address.Text);

                cmd.Parameters.AddWithValue("@PostNumber",Tb_PostNumber.Text);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("저장 완료");

                LoadCustomer();
            }
            catch (Exception ex)
            {
                // 데이터베이스 연결 실패 등 에러 발생 시 처리
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }

        // 고객 정보 추가 버튼
        private void Btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connStr);

                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert_Customer", conn);


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerCode", Convert.ToInt32(Tb_CustomerCode.Text));

                cmd.Parameters.AddWithValue("@CustomerName", Tb_CustomerName.Text);

                cmd.Parameters.AddWithValue("@SSN", Tb_SSN.Text);

                cmd.Parameters.AddWithValue("@CustomerType", Tb_CustomerType.Text);

                cmd.Parameters.AddWithValue("@Gender", Tb_Gender.Text);

                cmd.Parameters.AddWithValue("@Tel", Tb_Tel.Text);

                cmd.Parameters.AddWithValue("@Mobile", Tb_Mobile.Text);

                cmd.Parameters.AddWithValue("@Address", Tb_Address.Text);

                cmd.Parameters.AddWithValue("@PostNumber", Tb_PostNumber.Text);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("추가 완료");

                LoadCustomer();

                LoadCustomerCount();

            }

            catch (Exception ex)
            {
                // 데이터베이스 연결 실패 등 에러 발생 시 처리
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }

        // 고객 정보 삭제 버튼
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connStr);

                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete_Customer", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(
                       new SqlParameter("@CustomerCode", SqlDbType.Int)
                       {
                           Value = Convert.ToInt32(Tb_CustomerCode.Text)
                       });

                int rowEffect = cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("데이터 삭제 완료");

                LoadCustomer();

                LoadCustomerCount();
            }

            catch (Exception ex)
            {
                // 데이터베이스 연결 실패 등 에러 발생 시 처리
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }

        // 닫기 버튼 클릭 시 현재 폼 종료
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 현재 등록된 고객 수 조회 메서드
        private void LoadCustomerCount()
        {
            try
            {
                conn = new SqlConnection(connStr);


                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM CUSTOMER", conn);

                int count = (int)cmd.ExecuteScalar();

                Lb_Customer_Count.Text = count + "명";

                conn.Close();
            }

            catch (Exception ex)
            {
                // 데이터베이스 연결 실패 등 에러 발생 시 처리
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }

        // 고객관리 폼 로드 시 고객 정보 조회
        private void User_Info_Load(object sender, EventArgs e)
        {
            // 현재 고객 수 호출
            LoadCustomerCount();

            LoadCustomer();
        }

        // 고객 전체 목록 조회 메서드
        private void LoadCustomer() {
            try {
                // 기존 목록 초기화
                Gv_Customer.Rows.Clear();
                
                // DB 연결
                conn = new SqlConnection(connStr);

                conn.Open();
                // 전체 고객 조회 저장 프로시저 실행
                SqlCommand cmd = new SqlCommand("Select_All_Customer", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                // 조회 결과 읽기
                SqlDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {
                    // DataGridView에 데이터 출력
                    Gv_Customer.Rows.Add(
                        Dr["CustomerCode"],
                        Dr["CustomerName"],
                        Dr["SSN"],
                        Dr["CustomerType"],
                        Dr["Gender"],
                        Dr["Tel"],
                        Dr["Mobile"],
                        Dr["PostNumber"],
                        Dr["Address"]
                    );
                }
                Dr.Close();

                conn.Close();
            }
            catch (Exception ex)
            {
                // 데이터베이스 연결 실패 등 에러 발생 시 처리
                MessageBox.Show("오류 발생: " + ex.Message);
            }

        }

        // DataGridView 선택 시 고객 정보 출력
        private void Gv_Customer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                Gv_Customer.Rows[e.RowIndex];

            // "" = value Null 체크
            Tb_CustomerCode.Text = row.Cells[0].Value?.ToString() ?? "";
            Tb_CustomerName.Text = row.Cells[1].Value?.ToString() ?? "";
            Tb_SSN.Text = row.Cells[2].Value?.ToString() ?? "";
            Tb_CustomerType.Text = row.Cells[3].Value?.ToString() ?? "";
            Tb_Gender.Text = row.Cells[4].Value?.ToString() ?? "";
            Tb_Tel.Text = row.Cells[5].Value?.ToString() ?? "";
            Tb_Mobile.Text = row.Cells[6].Value?.ToString() ?? "";
            Tb_PostNumber.Text = row.Cells[7].Value?.ToString() ?? "";
            Tb_Address.Text = row.Cells[8].Value?.ToString() ?? "";
        }
    }
}


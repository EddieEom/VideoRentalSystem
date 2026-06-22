using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Video_Program
{
    public partial class Video_Rental_Setting : Form
    {

        // 폼 수정 여부 확인 변수
        public bool IsModified = false;

        // DB 연결
        private string connStr = @"Server=localhost;Database=VideoRentalDB;Trusted_Connection=True;TrustServerCertificate=True";
        private SqlConnection conn;

        // 대여 환경설정 폼 생성자
        public Video_Rental_Setting()
        {
            InitializeComponent();
        }

        // 환경설정 정보 조회 메서드
        private void LoadConfig()
        {
            try
            {
                conn = new SqlConnection(connStr);

                conn.Open();

                // 환경설정 조회 저장 프로시저 실행
                SqlCommand cmd = new SqlCommand("Select_Config",conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string type =
                        dr["ProgramType"].ToString() ?? "";

                    // 신작 환경설정 출력
                    if (type == "신작")
                    {
                        Tb_New_ChangeTime.Text = dr["ChangeDays"].ToString();

                        Tb_New_RentalDays.Text = dr["RentalDays"].ToString();

                        Tb_New_RentalFee.Text = dr["RentalFee"].ToString();

                        Tb_New_LateFee.Text = dr["LateFee"].ToString();
                    }

                    // 구작 환경설정 출력
                    else if (type == "구작")
                    {
                        Tb_Old_RentalDays.Text = dr["RentalDays"].ToString();

                        Tb_Old_RentalFee.Text = dr["RentalFee"].ToString();

                        Tb_Old_LateFee.Text = dr["LateFee"].ToString();
                    }
                }

                dr.Close();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 폼 로드 시 환경설정 조회
        private void Video_Rental_Setting_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }


        // 환경설정 등록 메서드
        private void InsertConfig(
        int id,
        string type,
        string? changeDay,
        string day,
        string fee,
        string late)

        {

            // 환경설정 등록 저장 프로시저 생성
            SqlCommand cmd = new SqlCommand("Insert_Config",conn);

            cmd.CommandType = CommandType.StoredProcedure;

            // 환경설정 번호 설정
            cmd.Parameters.AddWithValue("@ConfigID",id);

            // 신작 또는 구작 설정
            cmd.Parameters.AddWithValue("@ProgramType",type);

            // 신작 전환기간 설정
            if (string.IsNullOrWhiteSpace(changeDay))
            {
                cmd.Parameters.AddWithValue("@ChangeDays",DBNull.Value);
            }

            else
            {
                cmd.Parameters.AddWithValue("@ChangeDays",Convert.ToInt32(changeDay));
            }

            // 대여기간 설정
            cmd.Parameters.AddWithValue("@RentalDays",Convert.ToInt32(day));

            // 대여료 설정
            cmd.Parameters.AddWithValue("@RentalFee",Convert.ToInt32(fee));

            // 연체료 설정
            cmd.Parameters.AddWithValue("@LateFee",Convert.ToInt32(late));

            // 환경설정 등록 실행
            cmd.ExecuteNonQuery();
        }


        // 환경설정 등록 버튼 이벤트
        private void Btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connStr);

                conn.Open();

                // 신작 환경설정 등록
                InsertConfig(
                    1,
                    "신작",
                    Tb_New_ChangeTime.Text,
                    Tb_New_RentalDays.Text,
                    Tb_New_RentalFee.Text,
                    Tb_New_LateFee.Text
                );

                // 구작 환경설정 등록
                InsertConfig(
                    2,
                    "구작",
                    null,
                    Tb_Old_RentalDays.Text,
                    Tb_Old_RentalFee.Text,
                    Tb_Old_LateFee.Text
                );


                MessageBox.Show("등록 완료");

                // 화면 새로고침
                LoadConfig();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 환경설정 수정 메서드
        private void UpdateConfig(
        int id,
        string type,
        string? changeDay,
        string day,
        string fee,
        string late)
        {
            // 환경설정 수정 저장 프로시저 생성
            SqlCommand cmd = new SqlCommand("Update_Config",conn);

            cmd.CommandType = CommandType.StoredProcedure;

            // 환경설정 번호 설정
            cmd.Parameters.AddWithValue("@ConfigID",id);

            // 신작 또는 구작 설정
            cmd.Parameters.AddWithValue("@ProgramType",type);

            // 신작 전환기간 설정
            if (string.IsNullOrWhiteSpace(changeDay))
            {
                cmd.Parameters.AddWithValue("@ChangeDays",DBNull.Value);
            }

            else
            {
                cmd.Parameters.AddWithValue("@ChangeDays",
                Convert.ToInt32(changeDay));
            }

            // 대여기간 설정
            cmd.Parameters.AddWithValue(
            "@RentalDays",
            Convert.ToInt32(day));

            // 대여료 설정
            cmd.Parameters.AddWithValue(
            "@RentalFee",
            Convert.ToInt32(fee));

            // 연체료 설정
            cmd.Parameters.AddWithValue(
            "@LateFee",
            Convert.ToInt32(late));

            // 환경설정 수정 실행
            cmd.ExecuteNonQuery();
        }

        // 환경설정 수정 버튼 이벤트
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                conn =
                new SqlConnection(connStr);

                conn.Open();

                // 신작 환경설정 수정
                UpdateConfig(
                    1,
                    "신작",
                    Tb_New_ChangeTime.Text,
                    Tb_New_RentalDays.Text,
                    Tb_New_RentalFee.Text,
                    Tb_New_LateFee.Text
                );

                // 구작 환경설정 수정
                UpdateConfig(
                    2,
                    "구작",
                    null,
                    Tb_Old_RentalDays.Text,
                    Tb_Old_RentalFee.Text,
                    Tb_Old_LateFee.Text
                );

                MessageBox.Show("수정 완료");

                // 화면 새로고침
                LoadConfig();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 종료 버튼 클릭 시 현재 폼 닫기
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

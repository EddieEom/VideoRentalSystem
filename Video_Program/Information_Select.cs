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
    public partial class Information_Select : Form
    {
        // 폼 수정 여부 확인 변수
        public bool IsModified = false;

        // 폼 종료 시 수정 여부 확인 이벤트
        private void Information_Select_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsModified)
                return;
        }
        // 정보조회 폼 생성자
        public Information_Select()
        {
            InitializeComponent();
            this.FormClosing += Information_Select_FormClosing;
        }

        // DB 연결
        private string connStr = @"Server=localhost;Database=VideoRentalDB;Trusted_Connection=True;TrustServerCertificate=True";

        // SQL 연결 객체
        private SqlConnection conn;


        // DataGridView 초기화 메서드
        private void ClearGrid()
        {
            GV_Select.Columns.Clear();

            GV_Select.Rows.Clear();
        }

        // 종료 버튼 클릭 시 폼 닫기
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 비디오 대여 순위 조회 메서드
        private void LoadVideoRank()
        {
            try
            {
                // DataGridView 초기화
                ClearGrid();

                // 비디오 대여 순위 컬럼 생성
                GV_Select.Columns.Add("VideoCode", "비디오코드");

                GV_Select.Columns.Add("Title", "제목");

                GV_Select.Columns.Add("RentalCount", "대여횟수");

                // DB 연결
                conn = new SqlConnection(connStr);

                conn.Open();

                // 비디오 대여 순위 저장 프로시저 실행
                SqlCommand cmd = new SqlCommand("Select_VideoRank", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                // 조회 결과를 DataGridView에 출력
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    GV_Select.Rows.Add(

                    dr["VideoCode"],

                    dr["Title"],

                    dr["RentalCount"]);
                }

                dr.Close();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 비디오 대여 순위 라디오 버튼 선택 이벤트
        private void Rbt_RentalRank_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_RentalRank.Checked)
            {
                LoadVideoRank();
            }
        }


        // 고객 대여 순위 조회 메서드
        private void LoadCustomerRank()
        {
            try
            {
                // DataGridView 초기화
                ClearGrid();

                // 고객 대여 순위 컬럼 생성
                GV_Select.Columns.Add("CustomerCode", "고객코드");

                GV_Select.Columns.Add("CustomerName", "고객명");

                GV_Select.Columns.Add("RentalCount", "대여횟수");

                // DB 연결
                conn = new SqlConnection(connStr);

                conn.Open();

                // 고객 대여 순위 저장 프로시저 실행
                SqlCommand cmd = new SqlCommand("Select_CustomerRank", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                // 조회 결과를 DataGridView에 출력
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    GV_Select.Rows.Add(

                    dr["CustomerCode"],

                    dr["CustomerName"],

                    dr["RentalCount"]);
                }

                dr.Close();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 비디오 대여 순위 라디오 버튼 선택 이벤트
        private void Rbt_CustomerRank_CheckedChanged(
        object sender,
        EventArgs e)
        {
            if (Rbt_CustomerRank.Checked)
            {
                LoadCustomerRank();
            }
        }

        // 현재 대여 중인 비디오 조회 메서드
        private void LoadRentingVideo()
        {
            try
            {
                // DataGridView 초기화
                ClearGrid();

                // 대여 중인 비디오 컬럼 생성
                GV_Select.Columns.Add("VideoCode", "비디오코드");

                GV_Select.Columns.Add("Title", "제목");

                GV_Select.Columns.Add("CustomerName", "고객명");

                GV_Select.Columns.Add("RentalDate", "대여일");

                GV_Select.Columns.Add("DueDate", "반납예정일");

                // DB 연결
                conn = new SqlConnection(connStr);

                conn.Open();

                // 대여 중인 비디오 저장 프로시저 실행
                SqlCommand cmd = new SqlCommand("Select_RentingVideo", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                // 조회 결과를 DataGridView에 출력
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    GV_Select.Rows.Add(
                        dr["VideoCode"],
                        dr["Title"],
                        dr["CustomerName"],

                        Convert.ToDateTime(
                        dr["RentalDate"]).ToString("yyyy-MM-dd"),

                        Convert.ToDateTime(
                        dr["DueDate"]).ToString("yyyy-MM-dd")
                    );
                }

                dr.Close();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message);
            }
        }
        // 대여중인 비디오 라디오 버튼 선택 이벤트
        private void Rbt_RentingRank_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_RentingRank.Checked)
            {
                LoadRentingVideo();
            }
        }

        // 장르 조건으로 비디오 대여 순위 검색 메서드
        private void SearchVideoRank(string genre)
        {
            try
            {
                // DataGridView 초기화
                ClearGrid();


                // 비디오 대여 순위 컬럼 생성
                GV_Select.Columns.Add("VideoCode", "비디오코드");

                GV_Select.Columns.Add("Title", "제목");

                GV_Select.Columns.Add("RentalCount", "대여횟수");

                // DB 연결
                conn = new SqlConnection(connStr);

                conn.Open();

                // 장르 조건 검색 SQL 실행
                SqlCommand cmd = new SqlCommand(
                    @"SELECT
                    V.VideoCode,
                    V.Title, COUNT(*) 
                    AS RentalCount
                    FROM VIDEO V
                        INNER JOIN RENTAL R
                        ON V.VideoCode=
                        R.VideoCode
                        WHERE
                        (@Genre='' OR V.Genre 
                        LIKE '%'+ @Genre+'%')
                        GROUP BY
                        V.VideoCode,
                        V.Title
                        ORDER BY
                        RentalCount DESC"
                , conn);

                cmd.Parameters.AddWithValue("@Genre", genre);

                // 조회 결과를 DataGridView에 출력
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    GV_Select.Rows.Add(

                    dr["VideoCode"],

                    dr["Title"],

                    dr["RentalCount"]);
                }

                dr.Close();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message);
            }
        }

        // 고객 신분 조건으로 고객 대여 순위 검색 메서드
        private void SearchCustomerRank(string customerType)
        {
            try
            {
                // DataGridView 초기화
                ClearGrid();

                // 고객 대여 순위 컬럼 생성
                GV_Select.Columns.Add("CustomerCode", "고객코드");

                GV_Select.Columns.Add("CustomerName", "고객명");

                GV_Select.Columns.Add("RentalCount", "대여횟수");

                // DB 연결
                conn = new SqlConnection(connStr);

                conn.Open();

                // 고객 신분 조건 검색 SQL 실행
                SqlCommand cmd = new SqlCommand(

                @"SELECT
                C.CustomerCode,
                C.CustomerName,
                COUNT(*) AS RentalCount
                FROM CUSTOMER C
                    INNER JOIN RENTAL R
                    ON C.CustomerCode=
                    R.CustomerCode
                    WHERE
                    (@CustomerType=''
                    OR
                    C.CustomerType
                    LIKE '%'+
                    @CustomerType+'%')
                    GROUP BY
                    C.CustomerCode,
                    C.CustomerName
                    ORDER BY
                    RentalCount DESC"
                , conn);

                cmd.Parameters.AddWithValue("@CustomerType", customerType);

                // 조회 결과를 DataGridView에 출력
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    GV_Select.Rows.Add(

                    dr["CustomerCode"],

                    dr["CustomerName"],

                    dr["RentalCount"]);
                }

                dr.Close();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message);
            }
        }

        // 장르와 고객 신분 조건으로 대여중인 비디오 검색 메서드
        private void SearchRentingVideo(string genre, string customerType)
        {
            try
            {
                ClearGrid();

                GV_Select.Columns.Add("VideoCode", "비디오코드");

                GV_Select.Columns.Add("Title", "제목");

                GV_Select.Columns.Add("CustomerName", "고객명");

                GV_Select.Columns.Add("RentalDate", "대여일");

                GV_Select.Columns.Add("DueDate", "반납예정일");

                conn = new SqlConnection(connStr);

                conn.Open();

                SqlCommand cmd = new SqlCommand(

                @"SELECT
                V.VideoCode,
                V.Title,
                C.CustomerName,
                R.RentalDate,
                R.DueDate
                FROM RENTAL R
                    INNER JOIN VIDEO V
                    ON R.VideoCode=
                    V.VideoCode
                        INNER JOIN CUSTOMER C
                        ON R.CustomerCode=
                        C.CustomerCode
                        WHERE R.ReturnDate
                        IS NULL
                        AND (@Genre='' OR
                        V.Genre
                        LIKE '%'+@Genre+'%')
                        AND (@CustomerType=''
                        OR
                        C.CustomerType
                        LIKE '%'+
                        @CustomerType+'%')"

                , conn);

                cmd.Parameters.AddWithValue("@Genre", genre);

                cmd.Parameters.AddWithValue(
                "@CustomerType", customerType);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    GV_Select.Rows.Add(

                    dr["VideoCode"],

                    dr["Title"],

                    dr["CustomerName"],

                    Convert.ToDateTime(
                    dr["RentalDate"]).ToString("yyyy-MM-dd"),

                    Convert.ToDateTime(
                    dr["DueDate"]).ToString("yyyy-MM-dd")
                    );
                }

                dr.Close();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message);
            }
        }

        // 검색 버튼 클릭 시 선택한 조건으로 조회 수행
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            // 검색 조건 가져오기
            string genre = Tb_Genre.Text.Trim();

            string type = Tb_CustomerType.Text.Trim();

            // 비디오 대여 순위 검색
            if (Rbt_RentalRank.Checked)
            {
                SearchVideoRank(genre);
            }

            // 고객 대여 순위 검색
            else if (
            Rbt_CustomerRank.Checked)
            {
                SearchCustomerRank(type);
            }

            // 대여 중인 비디오 검색
            else if (
            Rbt_RentingRank.Checked)
            {
                SearchRentingVideo(
                genre,
                type);
            }

            // 조회 항목 미선택 시 안내 메시지 출력
            else
            {
                MessageBox.Show(
                "조회 항목을 선택하세요.");
            }
        }
    }
}

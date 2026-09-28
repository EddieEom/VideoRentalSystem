using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Program
{
    public partial class Information_Select : Form
    {
        // 폼 수정 여부 확인 변수
        public bool IsModified = false;

        // DB 연결 문자열
        private readonly string connStr =
            @"Server=localhost;Database=VideoRentalDB;Trusted_Connection=True;TrustServerCertificate=True";


        // 정보조회 폼 생성자
        public Information_Select()
        {
            InitializeComponent();

            this.FormClosing +=
                Information_Select_FormClosing;
        }


        // ============================================
        // 폼 종료 시 수정 여부 확인
        // ============================================

        private void Information_Select_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            if (!IsModified)
                return;
        }


        // ============================================
        // DataGridView 초기화
        // ============================================

        private void ClearGrid()
        {
            GV_Select.Columns.Clear();
            GV_Select.Rows.Clear();
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


        // ============================================
        // 비디오 대여 순위 조회
        // ============================================

        private async Task LoadVideoRankAsync()
        {
            try
            {
                ClearGrid();

                // 컬럼 생성
                GV_Select.Columns.Add(
                    "VideoCode",
                    "비디오코드");

                GV_Select.Columns.Add(
                    "Title",
                    "제목");

                GV_Select.Columns.Add(
                    "RentalCount",
                    "대여횟수");

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        "Select_VideoRank",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    GV_Select.Rows.Add(
                        dr["VideoCode"],
                        dr["Title"],
                        dr["RentalCount"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 비디오 대여 순위 라디오 버튼
        // ============================================

        private async void Rbt_RentalRank_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (Rbt_RentalRank.Checked)
            {
                await LoadVideoRankAsync();
            }
        }


        // ============================================
        // 고객 대여 순위 조회
        // ============================================

        private async Task LoadCustomerRankAsync()
        {
            try
            {
                ClearGrid();

                GV_Select.Columns.Add(
                    "CustomerCode",
                    "고객코드");

                GV_Select.Columns.Add(
                    "CustomerName",
                    "고객명");

                GV_Select.Columns.Add(
                    "RentalCount",
                    "대여횟수");

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        "Select_CustomerRank",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    GV_Select.Rows.Add(
                        dr["CustomerCode"],
                        dr["CustomerName"],
                        dr["RentalCount"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 고객 대여 순위 라디오 버튼
        // ============================================

        private async void Rbt_CustomerRank_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (Rbt_CustomerRank.Checked)
            {
                await LoadCustomerRankAsync();
            }
        }


        // ============================================
        // 현재 대여 중인 비디오 조회
        // ============================================

        private async Task LoadRentingVideoAsync()
        {
            try
            {
                ClearGrid();

                GV_Select.Columns.Add(
                    "VideoCode",
                    "비디오코드");

                GV_Select.Columns.Add(
                    "Title",
                    "제목");

                GV_Select.Columns.Add(
                    "CustomerName",
                    "고객명");

                GV_Select.Columns.Add(
                    "RentalDate",
                    "대여일");

                GV_Select.Columns.Add(
                    "DueDate",
                    "반납예정일");

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        "Select_RentingVideo",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    GV_Select.Rows.Add(
                        dr["VideoCode"],
                        dr["Title"],
                        dr["CustomerName"],

                        Convert.ToDateTime(
                            dr["RentalDate"])
                        .ToString("yyyy-MM-dd"),

                        Convert.ToDateTime(
                            dr["DueDate"])
                        .ToString("yyyy-MM-dd")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 대여 중인 비디오 라디오 버튼
        // ============================================

        private async void Rbt_RentingRank_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (Rbt_RentingRank.Checked)
            {
                await LoadRentingVideoAsync();
            }
        }


        // ============================================
        // 장르 조건으로 비디오 대여 순위 검색
        // ============================================

        private async Task SearchVideoRankAsync(
            string genre)
        {
            try
            {
                ClearGrid();

                GV_Select.Columns.Add(
                    "VideoCode",
                    "비디오코드");

                GV_Select.Columns.Add(
                    "Title",
                    "제목");

                GV_Select.Columns.Add(
                    "RentalCount",
                    "대여횟수");

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT
                            V.VideoCode,
                            V.Title,
                            COUNT(*) AS RentalCount
                          FROM VIDEO V
                          INNER JOIN RENTAL R
                            ON V.VideoCode = R.VideoCode
                          WHERE
                            (@Genre = ''
                             OR V.Genre LIKE '%' + @Genre + '%')
                          GROUP BY
                            V.VideoCode,
                            V.Title
                          ORDER BY
                            RentalCount DESC",
                        conn
                    );

                cmd.Parameters.AddWithValue(
                    "@Genre",
                    genre
                );

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    GV_Select.Rows.Add(
                        dr["VideoCode"],
                        dr["Title"],
                        dr["RentalCount"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 고객 신분 조건으로 고객 대여 순위 검색
        // ============================================

        private async Task SearchCustomerRankAsync(
            string customerType)
        {
            try
            {
                ClearGrid();

                GV_Select.Columns.Add(
                    "CustomerCode",
                    "고객코드");

                GV_Select.Columns.Add(
                    "CustomerName",
                    "고객명");

                GV_Select.Columns.Add(
                    "RentalCount",
                    "대여횟수");

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT
                            C.CustomerCode,
                            C.CustomerName,
                            COUNT(*) AS RentalCount
                          FROM CUSTOMER C
                          INNER JOIN RENTAL R
                            ON C.CustomerCode = R.CustomerCode
                          WHERE
                            (@CustomerType = ''
                             OR C.CustomerType
                             LIKE '%' + @CustomerType + '%')
                          GROUP BY
                            C.CustomerCode,
                            C.CustomerName
                          ORDER BY
                            RentalCount DESC",
                        conn
                    );

                cmd.Parameters.AddWithValue(
                    "@CustomerType",
                    customerType
                );

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    GV_Select.Rows.Add(
                        dr["CustomerCode"],
                        dr["CustomerName"],
                        dr["RentalCount"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 장르 + 고객 신분 조건 대여중 비디오 검색
        // ============================================

        private async Task SearchRentingVideoAsync(
            string genre,
            string customerType)
        {
            try
            {
                ClearGrid();

                GV_Select.Columns.Add(
                    "VideoCode",
                    "비디오코드");

                GV_Select.Columns.Add(
                    "Title",
                    "제목");

                GV_Select.Columns.Add(
                    "CustomerName",
                    "고객명");

                GV_Select.Columns.Add(
                    "RentalDate",
                    "대여일");

                GV_Select.Columns.Add(
                    "DueDate",
                    "반납예정일");

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT
                            V.VideoCode,
                            V.Title,
                            C.CustomerName,
                            R.RentalDate,
                            R.DueDate
                          FROM RENTAL R
                          INNER JOIN VIDEO V
                            ON R.VideoCode = V.VideoCode
                          INNER JOIN CUSTOMER C
                            ON R.CustomerCode = C.CustomerCode
                          WHERE
                            R.ReturnDate IS NULL
                            AND
                            (
                                @Genre = ''
                                OR V.Genre
                                LIKE '%' + @Genre + '%'
                            )
                            AND
                            (
                                @CustomerType = ''
                                OR C.CustomerType
                                LIKE '%' + @CustomerType + '%'
                            )",
                        conn
                    );

                cmd.Parameters.AddWithValue(
                    "@Genre",
                    genre
                );

                cmd.Parameters.AddWithValue(
                    "@CustomerType",
                    customerType
                );

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    GV_Select.Rows.Add(
                        dr["VideoCode"],
                        dr["Title"],
                        dr["CustomerName"],

                        Convert.ToDateTime(
                            dr["RentalDate"])
                        .ToString("yyyy-MM-dd"),

                        Convert.ToDateTime(
                            dr["DueDate"])
                        .ToString("yyyy-MM-dd")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 검색 버튼
        // ============================================

        private async void Btn_Search_Click(
            object sender,
            EventArgs e)
        {
            string genre =
                Tb_Genre.Text.Trim();

            string type =
                Tb_CustomerType.Text.Trim();

            // 비디오 대여 순위
            if (Rbt_RentalRank.Checked)
            {
                await SearchVideoRankAsync(
                    genre
                );
            }

            // 고객 대여 순위
            else if (Rbt_CustomerRank.Checked)
            {
                await SearchCustomerRankAsync(
                    type
                );
            }

            // 대여 중 비디오
            else if (Rbt_RentingRank.Checked)
            {
                await SearchRentingVideoAsync(
                    genre,
                    type
                );
            }

            else
            {
                MessageBox.Show(
                    "조회 항목을 선택하세요.");
            }
        }
    }
}
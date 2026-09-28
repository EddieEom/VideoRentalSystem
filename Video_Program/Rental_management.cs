using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Program
{
    public partial class Rental_management : Form
    {
        // 비디오 대여관리 폼 생성자
        public Rental_management()
        {
            InitializeComponent();
        }

        // DB 연결 문자열
        private readonly string connStr =
            @"Server=localhost;Database=VideoRentalDB;Trusted_Connection=True;TrustServerCertificate=True";

        // 폼 수정 여부 확인 변수
        public bool IsModified = false;


        // ============================================
        // 선택한 비디오가 현재 대여중인지 확인
        // ============================================

        private async Task<bool> IsRentalVideoAsync(int videoCode)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT COUNT(*)
                          FROM RENTAL
                          WHERE VideoCode = @VideoCode
                          AND ReturnDate IS NULL",
                        conn
                    );

                cmd.Parameters.AddWithValue(
                    "@VideoCode",
                    videoCode
                );

                object? result =
                    await cmd.ExecuteScalarAsync();

                int count =
                    Convert.ToInt32(result);

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }


        // ============================================
        // 고객 검색 버튼
        // ============================================

        private async void Btn_FindUser_Click(
            object sender,
            EventArgs e)
        {
            string keyword = "";

            if (!string.IsNullOrWhiteSpace(Tb_UserName.Text))
            {
                keyword =
                    Tb_UserName.Text;
            }
            else if (!string.IsNullOrWhiteSpace(Tb_UserCode.Text))
            {
                keyword =
                    Tb_UserCode.Text;
            }
            else if (!string.IsNullOrWhiteSpace(Tb_HP.Text))
            {
                keyword =
                    Tb_HP.Text;
            }
            else if (!string.IsNullOrWhiteSpace(Tb_Phone.Text))
            {
                keyword =
                    Tb_Phone.Text;
            }
            else
            {
                MessageBox.Show(
                    "검색어를 입력하세요.");

                return;
            }

            await SearchCustomerAsync(keyword);
        }


        // ============================================
        // 고객 검색
        // ============================================

        private async Task SearchCustomerAsync(
            string keyword)
        {
            try
            {
                Lb_CustomerSelect.Items.Clear();

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        "Search_Customer",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Keyword",
                    keyword
                );

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                int count = 0;

                while (await dr.ReadAsync())
                {
                    count++;

                    ListViewItem item =
                        new ListViewItem(
                            dr["CustomerCode"]
                            .ToString()
                        );

                    item.SubItems.Add(
                        dr["CustomerName"]
                        .ToString()
                    );

                    item.SubItems.Add(
                        dr["Mobile"]
                        .ToString()
                    );

                    Lb_CustomerSelect.Items.Add(item);
                }

                // 조회 결과 없음
                if (count == 0)
                {
                    MessageBox.Show(
                        "조회 결과가 없습니다.");
                }

                // 한 명이면 자동 선택
                else if (count == 1)
                {
                    int customerCode =
                        Convert.ToInt32(
                            Lb_CustomerSelect
                            .Items[0]
                            .Text
                        );

                    await LoadCustomerAsync(
                        customerCode
                    );

                    Lb_CustomerSelect
                        .Items
                        .Clear();
                }

                // 두 명 이상이면 고객 선택 탭 이동
                else
                {
                    User_control.SelectedTab =
                        User_Choice;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 선택한 고객의 상세 정보 조회
        // ============================================

        private async Task LoadCustomerAsync(
            int customerCode)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        "Select_Customer",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@CustomerCode",
                    customerCode
                );

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                if (await dr.ReadAsync())
                {
                    Tb_CustomerCode.Text =
                        dr["CustomerCode"]
                        .ToString();

                    Tb_CustomerName.Text =
                        dr["CustomerName"]
                        .ToString();

                    Tb_SSN.Text =
                        dr["SSN"]
                        .ToString();

                    Tb_CustomerType.Text =
                        dr["CustomerType"]
                        .ToString();

                    Tb_Tel.Text =
                        dr["Tel"]
                        .ToString();

                    Tb_Mobile.Text =
                        dr["Mobile"]
                        .ToString();

                    Tb_PostNumber.Text =
                        dr["PostNumber"]
                        .ToString();

                    Tb_Address.Text =
                        dr["Address"]
                        .ToString();
                }

                await LoadRentalListAsync(
                    customerCode
                );

                await LoadSummaryAsync(
                    customerCode
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 고객 선택 ListView 이벤트
        // ============================================

        private async void Lb_CustomerSelect_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (Lb_CustomerSelect
                .SelectedItems
                .Count == 0)
            {
                return;
            }

            string text =
                Lb_CustomerSelect
                .SelectedItems[0]
                .Text;

            int customerCode =
                Convert.ToInt32(text);

            await LoadCustomerAsync(
                customerCode
            );
        }


        // ============================================
        // 신작 → 구작 전환 기준일 조회
        // ============================================

        private async Task<int> GetChangeDaysAsync()
        {
            // 기본 전환 일수
            int changeDays = 180;

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT TOP 1
                          ChangeDays
                          FROM CONFIG
                          WHERE ProgramType = '신작'",
                        conn
                    );

                object? value =
                    await cmd.ExecuteScalarAsync();

                if (value != null &&
                    value != DBNull.Value)
                {
                    changeDays =
                        Convert.ToInt32(value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return changeDays;
        }


        // ============================================
        // 신작 / 구작 환경설정 조회
        // ============================================

        private async Task LoadRentalSettingAsync(
            string programType)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

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
                    if (dr["ProgramType"]
                        .ToString() == programType)
                    {
                        int rentalDays =
                            Convert.ToInt32(
                                dr["RentalDays"]);

                        int rentalFee =
                            Convert.ToInt32(
                                dr["RentalFee"]);

                        int lateFee =
                            Convert.ToInt32(
                                dr["LateFee"]);

                        // 대여료
                        Lb_Release_Money.Text =
                            rentalFee + "원";

                        // 연체료
                        Lb_Overdue_Money.Text =
                            lateFee + "원";

                        // 반납 예정일
                        Lb_ReturnDate.Text =
                            Dt_video_Rent.Value
                            .AddDays(rentalDays)
                            .ToString(
                                "yyyy-MM-dd");

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 비디오 코드 입력 후 정보 조회
        // ============================================

        private async void Tb_VideoCode_Leave(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                Tb_VideoCode.Text))
            {
                return;
            }

            try
            {
                // 신작 / 구작 기준 일수
                int changeDays =
                    await GetChangeDaysAsync();

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        "Select_Video",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@VideoCode",
                    Convert.ToInt32(
                        Tb_VideoCode.Text)
                );

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                if (await dr.ReadAsync())
                {
                    Tb_VideoTitle.Text =
                        dr["Title"]
                        .ToString();

                    DateTime releaseDate =
                        Convert.ToDateTime(
                            dr["ReleaseDate"]
                        );

                    // 출시일과 현재 날짜 차이
                    int diff =
                        (DateTime.Today -
                         releaseDate).Days;

                    string programType;

                    if (diff <= changeDays)
                    {
                        programType = "신작";
                    }
                    else
                    {
                        programType = "구작";
                    }

                    await LoadRentalSettingAsync(
                        programType
                    );
                }
                else
                {
                    MessageBox.Show(
                        "존재하지 않는 비디오입니다.");

                    Tb_VideoCode.Clear();
                    Tb_VideoTitle.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 다음 대여번호 자동 생성
        // ============================================

        private async Task<int> GetNextRentalNoAsync()
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT
                          ISNULL(MAX(RentalNo), 0) + 1
                          FROM RENTAL",
                        conn
                    );

                object? result =
                    await cmd.ExecuteScalarAsync();

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return 0;
            }
        }


        // ============================================
        // 현재 고객 대여 현황 통계
        // ============================================

        private async Task LoadSummaryAsync(
            int customerCode)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT
                          COUNT(*),
                          ISNULL(SUM(RentalFee), 0),
                          ISNULL(SUM(LateFee), 0)
                          FROM RENTAL
                          WHERE CustomerCode = @CustomerCode
                          AND ReturnDate IS NULL",
                        conn
                    );

                cmd.Parameters.AddWithValue(
                    "@CustomerCode",
                    customerCode
                );

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                if (await dr.ReadAsync())
                {
                    Lb_Every_Realse_Count.Text =
                        dr.GetInt32(0) + "개";

                    Lb_Every_Realse_Money.Text =
                        dr.GetInt32(1) + "원";

                    Lb_Every_Overdue_Money.Text =
                        dr.GetInt32(2) + "원";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 비디오 대여 등록
        // ============================================

        private async void Btn_VideoUpload_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                int videoCode =
                    Convert.ToInt32(
                        Tb_VideoCode.Text);

                // 중복 대여 여부 확인
                if (await IsRentalVideoAsync(
                    videoCode))
                {
                    MessageBox.Show(
                        "이미 대여중인 비디오입니다.");

                    return;
                }

                // 다음 대여번호 생성
                int rentalNo =
                    await GetNextRentalNoAsync();

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        "Insert_Rental",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                // 반납 예정일
                DateTime dueDate =
                    Convert.ToDateTime(
                        Lb_ReturnDate.Text
                    );

                // 대여료
                int rentalFee =
                    int.Parse(
                        Lb_Release_Money
                        .Text
                        .Replace("원", "")
                    );

                int customerCode =
                    Convert.ToInt32(
                        Tb_CustomerCode.Text
                    );

                cmd.Parameters.AddWithValue(
                    "@RentalNo",
                    rentalNo
                );

                cmd.Parameters.AddWithValue(
                    "@CustomerCode",
                    customerCode
                );

                cmd.Parameters.AddWithValue(
                    "@VideoCode",
                    videoCode
                );

                cmd.Parameters.AddWithValue(
                    "@RentalDate",
                    Dt_video_Rent.Value
                );

                cmd.Parameters.AddWithValue(
                    "@DueDate",
                    dueDate
                );

                cmd.Parameters.AddWithValue(
                    "@RentalFee",
                    rentalFee
                );

                await cmd.ExecuteNonQueryAsync();

                // 대여 목록 새로고침
                await LoadRentalListAsync(
                    customerCode
                );

                // 통계 새로고침
                await LoadSummaryAsync(
                    customerCode
                );

                MessageBox.Show(
                    "대여 완료");

                // 입력창 초기화
                Tb_VideoCode.Clear();

                Tb_VideoTitle.Clear();

                Lb_Release_Money.Text =
                    "0000원";

                Lb_Overdue_Money.Text =
                    "0000원";

                Lb_ReturnDate.Text =
                    "2000-01-01";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 현재 고객 대여 목록 조회
        // ============================================

        private async Task LoadRentalListAsync(
            int customerCode)
        {
            try
            {
                GV_VideoList.Rows.Clear();

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                string sql =
                    @"SELECT
                      R.RentalNo,
                      V.VideoCode,
                      V.Title,
                      R.RentalDate,
                      R.DueDate
                      FROM RENTAL R
                      INNER JOIN VIDEO V
                      ON R.VideoCode = V.VideoCode
                      WHERE R.CustomerCode = @CustomerCode
                      AND R.ReturnDate IS NULL
                      ORDER BY R.RentalDate";

                using SqlCommand cmd =
                    new SqlCommand(
                        sql,
                        conn
                    );

                cmd.Parameters.AddWithValue(
                    "@CustomerCode",
                    customerCode
                );

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    GV_VideoList.Rows.Add(
                        dr["RentalNo"],
                        dr["VideoCode"],
                        dr["Title"],
                        dr["RentalDate"],
                        dr["DueDate"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ============================================
        // 대여번호로 특정 대여정보 조회
        // ============================================

        private async Task<DateTime?> GetRentalDueDateAsync(
            int rentalNo)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        "Select_Rental",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@RentalNo",
                    rentalNo
                );

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                if (await dr.ReadAsync())
                {
                    return Convert.ToDateTime(
                        dr["DueDate"]
                    );
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return null;
            }
        }

        // ============================================
        // 연체료 계산
        // ============================================

        private int CalculateLateFee(
            DateTime dueDate)
        {
            int overdueDays =
                (DateTime.Today -
                 dueDate.Date).Days;

            if (overdueDays <= 0)
            {
                return 0;
            }

            int dailyLateFee =
                int.Parse(
                    Lb_Overdue_Money.Text
                    .Replace("원", "")
                );

            return overdueDays *
                   dailyLateFee;
        }


        // ============================================
        // 비디오 반납
        // ============================================

        private async void Btn_VideoRetrieve_Click(
            object sender,
            EventArgs e)
        {
            if (GV_VideoList
                .SelectedRows
                .Count == 0)
            {
                MessageBox.Show(
                    "비디오를 선택하세요.");

                return;
            }

            try
            {
                // 선택한 대여번호
                int rentalNo =
                    Convert.ToInt32(
                        GV_VideoList
                        .SelectedRows[0]
                        .Cells[0]
                        .Value
                    );

                // Select_Rental 저장 프로시저 사용
                DateTime? dueDate =
                    await GetRentalDueDateAsync(
                        rentalNo
                    );

                if (dueDate == null)
                {
                    MessageBox.Show(
                        "대여 정보를 찾을 수 없습니다.");

                    return;
                }

                // 연체료 계산
                int lateFee =
                    CalculateLateFee(
                        dueDate.Value
                    );

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        "Return_Rental",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@RentalNo",
                    rentalNo
                );

                cmd.Parameters.AddWithValue(
                    "@ReturnDate",
                    DateTime.Today
                );

                cmd.Parameters.AddWithValue(
                    "@LateFee",
                    lateFee
                );

                await cmd.ExecuteNonQueryAsync();

                MessageBox.Show(
                    "반납 완료");

                int customerCode =
                    Convert.ToInt32(
                        Tb_CustomerCode.Text
                    );

                await LoadRentalListAsync(
                    customerCode
                );

                await LoadSummaryAsync(
                    customerCode
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
    }
}
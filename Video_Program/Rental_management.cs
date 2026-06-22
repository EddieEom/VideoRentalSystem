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
    public partial class Rental_management : Form
    {
        // 비디오 대여관리 폼 생성자
        public Rental_management()
        {
            InitializeComponent();
        }

        // DB 연결
        private string connStr = @"Server=localhost;Database=VideoRentalDB;Trusted_Connection=True;TrustServerCertificate=True";
        private SqlConnection conn;

        // 폼 수정 여부 확인 변수
        public bool IsModified = false;

        // 선택한 비디오가 현재 대여중인지 확인하는 메서드
        private bool IsRentalVideo(int videoCode)
        {
            bool result = false;

            try
            {
                conn = new SqlConnection(connStr);

                conn.Open();

                SqlCommand cmd =
                new SqlCommand(
                    @"SELECT COUNT(*)
                    FROM RENTAL
                    WHERE VideoCode=
                    @VideoCode
                    AND ReturnDate
                    IS NULL"
                , conn);

                cmd.Parameters.AddWithValue("@VideoCode", videoCode);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                result = count > 0;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }


        // 고객 검색 버튼 이벤트
        // 고객명, 고객코드, 전화번호, 휴대폰으로 고객 검색하는 버튼 이벤트
        private void Btn_FindUser_Click(object sender, EventArgs e)
        {
            string keyword = "";

            if (!string.IsNullOrWhiteSpace(Tb_UserName.Text))
            {
                keyword = Tb_UserName.Text;
            }

            else if (!string.IsNullOrWhiteSpace(Tb_UserCode.Text))
            {
                keyword = Tb_UserCode.Text;
            }

            else if (!string.IsNullOrWhiteSpace(Tb_HP.Text))
            {
                keyword = Tb_HP.Text;
            }

            else if (!string.IsNullOrWhiteSpace(Tb_Phone.Text))
            {
                keyword = Tb_Phone.Text;
            }

            else
            {
                MessageBox.Show("검색어를 입력하세요.");
                return;
            }

            SearchCustomer(keyword);
        }


        // 고객 검색 메서드
        // 검색 결과를 고객 선택 ListView에 출력
        private void SearchCustomer(string keyword)
        {
            try
            {
                Lb_CustomerSelect.Items.Clear();

                conn = new SqlConnection(connStr);

                conn.Open();

                SqlCommand cmd = new SqlCommand("Search_Customer",conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Keyword",keyword);

                SqlDataReader dr = cmd.ExecuteReader();

                int count = 0;

                while (dr.Read())
                {
                    count++;

                    ListViewItem item =
                        new ListViewItem(
                        dr["CustomerCode"].ToString());

                    item.SubItems.Add(
                        dr["CustomerName"].ToString());

                    item.SubItems.Add(
                        dr["Mobile"].ToString());

                    Lb_CustomerSelect.Items.Add(item);
                }

                dr.Close();

                conn.Close();

                // 조회 결과 없음
                if (count == 0)
                {
                    MessageBox.Show("조회 결과가 없습니다.");
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

                    LoadCustomer(customerCode);

                    Lb_CustomerSelect.Items.Clear();
                }

                // 두 명 이상이면 고객 선택 탭 이동
                else
                {
                    User_control.SelectedTab = User_Choice;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 선택한 고객의 상세 정보 조회 메서드
        private void LoadCustomer(int customerCode)
        {
            try
            {
                conn =
                new SqlConnection(connStr);

                conn.Open();

                SqlCommand cmd = new SqlCommand("Select_Customer",conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue( "@CustomerCode",customerCode);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Tb_CustomerCode.Text =
                        dr["CustomerCode"].ToString();

                    Tb_CustomerName.Text =
                        dr["CustomerName"].ToString();

                    Tb_SSN.Text =
                        dr["SSN"].ToString();

                    Tb_CustomerType.Text =
                        dr["CustomerType"].ToString();

                    Tb_Tel.Text =
                        dr["Tel"].ToString();

                    Tb_Mobile.Text =
                        dr["Mobile"].ToString();

                    Tb_PostNumber.Text =
                        dr["PostNumber"].ToString();

                    Tb_Address.Text =
                        dr["Address"].ToString();
                }

                dr.Close();

                conn.Close();
                LoadRentalList(customerCode);

                LoadSummary(customerCode);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 고객 선택 ListView 이벤트
        // 선택한 고객 정보를 고객정보 영역에 출력
        private void Lb_CustomerSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Lb_CustomerSelect.SelectedItems.Count == 0)
                return;

            string text =
                Lb_CustomerSelect.SelectedItems[0].Text;

            int customerCode =
                Convert.ToInt32(text);

            LoadCustomer(customerCode);
        }


        // 신작에서 구작으로 변경되는 기준 일수 조회 메서드
        private int GetChangeDays()
        {
            // 기본 전환 일수 설정
            int changeDays = 180;

            // DB 연결
            conn = new SqlConnection(connStr);

            conn.Open();


            // 신작 전환 일수 조회
            SqlCommand cmd = new SqlCommand(

                @"SELECT TOP 1
                ChangeDays
                FROM CONFIG
                WHERE ProgramType='신작'", conn);

            object value = cmd.ExecuteScalar();

            // 전환 일수 반환
            if (value != DBNull.Value)
            {
                changeDays = Convert.ToInt32(value);
            }

            conn.Close();

            return changeDays;
        }

        // 신작/구작 환경설정 조회 메서드
        // 대여기간, 대여료, 연체료를 화면에 출력
        private void LoadRentalSetting(string programType)
        {
            try
            {
                // DB 연결
                conn = new SqlConnection(connStr);

                conn.Open();

                SqlCommand cmd = new SqlCommand("Select_Config",conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["ProgramType"].ToString() == programType)
                    {
                        int rentalDays = Convert.ToInt32(dr["RentalDays"]);

                        int rentalFee = Convert.ToInt32(dr["RentalFee"]);

                        int lateFee = Convert.ToInt32(dr["LateFee"]);

                        // 대여료
                        Lb_Release_Money.Text = rentalFee + "원";

                        // 연체료
                        Lb_Overdue_Money.Text = lateFee + "원";

                        // 반납 예정일
                        Lb_ReturnDate.Text = Dt_video_Rent.Value
                        .AddDays(rentalDays)
                        .ToString("yyyy-MM-dd");

                        break;
                    }
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

        // 비디오 코드 입력 후 비디오 정보 조회 이벤트
        private void Tb_VideoCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Tb_VideoCode.Text))
                return;

            try
            {
                // 신작/구작 기준 일수 조회
                int changeDays = GetChangeDays();

                // DB 연결
                conn = new SqlConnection(connStr);

                conn.Open();


                SqlCommand cmd = new SqlCommand("Select_Video",conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VideoCode",Convert.ToInt32(Tb_VideoCode.Text));

                // 비디오 정보 조회
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Tb_VideoTitle.Text = dr["Title"].ToString();

                    DateTime releaseDate = Convert.ToDateTime(dr["ReleaseDate"]);

                    // 출시일과 현재 날짜 차이 계산
                    int diff = (DateTime.Today - releaseDate).Days;

                    string programType;

                    // 신작/구작 판별
                    if (diff <= changeDays)
                    {
                        programType = "신작";
                    }

                    else
                    {
                        programType = "구작";
                    }

                    // 환경설정 정보 출력
                    LoadRentalSetting(programType);
                }
                // 존재하지 않는 비디오 처리
                else
                {
                    MessageBox.Show("존재하지 않는 비디오입니다.");

                    Tb_VideoCode.Clear();

                    Tb_VideoTitle.Clear();
                }

                dr.Close();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // 다음 대여번호 자동 생성 메서드
        private int GetNextRentalNo()
        {
            // DB 연결
            conn = new SqlConnection(connStr);

            conn.Open();


            // 다음 대여번호 생성
            SqlCommand cmd = new SqlCommand(
                @"SELECT
                ISNULL(MAX(RentalNo),0)+1
                FROM RENTAL", conn);

            int rentalNo =
            (int)cmd.ExecuteScalar();

            conn.Close();

            // 대여번호 반환
            return rentalNo;
        }


        // 현재 고객의 대여 현황 통계 조회 메서드
        // 총 대여 개수, 총 대여료, 총 연체료 계산
        private void LoadSummary(int customerCode)
        {
            try
            {
                // DB 연결
                conn = new SqlConnection(connStr);

                conn.Open();

                // 현재 고객의 대여 통계 조회
                SqlCommand cmd =
                new SqlCommand(

                @"SELECT
                COUNT(*),
                ISNULL(
                SUM(RentalFee),0),
                ISNULL(
                SUM(LateFee),0)
                FROM RENTAL
                WHERE CustomerCode=
                @CustomerCode
                AND ReturnDate IS NULL"
                , conn);

                cmd.Parameters.AddWithValue("@CustomerCode", customerCode);

                SqlDataReader dr = cmd.ExecuteReader();

                
                if (dr.Read())
                {
                    // 총 대여 개수 출력
                    Lb_Every_Realse_Count.Text =
                    dr.GetInt32(0) + "개";

                    // 총 대여료 출력
                    Lb_Every_Realse_Money.Text =
                    dr.GetInt32(1) + "원";

                    // 총 연체료 출력
                    Lb_Every_Overdue_Money.Text =
                    dr.GetInt32(2) + "원";
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

        // 비디오 대여 등록 버튼 이벤트
        private void Btn_VideoUpload_Click(object sender,EventArgs e)
        {
            // 중복 대여 여부 확인
            if (IsRentalVideo(Convert.ToInt32(Tb_VideoCode.Text)))
            {
                MessageBox.Show("이미 대여중인 비디오입니다.");

                return;
            }

            try
            {

                // 다음 대여번호 생성
                int rentalNo = GetNextRentalNo();
                conn = new SqlConnection(connStr);

                conn.Open();

                SqlCommand cmd = new SqlCommand("Insert_Rental",conn);

                cmd.CommandType = CommandType.StoredProcedure;

                // 반납 예정일 가져오기
                DateTime dueDate = Convert.ToDateTime(Lb_ReturnDate.Text);

                // 대여료 가져오기
                int rentalFee =
                    int.Parse(
                    Lb_Release_Money
                    .Text
                    .Replace("원", ""));

                cmd.Parameters.AddWithValue("@RentalNo", rentalNo);

                cmd.Parameters.AddWithValue("@CustomerCode",
                Convert.ToInt32(
                Tb_CustomerCode.Text));

                cmd.Parameters.AddWithValue("@VideoCode",
                Convert.ToInt32(
                Tb_VideoCode.Text));

                cmd.Parameters.AddWithValue("@RentalDate",Dt_video_Rent.Value);

                cmd.Parameters.AddWithValue("@DueDate",dueDate);

                cmd.Parameters.AddWithValue("@RentalFee",rentalFee);

                cmd.ExecuteNonQuery();

                conn.Close();

                // 대여 목록 새로고침
                LoadRentalList(
                Convert.ToInt32(
                Tb_CustomerCode.Text));

                // 통계 정보 새로고침
                LoadSummary(

                Convert.ToInt32(
                Tb_CustomerCode.Text));

                MessageBox.Show("대여 완료");

                // 입력창 초기화
                Tb_VideoCode.Clear();

                Tb_VideoTitle.Clear();

                Lb_Release_Money.Text = "0000원";

                Lb_Overdue_Money.Text = "0000원";

                Lb_ReturnDate.Text = "2000-01-01";
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message);
            }
        }



        // 현재 고객의 대여중인 비디오 목록 조회 메서드
        private void LoadRentalList(int customerCode)
        {

            try
            {
                // 기존 목록 초기화
                GV_VideoList.Rows.Clear();

                // DB 연결
                conn =
                    new SqlConnection(connStr);

                conn.Open();


                // 현재 고객의 대여 목록 조회
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
                    WHERE R.CustomerCode=@CustomerCode
                    AND R.ReturnDate IS NULL
                    ORDER BY R.RentalDate";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@CustomerCode", customerCode);

                SqlDataReader dr = cmd.ExecuteReader();


                // 조회 결과를 DataGridView에 출력
                while (dr.Read())
                {
                    GV_VideoList.Rows.Add(

                        dr["RentalNo"],

                        dr["VideoCode"],

                        dr["Title"],

                        dr["RentalDate"],

                        dr["DueDate"]
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

        // 연체료 계산 메서드
        private int CalculateLateFee()
        {
            // 선택한 비디오 확인
            if (GV_VideoList.SelectedRows.Count == 0)
                return 0;

            // 반납 예정일 가져오기
            DateTime dueDate =
                Convert.ToDateTime(
                GV_VideoList
                .SelectedRows[0]
                .Cells[4]
                .Value);

            // 연체 일수 계산
            int overdueDays = (DateTime.Today - dueDate).Days;

            // 연체 여부 확인
            if (overdueDays <= 0)

                return 0;

            // 하루 연체료 가져오기
            int dailyLateFee = int.Parse(Lb_Overdue_Money.Text.Replace("원", ""));

            // 최종 연체료 계산
            return overdueDays * dailyLateFee;
        }

        // 비디오 반납 버튼 이벤트
        private void Btn_VideoRetrieve_Click(object sender, EventArgs e)
        {
            // 선택한 비디오 확인
            if (GV_VideoList.SelectedRows.Count == 0)
            {
                MessageBox.Show("비디오를 선택하세요.");

                return;
            }

            try
            {
                // 선택한 대여번호 가져오기
                int rentalNo =
                Convert.ToInt32(

                GV_VideoList
                .SelectedRows[0]
                .Cells[0]
                .Value);

                // 연체료 계산
                int lateFee = CalculateLateFee();

                // DB 연결
                conn = new SqlConnection(connStr);

                conn.Open();

                SqlCommand cmd = new SqlCommand("Return_Rental", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                // 비디오 반납 처리
                cmd.Parameters.AddWithValue("@RentalNo",rentalNo);

                cmd.Parameters.AddWithValue("@ReturnDate",DateTime.Today);

                cmd.Parameters.AddWithValue("@LateFee",lateFee);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("반납 완료");

                // 대여 목록 새로고침
                LoadRentalList(Convert.ToInt32(Tb_CustomerCode.Text));

                // 통계 정보 새로고침
                LoadSummary(Convert.ToInt32(Tb_CustomerCode.Text));
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
    }
}

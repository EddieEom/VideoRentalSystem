namespace Video_Program
{
    public partial class MainForm : Form
    {
        // 메인폼 생성자
        public MainForm()
        {
            InitializeComponent();
        }

        // 자식폼 중복 생성 방지 메서드
        private void OpenChild(Form childForm)
        {
            foreach (Form frm in this.MdiChildren)
            {
                // 이미 열려있는 동일한 폼이면 활성화
                if (frm.GetType() == childForm.GetType())
                {
                    frm.Activate();
                    return;
                }
            }

            // MDI 부모폼 지정 후 화면 출력
            childForm.MdiParent = this;
            childForm.Show();
        }

        // 메뉴 - 모든 자식폼 열기
        private void Tool_AllOpen_Click(object sender, EventArgs e)
        {
            OpenChild(new Video_Info());

            OpenChild(new Rental_management());

            OpenChild(new User_Info());

            OpenChild(new Information_Select());

            OpenChild(new Video_Rental_Setting());

            OpenChild(new Video_Excel_Setting());
        }

        // 메뉴 - 현재 활성화된 자식폼 닫기
        private void Tool_Close_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        // 메뉴 - 모든 자식폼 닫기
        private void Tool_AllClose_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        // Tool - 환경설정 폼 열기
        private void Tool_Setting_Click(object sender, EventArgs e)
        {
            OpenChild(new Video_Rental_Setting());

            OpenChild(new Video_Excel_Setting());
        }

        // 메뉴 - 비디오 대여관리 폼 열기
        private void Tool_RentalManage_Click(object sender, EventArgs e)
        {
            OpenChild(new Rental_management());
        }

        // Tool - 대여/반납 메뉴 클릭 시 대여관리 폼 열기
        private void Tool_leaseNreturn_Click(object sender, EventArgs e)
        {
            Tool_RentalManage_Click(sender, e);
        }

        // 메뉴 - 대여관리 폼 열기
        private void Tool_VideoInfo_Click(object sender, EventArgs e)
        {
            OpenChild(new Rental_management());
        }

        // Tool - 비디오 정보관리 폼 열기
        private void Tool_Video_Click(object sender, EventArgs e)
        {
            OpenChild(new Video_Info());
        }

        // 메뉴 - 고객관리 폼 열기
        private void Tool_Customer_Click(object sender, EventArgs e)
        {
            OpenChild(new User_Info());
        }

        // Tool - 고객 메뉴 클릭 시 고객관리 폼 열기
        private void Tool_User_Click(object sender, EventArgs e)
        {
            OpenChild(new User_Info());
        }

        // 메뉴 - 정보조회 폼 열기
        private void Tool_VideoSelect_Click(object sender, EventArgs e)
        {
            OpenChild(new Information_Select());
        }

        // Tool - 정보조회 메뉴 클릭 시 정보조회 폼 열기
        private void Tool_Info_Click(object sender, EventArgs e)
        {
            OpenChild(new Information_Select());
        }

        // 메뉴 - 대여 환경설정 폼 열기
        private void Tool_VideoRentalSetting_Click(object sender, EventArgs e)
        {
            OpenChild(new Video_Rental_Setting());
        }

        // 메뉴 - 프로그램 종료
        private void Tm_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 메뉴 - 엑셀 출력 폼 열기
        private void Tm_Excel_Info_Click(object sender, EventArgs e)
        {
            OpenChild(new Video_Excel_Setting());
        }
    }
}
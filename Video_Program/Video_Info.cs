using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Program
{
    public partial class Video_Info : Form
    {
        // DB 연결 문자열
        private readonly string connStr =
            @"Server=localhost;Database=VideoRentalDB;Trusted_Connection=True;TrustServerCertificate=True";

        // 폼 수정 여부 확인 변수
        public bool IsModified = false;

        // 비디오 정보관리 폼 생성자
        public Video_Info()
        {
            InitializeComponent();
        }


        // ============================================
        // 현재 등록된 비디오 개수 조회
        // ============================================

        private async Task LoadVideoCountAsync()
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                using SqlCommand cmd =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM VIDEO",
                        conn
                    );

                object? result =
                    await cmd.ExecuteScalarAsync();

                int count =
                    Convert.ToInt32(result);

                // 화면에 비디오 개수 출력
                Video_Count.Text =
                    count + "개";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 비디오 전체 목록 조회
        // ============================================

        private async Task LoadVideoAsync()
        {
            try
            {
                // 기존 목록 초기화
                GV_Video.Rows.Clear();

                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                // 전체 비디오 조회 저장 프로시저 실행
                using SqlCommand cmd =
                    new SqlCommand(
                        "Select_All_Video",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                using SqlDataReader dr =
                    await cmd.ExecuteReaderAsync();

                // DataGridView에 데이터 출력
                while (await dr.ReadAsync())
                {
                    GV_Video.Rows.Add(
                        dr["VideoCode"],
                        dr["Genre"],
                        dr["Title"],
                        dr["MainActor"],
                        dr["Director"],
                        dr["Distributor"],
                        dr["ReleaseDate"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 비디오 등록
        // ============================================

        private async void Btn_Video_Insert_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                // 비디오 추가 저장 프로시저 실행
                using SqlCommand cmd =
                    new SqlCommand(
                        "Insert_Video",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@VideoCode",
                    Convert.ToInt32(
                        Tb_VideoCode.Text));

                cmd.Parameters.AddWithValue(
                    "@Title",
                    Tb_Title.Text);

                cmd.Parameters.AddWithValue(
                    "@Genre",
                    Tb_Genre.Text);

                cmd.Parameters.AddWithValue(
                    "@MainActor",
                    Tb_MainActor.Text);

                cmd.Parameters.AddWithValue(
                    "@Director",
                    Tb_Director.Text);

                cmd.Parameters.AddWithValue(
                    "@Distributor",
                    Tb_Distributor.Text);

                cmd.Parameters.AddWithValue(
                    "@ReleaseDate",
                    Dt_Video_Info.Value);

                await cmd.ExecuteNonQueryAsync();

                MessageBox.Show(
                    "추가 완료");

                // 화면 새로고침
                await LoadVideoAsync();

                // 비디오 개수 새로고침
                await LoadVideoCountAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 비디오 수정
        // ============================================

        private async void Btn_Video_Save_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                // 비디오 수정 저장 프로시저 실행
                using SqlCommand cmd =
                    new SqlCommand(
                        "Update_Video",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@VideoCode",
                    Convert.ToInt32(
                        Tb_VideoCode.Text));

                cmd.Parameters.AddWithValue(
                    "@Title",
                    Tb_Title.Text);

                cmd.Parameters.AddWithValue(
                    "@Genre",
                    Tb_Genre.Text);

                cmd.Parameters.AddWithValue(
                    "@MainActor",
                    Tb_MainActor.Text);

                cmd.Parameters.AddWithValue(
                    "@Director",
                    Tb_Director.Text);

                cmd.Parameters.AddWithValue(
                    "@Distributor",
                    Tb_Distributor.Text);

                cmd.Parameters.AddWithValue(
                    "@ReleaseDate",
                    Dt_Video_Info.Value);

                await cmd.ExecuteNonQueryAsync();

                MessageBox.Show(
                    "저장 완료");

                // 화면 새로고침
                await LoadVideoAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 비디오 삭제
        // ============================================

        private async void Btn_Video_Delete_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connStr);

                await conn.OpenAsync();

                // 비디오 삭제 저장 프로시저 실행
                using SqlCommand cmd =
                    new SqlCommand(
                        "Delete_Video",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@VideoCode",
                    Convert.ToInt32(
                        Tb_VideoCode.Text));

                await cmd.ExecuteNonQueryAsync();

                MessageBox.Show(
                    "삭제 완료");

                // 화면 새로고침
                await LoadVideoAsync();

                // 비디오 개수 새로고침
                await LoadVideoCountAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // ============================================
        // 선택한 비디오 정보를 입력창에 출력
        // ============================================

        private void GV_Video_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Tb_VideoCode.Text =
                GV_Video.Rows[e.RowIndex]
                .Cells[0]
                .Value?.ToString();

            Tb_Genre.Text =
                GV_Video.Rows[e.RowIndex]
                .Cells[1]
                .Value?.ToString();

            Tb_Title.Text =
                GV_Video.Rows[e.RowIndex]
                .Cells[2]
                .Value?.ToString();

            Tb_MainActor.Text =
                GV_Video.Rows[e.RowIndex]
                .Cells[3]
                .Value?.ToString();

            Tb_Director.Text =
                GV_Video.Rows[e.RowIndex]
                .Cells[4]
                .Value?.ToString();

            Tb_Distributor.Text =
                GV_Video.Rows[e.RowIndex]
                .Cells[5]
                .Value?.ToString();

            Dt_Video_Info.Value =
                Convert.ToDateTime(
                    GV_Video.Rows[e.RowIndex]
                    .Cells[6]
                    .Value
                );
        }


        // ============================================
        // 폼 로드
        // ============================================

        private async void Video_Info_Load(
            object sender,
            EventArgs e)
        {
            await LoadVideoAsync();

            await LoadVideoCountAsync();
        }


        // ============================================
        // 비디오 목록 CSV 저장
        // ============================================

        private async void Btn_VideoList_Save_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using SaveFileDialog save =
                    new SaveFileDialog();

                save.Filter =
                    "CSV 파일 (*.csv)|*.csv";

                save.FileName =
                    "비디오목록.csv";

                if (save.ShowDialog()
                    != DialogResult.OK)
                {
                    return;
                }

                using StreamWriter sw =
                    new StreamWriter(
                        save.FileName,
                        false,
                        Encoding.UTF8
                    );

                // 헤더 저장
                for (int i = 0;
                    i < GV_Video.Columns.Count;
                    i++)
                {
                    await sw.WriteAsync(
                        GV_Video.Columns[i]
                        .HeaderText);

                    if (i <
                        GV_Video.Columns.Count - 1)
                    {
                        await sw.WriteAsync(",");
                    }
                }

                await sw.WriteLineAsync();

                // 데이터 저장
                foreach (
                    DataGridViewRow row
                    in GV_Video.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    for (int i = 0;
                        i < GV_Video.Columns.Count;
                        i++)
                    {
                        await sw.WriteAsync(
                            row.Cells[i]
                            .Value?
                            .ToString());

                        if (i <
                            GV_Video.Columns.Count - 1)
                        {
                            await sw.WriteAsync(",");
                        }
                    }

                    await sw.WriteLineAsync();
                }

                MessageBox.Show(
                    "목록 저장 완료");
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

        private void Btn_Video_Exit_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}
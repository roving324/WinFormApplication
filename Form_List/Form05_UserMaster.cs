using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assambl;

namespace Form_List
{
    public partial class Form05_UserMaster : BaseChildForm
    {
        SqlConnection Connect;
        public Form05_UserMaster()
        {
            InitializeComponent();
        }

        private void Form05_UserMaster_Load(object sender, EventArgs e)
        {
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("USERID", typeof(string)); // 사용자ID
            dtGrid.Columns.Add("USERNAME", typeof(string)); // 사용자명
            dtGrid.Columns.Add("PW", typeof(string)); // 비밀번호
            dtGrid.Columns.Add("PW_FCOUNT", typeof(string)); // 실패횟수
            dtGrid.Columns.Add("CODENAME", typeof(string)); // 부서
            dtGrid.Columns.Add("MAKEDATE", typeof(string)); // 등록일시
            dtGrid.Columns.Add("MAKER", typeof(string)); // 등록자
            dtGrid.Columns.Add("EDITDATE", typeof(string)); // 수정일시
            dtGrid.Columns.Add("EDITOR", typeof(string)); // 수정자

            // 2. 셋팅된 컬럼을 그리드에 매핑.
            // DataSource : 데이터 베이스에서 가져온 테이블 형식의 데이터를 등록할 때 사용.
            dgvGrid.DataSource = dtGrid;

            // 3. 그리드 컬럼에 한글명칭으로 컬럼 Text 보여주기.
            dgvGrid.Columns["USERID"].HeaderText = "사용자ID";
            dgvGrid.Columns["USERNAME"].HeaderText = "사용자명";
            dgvGrid.Columns["PW"].HeaderText = "비밀번호";
            dgvGrid.Columns["PW_FCOUNT"].HeaderText = "실패횟수";
            dgvGrid.Columns["CODENAME"].HeaderText = "부서";
            dgvGrid.Columns["MAKEDATE"].HeaderText = "등록일시";
            dgvGrid.Columns["MAKER"].HeaderText = "등록자";
            dgvGrid.Columns["EDITDATE"].HeaderText = "수정일시";
            dgvGrid.Columns["EDITOR"].HeaderText = "수정자";

            /*
            // 4. 컬럼의 폭 지정.
            dgvGrid.Columns[0].Width = 100; // 품목코드
            dgvGrid.Columns[1].Width = 200; // 품목 명
            dgvGrid.Columns[3].Width = 300; // 품목 상세
            dgvGrid.Columns[6].Width = 250; // 등록일시
            dgvGrid.Columns[8].Width = 250; // 수정일시
            */

            // 5. 컬럼의 수정 여부 설정.
            dgvGrid.Columns["USERID"].ReadOnly = true;
            dgvGrid.Columns["MAKEDATE"].ReadOnly = true;
            dgvGrid.Columns["MAKER"].ReadOnly = true;
            dgvGrid.Columns["EDITDATE"].ReadOnly = true;
            dgvGrid.Columns["EDITOR"].ReadOnly = true;




            // 콤보박스에 품목유형 리스트 등록.

            Common.SetComboControl("DEPTCODE", cboCodeName); // 부서에 관련된 기준정보
        }


        public override void DoInquire()
        {
            // 조회 버튼 클릭 시 사용자 정보 조회
            string sUserId = txtUserID.Text;
            string sUserName = txtUserName.Text;
            string sDeptCode = Convert.ToString(cboCodeName.SelectedValue);

            // 데이터 베이스 오픈.
            DBHelper helper = new DBHelper();
            try
            {
                SqlDataAdapter Adapter = new SqlDataAdapter("BM_UsertMaster_S1",helper.sCon);

                // Adapter 에게 저장 프로시저 형식의 SQL 을 실행할 것을 등록함.
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 저장 프로시저가 받을 파라매터(인자) 값 설정
                Adapter.SelectCommand.Parameters.AddWithValue("@USERID"  , sUserId);
                Adapter.SelectCommand.Parameters.AddWithValue("@USERNAME", sUserName);
                Adapter.SelectCommand.Parameters.AddWithValue("@DEPTCODE", sDeptCode);

                // 기본적으로 모든 프로시져에 적용될 내용
                Adapter.SelectCommand.Parameters.AddWithValue("@LANG"   , "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("@RS_MSG" , "").Direction = ParameterDirection.Output;

                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                dgvGrid.DataSource = dtTemp;
            }
            catch(Exception ex)
            {

            }
            finally
            {
                helper.Close();
            }
        }
    }
}

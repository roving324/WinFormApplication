using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assambl;

namespace Form_List
{
    public partial class Form03_ItemMaster : Form
    {
        SqlConnection Connect;
        SqlTransaction sTran;
        string sItemCode;
        string sItemName;
        string sStartDate;
        string sEndDate;
        string sItemType;
        string sEndFlag = "Y";
        bool bFlag = true;

        public Form03_ItemMaster()
        {
            InitializeComponent();
        }

        private void Form03_ItemMaster_Load(object sender, EventArgs e)
        {
            // 아이템 마스터 화면이 오픈 될 때 처리되는 로직
            #region <1. 그리드 셋팅>
            // 1. 데이터 테이블 생성 (그리드에 표현될 컬럼을 셋팅).
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("ITEMCODE", typeof(string)); // 품목 코드
            dtGrid.Columns.Add("ITEMNAME", typeof(string)); // 품목 명
            dtGrid.Columns.Add("ITEMTYPE", typeof(string)); // 품목 유형
            dtGrid.Columns.Add("ITEMDESC", typeof(string)); // 품목 상세정보
            dtGrid.Columns.Add("ENDFLAG" , typeof(string)); // 단종 여부
            dtGrid.Columns.Add("PRODDATE", typeof(string)); // 출시 일자
            dtGrid.Columns.Add("MAKEDATE", typeof(string)); // 데이터 생성 일자
            dtGrid.Columns.Add("MAKER"   , typeof(string)); // 생성자
            dtGrid.Columns.Add("EDITDATE", typeof(string)); // 수정일시
            dtGrid.Columns.Add("EDITOR"  , typeof(string)); // 수정자

            // 2. 셋팅된 컬럼을 그리드에 매핑.
            // DataSource : 데이터 베이스에서 가져온 테이블 형식의 데이터를 등록할 때 사용.
            dgvGrid.DataSource = dtGrid;

            // 3. 그리드 컬럼에 한글명칭으로 컬럼 Text 보여주기.
            dgvGrid.Columns["ITEMCODE"].HeaderText = "품목코드";
            dgvGrid.Columns["ITEMNAME"].HeaderText = "품목명";
            dgvGrid.Columns["ITEMTYPE"].HeaderText = "품목유형";
            dgvGrid.Columns["ITEMDESC"].HeaderText = "품목정보";
            dgvGrid.Columns["ENDFLAG" ].HeaderText = "단종여부";
            dgvGrid.Columns["PRODDATE"].HeaderText = "출시일자";
            dgvGrid.Columns["MAKEDATE"].HeaderText = "등록일자";
            dgvGrid.Columns["MAKER"   ].HeaderText = "생성자";
            dgvGrid.Columns["EDITDATE"].HeaderText = "수정일시";
            dgvGrid.Columns["EDITOR"  ].HeaderText = "수정자";

            // 4. 컬럼의 폭 지정.
            dgvGrid.Columns[0].Width = 100; // 품목코드
            dgvGrid.Columns[1].Width = 200; // 품목 명
            dgvGrid.Columns[3].Width = 300; // 품목 상세
            dgvGrid.Columns[6].Width = 250; // 등록일시
            dgvGrid.Columns[8].Width = 250; // 수정일시

            // 5. 컬럼의 수정 여부 설정.
            dgvGrid.Columns["ITEMCODE"].ReadOnly = true;
            dgvGrid.Columns["MAKEDATE"].ReadOnly = true;
            dgvGrid.Columns["MAKER"   ].ReadOnly = true;
            dgvGrid.Columns["EDITDATE"].ReadOnly = true;
            dgvGrid.Columns["EDITOR"  ].ReadOnly = true;

            #endregion

            #region < 2. 품목 유형 콤보박스 셋팅 >
            try
            {
                // 데이터베이스에 공통기준정보(TB_Standard) 중 품목 유형(ITEMTYPE) 의 정보를
                // 받아 와서 콤보박스에 등록 하기.

                // 1. 데이터베이스 접속 클래스 설정.
                // Common.sConn : Assamble 에 등록 되어 있는 데이터베이스 접속 주소.
                Connect = new SqlConnection(Common.sConn);
                // 데이터 베이스 오픈.
                Connect.Open();
                // 2. 품목유형 데이터 리스트 조회 SQL
                string sSqlSelect = " SELECT ''                               AS CODE_ID   ";
                sSqlSelect       += "       ,'ALL'                            AS CODE_NAME ";
                sSqlSelect       += " UNION ALL                                            ";
                sSqlSelect       += " SELECT MINORCODE                        AS CODE_ID   ";
                sSqlSelect       += "       ,'[' + MINORCODE + ']' + CODENAME AS CODE_NAME ";
                sSqlSelect       += "   FROM TB_Standard                                   ";
                sSqlSelect       += "  WHERE MAJORCODE = 'ITEMTYPE'                        ";
                sSqlSelect       += "    AND MINORCODE<> '$';                              ";
                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                // 콤보박스에 품목유형 리스트 등록.
                cboItemType.DataSource    = dtTemp;
                cboItemType.ValueMember   = "CODE_ID";    // 로직 상 처리될 코드가 있는 컬럼.
                cboItemType.DisplayMember = "CODE_NAME"; // 사용자에게 보여줄 컬럼.

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
            #endregion
        }

        private void btnSearch_Click(object sender = null, EventArgs e = null)
        {
            // 조회 버튼 클릭 이벤트.
            SqlConnection Connect = new SqlConnection(Common.sConn);
            try
            {
                Connect.Open();

                if (bFlag)
                {
                    // 조회조건 받아올 변수 파라매터 선언 및 값 등록.
                    sItemCode = txtItemCode.Text;  // 품목 코드 입력 정보.
                    sItemName = txtItemName.Text;  // 품목 입력 정보.
                    sStartDate = dtpStart.Text;     // 출시 일자 시작 일자.
                    sEndDate = dtpEnd.Text;       // 출시 일자 끝 일자.
                    sItemType = Convert.ToString(cboItemType.SelectedValue); // Text : DisplayMember , SelectedValue : ValueMember
                    if (chkOnlyName.Checked) sItemCode = ""; // 품목코드 와는 관계없는 나머지 조회 조건으로 검색.
                    sEndFlag = "Y";
                    if (rdoProd.Checked) sEndFlag = "N"; // 생산이 선택되어 있을 때
                }
                bFlag = true;

                /*
                string sSqlSelect = " SELECT * FROM TB_ItemMaster WHERE ";
                sSqlSelect += $" ITEMCODE LIKE '%{sItemCode}%' AND ";
                sSqlSelect += $" ITEMNAME LIKE '%{sItemName}%' AND ";
                sSqlSelect += $" ITEMTYPE = '{sItemType}'  AND ";
                sSqlSelect += $" ENDFLAG  = '{sEndFlag}'   AND ";
                sSqlSelect += $" PRODDATE BETWEEN '{sStartDate}' and '{sEndDate}'; ";
                if (chkOnlyName.Checked) sSqlSelect = $" SELECT * FROM TB_ItemMaster WHERE ITEMNAME LIKE '%{sItemName}%'; ";
                SqlDataAdapter Adapter = new SqlDataAdapter(sSqlSelect, Connect);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);
                dgvGrid.DataSource = dtTemp;
                */

                // 품목 마스터 테이블에서 데이터를 조회할 SQL 구문 작성.
                string sSelectSql = string.Empty;
                sSelectSql += " SELECT ITEMCODE                                           ";
                sSelectSql += "       , ITEMNAME                                          ";
                sSelectSql += "       , ITEMTYPE                                          ";
                sSelectSql += "       , ITEMDESC                                          ";
                sSelectSql += "       , ENDFLAG                                           ";
                sSelectSql += "       , PRODDATE                                          ";
                sSelectSql += "       , MAKEDATE                                          ";
                sSelectSql += "       , MAKER                                             ";
                sSelectSql += "       , EDITDATE                                          ";
                sSelectSql += "       , EDITOR                                            ";
                sSelectSql += "   FROM TB_ItemMaster                                      ";
                sSelectSql += $"  WHERE ITEMCODE LIKE    '%{sItemCode}%'                  ";
                sSelectSql += $"    AND ITEMNAME LIKE    '%{sItemName}%'                  ";
                sSelectSql += $"    AND PRODDATE BETWEEN '{sStartDate}' AND '{sEndDate}'  ";
                sSelectSql += $"    AND ITEMTYPE LIKE    '%{sItemType}%'                  ";
                sSelectSql += $"    AND ENDFLAG  =       '{sEndFlag}'                     ";

                SqlDataAdapter Adapter = new SqlDataAdapter(sSelectSql,Connect);
                DataTable      dtTemp  = new DataTable();
                Adapter.Fill(dtTemp);
                
                dgvGrid.DataSource = dtTemp;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally 
            {
                Connect.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 품목 정보 등록을 위한 그리드 행 추가.
            // 1. 그리드의 컬럼 포멧이 들어있는 빈 행 데이터 타입이 필요. (DataRow : 행 데이터 타입.)
            // (DataTable)dgvGrid.DataSource : 데이터 테이블 형식으로 형변환 한다.
            //DataRow dr = ((DataTable)dgvGrid.DataSource).NewRow();

            // 2. 빈 깡통 행을 그리드에 추가.
            // ((DataTable)dgvGrid.DataSource).Rows.Add(dr);

            // 3. 품목 코드 입력 할 수 있도록 컬럼 수정 여부 풀기
            dgvGrid.Columns["ITEMCODE"].ReadOnly = false;

            DataTable dtTemp = new DataTable();
            dtTemp = ((DataTable)dgvGrid.DataSource);
            dtTemp.NewRow();
            ((DataTable)dgvGrid.DataSource).Rows.Add(dtTemp);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 품목 마스터 데이터 삭제.
            // 선택된 행에 있는 품목을 삭제.
            if (dgvGrid.Rows.Count == 0) return;
            //DialogResult dirResult = MessageBox.Show("선택한 품목을 삭제하시겠습니까?", "데이터 삭제", MessageBoxButtons.YesNo);
            //if (dirResult == DialogResult.No) return;
            if (MessageBox.Show("선택한 품목을 삭제하시겠습니까?", "데이터 삭제", MessageBoxButtons.YesNo) == DialogResult.No) return;

            // 데이터 베이스 접속 및 Delete 를 위한 Command 클래스 설정.

            // 1. 데이터 베이스 오픈
            SqlConnection sCon = new SqlConnection(Common.sConn);
            try
            {
                sCon.Open();

                // 2. 삭제 (delete) 명령어를 수행할 Command 객체
                SqlCommand cmd = new SqlCommand();

                // 3. 갱신 데이터 승인 권한 가지고 오기. Transation
               sTran = sCon.BeginTransaction();

                // 4. 커맨드에 트랜잭션 등록.
                cmd.Transaction = sTran;

                // 5. 커맨드에 접속경로 등록.
                cmd.Connection = sCon;

                // 6. DELETE SQL 구문 작성 및 Command 에 등록.

                // 선택한 행에 있는 ITEMCODE 값 추출 후 변수에 등록하기.
                string sItemCode = Convert.ToString(dgvGrid.CurrentRow.Cells["ITEMCODE"].Value);
                string sDeleteSql = string.Empty;
                sDeleteSql += " DELETE TB_ItemMaster       ";
                sDeleteSql += $"  WHERE ITEMCODE = '{sItemCode}' ";

                // 7. Command 실행.
                cmd.CommandText = sDeleteSql;
                cmd.ExecuteNonQuery();

                // 8. 정상 등록 시 COMMIT
                sTran.Commit();

                // 9. 정상 삭제 메세지 표현.
                MessageBox.Show("품목 정보를 삭제 하였습니다.");

                // 10. 재조회.
                bFlag = false;
                btnSearch_Click(); //btnSearch_Click(null,null);
            }
            catch (Exception ex)
            {
                if (sTran != null) sTran.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon.Close();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 선택된 행의 데이터를 저장하는 기능 구현.
            if (dgvGrid.Rows.Count == 0) return;

            // 선택 된 행에 있는 컬럼 별 데이터를 변수에 등록.
            string sItemCode = Convert.ToString(dgvGrid.CurrentRow.Cells["ITEMCODE"].Value); // 품목코드
            string sItemName = Convert.ToString(dgvGrid.CurrentRow.Cells["ITEMNAME"].Value); // 품목명
            string sItemType = Convert.ToString(dgvGrid.CurrentRow.Cells["ITEMTYPE"].Value); // 품목 타입
            string sItemDesc = Convert.ToString(dgvGrid.CurrentRow.Cells["ITEMDESC"].Value); // 품목상세
            string sEndFlag  = Convert.ToString(dgvGrid.CurrentRow.Cells["ENDflag"].Value);  // 품목상세
            string sProdDate = Convert.ToString(dgvGrid.CurrentRow.Cells["PRODDATE"].Value); // 품목상세

            // 필수 입력 정보 데이터 기입 여부 확인 (품목코드, 출시일자)
            string sMessage = string.Empty;
            if (sItemCode == "")      sMessage = "품목코드";
            else if (sProdDate == "") sMessage = "출시일자";
            
            if (sMessage != "")
            {
                MessageBox.Show(sMessage + "를 입력하지 않았습니다.");
                return;
            }
            
            // 선택된 행의 위치 찾기
            int iCuRowIndex = dgvGrid.CurrentRow.Index;
            
            // 중복되는 품목코드 찾기
            for(int i = 0; i < dgvGrid.Rows.Count - 1; i++)
            {
                if (iCuRowIndex == i) continue; // 자신의 품목코드 중복횟수 패스
                if (Convert.ToString(dgvGrid.Rows[i].Cells["ITEMCODE"].Value) == sItemCode)
                {
                    MessageBox.Show($"중복되는 품목코드를 입력하엿습니다. 코드 행 : {i+1}");
                    return;
                }
            }

            // 데이터베이스 오픈
            SqlConnection sCon = new SqlConnection(Common.sConn);
            sCon.Open();

            // 품목마스터 테이블에 이미 등록되어 있는 품목 코드 인지 확인.
            // 있다면 update, 없다면 insert
            string sSelectSQL = string.Empty;
            
            // 단종 상태의 다른 데이터에서의 중복되는 품목코드 찾기.
            if (sEndFlag == "Y") sEndFlag = "N";
            else sEndFlag = "Y";
            sSelectSQL = $" SELECT * FROM TB_ITEMMASTER WHERE ITEMCODE = '{sItemCode}' AND ENDFLAG = '{sEndFlag}'";
            SqlDataAdapter Adapter = new SqlDataAdapter(sSelectSQL, sCon);
            DataTable dtTemp = new DataTable();
            Adapter.Fill(dtTemp);

            if (dtTemp.Rows.Count != 0)
            {
                MessageBox.Show("중복되는 품목코드를 입력하엿습니다.");
                return;
            }

            // 품목 정보 갱신 등록 로직이 시작되는 곳.
            if (MessageBox.Show("선택한 품목정보를 등록 하시겠습니까?", "품목등록", MessageBoxButtons.YesNo) == DialogResult.No) return;

            if (sEndFlag == "Y") sEndFlag = "N";
            else sEndFlag = "Y";
            sSelectSQL = $" SELECT * FROM TB_ITEMMASTER WHERE ITEMCODE = '{sItemCode}'";
            SqlDataAdapter Adapter2 = new SqlDataAdapter(sSelectSQL, sCon);
            DataTable dtTemp2 = new DataTable();
            Adapter2.Fill(dtTemp2);

            // update, insert 실행

            SqlTransaction sTran = sCon.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = sTran;    // 1. 커맨드에 트랜잭션 연결
                cmd.Connection  = sCon;     // 2. 커맨드에 접속정보 연결

                // 단종 여부에 아무값도 입력하지 않았을 경우 기본 N 입력.
                if (sEndFlag == "") sEndFlag = "N";

                // cmd 에 update / insert SQL 등록
                string sUpInSQL = string.Empty;
                if(dtTemp2.Rows.Count == 0)
                {
                    // INSERT SQL
                    sUpInSQL = " INSERT INTO TB_ITEMMASTER (ITEMCODE, ITEMNAME, ITEMTYPE, ITEMDESC, " +
                               "                            ENDFLAG, PRODDATE, MAKEDATE, MAKER)     " +
                              $"                    VALUES ('{sItemCode}', '{sItemName}', '{sItemType}', '{sItemDesc}', " +
                              $"                            '{sEndFlag}', '{sProdDate}', GETDATE(), '{Common.sUserID}') ";
                }
                else
                {
                    // UPDATE SQL
                    sUpInSQL = " UPDATE TB_ITEMMASTER                 " +
                              $"    SET ITEMNAME = '{sItemName}'      " +
                              $"       ,ITEMTYPE = '{sItemType}'      " +
                              $"       ,ITEMDESC = '{sItemDesc}'      " +
                              $"       ,ENDFLAG  = '{sEndFlag}'       " +
                              $"       ,PRODDATE = '{sProdDate}'      " +
                              $"       ,MAKEDATE = GETDATE()          " +
                              $"       ,MAKER    = '{Common.sUserID}' " +
                              $"  WHERE ITEMCODE = '{sItemCode}'      ";
                }
                cmd.CommandText = sUpInSQL; // 3. 커맨드에 SQL 구문 등록.
                cmd.ExecuteNonQuery();      //    커맨드 실행.
                sTran.Commit();

                MessageBox.Show("정상적으로 등록을 완료 하였습니다.");

                // 재조회
                btnSearch_Click();
            }
            catch (Exception ex)
            {
                sTran.Rollback();
            }
            finally 
            {
                sCon.Close(); 
            }
            
        }
    }
}

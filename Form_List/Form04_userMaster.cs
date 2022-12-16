using Assambl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_List
{
    public partial class Form04_userMaster : Form
    {
        SqlConnection Connect;
        SqlTransaction sTran;
        bool bFlag = false;
        public Form04_userMaster()
        {
            InitializeComponent();
        }

        private void Form04_userMaster_Load(object sender, EventArgs e)
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
                string sSqlSelect = " SELECT ''                         AS CODENAME  ";
                sSqlSelect += "             ,'ALL'                      AS CODE_NAME ";
                sSqlSelect += "       UNION ALL                                      ";
                sSqlSelect += "       SELECT CODENAME                   AS CODENAME  ";
                sSqlSelect += "             ,CODENAME                   AS CODE_NAME ";
                sSqlSelect += "         FROM TB_Standard                             ";
                sSqlSelect += "        WHERE MAJORCODE = 'DEPTCODE'                  ";
                sSqlSelect += "          AND MINORCODE <> '$';                       ";
                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                // 콤보박스에 품목유형 리스트 등록.
                cboCodeName.DataSource    = dtTemp;
                cboCodeName.ValueMember   = "CODENAME";
                cboCodeName.DisplayMember = "CODE_NAME"; // 사용자에게 보여줄 컬럼.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
            
        } // 기본 창 설정

        private void btnSearch_Click(object sender = null, EventArgs e = null) // 조회
        {
            Connect = new SqlConnection(Common.sConn);
            try
            {
                Connect.Open();

                string sUserID = txtUserID.Text;  // 사용자ID 입력 정보.
                string sUserName = txtUserName.Text;  // 사용자명 입력 정보.
                string sCodeName = Convert.ToString(cboCodeName.SelectedValue);


                // 품목 마스터 테이블에서 데이터를 조회할 SQL 구문 작성.
                string sSelectSql = string.Empty;
                sSelectSql += " SELECT USERID                                       ";
                sSelectSql += "       ,USERNAME                                     ";
                sSelectSql += "       ,PW                                           ";
                sSelectSql += "       ,PW_FCOUNT                                    ";
                sSelectSql += "       ,CODENAME                                     ";
                sSelectSql += "       ,MAKEDATE                                     ";
                sSelectSql += "       ,MAKER                                        ";
                sSelectSql += "       ,EDITDATE                                     ";
                sSelectSql += "       ,EDITOR                                       ";
                sSelectSql += "   FROM TB_USER                                      ";
                sSelectSql += $" WHERE USERID   LIKE  '%{sUserID}%'                 ";
                sSelectSql += $"   AND USERNAME LIKE  '%{sUserName}%'               ";
                sSelectSql += $"   AND CODENAME LIKE  '%{sCodeName}%'               ";

                SqlDataAdapter Adapter = new SqlDataAdapter(sSelectSql, Connect);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                dgvGrid.DataSource = dtTemp;
                dgvGrid.Columns["USERID"].ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            dgvGrid.Columns["USERID"].ReadOnly = false;

            DataTable dtTemp = new DataTable();
            dtTemp = ((DataTable)dgvGrid.DataSource);
            dtTemp.NewRow();
            ((DataTable)dgvGrid.DataSource).Rows.Add(dtTemp);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGrid.Rows.Count == 0) return;
            if (MessageBox.Show("선택한 사용자 정보를 삭제하시겠습니까?", "데이터 삭제", MessageBoxButtons.YesNo) == DialogResult.No) return;

            Connect = new SqlConnection(Common.sConn);
            try
            {
                Connect.Open();

                // 2. 삭제 (delete) 명령어를 수행할 Command 객체
                SqlCommand cmd = new SqlCommand();

                // 3. 갱신 데이터 승인 권한 가지고 오기. Transation
                sTran = Connect.BeginTransaction();

                // 4. 커맨드에 트랜잭션 등록.
                cmd.Transaction = sTran;

                // 5. 커맨드에 접속경로 등록.
                cmd.Connection = Connect;

                // 6. DELETE SQL 구문 작성 및 Command 에 등록.

                // 선택한 행에 있는 ITEMCODE 값 추출 후 변수에 등록하기.
                string sUserID = Convert.ToString(dgvGrid.CurrentRow.Cells["USERID"].Value);
                string sDeleteSql = string.Empty;
                sDeleteSql += " DELETE TB_USER       ";
                sDeleteSql += $"  WHERE USERID = '{sUserID}' ";

                // 7. Command 실행.
                cmd.CommandText = sDeleteSql;
                cmd.ExecuteNonQuery();

                // 8. 정상 등록 시 COMMIT
                sTran.Commit();

                // 9. 정상 삭제 메세지 표현.
                MessageBox.Show("사용자 정보를 삭제 하였습니다.");

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
                Connect.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvGrid.Rows.Count == 0) return;
            if (MessageBox.Show("해당 정보를 저장하시겠습니까?", "정보 등록", MessageBoxButtons.YesNo) == DialogResult.No) return;
            // 선택 된 행에 있는 컬럼 별 데이터를 변수에 등록.
            string sUserID    = Convert.ToString(dgvGrid.CurrentRow.Cells["USERID"].Value); // 사용자ID
            string sUserName  = Convert.ToString(dgvGrid.CurrentRow.Cells["USERNAME"].Value); // 사용자명
            string sPW        = Convert.ToString(dgvGrid.CurrentRow.Cells["PW"].Value); // 비밀번호
            string sPW_Fcuont = Convert.ToString(dgvGrid.CurrentRow.Cells["PW_FCOUNT"].Value); // 비밀번호
            string sCodeName  = Convert.ToString(dgvGrid.CurrentRow.Cells["CODENAME"].Value); // 부서

            // 필수 입력 정보 데이터 기입 여부 확인 (품목코드, 출시일자)
            string sMessage = string.Empty;
            if (sUserID == "")        sMessage = "사용자ID";
            else if (sUserName == "") sMessage = "출시일자";
            else if (sPW == "")       sMessage = "비밀번호";

            if (sMessage != "")
            {
                MessageBox.Show(sMessage + "를 입력하지 않았습니다.");
                return;
            }

            // 선택된 행의 위치 찾기
            int iCuRowIndex = dgvGrid.CurrentRow.Index;

            // 중복되는 품목코드 찾기
            for (int i = 0; i < dgvGrid.Rows.Count - 1; i++)
            {
                if (iCuRowIndex == i) continue; // 자신의 품목코드 중복횟수 패스
                if (Convert.ToString(dgvGrid.Rows[i].Cells["USERID"].Value) == sUserID)
                {
                    MessageBox.Show($"중복되는 사용자ID를 입력하엿습니다. 코드 행 : {i + 1}");
                    return;
                }
            }

            // 데이터베이스 오픈
            SqlConnection sCon = new SqlConnection(Common.sConn);
            sCon.Open();

            // 품목마스터 테이블에 이미 등록되어 있는 품목 코드 인지 확인.
            // 있다면 update, 없다면 insert
            string sSelectSQL = string.Empty;
            sSelectSQL = $" SELECT * FROM TB_USER WHERE USERID = '{sUserID}'";
            SqlDataAdapter Adapter = new SqlDataAdapter(sSelectSQL, sCon);
            DataTable dtTemp = new DataTable();
            Adapter.Fill(dtTemp);

            // update, insert 실행

            SqlTransaction sTran = sCon.BeginTransaction();
            try
            {
                SqlCommand cmd  = new SqlCommand();
                cmd.Transaction = sTran;    // 1. 커맨드에 트랜잭션 연결
                cmd.Connection  = sCon;     // 2. 커맨드에 접속정보 연결


                // cmd 에 update / insert SQL 등록
                string sUpInSQL = string.Empty;
                if (dtTemp.Rows.Count == 0)
                {
                    // INSERT SQL
                    sUpInSQL = " INSERT INTO TB_USER (USERID, USERNAME, PW, CODENAME, " +
                               "                            MAKEDATE, MAKER)     " +
                              $"                    VALUES ('{sUserID}', '{sUserName}', '{sPW}', '{sCodeName}', " +
                              $"                            GETDATE(), '{Common.sUserID}') ";
                }
                else
                {
                    // UPDATE SQL
                    sUpInSQL = " UPDATE TB_USER                       " +
                              $"    SET USERNAME = '{sUserName}'      " +
                              $"       ,PW = '{sPW}'                  " +
                              $"       ,PW_FCOUNT = '{sPW_Fcuont}'    " +
                              $"       ,CODENAME  = '{sCodeName}'     " +
                              $"       ,EDITDATE = GETDATE()          " +
                              $"       ,EDITOR   = '{Common.sUserID}' " +
                              $"  WHERE USERID = '{sUserID}'          ";
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (dgvGrid.RowCount == 0) return;

            // 파일 탐색기 호출 (OpenFileDialog : 파일탐색기 클래스, Window 제공 API)
            OpenFileDialog dialog  = new OpenFileDialog();
            DialogResult dirResult = dialog.ShowDialog();
            if (dirResult != DialogResult.OK) return;

            // 사진을 선택 하였을 경우 처리되는 로직
            string sImageFilrPath = dialog.FileName; // 사진 파일이 저장되어 있는 풀더의 경로 와 사진파일의 정보.
            // 사진 파일의 경로를 찾아가 Byte[] 배열 형식으로 반환되어 이미지뷰어(picItemImage) 에 표현된다.
            picItemImage.Image = Bitmap.FromFile(sImageFilrPath);
            // 파일의 경로 및 정보를 tag에 저장
            picItemImage.Tag = sImageFilrPath;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            if (dgvGrid.RowCount == 0)      return;      // 품목 정보 미조회
            if (picItemImage.Image == null) return; // 저장 대상 이미지 미오픈

            DialogResult drResult = MessageBox.Show("현재 이미지를 품목에 등록하시겠습니까?", "이미지 저장", MessageBoxButtons.YesNo);
            if (drResult == DialogResult.No) return;

            Byte[] bImage = null; // 이미지 파일이 등록 될 Byte 배열.

            try
            {
                /*
                   --------------      BinaryReader    ---------------     FileStream     ---------------
                     APP (Byte)     <--------------->   RAM (Binary)    <-------------->    File (Byte)
                   --------------                      ---------------                    ---------------


                   Byte 바이트     : CPU가 아닌 가상머신(OS) 에서 이해 할 수 있는 코드의 이진 파일.
                   Binary 바이너리 : 컴퓨터(CPU) 가 인실 할 수 있는 0,1로 이루어진 이진코드.
                   
                */
                #region < 사진파일을 APP 으로 전달 >
                // 2. 파일 스트림을 통해 파일을 오픈하고 바이너리 형식을 변한
                // FileMode.Open   : 경로에 있는 사진 파일에 접근
                // FileAccess.Read : 읽기 전용으로 읽어오겠다.
                FileStream stream = new FileStream(Convert.ToString(picItemImage.Tag), FileMode.Open, FileAccess.Read);

                // 3. 스트림을 통해 읽어온 Binary 코드 Byte 코드 변환.
                BinaryReader reader = new BinaryReader(stream);

                // 4. 만들어진 Binary 코드의 이미지를 Byte 화 하여 APP의 데이터 자료형 구조에 담는다.
                bImage = reader.ReadBytes(Convert.ToInt32(stream.Length));

                // 5. 바이너리 리더 종료
                reader.Close();
                // 6. 파일 스트림 종료
                stream.Close();

                #endregion

                #region < 품목마스터에 품목 별 사진 저장 (UPDATE) >
                Connect = new SqlConnection(Common.sConn);

                // 데이터 배이스 오픈
                Connect.Open();

                // 커맨드 생성
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connect;

                string sUpdateSQL = " UPDATE TB_USER                " +
                                   $"    SET USERIMAGE = @USERIMAGE " +  // 품목 이미지 변수 생성.
                                   $"  WHERE USERID  = '{dgvGrid.CurrentRow.Cells["USERID"].Value}'";
                cmd.Parameters.AddWithValue("@USERIMAGE", bImage);

                // 커맨드에 SQL 구문 등록
                cmd.CommandText = sUpdateSQL;

                // 커맨드 실행
                cmd.ExecuteNonQuery();

                MessageBox.Show("이미지가 정상적으로 등록되었습니다.");
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("이미지등록에 실패하였습니다.\r\n" + ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }

        private void btnImageDelete_Click(object sender, EventArgs e)
        {
            if (dgvGrid.RowCount == 0) return;
            string sUserID = Convert.ToString(dgvGrid.CurrentRow.Cells["USERID"].Value);

            // 품복별 이미지를 삭제 (null 로 update)
            if (picItemImage.Image == null) return;

            if (MessageBox.Show("해당 이미지를 삭제하시겠습니까?", "이미지 삭제", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Connect = new SqlConnection(Common.sConn);
            try
            {
                Connect.Open();
                string sUpdateSQL = " UPDATE TB_USER              " +
                                    "    SET USERIMAGE = NULL     " +
                                   $"  WHERE USERID  = '{sUserID}'";

                SqlCommand cmd  = new SqlCommand();
                cmd.Connection  = Connect;
                cmd.CommandText = sUpdateSQL;
                cmd.ExecuteNonQuery();
                MessageBox.Show("이미지가 정상적으로 삭제되었습니다.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("이미지 삭제에 실패하였습니다.\r\n" + ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }

        private void dgvGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sUserID = Convert.ToString(dgvGrid.CurrentRow.Cells["USERID"].Value);
            if (sUserID == "사용자ID") return;
            if (sUserID == "")         return;
            picItemImage.Image = null;

            // 데이터베이스 오픈
            Connect = new SqlConnection(Common.sConn);
            try
            {
                Connect.Open();

                // database 에서 이미지 바이트 코드를 가져올 SQL 구문 작성.
                string sUpdateSQL = " SELECT USERIMAGE           " +
                                    "   FROM TB_USER             " +
                                   $"  WHERE USERID = '{sUserID}'";
                // Adapter 설정
                SqlDataAdapter Adapter = new SqlDataAdapter(sUpdateSQL, Connect);
                // DataTable 에서 결과 받기
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                // 품목 별 이미지 BYTE 코드가 있는지 체크
                //if (dtTemp.Rows.Count == 0) return;
                if (Convert.ToString(dtTemp.Rows[0]["USERIMAGE"]) == "") return;
                if (Convert.ToString(dtTemp.Rows[0]["USERIMAGE"]) == string.Empty) return;

                // byte[] 배열 형식으로 받아올 변수 생성.
                Byte[] bImage = null;

                // byte 배열 형식으로 byte 코드 형변환.
                bImage = (byte[])dtTemp.Rows[0]["USERIMAGE"];

                // byte[] 배열인 bImage 를 Bitmap(픽셀 이미지로 변경해주는 클래스) 로 변환
                picItemImage.Image = new Bitmap(new MemoryStream(bImage));
            }
            catch (Exception ex)
            {
                MessageBox.Show("이미지 로드에 실패하였습니다.\r\n" + ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }
    }
}

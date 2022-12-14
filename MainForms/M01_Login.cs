using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
// SQL Server 접속 클래스 라이브러리
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Assambl;

// 공통 로직 및 변수등을 관리하는 우리가 만든 클래스 라이브러리 (API)
using Assambl;

// WinFormApplication 강의의 목표.
// C# .NetFreamWork WinForm 의 기본 도구와 프로그래밍 문법을 사용하여
// 데이터 베이스와 유기적으로 연결되는
// 개발 솔루션의 프레임을 만들어 보고
// 시스템 개발 프레임 코어 소스의 구성 원리를 이해 및 기능을 습득한다.

/*---------------------------------------------------------------------------
 * NAME : M01_LogIn
 * DESC : 시스템 로그인
 * --------------------------------------------------------------------------
 * DATE   : 2022-12-08
 * AUTHER : 황준영
 * DESC   : 최초 프로그램 작성
 * -------------------------------------------------------------------------*/

namespace MainForms
{
    public partial class M01_Login : Form
    {
        #region < 필드 멤버 >
        int iCount = 0;
        SqlConnection Connect;
        //SqlTransaction sTc;
        //SqlCommand sCm;
        #endregion

        public M01_Login()
        {
            InitializeComponent();
        }

        #region < METHOD >
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void DoLogin()
        {
            #region < 실습 >
            /*
            try
            {
                // 데이터 베이스에 접속할 경로.
                string sConn = "Data Source = (local);Initial Catalog = AppDev;Integrated Security = SSPI;";

                // 데이터 베이스 접속.
                SqlConnection Connect = new SqlConnection(sConn);
                Connect.Open();

                // ID / PW 를 데이터 베이스에서 가져와서 비교 로직.
                string sUserId   = txtUserld.Text;
                string sPassWord = txtPassWord.Text;
               
                string sFindUserImfo = $"SELECT USERID FROM TB_USER WHERE USERID = '{sUserId}'";
                SqlDataAdapter adapter = new SqlDataAdapter(sFindUserImfo, Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("아이디가 잘못 되었습니다.");
                    return;
                }

                string sFindPWImfo = $"SELECT PW FROM TB_USER WHERE PW = '{sPassWord}'";
                SqlDataAdapter adapterPW = new SqlDataAdapter(sFindPWImfo, Connect);
                DataTable dtTempPW = new DataTable();
                adapterPW.Fill(dtTempPW);

                if (dtTempPW.Rows.Count == 0)
                {
                    MessageBox.Show("비밀번호가 잘못 되었습니다.");
                    return;
                }
                MessageBox.Show("로그인 되었습니다.");
                
                #region < ID 의 존재 여부에 따라 PW 의 일치 여부를 비교하는 경우 >
                string sFindUserImfo = $"SELECT USERID,PW FROM TB_USER WHERE USERID = '{sUserId}' OR PW = '{sPassWord}';";
                SqlDataAdapter adapter = new SqlDataAdapter(sFindUserImfo, Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("존재하지 않는 ID 입니다.");
                    return;
                }
                string s = dtTemp.Rows[0]["PW"].ToString();
                if (sPassWord != s)
                {
                    MessageBox.Show("비밀번호가 잘못 되었습니다.");
                    return;
                }
                MessageBox.Show("로그인 되었습니다.");
                #endregion

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                
            }
            */
            #endregion

            try
            {
                // 데이터 베이스에 접속 할 경로.
                string sConn = Common.sConn;
                Connect = new SqlConnection(sConn);
                // 데이터 베이스 접속. 
                Connect.Open();

                // ID / PW 를 데이터 베이스에서 가져와서 비교 로직. 
                string sUserId = txtUserld.Text;
                string sPassWord = txtPassWord.Text;

                #region < ID 와 PW 가 동시에 일치 하는지 를 비교하는 경우 >
                //ID 와 PW 를 정확하게 입력 하였는지 확인.
                ///string sFindUserImfo = $"SELECT USERID,PW FROM TB_USER WHERE USERID = '{sUserId}' AND PW = '{sPassWord}';";

                //// SqlDataAdapter : 데이터베이스 연결 후 SELECT SQL 구문 전달 및 결과를 
                ////                  응용프로그램에 받아오는 기능 클래스.
                //SqlDataAdapter adapter= new SqlDataAdapter(sFindUserImfo, Connect);

                //// DataTable : 프로그래밍 언어에서 데이터를 테이블 형태로 관리하는 클래스.
                //DataTable dtTemp = new DataTable();

                //adapter.Fill(dtTemp);


                //// ID 와 PW 를 정확히 입력하지 않은 경우. 
                //if (dtTemp.Rows.Count == 0)
                //{
                //    MessageBox.Show("로그인 ID 또는 PW 가 잘못 되었습니다.");
                //    return;
                //}
                //// 로그인을 성공하였을 경우 로직.
                #endregion


                #region < ID 의 존재 여부에 따라 PW 의 일치 여부를 비교하는 경우 >
                /*
                string sFindUserImfo = $"SELECT USERNAME,PW FROM TB_USER WHERE USERID = '{sUserId}';";
                SqlDataAdapter adapter = new SqlDataAdapter(sFindUserImfo, Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                // ID 를 잘못 입력한 경우 받아온 결과의 행이 없다.
                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("존재하지 않는 ID 입니다.");
                    return;
                }

                // 존재하는 ID를 입력하여 데이터 베이스에서 사용자 정보를 받아왔을 경우
                if (sPassWord != dtTemp.Rows[0]["PW"].ToString())
                {
                    MessageBox.Show("비밀번호가 잘못 입력하였습니다.");
                    return;
                }
                MessageBox.Show("로그인 되었습니다.");
                */
                #endregion

                #region < 비밀번호 3회 이상 실패시 프로그램 종료 >
                /*
                string sFindUserImfo = $"SELECT PW, USERNAME FROM TB_USER WHERE USERID = '{sUserId}'";
                SqlDataAdapter adapter = new SqlDataAdapter(sFindUserImfo, Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("존재하지 않는 ID 입니다.");
                    return;
                }

                // 존재하는 ID를 입력하여 데이터 베이스에서 사용자 정보를 받아왔을 경우
                if (sPassWord != dtTemp.Rows[0]["PW"].ToString())
                {
                    ++iCount;
                    if (iCount == 3)
                    {
                        MessageBox.Show("비밀번호를 3회 이상 잘못 입력하여 로그인 할 수 없으므로 관지자에게 문의바랍니다.");
                        // 종료
                        this.Close();
                    }
                    MessageBox.Show($"비밀번호가 잘못 입력하였습니다. 남은 횟수 : {3 - iCount}");
                    return;
                }
                */
                #endregion
                /*
                #region < 비밀번호 실패 횟수를 DB 에 저장하고 프로그램이 종료된 후 다시 실행시켜도 로그인이 되지 않도록 설정. >
                string sUserID = txtUserld.Text;
                string sUserPW = txtPassWord.Text;
                string sFindID = $"SELECT PW, USERNAME, PW_FCOUNT FROM TB_User WHERE USERID = '{sUserID}'";
                SqlDataAdapter Adapter = new SqlDataAdapter(sFindID, Connect);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("사용자 ID 가 없습니다.");
                    return;
                }

                if (Convert.ToInt32(dtTemp.Rows[0]["PW_FCOUNT"]) == 3)
                {
                    MessageBox.Show("비밀번호를 3회 이상 틀려 로그인할 수 없으므로 관리자에게 문의 바랍니다.");
                    return;
                }

                string sFindPW = $"UPDATE TB_User SET PW_FCOUNT = PW_FCOUNT + 1 WHERE USERID = '{sUserId}';";
                sTc = Connect.BeginTransaction();
                sCm = new SqlCommand();
                sCm.Transaction = sTc;
                sCm.Connection = Connect;
                sCm.CommandText = sFindPW;

                if (dtTemp.Rows[0]["PW"].ToString() != sUserPW)
                {
                    sCm.ExecuteNonQuery();
                    sTc.Commit();
                    MessageBox.Show($"비밀번호가 일치하지 않습니다. 남은 횟수 : {2 - Convert.ToInt32(dtTemp.Rows[0]["PW_FCOUNT"])}");
                    return;
                }
                */
                #endregion

                #region < 비밀번호 실패 횟수를 DB 에 저장하고 프로그램이 종료 된 후 다시 실행 시켜도 로그인이 되지 않도록 설정. > 

                // 로그인 할수 있는 id 와 비밀번호 입력했는지 확인.
                string sSelectSQL = " SELECT USERNAME                     " +
                                    "       ,PW                           " +
                                    "       ,ISNULL(PW_FCOUNT,0) AS PW_FCOUNT " +
                                    "   FROM TB_USER                      " +
                                   $"  WHERE USERID = '{sUserId}'           ";

                SqlDataAdapter Adapter = new SqlDataAdapter(sSelectSQL, Connect);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("ID 가 존재하지 않습니다.");
                    return;
                }
                else if (Convert.ToInt32(dtTemp.Rows[0]["PW_FCOUNT"]) == 3)
                {
                    MessageBox.Show("비밀번호 3회 오기입. 관리자와 문의하세요.");
                    this.Close();
                    return;
                }
                else if (sPassWord != dtTemp.Rows[0]["PW"].ToString())
                {
                    int iPwFcnt = Convert.ToInt32(dtTemp.Rows[0]["PW_FCOUNT"]);
                    iPwFcnt++;

                    // 트랜잭션 클래스
                    SqlTransaction Tran = Connect.BeginTransaction();
                    // 갱신 명령어 전달 클래스. 
                    SqlCommand Cmd = new SqlCommand();
                    try
                    {
                        // Command 에 접속 주소 등록. 
                        Cmd.Connection = Connect;
                        // Command 에 트랜잭션 등록.
                        Cmd.Transaction = Tran;
                        // Command 에 명령문 등록.
                        string sUpdateSQL = "  UPDATE TB_USER              " +
                                            $"     SET PW_FCOUNT = '{iPwFcnt}'  " +
                                            $"   WHERE USERID  = '{sUserId}'  ";
                        Cmd.CommandText = sUpdateSQL;

                        // CMD 로 UPDATE 문 데이터베이스에 실행.
                        Cmd.ExecuteNonQuery();

                        Tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        Tran.Rollback();
                        MessageBox.Show(ex.ToString());
                        return;
                    }
                    if (iPwFcnt == 3)
                    {
                        MessageBox.Show("비밀번호를 3회 틀렸으므로 프로그램을 종료합니다.");
                        this.Close();
                        return;
                    }
                    // ID 는 있는데 비밀번호가 틀린경우. 3
                    MessageBox.Show($"비밀번호 가 맞지 않습니다.  남은 횟수 : {3 - iPwFcnt}");
                    return;
                }

                #endregion

                // 성공 하였을 경우
                iCount = 0 ;
                MessageBox.Show(dtTemp.Rows[0]["USERNAME"].ToString() + "님 반갑습니다.");
                Common.sUserID = sUserId; // 접속한 사용자의 ID 를 저장.
                //M03_Main.bFlag = true;
                //Common.bLoginSF = true;
                this.Tag = true;
                this.Close();
            }
            catch (Exception ex)
            {
                //if(sTc != null) sTc.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //if (Connect != null) Connect.Close();
            }
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            // 엔터키를 눌렀을 경우 로그인 한다.
            if (e.KeyCode == Keys.Enter) DoLogin();
        }

        private void btnPWChang_Click(object sender, EventArgs e)
        {
            // 비밀번호 변경 창 호출.
            M02_PasswordChang m02 = new M02_PasswordChang();
            this.Visible = false; // 로그인 창 숨기기.
            //this.Hide();
            m02.ShowDialog(); // 비동기(Show)식 창을 동기(ShowDialog)화 시킨다.
            this.Visible = true; // 로그인 창 표시하기.
        }
    }
}
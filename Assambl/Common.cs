using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 클래스 라이브러리 = namespace = 프로젝트 = DLL 파일.
namespace Assambl
{
    // 클래스 라이브러리
    // 하나 이상의 APP 또는 프로젝트 에서 호출되는 변수,
    // 및 메서드(로직) 등을 작성하여
    // DLL 파일로 제공할 수 있게 만든 프로젝트 형식.
    // 단독으로 실행되지 않고 외부 프로그램에서 참조해서 호출하는 방식
    // 배포 및 재사용이 용이, 보안성 향상 의 장점이 있다.

    public class Common
    {
        public const string sConn = "Data Source = (local); Initial Catalog  = AppDev; Integrated Security = SSPI;";
        public static string sUserID = "";
        public static string sUserName = "";

        // 로그인 성공 여부 판단.
        // public static bool bLoginSF = false;


        public static void SetComboControl(string sMajorcode, ComboBox cboTemp)
        {
            SqlConnection Connect = new SqlConnection(sConn);
            DataTable dtTemp = new DataTable();
            try
            {
                // 데이터베이스에 공통기준정보(TB_Standard) 중 품목 유형(ITEMTYPE) 의 정보를
                // 받아 와서 콤보박스에 등록 하기.

                // 1. 데이터베이스 접속 클래스 설정.
                // Common.sConn : Assamble 에 등록 되어 있는 데이터베이스 접속 주소.
                // 데이터 베이스 오픈.
                Connect.Open();
                // 2. 품목유형 데이터 리스트 조회 SQL
                string sSqlSelect = " SELECT ''                         AS CODENAME  ";
                sSqlSelect += "             ,'ALL'                      AS CODE_NAME ";
                sSqlSelect += "       UNION ALL                                      ";
                sSqlSelect += "       SELECT CODENAME                   AS CODENAME  ";
                sSqlSelect += "             ,CODENAME                   AS CODE_NAME ";
                sSqlSelect += "         FROM TB_Standard                             ";
                sSqlSelect += $"        WHERE MAJORCODE = '{sMajorcode}'             ";
                sSqlSelect += "          AND MINORCODE <> '$';                       ";
                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, Connect);
                adapter.Fill(dtTemp);

                cboTemp.DataSource = dtTemp;
                cboTemp.ValueMember = "CODENAME";
                cboTemp.DisplayMember = "CODE_NAME"; // 사용자에게 보여줄 컬럼.
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
    }
}

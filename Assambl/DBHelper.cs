using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // SQL Server에 접속할 수 있게 도와주는 API

namespace Assambl
{
    /*-----------------------------------------------------------------
     * 데이터 베이스 접속 및 트랜잭션을 관리할 수 있게 도와주는
     * DBhelper Class
     * ----------------------------------------------------------------*/
    public class DBHelper
    {
        public SqlConnection sCon = new SqlConnection(Common.sConn);
        public DBHelper()
        {
            // 데이터 베이스 오픈.
            sCon.Open();
        }

        public void Close()
        {
            // 데이터 베이스 종료
            sCon.Close();
        }
    }
}

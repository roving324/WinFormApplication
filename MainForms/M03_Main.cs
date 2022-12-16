using Assambl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 스레드(Thread)를 사용하기 위한 라이브러리 참조.
using System.Threading;
// Form_List 클래스 라이브러리 참조.
using Form_List;
using System.Reflection;

namespace MainForms
{
    public partial class M03_Main : Form
    {
        // 메인화면 클래스 내부에서 시작 및 종료를 할 수 있도록 하기 위하여
        // 클래스 내부의 필드 멤버로 스레드 객체 그릇 명명.
        Thread thNowTime;

        public M03_Main()
        {
            // 로그인 창 실행.
            M01_Login M01 = new M01_Login();
            //M01.ShowDialog();
            M01.Tag = true;

            if (!(Convert.ToBoolean(M01.Tag)/*Common.bLoginSF*/))
            {
                // 로그인 실패 시. 메인창 종료

                // 현재 클래스 종료
                // 객체의 생성자 멤버에서 Close() 실행 시 정상 종료 할 수 없음.
                // this.Close();

                // 어플리케이션 클래스를 사용하여 프로세스의 강제 종료 처리.
                // 현시점에서 어플리케이션 강제 종료.
                Environment.Exit(0);
            }
            // 폼에 잇는 컨트롤 디자인을 초기화하여 구성함.
            InitializeComponent();

            // 타이머 도구 기능 중지.
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 문자의 서식 지정하여 현재 시간 표시.
            stsNowDateTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
        }


        private void M03_Main_Load(object sender, EventArgs e)
        {
            // 메인 화면 폼이 오픈되는 시점.

            /* 신규 스레드를 통한 시간 체크
               스레드 (Thread) : 프로세스 내부에서 생성되는 실제 작업의 주체를 추가 생성함으로서
                                 하나의 프로세스(Main) 외에 여러가지 일을 동시에 수행하는 기능.
                                 메인프로세스 와는 별개로 개별적인 리소스(컴퓨터메모리)를 가지고 구동
                                 비동기식, 병렬식
            */

            // 스레드를 이용한 현재시간 표시 기능 구현.
            // 1. 스레드가 실행 할 메서드를 포함한 클래스 객체. (ThreadStart)
            ThreadStart ThreadS = new ThreadStart(NowTimeSet);

            // 2. 스레드 클래스 생성 후 실행 메서드 포함되어있는 클래스 첨부
            thNowTime = new Thread(ThreadS);

            // 3. 스레드를 시작.
            thNowTime.Start();
        }

        private void NowTimeSet()
        {
            // 스레드가 실행 할 메서드.
            // 현재 시간 표현 로직 구현.
            //int iBreakTime = 0;
            //int iBreakTime = 0;
            // 무한루프를 통한 현재 시각 표현.
                while (true)
            {
                Thread.Sleep(1 * 100); // Timer 의 interval 과 같은 기능을 가진다. 1초
                stsNowDateTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                //iBreakTime++;
                //if (iBreakTime == 5) break;
            }
            //MessageBox.Show($"{iBreakTime}초가 되어 스레드를 종료합니다.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // 시스템 종료 버튼 클릭
            // 종료 버튼을 눌러 프로그램을 종료할 때 스레드를 정상완료 하지 않으면
            // 응용 프로그램이 완벽히 종료되지 않는다.
            // Environment.Exit(0);

            // 종료 이벤트를 통해 스레드 등 관련 프로세스를 리소스에서
            // 제거 후 안전하게 종료할 수 있다.
            Application.Exit();
        }

        private void M03_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 창의 x 버튼 클릭 또는 alt + F4 기능 실행, 종료 버튼 클릭했을 때 실행 이벤트.
            // 프로그램 종료 여부를 확인 하거나
            // 실행되고 있는 스레드를 안전하게 삭제 후 종료할 수 있다.

            // 1. 프로그램 종료 후 확인 메세지.
            if(MessageBox.Show("프로그램을 종료하시겠습니까?","프로그램 종료",MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }

            // 2. 구동되고 있는 스레드가 있다면 종료.
            // ****** Abort (프로세스의 종료를 구현할 수 있는 대표적인 키워드)
            // Dispose()
            if (thNowTime.IsAlive) thNowTime.Abort();
        }

        private void M_Test_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // 매뉴 리스트의 아이템(매뉴)를 클릭하였을 때 이벤트.

            // 1. CS 파일을 직접 호출
            //Form01_MDITest Form01 = new Form01_MDITest();
            //Form01.Show();

            // MDI 로 하위 화면(자식 창)을 상위 폼(부모 창) 안에서 활성화 시키기.
            // MDI : Multiple Document Interface 의 약자로
            //       한개의 창에서 여러가지 작업을 할 수 있는 인터페이스를 뜻한다.

            // 2. MDI 를 이용하여 화면 호출.
            //Form01_MDITest Form01 = new Form01_MDITest();
            // MDI 부모 창 Form 과 연결.
            //Form01.MdiParent = this;
            //Form01.Show();

            //// 3. 어셈블리(=클래스 라이브러리, namespace, 프로젝트, DLL 파일)
            //// Form_List 프로젝트 를 호출
            //// Application.StartupPath : 메인 프로그램이 시작되는 파일의 위치
            //Assembly assembly = Assembly.LoadFrom($"{Application.StartupPath}\\Form_List.Dll");
            //// 클릭한 매뉴의 CS 파일 타입 확인.
            //Type typeform = assembly.GetType($"Form_List.{e.ClickedItem.Name}", true);
            //// Form 형식으로 전환
            //Form FormMdi = (Form)Activator.CreateInstance(typeform);
            //// 종속관계 연결
            //FormMdi.MdiParent = this;  //isMDIContainer 를 true로 설정해야 한다.
            //// 화면 오픈.
            //FormMdi.Show();

            //// 4. 탭 컨트롤(MyTabControl) 의 탭 페이지에 매뉴선택한 클래스 화면 등록 및 활성화.
            //// Form_List.DLL
            //Assembly assembly = Assembly.LoadFrom($"{Application.StartupPath}\\Form_List.Dll");
            //// 클릭한 매누의 CS 파일 타입 확인 및 추출
            //Type typeform = assembly.GetType($"Form_List.{e.ClickedItem.Name}", true);
            //// Form 형식으로 전환
            //Form FormMdi = (Form)Activator.CreateInstance(typeform);
            //// 탭 페이지에 폼을 추가하여 오픈한다.
            //myTabControlr.AddForm(FormMdi);

            // 5. 이미 활성화 되어있는 페이지의 매뉴를 클릭 시 해당화면 활성화
            //    활성화 되어 있지 않은 매뉴 선택시 신규 탭 추가.
            // Form_List.DLL
            Assembly assembly = Assembly.LoadFrom($"{Application.StartupPath}\\Form_List.Dll");
            // 클릭한 매뉴의 CS 파일 타입 확인 및 추출
            Type typeform = assembly.GetType($"Form_List.{e.ClickedItem.Name}", true);
            // Form 형식으로 전환
            Form FormMdi = (Form)Activator.CreateInstance(typeform);
            // 탭 페이지에 폼을 추가하여 오픈한다.

            // 해당되는 폼이 이미 오픈되어 있는지 확인 후 활성화 또는 신규 오픈.
            // int i = 0 : 탭 페이지의 주소를 나타낼 int
            bool bFlag = false;
            for (int i = 0; i <= myTabControlr.TabPages.Count - 1; i++)
            {
                // 클릭한 매뉴의 이름과 오픈되어있는 페이지의 이름이 같다면.
                if (myTabControlr.TabPages[i].Name == $"{e.ClickedItem.Name}")
                {
                    myTabControlr.SelectedTab = myTabControlr.TabPages[i];
                    bFlag= true;
                    break;
                    //return;
                }
            }
            if(!bFlag) myTabControlr.AddForm(FormMdi);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 오픈되어 있는 페이지가 없을 때는 닫기 기능 종료
            // 닫기 버튼 클릭 시 활성화 되어 있는 페이지 닫기.
            if(myTabControlr.TabPages.Count > 0) myTabControlr.SelectedTab.Dispose();
        }

        #region < 툴바의 기능 연계 >
        private void btnFunction_Click(object sender, EventArgs e)
        {
            ToolStripButton tsFunction = (ToolStripButton)sender;
            DoFuncition(tsFunction.Text);

        }

        void DoFuncition(string sStatue)
        {
            // 오픈되어 있는 페이지가 없을 경우 return
            if (myTabControlr.TabPages.Count == 0) return;

            // 현재 활성화 된 화면의 조회/추가/삭제/저장 기능을 수행하는 메서드

            #region < AS 와 IS >
            // 캐스팅 : 상속받은 부모 클래스로부터 형 변환이 가능 할 경우 형변환을
            //          명시적으로 실행하는 기능.

            // as     : 대상으로부터 사옥받은 클래스이면, 형변환을 수행하고/
            //          그렇지 않으면 null 값을 대입하는 연산자

            // is     : 대상으로부터 상속받았는지 여부를 bool 형식으로 결과값만 반환.

            // myTabControlr.SelectedTab.Controls[0] : Page 에 추가 된 컨트롤 중에 최상위 컨트롤
            //                                         ex) Form04_ItemMaster
            if (myTabControlr.SelectedTab.Controls[0] is BaseChildForm == false) return; // myTabControlr.SelectedTab.Controls[0]가 BaseChildForm에게 상속받았다면
            BaseChildForm Child = (BaseChildForm)myTabControlr.SelectedTab.Controls[0];

            //BaseChildForm Child = myTabControlr.SelectedTab.Controls[0] as BaseChildForm; // 상속을 받았다면 대입 아니면 null을 반환
            //if (Child == null) return;
            #endregion
            
            if      (sStatue == "조회") Child.DoInquire();
            else if (sStatue == "추가") Child.DoNew();
            else if (sStatue == "삭제") Child.DoDelete();
            else if (sStatue == "저장") Child.DoSave();

        }
        #endregion

        //private void Form01_MDITest_Click(object sender, EventArgs e)
        //{
        //    Form01_MDITest Form01 = new Form01_MDITest();
        //    // MDI 부모 창 Form 과 연결.
        //    Form01.MdiParent = this;
        //    Form01.Show();
        //}

        //private void toolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    Form02_MDITest Form02 = new Form02_MDITest();
        //    // MDI 부모 창 Form 과 연결.
        //    Form02.MdiParent = this;
        //    Form02.Show();
        //}
    }
}

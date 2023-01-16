# WinFormApplication

# 1일차
1. 데이터 베이스 연동
  - 데이터 검색 및 로직 처리 
  - 데이터 갱신 및 승인처리 

# 2일차
2. 클래스 라이브러리 
  - 보안성 향상 및 코드의 재사용 성 용이

3. 클래스 간 연동 메인화면 호출. 
  - 생성자 멤버에서 로그인 창 호출 
  - ShowDialog
  - 로그인의 성공여부 전달 (외부변수, Tag)

# 3일차
4. 메인화면 디자인 

5. 현재시각 표시 
 - Timer , Thread 와 무한루프

6. 프로그램 종료
 - Formclosing 이벤트를 통한 Thread.Abort();

7. MDI 를 통한 화면간의 종속성 연결하기

8. 지정한 매뉴의 이름으로 클래스 라이브러리에서 클래스 파일 추출하기

# 4일차
9. 사용자 정의 컨트롤 (MyTabControl) 생성 후 선택한 화면 등록 및 표현하기
  - Tabcontrol 클래스 상속
  - FormAdd 메서드 추가

10. 매뉴 클릭 시  탭 페이지에 이미 활성화 되어 있는 화면 활성화 및 페이지 신규 추가 하기
   - SelectedTab

11. Dispose 기능을 이용한 탭 페이지 화면 제거 

12. 품목마스터 (Form03_ItemMaster) 화면 디자인 및 도구 배치 
   - DateTimePicker
   - RadioButton
   - CheckBox
   - ComboBox
   - DataGridView

13.  DataGridView 컬럼 셋팅 기능 확인

14.  ComboBox 데이터 등록을 위한 데이터베이스 연동 및 표현
   - ValueMember   : 보여지지 않는 로직 상 처리 할 데이터 공간
   - DisplayMember : 사용자에게 보여지는 텍스트 데이터

15. 조회 버튼을 통한 품목 마스터 데이터 조회 및 그리드 바인딩. 
  - DataSource

# 5일차
16. 조회 할때 조회조건 에 따른 SQL 구문 Where 절 작성 및 적용. 

17. 콤보박스 선택 데이터 중 모두선택 추가 를 위한 SQL 구문의 UNION 절 적용

18. 데이터 그리드뷰 행 추가 

19. 선택 한 품목 내역 DB 에서 삭제 로직 (DELETE SQL) 처리 . 

20. 저장 버튼 클릭 시 UPDATE / INSERT SQL 분기 처리 
  - 품목마스터 테이블에 등록되어 있는 ITEMCODE 인지 확인 후 있으면 UPDATE , 없으면 INSERT

21. 그리드 에서 나타난 품목코드를 중복 추가 등록 시 검출 로직 적용. 

# 6일차 
22. 파일 탐색기 에서 사진 파일 로드 하여 이미지 뷰어(PictureBox) 에 표현하기. 

23. 사진 파일 FileStream, BinaryReader 을 이용하여 Byte 코드 변형 및 데이터 베이스 등록 하기 

24. 선택한 품목 별 이미지 Byte 코드 데이터베이스에 서 조회 후 이미지뷰어(PictureBox) 에 표현하기. 

25. 선택한 품목별 이미지 삭제 하기.

26. 어플리케이션 설계서를 확인 후 사용자 마스터 화면 구현하기. 

# 7일차
27. Interface 를 통한 시스템 의 멤버 규칙 정의 

28. Interface 상속 클래스(BasechildFrom) 에서 Interface 기능 구현 
   
29. BasechildFrom 의 상속 클래스 (From05_userMaster) 에서 메서드 Overriding<br/>
  - virtual / abstrict  과 overriding

30. 툴바 기능 연계를 위한 이벤트 메스드 간추리기 <br/>
  - sender : 이벤트 발생시 메서드를 호출한 클래스의 객체 정보

31. 캐스팅 과 (As / is) 를 통한 종속관계 클래스 연계 및 툴바 기능연결

32. BaseChildForm 을 상속받은 사용자마스터(Form05_UserMaster) 매뉴 등록 및 디자인

33. 콤보박스 셋팅 SQL 로직 메서드화 하여 클래스라이브러리(Assemble 의 Common) 에 등록<br/>
    및 사용자 마스터 화면(Form05_UserMaster) 에서 호출

34. DBHelper 클래스 생성 후 데이터 베이스 Open 및 close 함수화

35. 저장 프로시저 (조회) 호출 로직 작성.

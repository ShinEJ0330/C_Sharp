# C_Sharp
## 도서관
개인 프로젝트
```
<구성>
1. 로그인 창

2. 도서 대출/반납 창

3. 사용된 DB(mssql)

```
>1. 로그인 창
>
>![도서관1](https://user-images.githubusercontent.com/90272655/136759326-2a48b7c6-2e2c-4776-bb94-f6ffcfd7e264.gif)
>+ DB에서 관리자 아이디와 비밀번호를 얻어 로그인한다.
>2. 도서 대출/반납 창
>
>![도서관2](https://user-images.githubusercontent.com/90272655/136759398-ddbc1250-6244-4362-bd92-7305c3e8bd94.gif)
>+ 회원 정보를 입력해 대출한 도서 정보를 확인한다.
>+ 도서 정보를 입력해 대출할 수 있는 도서를 확인한다.
>+ DB 정보를 그리드 뷰에 표시한다.
>   + 회원 정보를 입력했을 경우
>       + 입력한 회원의 대출한 도서 정보 표시
>       + 대출한 도서 반납 가능
>   + 도서 정보를 입력했을 경우
>       + 입력한 도서의 상태 확인(대출 중/ 대출 가능)
>       + 입력한 도서 대출 가능
>
>3. 사용된 DB(mssql)
><img width="40%" src="https://user-images.githubusercontent.com/90272655/136759135-221cc0f3-e681-4d61-8b71-b3d57b043ed1.gif"/>

------------

## 주차장
참여 인원 : 4명
```
<구성>

1. 로그인 창

2. 수입 통계 창

3. 주차 상태 창

4. 사용된 DB (mssql)

```
>1. 로그인 창
><img width="40%" src="https://user-images.githubusercontent.com/90272655/136754083-4820dd8e-e97b-4a86-8079-55e2443b9562.gif"/>
>
>+ DB에서 관리자 아이디와 비밀번호를 얻어 로그인한다.
>   + 아이디, 비밀번호가 틀렸을 경우
>       + 오류 화면이 생성된다.
>   
>        ![사본 -로그인 창_실패](https://user-images.githubusercontent.com/90272655/136758639-00af1d15-e394-4d13-8e18-5542fb871cd8.png)
>   + 아이디, 비밀번호가 맞을 경우
>       + 수입통계 창이 켜진다.
>
>2. 수입통계 창
><img width="80%" src="https://user-images.githubusercontent.com/90272655/136755926-8c68961f-01a0-44b2-b6f6-f5bce9b3e769.gif"/>
>
>+ DB에서 수입 통계 정보를 얻어 조회한다.
>+ 차량 입/출차 하면 새로고침 버튼을 눌러 정보를 업데이트 한다.
>+ 필요한 경우 요금 정보를 수정한다.(DB연동)
>+ 주차장 버튼을 입력하면 주차 상태 창을 활성화 해준다.
>
>3. 주차 상태 창
>+ 차량 번호와 종류를 입력하고 차량을 입장시킨다.
>   + 번호와 종류를 미입력할 경우
>       + 오류 화면이 생성
>       
>       ![사본 -주차 상태창_오류(번호미입력)](https://user-images.githubusercontent.com/90272655/136760708-0c3675b3-3aa3-4972-a8ba-aae159f5d0a9.png)
>       ![사본 -주차 상태창_오류(종류미선택)](https://user-images.githubusercontent.com/90272655/136760745-5b5bed56-fc8d-4573-8a07-e4ddf55fa2d3.png)
>       
>   + 번호와 종류를 입력할 경우
>       + 차량 위치가 활성화 된다.
>       
>       ![사본 -주차 상태창_입장](https://user-images.githubusercontent.com/90272655/136761184-4dba87d6-7066-4e0f-b07f-1d89d56629b0.png)
>       
>+ 원하는 차량 위치를 선택한다.
>   + 선택한 위치가 빨간색일 경우
>   
>   ![사본 -주차 상태창_오류(주차 오류)](https://user-images.githubusercontent.com/90272655/136761121-5429820f-ac22-4859-94ab-d61f3e5e1833.png)
>   
>   + 선택한 위치가 초록색일 경우
>        + 차량이 입장한 자리가 빨간색으로 변한다.
>   
>   ![사본 -주차 상태창_주차완료](https://user-images.githubusercontent.com/90272655/136761233-2595d82d-6b8d-4f50-a55d-749fee1346db.png)
>   
>+ 그리드 뷰에 주차된 차량이 나타난다.
>+ 그리드 뷰에서 차량을 선택해 퇴장 버튼을 누르면 차량이 퇴장하고 차량이 있던 자리가 초록색으로 변한다.
>+ 전광판에 남은 주차 수를 알려준다.
>
>4. 사용된 DB (mssql)
>
>![주차장4](https://user-images.githubusercontent.com/90272655/136761378-91b1618a-c112-49db-bd8a-2874f4c58bec.gif)


------------
## 재고관리
개인 프로젝트
```
<구성>
1. 재고관리 창

2. 입고관리 창

3. 출고관리 창

4. 조회 창

5. 모니터링 창

6. 통계화면 창

7. 사용된 DB (mysql)

```
>1. 재고관리 창
>
>![재고관리1](https://user-images.githubusercontent.com/90272655/136762463-d92ce4b8-c4a8-4f9e-b66d-d85cd7caaa1b.gif)
>
>2. 입고관리 창
>
>![재고관리2](https://user-images.githubusercontent.com/90272655/136762946-ca15dabe-8e3d-4831-b350-3668f0989af4.gif)
>
>3. 출고관리 창
>
>![재고관리3](https://user-images.githubusercontent.com/90272655/136762975-5a15962e-2a4f-4b87-92f4-fe7eb72ba8ae.gif)
>
>4. 조회 창
>
>![재고관리4](https://user-images.githubusercontent.com/90272655/136762995-cdfc9ac3-6cdf-42aa-ac6b-d619e8ac9153.gif)
>
>5. 모니터링 창
>
>![재고관리5](https://user-images.githubusercontent.com/90272655/136763018-72f04ef6-d988-4d2c-8780-3107f173f40f.gif)
>
>6. 통계화면 창
>
>![재고관리6](https://user-images.githubusercontent.com/90272655/136763039-c0f1b0b3-8c56-482f-9b3b-3ecf5ee0dda6.gif)
>
>7. 사용된 DB (mysql)

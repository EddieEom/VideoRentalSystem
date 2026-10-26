# C# 비디오 대여 관리 프로그램

수업에서 시작한 WinForms 프로그램을 보완하며 **비동기 처리, 저장 프로시저, DB 정규화**를 공부했습니다. 고객·비디오·대여 정보를 입력하고, DB에 저장한 뒤 다시 화면으로 조회하는 프로그램입니다.

## 이 프로젝트에서 공부한 것

- **비동기 처리:** 기존 DB 처리에 async/await를 적용하며 DB 작업을 기다리는 흐름과 완료 후 화면을 갱신하는 순서를 공부했습니다.
- **저장 프로시저:** 기능별 SQL을 작성하고 C#에서 매개변수를 전달해 호출했습니다.
- **DB 정규화:** 고객·비디오·대여 정보를 나눠 저장하고 관계를 구성하는 과정을 공부했습니다. 정규화·테이블·인덱스 관련 자료도 남겼습니다.

[WinForms 소스](Video_Program) · [SQL 스크립트](database) · [DB 학습 자료](docs/database)

실제 서비스의 성능 개선을 증명하는 프로젝트보다는, 화면과 DB를 연결하고 기존 코드를 고쳐 본 학습 기록입니다.

## 실행 화면

<img src="https://raw.githubusercontent.com/EddieEom/EddieEom/main/assets/screenshots/video-rental.jpg" alt="비디오·고객·대여 관리와 정보 조회를 함께 연 WinForms 화면" width="100%"/>

**고객·비디오·대여 정보 관리** · 여러 관리 화면과 조회 결과를 MDI 창에서 확인할 수 있습니다.

## 🖥️ 주요 기능

<table>
<tr>
<td width="33%" align="center"><img src="./assets/images/video.png" width="72" alt="비디오 관리 기능 아이콘"/><br><b>비디오 관리</b><br>등록 · 수정 · 삭제 · 검색</td>
<td width="33%" align="center"><img src="./assets/images/Customer.png" width="72" alt="고객 관리 기능 아이콘"/><br><b>고객 관리</b><br>고객 정보 관리 · 검색</td>
<td width="33%" align="center"><img src="./assets/images/video-manage.png" width="72" alt="대여 관리 기능 아이콘"/><br><b>대여·반납</b><br>대여 상태 · 요금 처리</td>
</tr>
<tr>
<td colspan="2"><b>조회 및 출력</b> · 대여 현황과 순위 조회 · Excel 출력</td>
<td><b>설정</b> · 대여 기간 · 대여료 · 연체료</td>
</tr>
</table>

## 🔧 구현 과정

| 단계 | 진행 내용 |
| :--- | :--- |
| **1. 요구사항 구현** | 제공된 화면과 기능에 맞춰 WinForms 구성 |
| **2. DB 연동** | ADO.NET·저장 프로시저로 SQL Server CRUD 처리 |
| **3. 기존 코드 보완** | 동기 방식으로 구현한 프로그램에 비동기·스레드 처리 추가 |

WinForms 이벤트에서 DB를 조회하고 결과를 표에 표시하는 흐름을 구현했습니다. 이후 DB 작업과 화면 갱신 처리를 공부하며 기존 코드를 보완했습니다.

<details>
<summary><b>🧰 사용 기술</b></summary>

## 사용 기술

| 구분 | 기술 |
| --- | --- |
| 언어·화면 | C#, WinForms, .NET 9 |
| DB | SQL Server |
| DB 연결 | ADO.NET, Microsoft.Data.SqlClient, 저장 프로시저 |
| 파일 출력 | ClosedXML |

</details>

<details>
<summary><b>⚙️ 설치 및 실행</b></summary>

## 실행 방법

### Requirements

```text
Windows
.NET 9 SDK
Visual Studio
Microsoft SQL Server
SQL Server Management Studio
```


### 1. Clone Repository

```bash
git clone https://github.com/EddieEom/VideoRentalSystem.git
cd VideoRentalSystem
```


### 2. Create Database

SQL Server에서

```text
database/비디오 프로그램 테이블 생성 쿼리문.sql
```

을 실행하여

```text
VideoRentalDB
```

를 생성합니다.


### 3. Create Stored Procedures

Repository에 포함된 Stored Procedure Script를 실행합니다.

```text
database/비디오 프로그램 비디오 정보 관리 저장프로시저 쿼리문.sql

database/비디오 프로그램 고객 관리 저장프로시저 쿼리문.sql

database/비디오 프로그램 비디오 대여관리 저장프로시저 쿼리문.sql

database/비디오 프로그램 정보조회 저장프로시저 쿼리문.sql

database/비디오 프로그램 환경설정 저장프로시저 쿼리문.sql
```


### 4. Database Connection

현재 개발 환경에서는 다음 Connection String을 사용합니다.

```text
Server=localhost;
Database=VideoRentalDB;
Trusted_Connection=True;
TrustServerCertificate=True;
```

실행 환경에 맞게 SQL Server 연결 정보를 변경해야 합니다.


### 5. Open Solution

Visual Studio에서

```text
Video_Program.slnx
```

를 엽니다.


### 6. Restore Packages

프로젝트에서 사용하는 주요 NuGet Package:

```text
Microsoft.Data.SqlClient 7.0.1
ClosedXML 0.105.0
```

Visual Studio 또는 다음 명령으로 복원할 수 있습니다.

```bash
dotnet restore
```


### 7. Run

```bash
dotnet run --project Video_Program
```

또는 Visual Studio에서 `F5`를 눌러 실행합니다.

SQL 스크립트와 연결 문자열을 실행 환경에 맞게 준비해야 합니다.

</details>


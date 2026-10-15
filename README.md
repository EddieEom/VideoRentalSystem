# 비디오 대여 관리 프로그램

C# WinForms와 ADO.NET으로 DB 연동과 CRUD를 연습한 수업 과제입니다.

교수님이 화면 결과와 필요한 기능을 인쇄물로 제공했고, 그 요구사항에 맞춰 프로그램을 만들었습니다.

## 진행 과정

처음에는 동기 방식으로 화면과 DB 기능을 구현했습니다. 이후 C# 기반 프로그램 개발을 더 공부하기 위해 비동기 처리와 스레드 처리를 추가했습니다.

| 단계 | 진행 내용 |
| --- | --- |
| 수업 과제 | 제공된 화면·기능 요구사항에 맞춰 WinForms 프로그램 작성 |
| DB 연동 | ADO.NET과 SQL Server를 이용한 조회·등록·수정·삭제 |
| 추가 수정 | 기존 동기 처리 코드를 비동기 처리와 스레드 처리를 사용하는 방향으로 수정 |

추가 수정 전후의 응답 시간이나 성능은 별도 수치로 비교하지 않았습니다.

## 주요 기능

- 비디오·고객 정보 조회, 등록, 수정, 삭제
- 비디오 대여와 반납
- 대여 기간·대여료·연체료 설정
- 대여 현황과 순위 조회
- ClosedXML을 이용한 Excel 출력

## 사용 기술

| 구분 | 기술 |
| --- | --- |
| 언어·화면 | C#, WinForms, .NET 9 |
| DB | SQL Server |
| DB 연결 | ADO.NET, Microsoft.Data.SqlClient, 저장 프로시저 |
| 파일 출력 | ClosedXML |

## 화면

### 비디오 관리

![비디오 관리](./video.png)

### 고객 관리

![고객 관리](./Customer.png)

### 대여·반납

![대여 관리](./video-manage.png)

### 환경설정

![대여 정책 설정](./gear.png)

### 정보 조회

![정보 조회](./find_information.png)

## 과제와 추가 수정에서 다룬 내용

WinForms 이벤트에서 DB를 조회하고 결과를 표에 표시하는 흐름을 연습했습니다. 대여·반납 데이터를 여러 테이블과 연결하고, 최근에는 DB 작업과 화면 갱신을 어떻게 처리할지 공부하며 기존 코드를 수정했습니다.

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
비디오 프로그램 테이블 생성 쿼리문.sql
```

을 실행하여

```text
VideoRentalDB
```

를 생성합니다.


### 3. Create Stored Procedures

Repository에 포함된 Stored Procedure Script를 실행합니다.

```text
비디오 프로그램 비디오 정보 관리 저장프로시저 쿼리문.sql

비디오 프로그램 고객 관리 저장프로시저 쿼리문.sql

비디오 프로그램 비디오 대여관리 저장프로시저 쿼리문.sql

비디오 프로그램 정보조회 저장프로시저 쿼리문.sql

비디오 프로그램 환경설정 저장프로시저 쿼리문.sql
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

실행 안내는 기존 개발 환경 설정을 유지했습니다. SQL 스크립트와 연결 문자열을 실행 환경에 맞게 준비해야 합니다.

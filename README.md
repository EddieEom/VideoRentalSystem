# 비디오 대여 관리 · C# WinForms와 DB CRUD

**화면에서 입력한 값을 DB에 저장하고, 조회 결과를 다시 표시하는 기본기를 공부한 프로그램입니다.**

C# · WinForms · ADO.NET · MSSQL · 저장 프로시저 · async/await · ClosedXML

<img src="https://raw.githubusercontent.com/EddieEom/EddieEom/main/assets/screenshots/video-rental.jpg" alt="고객·비디오·대여 관리 화면" width="100%"/>


## 이 프로젝트에서 구현한 것

| 기능 | 적용한 기술 |
| --- | --- |
| 고객·비디오 정보 등록·조회·수정·삭제 | WinForms 이벤트, ADO.NET, 저장 프로시저 |
| 대여·반납과 현황 조회 | 테이블 관계, JOIN·집계 쿼리 |
| DB 작업과 목록 갱신 | async/await, 비동기 SQL 호출 |
| 조회 결과 Excel 출력 | ClosedXML |
| 대여 기간·대여료·연체료 설정 | 설정값 저장·조회 |

수업에서 제시한 화면과 기능을 바탕으로 시작했습니다. CRUD를 연결한 뒤 기존 코드를 비동기 방식으로 보완하고, DB 정규화와 저장 프로시저를 공부했습니다.

## 개발 과정

### 입력부터 목록 갱신까지 연결하기

고객 등록 버튼에서 값을 읽고 저장 프로시저에 매개변수로 전달했습니다. 저장이 끝나면 고객 목록과 고객 수를 다시 조회해 화면에 반영했습니다. 단순히 SQL을 실행하는 것에서 끝내지 않고, 사용자가 변경된 결과를 확인하는 흐름까지 연결했습니다.

[고객 관리 코드](Video_Program/User_Info.cs)

### 동기 코드를 비동기로 바꾸기

기존 DB 처리에 `OpenAsync`, `ExecuteReaderAsync`, `ExecuteNonQueryAsync` 등을 적용했습니다. 어떤 작업이 끝나야 다음 처리를 할 수 있는지 확인하며, DB 요청과 화면 갱신의 순서를 공부했습니다.

### 테이블과 SQL을 정리하기

고객·비디오·대여 정보를 나눠 저장하고 관계를 구성했습니다. 기능별 저장 프로시저와 정규화·인덱스 학습 자료를 함께 정리했습니다. 화면 코드와 SQL을 함께 보면서 입력값이 어떤 데이터로 저장되는지 익혔습니다.

## 코드와 학습 자료

[WinForms 소스](Video_Program) · [테이블·저장 프로시저](database) · [정규화·인덱스 자료](docs/database)

이 프로젝트를 통해 데이터 관리 화면의 CRUD와 DB 연결을 연습했습니다. 현재 연결 문자열과 DB 접근 코드가 여러 폼에 있어, 설정을 모으고 화면과 데이터 접근을 분리하는 작업을 보완하려고 합니다.

## 실행 방법

Windows, Visual Studio, .NET 9 SDK, SQL Server가 필요합니다.

1. `database/`의 테이블 생성 SQL과 기능별 저장 프로시저를 실행합니다.
2. 소스의 연결 문자열을 `VideoRentalDB` 환경에 맞춥니다.
3. `Video_Program.slnx`를 열어 실행합니다.

```powershell
dotnet restore Video_Program/Video_Program.csproj
dotnet run --project Video_Program/Video_Program.csproj
```

현재 소스는 `Video_Program/`, SQL은 `database/`, 학습 자료는 `docs/database/`에 있습니다. `archive/`는 이전 압축본입니다.

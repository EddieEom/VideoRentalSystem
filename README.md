# 🎬 Video Rental Management System

<div align="center">

### C# · WinForms · MSSQL 기반 비디오 대여 관리 시스템

**비디오·고객·대여 데이터를 관계형 데이터베이스로 설계하고,
실제 대여 업무 흐름과 정책을 C# WinForms 애플리케이션으로 구현한 개인 프로젝트입니다.**

<br>

![CSharp](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge\&logo=dotnet\&logoColor=white)
![.NET](https://img.shields.io/badge/.NET%209-512BD4?style=for-the-badge\&logo=dotnet\&logoColor=white)
![WinForms](https://img.shields.io/badge/Windows%20Forms-0078D4?style=for-the-badge\&logo=windows\&logoColor=white)
![MSSQL](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge\&logo=microsoftsqlserver\&logoColor=white)
![ClosedXML](https://img.shields.io/badge/ClosedXML-217346?style=for-the-badge\&logo=microsoftexcel\&logoColor=white)

</div>

<br>

---

# 📌 Project Overview

비디오 대여점의 업무를 가정하여 제작한
**C# / MSSQL 기반 데이터 중심 관리 프로그램**입니다.

단순 CRUD 화면을 만드는 것에 그치지 않고,

```text
요구사항
   ↓
Database 설계
   ↓
Stored Procedure
   ↓
Business Rule
   ↓
C# Application
   ↓
조회 / 통계 / Excel Export
```

의 흐름을 직접 구성했습니다.

비디오와 고객 정보를 관리하고,

* 고객 검색
* 대여 가능 여부 확인
* 신작 / 구작 판정
* 대여 기간 및 요금 계산
* 대여 등록
* 반납
* 연체료 계산
* 대여 현황 조회
* 통계 조회
* 정책 변경
* Excel 데이터 출력

까지 하나의 프로그램에서 처리할 수 있도록 구현했습니다.

<br>

---

# 🎯 Development Goal

이 프로젝트의 목표는 CRUD 자체보다

> **Database에 저장된 데이터를 실제 업무 규칙과 연결하는 프로그램을 구현하는 것**

이었습니다.

특히 다음 부분에 중점을 두었습니다.

* 관계형 Database Modeling
* PK / FK 기반 데이터 관계 설계
* Stored Procedure 기반 CRUD
* Parameterized Query
* 실제 업무 규칙을 반영한 Business Logic
* 정책 데이터와 프로그램 코드 분리
* JOIN / GROUP BY 기반 정보 조회
* Desktop UI와 Database 데이터 흐름 연결

<br>

---

# 🏗️ System Architecture

```text
┌──────────────────────────────────────┐
│            WinForms Client           │
│                                      │
│  Video / Customer / Rental / Query   │
└──────────────────┬───────────────────┘
                   │
                   │ Microsoft.Data.SqlClient
                   ▼
┌──────────────────────────────────────┐
│               MSSQL                  │
│                                      │
│   Stored Procedure / SQL Query       │
└──────────────────┬───────────────────┘
                   │
                   ▼
        ┌─────────────────────┐
        │   VideoRentalDB     │
        │                     │
        │  VIDEO              │
        │  CUSTOMER           │
        │  RENTAL             │
        │  CONFIG             │
        └─────────────────────┘
```

<br>

---

# 🖥️ Application Structure

MainForm을 **MDI Parent**로 구성하고
업무 영역별 화면을 Child Form으로 분리했습니다.

```text
MainForm
│
├── 🎥 Video_Info
│     └── 비디오 정보 관리
│
├── 👤 User_Info
│     └── 고객 정보 관리
│
├── 📀 Rental_management
│     └── 대여 / 반납
│
├── 📊 Information_Select
│     └── 통계 / 정보 조회
│
├── ⚙️ Video_Rental_Setting
│     └── 대여 정책 설정
│
└── 📄 Video_Excel_Setting
      └── Excel Export
```

동일한 업무 화면이 여러 번 생성되지 않도록
현재 열려 있는 MDI Child Form의 Type을 확인한 후 기존 Window를 활성화하도록 구현했습니다.

```text
Open Menu
    ↓
Check MDI Children
    ↓
Already Open?
   ↙       ↘
 Yes       No
  ↓         ↓
Activate   Create
Existing   Child Form
```

<br>

---

# ✨ Main Features

# 🎥 1. Video Management

비디오 정보를 등록하고 관리하는 화면입니다.

### 관리 데이터

```text
VideoCode
Title
Genre
MainActor
Director
Distributor
ReleaseDate
```

### Features

* 비디오 등록
* 비디오 수정
* 비디오 삭제
* 전체 비디오 목록 조회
* 현재 등록된 비디오 수 표시
* DataGridView Row 선택을 통한 상세 정보 조회
* 비디오 목록 CSV Export

<br>

### CRUD Flow

```text
WinForms
   ↓
Stored Procedure
   ↓
VIDEO
   ↓
DataGridView Refresh
```

등록:

```text
Insert_Video
```

수정:

```text
Update_Video
```

삭제:

```text
Delete_Video
```

조회:

```text
Select_Video
Select_All_Video
```

<br>

## 📷 Video Management

![Video Management](./video.png)

<br>

---

# 👤 2. Customer Management

고객 정보를 등록하고 관리합니다.

### 관리 데이터

```text
CustomerCode
CustomerName
SSN
CustomerType
Gender
Tel
Mobile
PostNumber
Address
```

### Features

* 고객 등록
* 고객 정보 수정
* 고객 삭제
* 전체 고객 조회
* 현재 등록 고객 수 표시
* DataGridView 기반 고객 선택

고객 데이터는 `CUSTOMER` Table에서 관리하고
대여 시 `CustomerCode`를 통해 RENTAL 데이터와 연결됩니다.

<br>

## 📷 Customer Management

![Customer Management](./Customer.png)

<br>

---

# 📀 3. Rental Management

프로젝트에서 가장 많은 Business Logic이 포함된 화면입니다.

```text
Customer Search
       ↓
Customer Select
       ↓
Video Select
       ↓
Rental Availability Check
       ↓
New / Old Video Classification
       ↓
Load Rental Policy
       ↓
Rental
       ↓
Return
       ↓
Late Fee Calculation
```

<br>

## 🔎 Customer Search

다음 값을 이용하여 고객을 검색할 수 있습니다.

```text
CustomerCode
CustomerName
Tel
Mobile
```

`Search_Customer` Stored Procedure를 통해
입력된 Keyword와 일치하는 고객을 검색합니다.

### 검색 결과 처리

```text
검색 결과 0명
   ↓
조회 결과 없음

검색 결과 1명
   ↓
자동 선택

검색 결과 2명 이상
   ↓
고객 선택 화면
```

검색 결과 수에 따라 UX를 다르게 처리하도록 구현했습니다.

<br>

---

# 🎞️ New / Old Video Classification

비디오 출시일과 현재 날짜의 차이를 계산하여
비디오를 **신작 또는 구작**으로 자동 분류합니다.

```text
ReleaseDate
     ↓
Today - ReleaseDate
     ↓
ChangeDays
     ↓
┌───────────────┐
│ New / Old     │
│ Classification│
└───────────────┘
```

전환 기준은 코드에 고정하지 않고
`CONFIG.ChangeDays` 값을 사용합니다.

예:

```text
ChangeDays = 180

출시 후 180일 이하
→ 신작

180일 초과
→ 구작
```

<br>

---

# ⚙️ 4. Rental Policy

대여 정책을 프로그램 코드에 직접 작성하지 않고
별도의 `CONFIG` Table로 분리했습니다.

```text
CONFIG
│
├── ProgramType
├── ChangeDays
├── RentalDays
├── RentalFee
└── LateFee
```

신작과 구작에 서로 다른 정책을 설정할 수 있습니다.

### New Video

```text
신작 → 구작 전환 기간
대여 기간
대여료
일일 연체료
```

### Old Video

```text
대여 기간
대여료
일일 연체료
```

<br>

## Why CONFIG?

대여 기간이나 가격을 코드에 직접 작성할 경우

```csharp
rentalDays = 3;
rentalFee = 3000;
lateFee = 1000;
```

정책이 변경될 때마다 프로그램을 수정해야 합니다.

MindBuilder가 아닌 실제 업무 시스템을 가정한 이 프로젝트에서는 이를

```text
Application
     ↓
CONFIG Table
     ↓
Rental Policy
```

구조로 분리했습니다.

이를 통해 정책 값의 변경과 프로그램 로직을 분리했습니다.

<br>

## 📷 Rental Policy Setting

![Rental Policy](./gear.png)

<br>

---

# 💿 5. Rental Processing

비디오를 대여하기 전 현재 대여 상태를 확인합니다.

```sql
SELECT COUNT(*)
FROM RENTAL
WHERE VideoCode = @VideoCode
AND ReturnDate IS NULL
```

현재 반납되지 않은 RENTAL 데이터가 존재하면

```text
이미 대여중인 비디오입니다.
```

메시지를 출력하고 대여를 차단합니다.

<br>

## Rental Flow

```text
Customer
   ↓
Video
   ↓
Check Active Rental
   ↓
New / Old Classification
   ↓
CONFIG
   ↓
RentalDays
RentalFee
LateFee
   ↓
Calculate DueDate
   ↓
Insert_Rental
```

저장되는 주요 데이터:

```text
RentalNo
CustomerCode
VideoCode
RentalDate
DueDate
RentalFee
```

대여 완료 후 고객의 현재 대여 목록과
대여 통계 데이터를 자동으로 갱신합니다.

<br>

## 📷 Rental Management

![Rental Management](./video-manage.png)

<br>

---

# 🔁 6. Return Processing

현재 고객이 대여 중인 비디오 목록에서
반납할 비디오를 선택할 수 있습니다.

반납 시

```text
DueDate
   ↓
Today
   ↓
Overdue Days
   ↓
Daily Late Fee
   ↓
Final Late Fee
```

순서로 연체료를 계산합니다.

### Late Fee

```text
OverdueDays <= 0
→ LateFee = 0

OverdueDays > 0
→ OverdueDays × DailyLateFee
```

계산된 연체료와 실제 반납일을

```text
Return_Rental
```

Stored Procedure를 통해 저장합니다.

```text
ReturnDate = Today
LateFee = Calculated Late Fee
```

<br>

---

# 💰 Customer Rental Summary

선택한 고객을 기준으로 현재 대여 현황도 집계합니다.

```text
Current Rental Count
Total Rental Fee
Total Late Fee
```

SQL Aggregate Function을 활용해 계산합니다.

```sql
COUNT(*)
SUM(RentalFee)
SUM(LateFee)
```

<br>

---

# 📊 7. Information & Statistics

대여 데이터를 기반으로 운영 정보를 조회할 수 있습니다.

### Video Rental Ranking

```text
VIDEO
  JOIN
RENTAL
   ↓
GROUP BY Video
   ↓
COUNT(*)
   ↓
Rental Ranking
```

### Customer Rental Ranking

```text
CUSTOMER
   JOIN
RENTAL
   ↓
GROUP BY Customer
   ↓
COUNT(*)
   ↓
Customer Ranking
```

### Currently Rented Videos

`ReturnDate IS NULL`인 데이터를 조회하여
현재 대여 중인 비디오를 확인합니다.

<br>

### Statistics

* 비디오별 대여 횟수
* 고객별 대여 횟수
* 현재 대여 중인 비디오
* 고객별 현재 대여 현황

<br>

### Conditional Search

추가로 조건을 이용한 검색 기능을 구현했습니다.

#### Video Ranking

```text
Genre
```

#### Customer Ranking

```text
CustomerType
```

#### Current Rental

```text
Genre
+
CustomerType
```

JOIN, GROUP BY, LIKE, Parameterized Query 등을 활용하여 구현했습니다.

<br>

## 📷 Information Search

![Information Search](./find_information.png)

<br>

---

# 📄 8. Data Export

프로그램 데이터를 외부 파일로 저장할 수 있도록 구현했습니다.

## CSV

비디오 관리 화면의 DataGridView 내용을

```text
비디오목록.csv
```

형태로 저장할 수 있습니다.

<br>

## Excel

`ClosedXML`을 사용하여 Excel `.xlsx` 파일을 생성합니다.

### Video List

```text
VIDEO
 ↓
Genre Filter
 ↓
SqlDataReader
 ↓
ClosedXML
 ↓
비디오목록.xlsx
```

전체 비디오 또는 선택한 장르만 출력할 수 있습니다.

### Rental Status

```text
RENTAL
   ↓
SqlDataReader
   ↓
ClosedXML
   ↓
대여현황.xlsx
```

### Excel Processing

```text
SQL Query
   ↓
SqlDataReader
   ↓
Create Workbook
   ↓
Create Worksheet
   ↓
Write Header
   ↓
Write Rows
   ↓
AdjustToContents()
   ↓
Save .xlsx
```

<br>

---

# 🗄️ Database Design

Database:

```text
VideoRentalDB
```

주요 Table은 4개로 구성했습니다.

```text
VIDEO
CUSTOMER
RENTAL
CONFIG
```

<br>

## Entity Relationship

```text
┌─────────────────┐
│    CUSTOMER     │
│─────────────────│
│ PK CustomerCode │
└────────┬────────┘
         │
         │ 1:N
         ▼
┌─────────────────┐
│     RENTAL      │
│─────────────────│
│ PK RentalNo     │
│ FK CustomerCode │
│ FK VideoCode    │
│ RentalDate      │
│ DueDate         │
│ ReturnDate      │
│ RentalFee       │
│ LateFee         │
└────────┬────────┘
         │
         │ N:1
         ▼
┌─────────────────┐
│      VIDEO      │
│─────────────────│
│ PK VideoCode    │
└─────────────────┘


┌─────────────────┐
│     CONFIG      │
│─────────────────│
│ PK ConfigID     │
│ ProgramType     │
│ RentalDays      │
│ RentalFee       │
│ LateFee         │
│ ChangeDays      │
└─────────────────┘
```

`CONFIG`는 대여 Transaction과 직접적인 FK 관계를 갖지 않고
대여 정책을 제공하는 설정 데이터 역할을 합니다.

<br>

---

# 🔐 Database Constraints

Database 단계에서도 일부 데이터 무결성 규칙을 적용했습니다.

### CUSTOMER

```text
CustomerCode → Primary Key
SSN          → UNIQUE

Gender
→ '남' / '여'만 허용
```

### CONFIG

```text
ConfigID       → Primary Key
ProgramType    → UNIQUE

RentalDays > 0
RentalFee >= 0
LateFee >= 0
```

### RENTAL

```text
RentalNo → Primary Key

CustomerCode
→ CUSTOMER Foreign Key

VideoCode
→ VIDEO Foreign Key

RentalDate
→ Default GETDATE()

RentalFee
→ Default 0

LateFee
→ Default 0
```

Application뿐 아니라 Database에서도
가능한 범위의 데이터 무결성을 보장하도록 구성했습니다.

<br>

---

# 🧩 Database Normalization

데이터를 하나의 Table에 저장하지 않고 역할에 따라 분리했습니다.

```text
Video Information
→ VIDEO

Customer Information
→ CUSTOMER

Rental Transaction
→ RENTAL

Rental Policy
→ CONFIG
```

이를 통해

* 비디오 정보 중복 방지
* 고객 정보 중복 방지
* 대여 이력 독립 관리
* 정책 데이터 독립 관리

가 가능하도록 구성했습니다.

`RENTAL`은 VIDEO와 CUSTOMER의 식별자를 Foreign Key로 참조하여
Transaction 정보만 관리합니다.

<br>

---

# ⚡ Stored Procedure

주요 CRUD와 조회 기능은 MSSQL Stored Procedure를 활용했습니다.

## VIDEO

```text
Insert_Video
Update_Video
Delete_Video
Select_Video
Select_All_Video
```

## CUSTOMER

```text
Insert_Customer
Update_Customer
Delete_Customer
Select_Customer
Select_All_Customer
```

## RENTAL

```text
Insert_Rental
Return_Rental
Select_Rental
Select_All_Rental
Search_Customer
```

## INFORMATION

```text
Select_VideoRank
Select_CustomerRank
Select_RentingVideo
```

## CONFIG

```text
Insert_Config
Update_Config
Select_Config
```

Application에서는

```csharp
cmd.CommandType = CommandType.StoredProcedure;
```

방식으로 Procedure를 호출하고
Parameter를 전달하여 Database 작업을 수행합니다.

<br>

---

# 🔎 Parameterized Query

사용자 입력값을 SQL 문자열에 직접 연결하는 대신
Parameter를 통해 전달하도록 구현했습니다.

예:

```text
@VideoCode
@CustomerCode
@Keyword
@Genre
@CustomerType
```

```text
User Input
    ↓
SqlParameter
    ↓
SqlCommand
    ↓
MSSQL
```

Stored Procedure뿐 아니라 조건 검색 SQL에서도
Parameterized Query를 활용했습니다.

<br>

---

# 🧠 Business Rules

이 프로젝트에서 CRUD보다 중요하게 다룬 부분입니다.

## Rule 1 — 중복 대여 방지

```text
ReturnDate IS NULL
        ↓
현재 대여 중
        ↓
새로운 대여 차단
```

<br>

## Rule 2 — 신작 / 구작 자동 구분

```text
Today - ReleaseDate
        ↓
ChangeDays 비교
        ↓
New / Old
```

<br>

## Rule 3 — 정책 기반 대여

```text
ProgramType
     ↓
CONFIG
     ↓
RentalDays
RentalFee
LateFee
```

<br>

## Rule 4 — 반납 예정일 자동 계산

```text
RentalDate + RentalDays
        ↓
DueDate
```

<br>

## Rule 5 — 연체료 자동 계산

```text
Today - DueDate
      ↓
OverdueDays
      ↓
OverdueDays × LateFee
```

<br>

---

# 🛠️ Tech Stack

## Language

![CSharp](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge\&logo=dotnet\&logoColor=white)

<br>

## Framework

![.NET](https://img.shields.io/badge/.NET%209-512BD4?style=for-the-badge\&logo=dotnet\&logoColor=white)

`Windows Forms`

<br>

## Database

![MSSQL](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge\&logo=microsoftsqlserver\&logoColor=white)

`Stored Procedure` `JOIN` `GROUP BY`
`PK / FK` `Constraint` `Parameterized Query`

<br>

## Data Access

`Microsoft.Data.SqlClient 7.0.1`

<br>

## Excel

![Excel](https://img.shields.io/badge/ClosedXML-217346?style=for-the-badge\&logo=microsoftexcel\&logoColor=white)

`ClosedXML 0.105.0`

<br>

## Development

![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge\&logo=visualstudio\&logoColor=white)

`Visual Studio` `SSMS` `Git` `GitHub`

<br>

---

# 📂 Project Structure

```text
VideoRentalSystem/
│
├── Video_Program.slnx
│
├── README.md
│
├── Customer.png
├── video.png
├── video-manage.png
├── find_information.png
├── gear.png
│
├── Video_Program/
│   │
│   ├── Program.cs
│   │
│   ├── MainForm.cs
│   │
│   ├── Video_Info.cs
│   │
│   ├── User_Info.cs
│   │
│   ├── Rental_management.cs
│   │
│   ├── Information_Select.cs
│   │
│   ├── Video_Rental_Setting.cs
│   │
│   ├── Video_Excel_Setting.cs
│   │
│   └── Video_Program.csproj
│
├── 비디오 프로그램 테이블 생성 쿼리문.sql
├── 비디오 프로그램 비디오 정보 관리 저장프로시저 쿼리문.sql
├── 비디오 프로그램 고객 관리 저장프로시저 쿼리문.sql
├── 비디오 프로그램 비디오 대여관리 저장프로시저 쿼리문.sql
├── 비디오 프로그램 정보조회 저장프로시저 쿼리문.sql
└── 비디오 프로그램 환경설정 저장프로시저 쿼리문.sql
```

<br>

---

# 🚀 Getting Started

## Requirements

```text
Windows
.NET 9 SDK
Visual Studio
Microsoft SQL Server
SQL Server Management Studio
```

<br>

## 1. Clone Repository

```bash
git clone https://github.com/EddieEom/VideoRentalSystem.git
cd VideoRentalSystem
```

<br>

## 2. Create Database

SQL Server에서

```text
비디오 프로그램 테이블 생성 쿼리문.sql
```

을 실행하여

```text
VideoRentalDB
```

를 생성합니다.

<br>

## 3. Create Stored Procedures

Repository에 포함된 Stored Procedure Script를 실행합니다.

```text
비디오 프로그램 비디오 정보 관리 저장프로시저 쿼리문.sql

비디오 프로그램 고객 관리 저장프로시저 쿼리문.sql

비디오 프로그램 비디오 대여관리 저장프로시저 쿼리문.sql

비디오 프로그램 정보조회 저장프로시저 쿼리문.sql

비디오 프로그램 환경설정 저장프로시저 쿼리문.sql
```

<br>

## 4. Database Connection

현재 개발 환경에서는 다음 Connection String을 사용합니다.

```text
Server=localhost;
Database=VideoRentalDB;
Trusted_Connection=True;
TrustServerCertificate=True;
```

실행 환경에 맞게 SQL Server 연결 정보를 변경해야 합니다.

<br>

## 5. Open Solution

Visual Studio에서

```text
Video_Program.slnx
```

를 엽니다.

<br>

## 6. Restore Packages

프로젝트에서 사용하는 주요 NuGet Package:

```text
Microsoft.Data.SqlClient 7.0.1
ClosedXML 0.105.0
```

Visual Studio 또는 다음 명령으로 복원할 수 있습니다.

```bash
dotnet restore
```

<br>

## 7. Run

```bash
dotnet run --project Video_Program
```

또는 Visual Studio에서 `F5`를 눌러 실행합니다.

<br>

---

# 🔄 Main Data Flow

```text
User
  ↓
WinForms UI
  ↓
Business Logic
  ↓
SqlCommand
  ↓
Stored Procedure / SQL
  ↓
MSSQL
  ↓
SqlDataReader
  ↓
DataGridView / UI
```

대여 기능에서는 여기에 정책 데이터가 추가됩니다.

```text
Customer
   ↓
Video
   ↓
Rental Validation
   ↓
CONFIG
   ↓
Business Rule
   ↓
RENTAL
   ↓
Statistics
   ↓
UI
```

<br>

---

# 💡 Problem Solving

## 1. 동일 비디오의 중복 대여

### Problem

반납되지 않은 동일 비디오가 다시 대여되는 경우
데이터상 한 비디오가 동시에 여러 고객에게 대여될 수 있습니다.

### Solution

```text
VideoCode
    ↓
RENTAL Search
    ↓
ReturnDate IS NULL?
    ↓
Yes → Rental Block
No  → Rental Available
```

현재 대여 상태를 확인한 후 대여 기능을 실행하도록 변경했습니다.

<br>

---

## 2. 대여 정책이 코드에 종속되는 문제

### Problem

대여 기간이나 대여료가 코드에 직접 작성되어 있다면
가격 정책이 변경될 때마다 프로그램 수정이 필요합니다.

### Solution

```text
CONFIG
```

Table을 분리하여

```text
ChangeDays
RentalDays
RentalFee
LateFee
```

를 Database에서 관리하도록 구성했습니다.

Application은 현재 정책을 조회하여 계산에 사용합니다.

<br>

---

## 3. 신작과 구작의 서로 다른 정책 처리

### Problem

모든 비디오가 동일한 가격과 대여 기간을 사용하면
출시일에 따른 업무 정책을 반영할 수 없습니다.

### Solution

```text
ReleaseDate
     ↓
ChangeDays
     ↓
ProgramType
     ↓
CONFIG
```

구조로 신작과 구작을 자동 판별한 뒤
각 유형에 맞는 정책을 적용했습니다.

<br>

---

## 4. 연체료 수기 계산

### Problem

직접 연체일과 요금을 계산할 경우
계산 오류가 발생할 수 있습니다.

### Solution

```text
Today
-
DueDate
=
OverdueDays

OverdueDays
×
DailyLateFee
=
FinalLateFee
```

형태로 반납 시 자동 계산하도록 구현했습니다.

<br>

---

## 5. 운영 데이터 활용

### Problem

CRUD만으로는 축적된 대여 데이터를 업무 정보로 활용하기 어렵습니다.

### Solution

JOIN과 Aggregate Query를 이용하여

```text
Video Rental Ranking

Customer Rental Ranking

Current Rental Status
```

를 별도의 정보 조회 기능으로 구현했습니다.

<br>

---

# 🎯 What I Learned

이 프로젝트를 통해 단순한 WinForms 화면 구현보다
**Database를 중심으로 하나의 업무 프로그램이 어떻게 동작하는지**를 경험했습니다.

### Database

* MSSQL Table 설계
* PK / FK 관계 설정
* Database Constraint
* 관계형 데이터 분리
* Stored Procedure
* JOIN
* GROUP BY
* Aggregate Function
* Parameterized Query

### C# / .NET

* C#
* .NET 9
* WinForms
* MDI Parent / Child
* Event-driven Programming
* DataGridView
* Microsoft.Data.SqlClient
* SqlConnection
* SqlCommand
* SqlDataReader

### Business Logic

* 대여 가능 여부 검증
* 신작 / 구작 판정
* Database 기반 정책 관리
* 반납 예정일 계산
* 연체료 계산
* 고객별 대여 현황 집계

### Data Output

* CSV Export
* ClosedXML
* Excel `.xlsx` Export

<br>

---

# 📈 Project Summary

| Item            | Description                            |
| --------------- | -------------------------------------- |
| Project Type    | Individual Project                     |
| Language        | C#                                     |
| Framework       | .NET 9 / WinForms                      |
| Database        | Microsoft SQL Server                   |
| Main Tables     | VIDEO / CUSTOMER / RENTAL / CONFIG     |
| Data Access     | Microsoft.Data.SqlClient               |
| DB Logic        | Stored Procedure / Parameterized Query |
| Business Domain | Video Rental Management                |
| Export          | CSV / Excel                            |
| Excel Library   | ClosedXML                              |
| UI Structure    | MDI Parent / Child                     |

<br>

---

# 👨‍💻 Developer

**엄인섭**

GitHub
https://github.com/EddieEom

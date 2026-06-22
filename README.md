# 🎬 Video Rental Management System

## 📌 프로젝트 소개

WinForms와 MSSQL을 활용하여 제작한 비디오 대여 관리 프로그램입니다.

단순 CRUD 기능 구현을 넘어 요구사항 분석, 데이터베이스 정규화, 저장 프로시저 설계, 인덱스 최적화, 환경설정 기능까지 직접 설계 및 구현하였습니다.

실제 업무 시스템에서 사용되는 데이터 중심 개발 방식을 경험하는 것을 목표로 제작하였습니다.

---

## 👨‍💻 개발자

엄인섭

한국폴리텍대학 부산캠퍼스 소프트웨어융합과

관심 분야 : Backend / Database / AI

---

## 🛠 개발 환경

### Language

* C#

### Framework

* WinForms (.NET)

### Database

* MSSQL (SQL Server)

### Data Access

* ADO.NET

### Excel

* ClosedXML

### Development Tool

* Visual Studio 2022
* SQL Server Management Studio (SSMS)

### Version Control

* Git
* GitHub

---

## 🏗 시스템 구조

```text
MainForm (MDI)

├── 비디오 정보관리
│     └── Video_Info

├── 고객 관리
│     └── User_Info

├── 비디오 대여 및 반납
│     └── Rental_Management

├── 정보 조회
│     └── Information_Select

├── 대여 정책 설정
│     └── Video_Rental_Setting

└── Excel 출력
      └── Video_Excel_Setting
```

---

## 📋 주요 기능

### 🎥 비디오 관리

* 비디오 등록
* 비디오 수정
* 비디오 삭제
* 비디오 목록 조회

### 👤 고객 관리

* 고객 등록
* 고객 수정
* 고객 삭제
* 고객 목록 조회

### 📀 비디오 대여 및 반납

* 고객 검색
* 비디오 대여 등록
* 비디오 반납 처리
* 연체료 자동 계산
* 중복 대여 방지

### 📊 정보 조회

* 비디오 대여 순위 조회
* 고객 대여 순위 조회
* 현재 대여 중인 비디오 조회
* 장르 및 고객 신분 조건 검색

### ⚙ 환경 설정

* 신작/구작 정책 관리
* 대여 기간 설정
* 대여료 설정
* 연체료 설정
* 신작 → 구작 전환 기간 설정

### 📄 Excel 출력

* 비디오 목록 출력
* 대여 현황 출력

---

## 🗄 데이터베이스 설계

### 테이블 구성

* VIDEO
* CUSTOMER
* RENTAL
* CONFIG

### 정규화 적용

* 1NF : 엔터티 분리
* 2NF : 단일 PK 구조 적용
* 3NF : 종속성 제거

---

## ⚡ 저장 프로시저

총 24개의 저장 프로시저 구현

### VIDEO

* Insert_Video
* Update_Video
* Delete_Video
* Select_Video
* Select_All_Video

### CUSTOMER

* Insert_Customer
* Update_Customer
* Delete_Customer
* Select_Customer
* Select_All_Customer

### RENTAL

* Insert_Rental
* Return_Rental
* Select_Rental
* Select_All_Rental

### INFORMATION

* Select_VideoRank
* Select_CustomerRank
* Select_RentingVideo

### CONFIG

* Insert_Config
* Update_Config
* Select_Config

---

## 🚀 성능 최적화

### 적용 인덱스

### VIDEO

* IX_VIDEO_GENRE

### CUSTOMER

* IX_CUSTOMER_NAME
* IX_CUSTOMER_MOBILE

### RENTAL

* IX_RENTAL_CUSTOMER
* IX_RENTAL_VIDEO
* IX_RENTAL_RETURNDATE

---

## 🔧 문제 해결 경험

### 1. 중복 대여 방지

문제

동일한 비디오를 여러 사용자가 동시에 대여할 수 있는 문제가 발생

해결

```sql
SELECT COUNT(*)
FROM RENTAL
WHERE VideoCode=@VideoCode
AND ReturnDate IS NULL
```

현재 대여 여부를 확인하여 중복 대여를 차단

---

### 2. 정책 변경 유지보수 문제 해결

문제

대여 기간, 대여료 변경 시 소스 코드 수정이 필요

해결

CONFIG 테이블을 별도로 설계하여 정책 중앙 관리

---

### 3. 조회 성능 개선

문제

고객 및 대여 데이터 증가 시 검색 속도 저하 가능성 존재

해결

조회 빈도가 높은 컬럼에 NonClustered Index 적용

---

## 📈 프로젝트 결과

| 항목       | 결과      |
| -------- | ------- |
| 개발 인원    | 1명      |
| 개발 기간    | 2026.06 |
| 화면 수     | 6개      |
| DB 테이블   | 4개      |
| 저장 프로시저  | 24개     |
| 인덱스      | 6개      |
| Excel 기능 | 2개      |
| 통계 기능    | 3개      |

---

## 💡 프로젝트를 통해 얻은 경험

단순 CRUD 구현을 넘어 요구사항 분석, 데이터베이스 설계, 정규화, 저장 프로시저, 인덱스 설계, 화면 구현까지 전체 서비스 흐름을 직접 경험하였습니다.

데이터 중심의 구조적인 개발 방식을 학습하며 유지보수성과 확장성을 고려하는 개발 역량을 향상시켰습니다.

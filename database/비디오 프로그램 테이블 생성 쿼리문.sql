-- 비디오 프로그램 DB 생성 = DB 명 : VideoRentalDB
Create Database VideoRentalDB;

-- VideoRentalDB 사용
Use VideoRentalDB;


-- VIDEO 테이블 생성 : 비디오 정보를 저장하는 테이블
CREATE TABLE VIDEO
(
    VideoCode INT PRIMARY KEY,

    Title NVARCHAR(30) NOT NULL,

    Genre NVARCHAR(10) NOT NULL,

    MainActor NVARCHAR(15) NOT NULL,

    Director NVARCHAR(15) NOT NULL,

    Distributor NVARCHAR(20) NOT NULL,

    ReleaseDate DATE NOT NULL
);

-- CUSTOMER 테이블 생성 : 회원 정보를 저장하는 테이블
CREATE TABLE CUSTOMER
(
    CustomerCode INT PRIMARY KEY,

    CustomerName NVARCHAR(10) NOT NULL,

    SSN NVARCHAR(14) NOT NULL UNIQUE,

    CustomerType NVARCHAR(10) NOT NULL,

    Gender NCHAR(2) NOT NULL
        CHECK (Gender IN (N'남', N'여')),

    Tel NVARCHAR(15),

    Mobile NVARCHAR(15) NOT NULL,

    PostNumber VARCHAR(10) NOT NULL,

    Address NVARCHAR(50) NOT NULL,
);


-- CONFIG 테이블 생성 : 대여 이력을 저장하는 테이블
CREATE TABLE CONFIG
(
    ConfigID INT PRIMARY KEY,

    ProgramType NVARCHAR(3) NOT NULL UNIQUE,

    RentalDays INT NOT NULL
        CHECK (RentalDays > 0),

    RentalFee INT NOT NULL
        CHECK (RentalFee >= 0),

    LateFee INT NOT NULL
        CHECK (LateFee >= 0),

    ChangeDays INT 
);


-- RENTAL 테이블 생성 : 프로그램 환경설정 정보를 저장하는 테이블
CREATE TABLE RENTAL
(
    RentalNo INT PRIMARY KEY,

    CustomerCode INT NOT NULL,

    VideoCode INT NOT NULL,

    RentalDate DATE NOT NULL
        DEFAULT(GETDATE()),

    DueDate DATE NOT NULL,

    ReturnDate DATE NULL,

    RentalFee INT NOT NULL
        DEFAULT(0),

    LateFee INT NOT NULL
        DEFAULT(0),

    CONSTRAINT FK_RENTAL_CUSTOMER
        FOREIGN KEY(CustomerCode)
        REFERENCES CUSTOMER(CustomerCode),

    CONSTRAINT FK_RENTAL_VIDEO
        FOREIGN KEY(VideoCode)
        REFERENCES VIDEO(VideoCode)
);
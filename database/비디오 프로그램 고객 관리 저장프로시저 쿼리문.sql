-- 고객 관리 저장 프로시저
-- 1. 고객 추가용
CREATE PROC Insert_Customer
(
    @CustomerCode INT,
    @CustomerName NVARCHAR(10),
    @SSN NVARCHAR(14),
    @CustomerType NVARCHAR(10),
    @Gender NCHAR(2),
    @Tel NVARCHAR(15),
    @Mobile NVARCHAR(15),
    @Address NVARCHAR(50),
    @PostNumber VARCHAR(5)

)
AS
BEGIN

    INSERT INTO CUSTOMER
    (
        CustomerCode,
        CustomerName,
        SSN,
        CustomerType,
        Gender,
        Tel,
        Mobile,
        Address,
        PostNumber
    )
    VALUES
    (
        @CustomerCode,
        @CustomerName,
        @SSN,
        @CustomerType,
        @Gender,
        @Tel,
        @Mobile,
        @Address,
        @PostNumber
    )

END


ALter table CUSTOMER

-- 3. 고객 삭제용
CREATE PROC Delete_Customer
(
    @CustomerCode INT
)
AS
BEGIN

    DELETE FROM CUSTOMER
    WHERE CustomerCode = @CustomerCode

END


-- 4. 특정 고객 조회용
CREATE PROC Select_Customer
(
    @CustomerCode INT
)
AS
BEGIN

    SELECT *
    FROM CUSTOMER
    WHERE CustomerCode = @CustomerCode

END


-- 5. 고객 전체 조회용
CREATE PROC Select_All_Customer
AS
BEGIN

    SELECT *
    FROM CUSTOMER
    ORDER BY CustomerCode

END


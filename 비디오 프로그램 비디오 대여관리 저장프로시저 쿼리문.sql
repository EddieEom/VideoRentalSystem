-- 비디오 대여 저장 프로시저
-- 1. 대여 비디오 입력 등록용
CREATE PROC Insert_Rental
(
    @RentalNo INT,
    @CustomerCode INT,
    @VideoCode INT,
    @RentalDate DATE,
    @DueDate DATE,
    @RentalFee INT
)
AS
BEGIN

    INSERT INTO RENTAL
    (
        RentalNo,
        CustomerCode,
        VideoCode,
        RentalDate,
        DueDate,
        ReturnDate,
        RentalFee,
        LateFee
    )
    VALUES
    (
        @RentalNo,
        @CustomerCode,
        @VideoCode,
        @RentalDate,
        @DueDate,
        NULL,
        @RentalFee,
        0
    )

END


-- 2. 비디오 회수용
CREATE PROC Return_Rental
(
    @RentalNo INT,
    @ReturnDate DATE,
    @LateFee INT
)
AS
BEGIN

    UPDATE RENTAL
    SET
        ReturnDate = @ReturnDate,
        LateFee = @LateFee
    WHERE RentalNo = @RentalNo

END


-- 3. 대여 비디오 정보 조회용
CREATE PROC Select_Rental
(
    @RentalNo INT
)
AS
BEGIN

    SELECT *
    FROM RENTAL
    WHERE RentalNo = @RentalNo

END



-- 4. 비디오 대여 전체조회용
CREATE PROC Select_All_Rental
AS
BEGIN

    SELECT *
    FROM RENTAL
    ORDER BY RentalNo

END


-- 5. 고객 정보 조회용 (수기 입력 찾기)
CREATE PROC Search_Customer
(
    @Keyword NVARCHAR(20)
)
AS
BEGIN

    SELECT *
    FROM CUSTOMER
    WHERE CustomerCode LIKE '%' + @Keyword + '%'
       OR CustomerName LIKE '%' + @Keyword + '%'
       OR Tel LIKE '%' + @Keyword + '%'
       OR Mobile LIKE '%' + @Keyword + '%'

END
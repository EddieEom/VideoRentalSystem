-- 환경설정용 저장프로시저
-- 1. 환경설정 조회용
CREATE PROC Select_Config
AS
BEGIN

    SELECT *
    FROM CONFIG
    ORDER BY ConfigID

END

Drop proc Update_Config
-- 2. 환경설정 수정용
CREATE PROC Update_Config
(
    @ConfigID INT,
    @ProgramType NVARCHAR(3),
    @ChangeDays INT,
    @RentalDays INT,
    @RentalFee INT,
    @LateFee INT
)
AS
BEGIN
    UPDATE CONFIG
    SET
        ProgramType = @ProgramType,
        RentalDays = @RentalDays,
        ChangeDays = @ChangeDays,
        RentalFee = @RentalFee,
        LateFee = @LateFee
    WHERE ConfigID = @ConfigID

END

-- 3. 환경설정 등록용
CREATE PROC Insert_Config
(
    @ConfigID INT,
    @ProgramType NVARCHAR(3),
    @ChangeDays INT,
    @RentalDays INT,
    @RentalFee INT,
    @LateFee INT
)
AS
BEGIN

    INSERT INTO CONFIG
    (
        ConfigID,
        ProgramType,
        ChangeDays,
        RentalDays,
        RentalFee,
        LateFee
    )
    VALUES
    (
        @ConfigID,
        @ProgramType,
        @ChangeDays,
        @RentalDays,
        @RentalFee,
        @LateFee
    )

END



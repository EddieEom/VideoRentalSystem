-- VIDEO 저장 프로시저
-- 1. 비디오 추가용
CREATE PROC Insert_Video
(
    @VideoCode INT,
    @Title NVARCHAR(30),
    @Genre NVARCHAR(10),
    @MainActor NVARCHAR(15),
    @Director NVARCHAR(15),
    @Distributor NVARCHAR(20),
    @ReleaseDate DATE
)
AS
BEGIN

    INSERT INTO VIDEO
    (
        VideoCode,
        Title,
        Genre,
        MainActor,
        Director,
        Distributor,
        ReleaseDate
    )
    VALUES
    (
        @VideoCode,
        @Title,
        @Genre,
        @MainActor,
        @Director,
        @Distributor,
        @ReleaseDate
    )

END;


-- 2. 비디오 저장용
CREATE PROC Update_Video
(
    @VideoCode INT,
    @Title NVARCHAR(30),
    @Genre NVARCHAR(10),
    @MainActor NVARCHAR(15),
    @Director NVARCHAR(15),
    @Distributor NVARCHAR(20),
    @ReleaseDate DATE
)
AS
BEGIN

    UPDATE VIDEO
    SET
        Title = @Title,
        Genre = @Genre,
        MainActor = @MainActor,
        Director = @Director,
        Distributor = @Distributor,
        ReleaseDate = @ReleaseDate
    WHERE VideoCode = @VideoCode

END;


-- 3. 비디오 삭제용
CREATE PROC Delete_Video
(
    @VideoCode INT
)
AS
BEGIN

    DELETE FROM VIDEO
    WHERE VideoCode = @VideoCode

END;


-- 4. 비디오 조회용(1개 선택시)
CREATE PROC Select_Video
(
    @VideoCode INT
)
AS
BEGIN

    SELECT *
    FROM VIDEO
    WHERE VideoCode = @VideoCode

END;

-- 5. 비디오 전체 조회용(DataGridView 목록 조회)
CREATE PROC Select_All_Video
AS
BEGIN

    SELECT *
    FROM VIDEO
    ORDER BY VideoCode

END;
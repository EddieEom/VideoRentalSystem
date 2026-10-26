-- 정보조회 저장프로시저
-- 1. 비디오 대여 순위용
CREATE PROC Select_VideoRank
AS
BEGIN
    SELECT
        V.VideoCode,
        V.Title,
        COUNT(*) AS RentalCount
    FROM VIDEO V
        INNER JOIN RENTAL R
            ON V.VideoCode = R.VideoCode
    GROUP BY
        V.VideoCode,
        V.Title
    ORDER BY RentalCount DESC
END



-- ２．고객 대여 순위용
CREATE PROC Select_CustomerRank
AS
BEGIN
    SELECT
        C.CustomerCode,
        C.CustomerName,
        COUNT(*) AS RentalCount
    FROM CUSTOMER C
        INNER JOIN RENTAL R
            ON C.CustomerCode = R.CustomerCode
    GROUP BY
        C.CustomerCode,
        C.CustomerName
    ORDER BY RentalCount DESC
END


-- ３．대여중인 비디오용
CREATE PROC Select_RentingVideo
AS
BEGIN
    SELECT
        V.VideoCode,
        V.Title,
        C.CustomerName,
        R.RentalDate,
        R.DueDate
    FROM RENTAL R
        INNER JOIN VIDEO V
            ON R.VideoCode = V.VideoCode
        INNER JOIN CUSTOMER C
            ON R.CustomerCode = C.CustomerCode
    WHERE R.ReturnDate IS NULL
END


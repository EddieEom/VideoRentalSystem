-- 1. 비디오 정보관리 페이지

-- 비디오 장르별 조회 성능 향상
CREATE NONCLUSTERED INDEX IX_VIDEO_GENRE
ON VIDEO(Genre);



-- 2. 고객관리 페이지
-- 고객명 검색 성능 향상
CREATE NONCLUSTERED INDEX IX_CUSTOMER_NAME
ON CUSTOMER(CustomerName);

-- 휴대폰 번호 검색 성능 향상
CREATE NONCLUSTERED INDEX IX_CUSTOMER_MOBILE
ON CUSTOMER(Mobile);


-- 3. 비디오 대여관리 페이지
-- 고객별 대여 내역 조회 성능 향상
CREATE NONCLUSTERED INDEX IX_RENTAL_CUSTOMER
ON RENTAL(CustomerCode);

-- 비디오별 대여 내역 조회 성능 향상
CREATE NONCLUSTERED INDEX IX_RENTAL_VIDEO
ON RENTAL(VideoCode);

-- 반납 여부 및 대여중인 비디오 조회 성능 향상
CREATE NONCLUSTERED INDEX IX_RENTAL_RETURNDATE
ON RENTAL(ReturnDate);




# C# 비디오 대여 관리

**고객·비디오·대여 정보를 관리하며 비동기 처리, 저장 프로시저, DB 정규화를 공부했습니다.**

<img src="https://raw.githubusercontent.com/EddieEom/EddieEom/main/assets/screenshots/video-rental.jpg" alt="고객·비디오·대여 관리 화면을 연 기존 실행 캡처" width="100%"/>

[담당 범위](#담당-범위) · [개발 과정](#개발-과정) · [코드와 확인 범위](#코드와-확인-범위) · [실행 방법](#실행-방법)

## 담당 범위

수업에서 제공된 화면·기능 요구사항을 바탕으로 WinForms와 SQL Server를 연결했습니다. 고객·비디오 관리, 대여·반납, 조회·Excel 출력과 DB 작업을 구현하고 기존 코드에 비동기 처리를 추가한 학습 프로젝트입니다.

화면 요구사항을 제공받은 부분과 이를 프로그램으로 구성한 부분을 구분합니다. 코드 작성 도구별 기여율은 기록이 없어 백분율로 제시하지 않습니다.

## 개발 과정

### 화면을 만든 다음 DB 처리를 다시 보기

처음에는 요구한 화면과 CRUD 기능을 연결하는 데 집중했습니다. 이후 기존 동기 방식의 DB 처리를 보완하면서, DB 요청이 끝난 뒤 목록과 고객 수를 다시 조회하는 순서를 공부했습니다.

고객 관리 코드는 `OpenAsync`로 연결하고 저장 프로시저를 실행한 다음 목록을 갱신합니다. 비동기를 사용했다는 사실뿐 아니라, 어느 작업을 기다리고 어느 시점에 화면을 바꾸는지를 확인했습니다. UI 응답성의 개선 수치를 별도로 측정한 기록은 없습니다.

### SQL을 화면과 연결하기

C#의 입력값을 저장 프로시저 매개변수로 넘기고 조회 결과를 그리드에 표시했습니다. 고객·비디오·대여 정보를 나누는 정규화 과정과 테이블·인덱스 학습 자료도 남겼습니다.

지금도 DB 연결 문자열과 접근 코드가 여러 폼에 들어 있습니다. 기능 구현을 먼저 진행한 구조라서 설정 통합과 DB 접근 코드 분리는 다음 보완 과제입니다.

## 코드와 확인 범위

| 볼 내용 | 근거 |
| --- | --- |
| 비동기 DB 호출과 목록 갱신 | [User_Info.cs](Video_Program/User_Info.cs) |
| 화면별 구현 | [WinForms 소스](Video_Program) |
| 테이블·저장 프로시저 | [database](database) |
| 정규화·인덱스 학습 과정 | [학습 자료](docs/database) |

위 캡처는 기존 실행 화면입니다. 저장소의 `archive/`는 이전 압축본이며 현재 구현은 `Video_Program/`과 `database/`를 기준으로 봅니다.

## 실행 방법

Windows, Visual Studio, .NET 9 SDK, SQL Server가 필요합니다.

1. `database/`의 테이블 생성 SQL과 기능별 저장 프로시저를 준비합니다.
2. 소스의 연결 문자열을 `VideoRentalDB` 환경에 맞춥니다.
3. `Video_Program.slnx`를 열어 실행합니다.

```powershell
dotnet restore Video_Program/Video_Program.csproj
dotnet run --project Video_Program/Video_Program.csproj
```

SQL·PDF·Excel·이미지·이전 압축본은 각각 `database/`, `docs/database/`, `assets/images/`, `archive/`에 있습니다.

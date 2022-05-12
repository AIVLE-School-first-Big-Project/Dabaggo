# 📱 Dabaggo : 외국인과 소통을 위한 웹 동시 통역기 

`2022.04.11 ~ 2022.05.11 KT AIVLE 충남/충북 2조 (21조) 빅프로젝트`
> 'Dabaggo'는 외국인과 소통을 위한 웹 동시 통역기 서비스입니다. 
> <br>  서버 구동 시, https://carot-4cbc3.web.app/ 해당 URL을 통해 접속가능합니다.

## 💥사용 전 필독 !! (위의 순서대로 따라해주세요!!!!)💥
1. 호스팅 된 주소로 접속한 후, 자체번역 모델 사용시 크롬-> 사이트 설정-> 안전하지 않은 컨텐츠를 허용으로 변경해주세요! <br/>
(채팅 기반의 웹서비스 이므로 매우 권장합니다!) 

2. 1번의 방법이 안될 시,

   (1) git clone "https://github.com/AIVLE-School-first-Big-Project/Dabaggo.git"  <br/>
   (2) VSCode에서 Live Server 확장자 프로그램 설치  <br/>
   (3) 우측 하단에 "Go Live!" 버튼을 클릭하여 서비스를 이용해주세요! <br/>
3. 로컬에서 Flask Server를 동작하고 싶을 시 Flask Host를 local로 변경해주시고, chatroom.html의 1228, 1249 라인을 local로 변경해주세요!<br/> 
(매우 권장하지 않습니다)

## 👤 조원소개
`충남충북 21조`
> 이진호(조장) 김동민 류승현 안세영 장서윤

## 1. 개발 배경 및 기대효과

`개발배경`

> 코로나 방역이 종료됨에 따라 해외여행을 가고자 하는 사람의 수는 증가하고 있습니다. 하지만 해외에 나가서 자국어 이외에 타국어를 잘 쓸 줄 아는 사람은 많지가 않아 사람들은 외국인과 소통을 필요로 할 때 언어의 장벽을 느끼곤 합니다. 마찬가지로 국내에서도 외국인이 내게 말을 걸었을 때 분명 공부한 영어 문법과 회화 문장은 머릿속에서 떠돌지만 막상 입으로 말하기는 쉽지 않습니다. 그래서 저희는 직접 개발한 AI 모델링 기반 통역 서비스로 위와 같은 상황에서 소통 시 불편한 점을 해소하고자 합니다.

`기대효과`

> 1. 메타버스 및 온라인 행사 등 글로벌 비즈니스에 기여 <br/>
> 2. 전문 통역사 고용의 필요가 줄어들어 전반적인 비용 절감 <br/>
> 3. 추후, 기가지니와 협력하여 통화 번역 서비스로 이용 가능

## 2. 기능 및 UI/UX

#### 서비스 주요 기능
> - 실시간 음성 인식, 텍스트 전송을 이용한 동시 번역 서비스
> - 대화 내용 저장 (영어, 한국어)
> - 대화 내용 기록 시, 화자 분리
> - 챗봇을 이용한 한영 위키백과 서비스 제공
 
#### AI 주요 기능
> - 자체 한국어-영어 번역 AI모델을 통해 입력 언어를 타켓 언어로 번역
> - 파파고 API를 이용하여 입력 언어를 타켓 언어로 번역
> - 카카오 음성 인식(STT)을 이용하여 입력을 받음 (한국어)
> - 자체 STT 모델을 이용하여 입력을 받음 (영어)
> - 요청에서 받은 번역내용을 TTS를 이용해 음성으로 출력가능 (gTTS)

#### 음성 번역 예시

<details>
<summary> 1. 요청(requests)  </summary>   
<div markdown="1">  <br/>
   <img src = "https://user-images.githubusercontent.com/76045608/164461616-3f157212-431c-4fe9-b2cd-4cc477d9d8af.PNG" width = "600" height = "300">
</div>
</details>

<details>
<summary> 2. 응답(response)  </summary>
<div markdown="1">  <br/>
   
  > - 요청이 왔을 경우 음성 입력받음
  > - 입력받은 음성을 텍스트로 변환 (카카오 음성 API (한국어), 자체 STT 모델 (영어))  
  > - 텍스트를 번역하여 요청온 곳에 리턴 (파파고 API, 자체 번역 모델)  <br/>
  
<img src = "https://user-images.githubusercontent.com/76045608/164462590-1edc2b6c-a385-4bf0-b2c9-609d30a19046.PNG" width = "600" height = "300">
   
</div>
</details>

#### UI / UX

<details>
<summary> 메인화면</summary>
<div markdown="1">
  <img src = "https://user-images.githubusercontent.com/86819254/168004739-30f9e318-2d1b-46eb-a97a-895e233f48f4.jpeg">
</div>
</details>

<details>
<summary> 회원가입</summary>
<div markdown="1">
  <img src = "https://user-images.githubusercontent.com/86819254/168001911-e2493e95-a692-4c53-94ea-b8410297bbb5.png" width = "880" height = "380">
</div>
</details>

<details>
<summary> 공지사항</summary>
<div markdown="1">
  <img src = "https://user-images.githubusercontent.com/86819254/168004947-f941a91f-127f-4228-8141-001588595cc8.jpeg">
</div>
</details>

<details>
<summary> 사용가이드</summary>
<div markdown="1">
   <img src = "https://user-images.githubusercontent.com/86819254/168004613-d828f253-2724-46b5-aabd-2763a54cfabd.jpeg">
</div>
</details>

<details>
<summary> 질문게시판</summary>
<div markdown="1">
   <img src = "https://user-images.githubusercontent.com/86819254/168002730-738eb3f9-d8c6-4701-9557-6f1bf6d40228.png" width = "880" height = "380">
</div>
</details>

<details>
<summary> 채팅홈</summary>
<div markdown="1">
   <img src = "https://user-images.githubusercontent.com/86819254/168005389-9b9772c2-a6ab-4748-9ba4-a25ff230e989.jpeg">
</div>
</details>

<details>
<summary> 채팅방</summary>
<div markdown="1">
   <img src = "https://user-images.githubusercontent.com/86819254/168005583-69bdb126-88b2-41f0-9c28-dd046e168136.jpeg">
</div>
</details>

<details>
<summary> 챗봇</summary>
<div markdown="1">
   <img src = "https://user-images.githubusercontent.com/86819254/168002917-31eacdaf-7c17-4817-a3fb-d6216bcb71f4.png" width = "880" height = "330">
</div>
</details>

## 3. ERD
<img src = "https://user-images.githubusercontent.com/86819254/167996192-c856437b-6225-4472-a78c-5b9fbd5d72e1.png" width = "880" height = "380">

## 4. Architecture (2 Tier)

<img src = "https://user-images.githubusercontent.com/86819254/164353189-4df60420-f190-41e3-9029-7bf8a4e449ec.png" width = "880" height = "380">

## 5. 서비스 Flow

`서비스 Flow`

<img src = "https://user-images.githubusercontent.com/86819254/166141535-4624b392-9d3f-4738-a64c-5c0f341c9d01.png" width = "880" height = "380">

`서비스 프로세스`

<img src = "https://user-images.githubusercontent.com/86819254/167996405-540d6ea3-0a67-4d0b-be6b-0fb6c19647b5.png" width = "880" height = "380"> <div style="text-align: left">

## 6. 개발 환경

<img src = "https://user-images.githubusercontent.com/86819254/167998186-917b350f-dacb-424d-b65c-322b9610af86.png" width = "880" height = "320">

## 7. 개발 일정 

<img src = "https://user-images.githubusercontent.com/86819254/167998022-086d29fb-4e98-42df-8a5f-48d8a651eed1.png" width = "880" height = "380">

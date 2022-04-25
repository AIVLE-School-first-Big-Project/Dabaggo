# 📱 Dabaggo : 외국인과 소통을 위한 웹 동시 통역기 

> 2022.04.11 ~ 2022.05.13 KT AIVLE 충남/충북 2조 (21조) 빅프로젝트
'Dabaggo'는 외국인과 소통을 위한 웹 동시 통역기 서비스입니다.

## 조원소개
> 충남충북 21조 :
이진호(조장) 김동민 류승현 안세영 장서윤

## 1. 개발 배경 및 목적

> 코로나가 끝나감에 따라 해외여행을 가고자 하는 사람의 수는 증가하고 있습니다. 하지만 해외에 나가서 자국어 이외에 타국어를 잘 쓸 줄 아는 사람은 많지가 않아 사람들은 외국인과 소통을 필요로 할 때 언어의 장벽을 느끼곤 합니다. 마찬가지로 국내에서도 외국인이 내게 말을 걸었을 때 분명 공부한 영어 문법과 회화 문장은 머릿속에서 떠돌지만 막상 입으로 말하기는 쉽지 않습니다. 그래서 저희는 직접 개발한 AI 모델링을 사용하여 사용자가 외국인과 소통을 필요로 할 때 보다 기능이 간결하고 편리한 서비스를 개발함으로써 위의 불편함을 해결하고자 합니다

## 2. 기능

#### 서비스 주요 기능
> - 실시간 음성 인식을 이용한 동시 번역 서비스
> - 대화 내용 저장(원어,번역어)
> - 대화 내용 기록 시, 화자 분리
> - 챗봇을 이용한 한영 위키백과 서비스 제공
 
#### AI 주요 기능
> - 카카오 음성 인식(STT)을 이용하여 입력을 받음(한국어)
> - 자체 STT 모델을 이용하여 입력을 받음(영어)
> - 파파고 API를 이용하여 입력 언어를 타켓 언어로 번역함
> - 자체내 영어 번역 ai 모델을 만들어 영어로 번역함
> - AI허브의 한국 위키백과 데이터를 이용한 챗봇 서비스
#### 음성 번역 예시
1. 요청(requests) 
<img src = "https://user-images.githubusercontent.com/76045608/164461616-3f157212-431c-4fe9-b2cd-4cc477d9d8af.PNG" width = "600" height = "300">

2. 응답(response) 
     - 요청이 왔을 경우 음성을 입력받음
     - 입력받은 음성을 텍스트로 변환함{카카오 음성 API(한국어),자체 STT 모델 구축(영어)}
     - 텍스트를 번역하여 요청온 곳에 리턴함{파파고 API, 자체 번역 모델 구축(한->영)}
<img src = "https://user-images.githubusercontent.com/76045608/164462590-1edc2b6c-a385-4bf0-b2c9-609d30a19046.PNG" width = "600" height = "300">

- 추가
  - 요청에서 받은 번역내용을 TTS를 이용해 음성으로 출력가능 (gTTS) 사용
  - *모델은 추후 공개 예정* 

#### UI / UX
1. 홈화면
<img src= "https://user-images.githubusercontent.com/94459523/164611477-47bf765e-8c4e-4db6-bfca-8aa997f8a923.PNG" width = "1280" height = "500">



## 3. 2 Tier Architecture

<img src = "https://user-images.githubusercontent.com/86819254/164353189-4df60420-f190-41e3-9029-7bf8a4e449ec.png" width = "880" height = "419">

## 4. 서비스 Flow

<img src = "https://user-images.githubusercontent.com/86819254/164353597-39c2906d-c053-49d9-8d70-39ae1a9ea926.png" width = "881" height = "360">

## 5. ERD 

<img src = "https://user-images.githubusercontent.com/86819254/164353624-89cffe82-1599-41b3-9af6-9dba5aa3710b.png" width = "881" height = "481">


## 6. 개발 환경

<img src = "https://user-images.githubusercontent.com/86819254/164356250-c046ec42-2688-4925-8796-60dfcd46dc29.png" width = "881" height = "416">

## 7. 개발 일정 

<img src = "https://user-images.githubusercontent.com/86819254/164357250-4d36e742-1e7e-4380-81aa-9abef48abb62.png" width = "859" height = "328">




import requests
from flask import Flask,request
from flask_restful import reqparse
from flask_cors import CORS

app = Flask(__name__)
CORS(app)

@app.route('/kor_to_eng',methods=['POST'])
def kor_to_eng():
    if request.method=='POST':
        parser = reqparse.RequestParser()
        parser.add_argument('text', action='append')
        parser.add_argument('key', action='append')
        args = parser.parse_args()
        keys=args['key']
        print(keys)
        if keys[0]!='aivle':
            return 'reject'
        else:
            target=args['text'][0]
            print('입력:',target)
            url="https://openapi.naver.com/v1/papago/n2mt"
            CLIENT_ID, CLIENT_SECRET = "qxN6CTfMZx5z_Yn7HRxk", "6h6VEfBrED"

            headers={"Content-Type":"application/x-www-form-urlencoded; charset=UTF-8",
                    "X-Naver-Client-Id":CLIENT_ID,
                    "X-Naver-Client-Secret":CLIENT_SECRET}
            params = {"source": "ko", "target": "en", "text": target}
            response = requests.post(url,params,headers=headers)
            target=response.json()['message']['result']['translatedText']
            print('번역:',target)
            return target
@app.route('/eng_to_kor',methods=['POST'])
def eng_to_kor():
    if request.method=='POST':
        parser = reqparse.RequestParser()
        parser.add_argument('text', action='append')
        parser.add_argument('key', action='append')
        args = parser.parse_args()
        keys=args['key']
        print(keys)
        if keys[0]!='aivle':
            return 'reject'
        else:
            target=args['text'][0]
            print('입력:',target)
            url="https://openapi.naver.com/v1/papago/n2mt"
            CLIENT_ID, CLIENT_SECRET = "qxN6CTfMZx5z_Yn7HRxk", "6h6VEfBrED"

            headers={"Content-Type":"application/x-www-form-urlencoded; charset=UTF-8",
                    "X-Naver-Client-Id":CLIENT_ID,
                    "X-Naver-Client-Secret":CLIENT_SECRET}
            params = {"source": "en", "target": "ko", "text": target}
            response = requests.post(url,params,headers=headers)
            target=response.json()['message']['result']['translatedText']
            print('번역:',target)
            return target
@app.route('/home')
def home():
    return 'restful_api'    

if __name__ == '__main__':
    app.run(host='0.0.0.0',port='9995')
    
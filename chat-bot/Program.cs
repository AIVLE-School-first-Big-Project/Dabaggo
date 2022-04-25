using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Genbox.Wikipedia;
using Genbox.Wikipedia.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Google.Cloud.Firestore;

namespace TransforBot
{
    class Program
    {
        DiscordSocketClient client; //봇 클라이언트
        CommandService commands;    //명령어 수신 클라이언트
        List<string> First_Player_List = new List<string>();
        List<string> Two_Player_List = new List<string>();

      
        //파이어베이스
        //json파일은 꼭 실행경로에 저장하셔야합니다.
        FirestoreDb db;
        CollectionReference coll;
        string fireBaseFileName = string.Empty;
        string fireBaseDB = string.Empty;
        string fireBaseCollectionname = string.Empty;
        //파파고
        string papagoKey = string.Empty;
        string papagoSecret = string.Empty;



        static void Main(string[] args)
        {
            new Program().BotMain().GetAwaiter().GetResult();   //봇의 진입점 실행
        }

  
        public async Task BotMain()
        {


            client = new DiscordSocketClient(new DiscordSocketConfig()
            {    //디스코드 봇 초기화
                LogLevel = LogSeverity.Verbose                              //봇의 로그 레벨 설정 
            });
            commands = new CommandService(new CommandServiceConfig()        //명령어 수신 클라이언트 초기화
            {
                LogLevel = LogSeverity.Verbose                              //봇의 로그 레벨 설정
            });

            //로그 수신 시 로그 출력 함수에서 출력되도록 설정
            client.Log += OnClientLogReceived;
            commands.Log += OnClientLogReceived;
            string token = string.Empty;
            string jsonFilePath = $@"{System.Environment.CurrentDirectory}\KEY.json";
            using (StreamReader file = File.OpenText(jsonFilePath))
            using (JsonTextReader readers = new JsonTextReader(file))
            {
                JObject json = (JObject)JToken.ReadFrom(readers);
                token = (string)json["DiscordKEY"].ToString();
                fireBaseFileName = (string)json["fireBaseFileName"].ToString();
                fireBaseDB = (string)json["fireBaseDB"].ToString();
                fireBaseCollectionname = (string)json["fireBaseCollectionname"].ToString();
                papagoKey = (string)json["papagoKey"].ToString();
                papagoSecret = (string)json["papagoSecret"].ToString();
            }

            await client.LoginAsync(TokenType.Bot, token); //봇의 토큰을 사용해 서버에 로그인
            await client.StartAsync();                         //봇이 이벤트를 수신하기 시작



            client.MessageReceived += OnClientMessage;         //봇이 메시지를 수신할 때 처리하도록 설정

            string path = AppDomain.CurrentDomain.BaseDirectory + fireBaseFileName;
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            db = FirestoreDb.Create(fireBaseDB);//타이틀
            coll = db.Collection(fireBaseCollectionname);//디비


            await Task.Delay(-1);   //봇이 종료되지 않도록 블로킹
        }
  

 
        private async Task OnClientMessage(SocketMessage arg)
        {
            //수신한 메시지가 사용자가 보낸 게 아닐 때 취소
            var message = arg as SocketUserMessage;

            if (message == null) return;

            int pos = 0;

            //메시지 앞에 !이 달려있지 않고, 자신이 호출된게 아니거나 다른 봇이 호출했다면 취소
            if (!(message.HasCharPrefix('!', ref pos) ||
             message.HasMentionPrefix(client.CurrentUser, ref pos)) ||
              message.Author.IsBot)
                return;

            var context = new SocketCommandContext(client, message);                    //수신된 메시지에 대한 컨텍스트 생성   

          

            string[] cmd = message.Content.Split(' ');


            bool bExist = false;
            //파파고 API 호출관련..
            string url = "https://openapi.naver.com/v1/papago/n2mt";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", papagoKey);
            request.Headers.Add("X-Naver-Client-Secret", papagoSecret);
            request.Method = "POST";
            string query = string.Empty;
            byte[] byteDataParams;
            Stream st;
            HttpWebResponse response;
            Stream stream;
            StreamReader reader;
            string text = string.Empty;
            JObject jsonData;
            string ResultData;
            switch (cmd[0])
            {
                //영어 -> 한글
                case "!한글":
                  
                     query = cmd[1];
                   byteDataParams = Encoding.UTF8.GetBytes("source=en&target=ko&text=" + query);
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = byteDataParams.Length;
                    st = request.GetRequestStream();
                    st.Write(byteDataParams, 0, byteDataParams.Length);
                    st.Close();
                    response = (HttpWebResponse)request.GetResponse();
                    stream = response.GetResponseStream();
                    reader = new StreamReader(stream, Encoding.UTF8);
                    text = reader.ReadToEnd();
                    jsonData = JObject.Parse(text);
                    ResultData = jsonData["message"]["result"]["translatedText"].ToString();
                    stream.Close();
                    response.Close();
                    reader.Close();
                    await message.Channel.SendMessageAsync(ResultData);
                    await wiki(message, ResultData);



                    break;
                //한글 -> 영어
                case "!영어":
                    query = cmd[1];
                    byteDataParams = Encoding.UTF8.GetBytes("source=ko&target=en&text=" + query);
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = byteDataParams.Length;
                    st = request.GetRequestStream();
                    st.Write(byteDataParams, 0, byteDataParams.Length);
                    st.Close();
                    response = (HttpWebResponse)request.GetResponse();
                    stream = response.GetResponseStream();
                    reader = new StreamReader(stream, Encoding.UTF8);
                    text = reader.ReadToEnd();
                    jsonData = JObject.Parse(text);
                    ResultData = jsonData["message"]["result"]["translatedText"].ToString();
                    stream.Close();
                    response.Close();
                    reader.Close();
                    await message.Channel.SendMessageAsync(ResultData);
                    await wiki(message, ResultData);
                    break;

            }

        }
        //위키관련 API Method
        private async Task wiki(SocketUserMessage msg,string text)
        {
            using (WikipediaClient client = new WikipediaClient())
            {
                WikiSearchRequest req = new WikiSearchRequest(text);
                req.Limit = 1;
                req.WhatToSearch = WikiWhat.Text; //We would like to search inside the articles
                req.WikiLanguage = WikiLanguage.Korean;
                WikiSearchResponse resp = await client.SearchAsync(req).ConfigureAwait(false);

                Console.WriteLine($"Searching for {req.Query}");
                Console.WriteLine();
                Console.WriteLine($"Found {resp.QueryResult.SearchResults.Count} English results:");

                foreach (var s in resp.QueryResult.SearchResults)
                {
                    string ment = s.Snippet.Replace("<span class=\"searchmatch\">", "").Replace("</span>", "");
                    EmbedBuilder eb = new EmbedBuilder();
                    eb.Title = s.Title;
                    eb.AddField($"내용", $"{ment}");
                    eb.AddField($"링크", $"{s.Url}");
                    await msg.Channel.SendMessageAsync("", false, eb.Build());
             
                    Dictionary<string, string> data1 = new Dictionary<string, string>();
                    data1.Add("Title", s.Title);
                    data1.Add("Data", ment);
                    data1.Add("URL", s.Url.ToString());
                    coll.AddAsync(data1);
                }

                
            }

        }

        private void RunLogic(byte[] parm)
        {

        }

     

           
        

       



        private Task OnClientLogReceived(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());  //로그 출력
            return Task.CompletedTask;
        }
    }
    //Fire
 
}

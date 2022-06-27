using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;
using System.Linq;
using SimpleJSON;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    public static AppManager instance;

    void Start()
    {
        var a = "teste";

        StartCoroutine(
            GetRequest(
                (r) =>
                {
                    if (r == null)
                    {
                        Debug.Log("erro ao carregar o jogo");
                    }
                    else
                    {
                        Debug.Log("resultado:" + r["name"]);
                    }
                    // o que eu quero fazer com o resultado da API
                },
                "https://api.ebattle.lamia.sh.utfpr.edu.br/games/4",
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOjEsImVtYWlsIjoiZ3VpbGhlcm1lQGdtYWlsLmNvbSIsImlhdCI6MTY1NTI0NDgxNywiZXhwIjoxNjU1MjQ4NDE3fQ.LBUUywjvThdUSrSMJ0GRrifE25RieY0HYtKLy8KbbuI"
            )
        );

        //StartCoroutine(GetRequest(Processar,"https://api.ebattle.lamia.sh.utfpr.edu.br/games/4", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOjEsImVtYWlsIjoiZ3VpbGhlcm1lQGdtYWlsLmNvbSIsImlhdCI6MTY1MjA2NjEzNCwiZXhwIjoxNjUyMDY5NzM0fQ.c8NKzqf0bL4aO5YKT1lnMhG5ylw2uOyvcPPQH4jiyWw"));
        //StartCoroutine(SendData());
    }

    IEnumerator SendData(Action<bool> action, string uri, string token)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", "guilherme@gmail.com");
        form.AddField("password", "guilherme");

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + token);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                action(false);
            }
            else
            {
                Debug.Log("Form upload complete!");
                Debug.Log(www.downloadHandler.text);
                action(true);
            }
        }
    }

    IEnumerator GetRequest(Action<JSONNode> action, string uri, string token)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            webRequest.SetRequestHeader("Authorization", "Bearer " + token);
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    action(null);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP Error: " + webRequest.error);
                    action(null);
                    break;
                case UnityWebRequest.Result.Success:
                    //Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                    var jsonResult = JSON.Parse(webRequest.downloadHandler.text);
                    action(jsonResult);
                    //Debug.Log(jsonResult["name"]);
                    break;
            }
        }
    }
}
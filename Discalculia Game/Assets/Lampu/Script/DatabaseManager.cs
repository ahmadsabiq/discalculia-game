using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class DatabaseManager : MonoBehaviour
{
    public static IEnumerator InsertData(int attempt, string tittle, string level, string question)
    {
        WWWForm form = new WWWForm();
        form.AddField("attempt", attempt);
        form.AddField("tittle", tittle);
        form.AddField("level", level);
        form.AddField("question", question);
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/unitytestdb/insertmodule.php", form);
        yield return request.SendWebRequest();
        request.Dispose();
    }
}

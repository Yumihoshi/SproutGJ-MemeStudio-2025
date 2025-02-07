using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using System.Collections.Generic;
using System;

public class GameJamSaveSystem
{
    public static Dictionary<string, UserData> usersData = new Dictionary<string, UserData>();

    public static char[] keyChars = { 'a', 'b', 'c', 'd', 'e' };

    public static string Encrypt(string data)
    {
        char[] dataChars = data.ToCharArray();
        for (int i = 0; i < dataChars.Length; i++)
        {
            char dataChar = dataChars[i];
            char keyChar = keyChars[i % keyChars.Length];
            char newChar = (char)(dataChar ^ keyChar);
            dataChars[i] = newChar;
        }
        return new string(dataChars);
    }

    public static string Decrypt(string data)
    {
        return Encrypt(data);
    }

    public static void SaveData(UserData userData)
    {

        if (!File.Exists(Application.streamingAssetsPath + "/GameJamSaveSystem"))
        {
            System.IO.Directory.CreateDirectory(Application.streamingAssetsPath + "/GameJamSaveSystem");
        }

        usersData[userData.filename] = userData;

        string jsonData = JsonConvert.SerializeObject(userData);

        File.WriteAllText(Application.streamingAssetsPath + string.Format("/GameJamSaveSystem/{0}.json", userData.filename), jsonData);
    }

    public static UserData LoadData(string userName)
    {

        if (usersData.ContainsKey(userName))
        {
            return usersData[userName];
        }

        string path = Application.streamingAssetsPath + string.Format("/GameJamSaveSystem/{0}.json",userName);

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);

            UserData userData = JsonConvert.DeserializeObject<UserData>(jsonData);
            return userData;
        }
        else
        {
            return null;
        }
    }
}

[Serializable]
public class UserData
{
    [Header("文件名")]
    [ReadOnly]
    public string filename;
    [Header("时间")]
    [ReadOnly]
    public string time;
    [Header("关卡")]
    [ReadOnly]
    public int level;
    [Header("进度")]
    [ReadOnly]
    public float process;
    [Header("玩家位置")]
    [ReadOnly]
    public Vector2 pos;


    public UserData(string filename,string time, int level,float process,Vector2 pos)
    {
        this.filename = filename;
        this.time = time;
        this.level = level;
        this.process = process;
        this.pos = pos;
    }
}

public class Vector2Pos
{
    public float X;
    public float Y;

    public Vector2Pos(float X,float Y)
    {
        this.X = X;
        this.Y = Y;
    }

}

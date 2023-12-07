using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

//Example!!!!!!!!
public class Global : MonoBehaviour
{
    public class Homework
    {
        public DateTime Date;
        public string Title, Description;
    }

    public static class Homeworks
    {
        public static List<Homework> Data = new List<Homework>();
        private static readonly string DataPath = Path.Combine(Application.dataPath, "data.json");
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        public static void Save()
        {
            File.WriteAllText(DataPath, JsonConvert.SerializeObject(Data, Settings));
        }
        public static void Load()
        {
            if (!File.Exists(DataPath))
            {
                Data = new List<Homework>();
            }
            else
            {
                Data = JsonConvert.DeserializeObject<List<Homework>>(File.ReadAllText(DataPath));
            }
        }
    }
}
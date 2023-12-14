using System;
using System.IO;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;

public class Saver : IDisposable
{
    private string _filePath;

    private SaveData _data;

    public Saver()
    {
        _filePath = Application.persistentDataPath + "/Save.json";
        Application.quitting += () => Save(_data);
    }

    public void Save(SaveData data)
    {
        string json = JsonConvert.SerializeObject(data);
        using (var writer = new StreamWriter(_filePath))
        {
            writer.WriteLine(json);
        }
    }

    public SaveData Load()
    {
        var json = "";

        using (var reader = new StreamReader(_filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
                json += line;
        }
        
        _data = string.IsNullOrEmpty(json)
            ? _data = new SaveData()
            : _data = JsonConvert.DeserializeObject<SaveData>(json);

        return _data;
    }

    public void Dispose()
    {
        Application.quitting -= () => Save(_data);
    }
}
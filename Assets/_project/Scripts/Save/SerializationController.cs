using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SerializationController : MonoBehaviour
{
    public static Data ReadFile(string fileName, bool isLavito)
    {
        string filePath = Application.persistentDataPath + "/" + fileName;
        Debug.Log(filePath);

        Type type = isLavito ? typeof(LavitoData) : typeof(MoneyData);
        XmlSerializer serializer = new(type);
        Stream stream = File.OpenRead(filePath);

        var file = (Data)serializer.Deserialize(stream);
        stream.Close();
        return file;
    }

    public static void SaveFile(Data file, string fileName)
    {
        string filePath = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(filePath)) File.Delete(filePath);

        Type type;
        try
        {
            LavitoData data = (LavitoData)file;
            type = typeof(LavitoData);
        }
        catch
        {
            type = typeof(MoneyData);
        }
        /*
       Type type;
         
       if (file != null)
           type = typeof(LavitoData);
       else if ((MoneyData)file != null)
           type = typeof(MoneyData);
       else if ((TaskTreeData)file != null)
           type = typeof(TaskTreeData);
       else
           return;
        */
        var serializer = new XmlSerializer(type);
        var writer = File.OpenWrite(filePath);

        serializer.Serialize(writer, file);
        writer.Close();
    }
}

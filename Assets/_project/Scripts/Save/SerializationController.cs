using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SerializationController : MonoBehaviour
{
    public static Data ReadFile(string fileName, Type type)
    {
        string filePath = Application.persistentDataPath + "/" + fileName;

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

        Type type = file.GetType(); ;

        var serializer = new XmlSerializer(type);
        var writer = File.OpenWrite(filePath);

        serializer.Serialize(writer, file);
        writer.Close();
    }
}

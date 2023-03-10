using System;
using System.IO;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    [SerializeField] FileAbstraction[] _files;
    static FileAbstraction[] _staticFiles;

    private void Start()
    {
        _staticFiles = _files;
        foreach (FileAbstraction file in _files)
            if (File.Exists(Application.persistentDataPath + "/" + file.GetFileName()))
                Read(file);

        foreach (FileAbstraction file in _files)
            Save(file);
    }

    public static void Save(FileAbstraction file)
    {
        SerializationController.SaveFile(file.GetData(), file.GetFileName());
    }

    public static void Save(string fileName)
    {
        foreach (FileAbstraction file in _staticFiles)
            if (file.GetFileName() == fileName)
                SerializationController.SaveFile(file.GetData(), fileName);
    }

    public void ResetSaves()
    {
        foreach (FileAbstraction file in _files)
            File.Delete(Application.persistentDataPath + "/" + file.GetFileName());
        PlayerPrefs.DeleteAll();
    }

    private void Read(FileAbstraction file)
    {
        Type needType = GetDataFileType(file);

        file.SetData(SerializationController.ReadFile(file.GetFileName(), needType));
    }


    private Type GetDataFileType(FileAbstraction file)
    {
        Type type = file.GetType();

        if (type == typeof(LavitoPositionsFile))
            return typeof(LavitoData);
        else if (type == typeof(TaskTreeFile))
            return typeof(TaskTreeData);
        else if (type == typeof(MoneyFile))
            return typeof(MoneyData);
        return null;
    }
}

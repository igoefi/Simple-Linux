using System.Collections;
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
        {
            if (File.Exists(Application.persistentDataPath + "/" + file.GetFileName()))
                Read(file);
            else
                Save(file);
        }
    }

    public static void Save(FileAbstraction file)
    {
        SerializationController.SaveFile(file.GetData(), file.GetFileName());
    }

    public static void Save(string fileName)
    {
        foreach (var file in _staticFiles)
            if(file.GetFileName() == fileName)
                SerializationController.SaveFile(file.GetData(), fileName);
    }

    private void Read(FileAbstraction file)
    {
        Data ReadFile = SerializationController.ReadFile(file.GetFileName(), (LavitoPositionsFile)file != null);

        file.SetData(ReadFile);
    }

}

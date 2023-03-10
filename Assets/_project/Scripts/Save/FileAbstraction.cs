using UnityEngine;

public abstract class FileAbstraction : MonoBehaviour
{
    protected string _fileName = "file.json";

    public string GetFileName()
    {
        return _fileName;
    }

    public abstract void SetData(Data data);

    public abstract Data GetData();
}

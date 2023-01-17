using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class FileAbstraction : MonoBehaviour
{
    protected string _fileName = "y.json";

    public string GetFileName()
    {
        return _fileName;
    }

    public abstract void SetData(Data data);

    public abstract Data GetData();
}

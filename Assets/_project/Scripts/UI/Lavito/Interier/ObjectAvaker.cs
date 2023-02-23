using UnityEngine;

public class ObjectAvaker : MonoBehaviour
{
    [SerializeField] LavitoPositionsFile _file;
    [SerializeField] InterierObject[] _objects;
    void Start()
    {
        CheckObjectActive();

        LavitoAPI.BuySomething.AddListener(CheckObjectActive);
    }

    private void CheckObjectActive()
    {
        LavitoPosition[] objects = _file.GetInteriers();

        foreach (InterierObject obj in _objects)
            foreach (LavitoPosition fileObj in objects)
                if (fileObj.Compare(obj.getName()) && fileObj.IsBuy == true)
                    obj.gameObject.SetActive(true);
    }

}

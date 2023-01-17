using UnityEngine;
using UnityEngine.UI;

public class InterierObject : MonoBehaviour
{
    [SerializeField] string _name;

    public string getName()
    {
        return _name;
    }
}

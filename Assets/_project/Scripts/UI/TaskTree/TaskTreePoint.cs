using UnityEngine;

public class TaskTreePoint : MonoBehaviour
{
    [SerializeField] string _levelName;

    [SerializeField] int _money;

    private bool _isPassed;

    public void SetIsPassedTrue() => _isPassed = true;

    public bool GetIsPassed() => _isPassed;

    public int GetMoney() => _money;

    public string GetLevelName() => _levelName;

}

using UnityEngine;

public class TaskTreePoint : MonoBehaviour
{
    [SerializeField] string _levelName;

    [SerializeField] float _maxMoney;
    [SerializeField] float _minMoney;
    [SerializeField] float _maxNormalTime;

    public Time Time { get; private set; } = new();
    public float MoneyTaken { get; private set; } = 0;
    public bool IsPassed { get; private set; } = false;

    public void SetIsPassedTrue(Time time, float moneyTaken)
    {
        IsPassed = true;
        Time= time;
        MoneyTaken = moneyTaken;
    }

    public string GetLevelName()
    {
        return _levelName;
    }
}

using System.Collections.Generic;

[System.Serializable]
public abstract class Data
{
    public Data()
    {

    }
}

[System.Serializable]
public class LavitoData : Data
{
    public List<LavitoPositionData> InterierPositions;
    public List<LavitoPositionData> AvatarPositions;

    public void SetInterierPosition(LavitoPosition[] positions)
    {
        InterierPositions = new();
        foreach (LavitoPosition position in positions)
            InterierPositions.Add(new LavitoPositionData { Name = position.GetName(), IsBuy = position.IsBuy });
    }
    public void SetAvatarPosition(LavitoPosition[] positions)
    {
        AvatarPositions = new();
        foreach (LavitoPosition position in positions)
            AvatarPositions.Add(new LavitoPositionData { Name = position.GetName(), IsBuy = position.IsBuy });
    }
}

[System.Serializable]
public class TaskTreeData : Data
{
    public List<TaskTreePointData> _points;

    public void SetTaskTreePoint(TaskTreePoint[] points)
    {
        _points = new();
        foreach (TaskTreePoint point in points)
            _points.Add(new TaskTreePointData
            {
                Name = point.GetLevelName(),
                Money = point.GetMoney(),
                IsPassed = point.GetIsPassed(),
            });
    }
}

public class MoneyData : Data
{
    public int Money;
}

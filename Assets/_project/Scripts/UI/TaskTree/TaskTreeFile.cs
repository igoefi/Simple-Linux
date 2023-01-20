using UnityEngine;
using UnityEngine.UIElements;

public class TaskTreeFile : FileAbstraction
{
    [SerializeField] TaskTreePoint[] _points;

    public TaskTreeFile()
    {
        _fileName = "TaskTree.json";
    }

    public override void SetData(Data data)
    {
        var needFile = (TaskTreeData)data;

        if (needFile == null) return;

        foreach(var point in _points)
            foreach(var dataPoint in needFile._points)
                if (point.GetLevelName() == dataPoint.Name)
                {
                    if (dataPoint.IsPassed == true)
                        point.SetIsPassedTrue(dataPoint.Time, dataPoint.MoneyTaken);
                    break;
                }
    }


    public TaskTreePoint[] GetValues()
    {
        return _points;
    }

    public override Data GetData()
    {
        var data = new TaskTreeData();
        data.SetTaskTreePoint(_points);

        return data;
    }
}


using UnityEngine;

public class TaskTreeFile : FileAbstraction
{
    [SerializeField] TaskTreePoint[] _points;

    public TaskTreeFile()
    {
        _fileName = "TaskTree.xml";
    }

    public override void SetData(Data data)
    {
        TaskTreeData needFile = (TaskTreeData)data;

        if (needFile == null) return;

        foreach (TaskTreePoint point in _points)
            foreach (TaskTreePointData dataPoint in needFile._points)
                if (point.GetLevelName() == dataPoint.Name)
                {
                    if (dataPoint.IsPassed == true)
                        point.SetIsPassedTrue();
                    break;
                }
    }


    public TaskTreePoint[] GetValues()
    {
        return _points;
    }

    public override Data GetData()
    {
        TaskTreeData data = new();
        data.SetTaskTreePoint(_points);

        return data;
    }
}


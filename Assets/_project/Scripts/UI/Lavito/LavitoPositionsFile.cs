using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LavitoPositionsFile : FileAbstraction
{
    public static UnityEvent SaveEvent = new();

    [SerializeField] LavitoPosition[] _interierPositions;
    [SerializeField] LavitoPosition[] _avatarPositions;

    LavitoPositionsFile()
    {
        _fileName = "Lavito.xml";
        SaveEvent.AddListener(Save);
    }

    private void Save()
    {
        FileManager.Save(_fileName);
    }

    public LavitoPosition[] GetInteriers()
    {
        return _interierPositions;
    }

    public LavitoPosition[] GetAvatars()
    {
        return _avatarPositions;
    }

    public override void SetData(Data data)
    {
        LavitoData needFile = (LavitoData)data;
        if (needFile == null) return;

        SetIsBuyInArray(_interierPositions, needFile.InterierPositions);
        SetIsBuyInArray(_avatarPositions, needFile.AvatarPositions);

        PositionSelector.BuyUpdate.Invoke();
    }

    public override Data GetData()
    {
        LavitoData data = new();
        data.SetInterierPosition(_interierPositions);
        data.SetAvatarPosition(_avatarPositions);

        return data;
    }

    private void SetIsBuyInArray(LavitoPosition[] positions, List<LavitoPositionData> dataPositions)
    {
        foreach (LavitoPosition position in positions)
            foreach (LavitoPositionData dataPosition in dataPositions)
                if (position.GetName() == dataPosition.Name)
                {
                    if (dataPosition.IsBuy == true)
                        position.SetIsBuyTrue();
                    break;
                }
    }
}

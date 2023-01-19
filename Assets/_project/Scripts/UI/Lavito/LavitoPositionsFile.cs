using System.Collections.Generic;
using Unity.VisualScripting;
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
        Debug.Log("Set Data");
        var needFile = (LavitoData)data;
        if (needFile == null) return;
        Debug.Log("Really Set Data");

        SetIsBuyInArray(_interierPositions, needFile.InterierPositions);
        SetIsBuyInArray(_avatarPositions, needFile.AvatarPositions);

        PositionSelector.BuyUpdate.Invoke();
    }

    public override Data GetData()
    {
        var data = new LavitoData();
        data.SetInterierPosition(_interierPositions);
        data.SetAvatarPosition(_avatarPositions);

        return data;
    }

    private void SetIsBuyInArray(LavitoPosition[] positions, List<LavitoPositionData> dataPositions)
    {
        foreach (var position in positions)
            foreach (var dataPosition in dataPositions)
                if (position.GetName() == dataPosition.Name)
                {
                    if (dataPosition.IsBuy == true)
                        position.SetIsBuyTrue();
                    break;
                }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyFile : FileAbstraction
{
    public static UnityEvent ChangeMoney { get; private set; } = new();

    public static int Money { get; private set; }

    public MoneyFile()
    {
        _fileName = "Money.xml";
        Money = 0;
    }

    public bool PlusMoney(int moneyPlus)
    {
        if (Money + moneyPlus < 0) return false;

        Money += moneyPlus;
        ChangeMoney.Invoke();
        FileManager.Save(_fileName);
        return true;
    }

    public override void SetData(Data data)
    {
        var needFile = (MoneyData)data;
        if (needFile == null) return;

        Money = needFile.Money;
        ChangeMoney.Invoke();
    }

    public override Data GetData()
    {
        return new MoneyData() { Money = Money };
    }
}

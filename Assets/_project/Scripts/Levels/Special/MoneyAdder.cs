using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyAdder : MonoBehaviour
{
    [SerializeField] MoneyFile _file;
    [SerializeField] int _needMoneyToAdd;

    private void Start()
    {
        _file.PlusMoney(_needMoneyToAdd);
    }
}

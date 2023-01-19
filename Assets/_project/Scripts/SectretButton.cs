using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectretButton : MonoBehaviour
{
    [SerializeField] MoneyFile file;

    public void MONEY()
    {
        file.PlusMoney(100);
    }
}

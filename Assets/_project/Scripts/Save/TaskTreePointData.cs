using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTreePointData 
{
    public string Name;
    public int Money;
    public bool IsPassed;

    public void SetIsPassedTrue() =>
        IsPassed = true;
}

using UnityEngine;

public class SectretButton : MonoBehaviour
{
    [SerializeField] MoneyFile file;

    public void MONEY()
    {
        file.PlusMoney(100);
    }
}

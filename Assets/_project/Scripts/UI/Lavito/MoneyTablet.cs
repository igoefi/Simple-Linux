using TMPro;
using UnityEngine;

public class MoneyTablet : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public MoneyTablet() =>
        MoneyFile.ChangeMoney.AddListener(SetMoneyText);

    private void SetMoneyText() =>
        text.text = MoneyFile.Money.ToString();
}

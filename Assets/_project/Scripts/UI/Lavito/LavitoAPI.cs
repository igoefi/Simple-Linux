using UnityEngine;
using UnityEngine.Events;

public class LavitoAPI : MonoBehaviour
{
    public static UnityEvent BuySomething { get; private set; } = new();

    [SerializeField] GameObject _BGCharter;
    [SerializeField] LavitoPositionsFile lavitoPositions;
    [SerializeField] PositionSelector positionSelector;

    void OnEnable() =>
        positionSelector.SetPositions(positionSelector.IsInterier ? lavitoPositions.GetInteriers()
            : lavitoPositions.GetAvatars(), 0);

    public void SelectCharter(GameObject BGCharter)
    {
        if (_BGCharter == BGCharter) return;

        _BGCharter.SetActive(false);

        BGCharter.SetActive(true);
        _BGCharter = BGCharter;

        positionSelector.SelectCharter();
        positionSelector.SetPositions(positionSelector.IsInterier ? lavitoPositions.GetInteriers()
            : lavitoPositions.GetAvatars(), 0);
    }

    public void Listing(bool isNext)
    {
        positionSelector.SetPositions(positionSelector.IsInterier ? lavitoPositions.GetInteriers()
            : lavitoPositions.GetAvatars(), isNext ? 1 : -1);
    }

    public void Buy(Position position)
    {
        position.SetBuyIsTrue();
        BuySomething.Invoke();
    }
}

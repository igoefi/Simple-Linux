using TMPro;
using UnityEngine;

public class TaskTreePointInterface : MonoBehaviour
{
    [SerializeField] TMP_Text _moneyText;
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _completeText;

    [SerializeField] GameObject _startButton;
    [SerializeField] TaskTreePoint _behaindPoint;

    private const string _ifCompleteText = "пройден";
    private const string _ifUncompleteText = "непройден";

    private bool _isPassed;

    private void Start()
    {
        TaskTreePoint pointInfo = gameObject.GetComponent<TaskTreePoint>();
        _moneyText.text = pointInfo.GetMoney().ToString();
        _nameText.text = pointInfo.GetLevelName();
        _completeText.text = pointInfo.GetIsPassed() ? _ifCompleteText : _ifUncompleteText;
        _isPassed = pointInfo.GetIsPassed();

        if (_behaindPoint != null)
            _startButton.SetActive(_behaindPoint.GetIsPassed());
    }

    public void OpenCloseMenu(GameObject menu) =>
        menu.SetActive(!menu.activeSelf);

    public bool GetIsPassed() => _isPassed;
}

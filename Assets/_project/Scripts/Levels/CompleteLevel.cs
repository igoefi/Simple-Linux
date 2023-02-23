using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] TMP_Text _moneyText;
    [SerializeField] int _levelNum;

    public CompleteLevel() =>
        DialogueController.EndDialogueEvent.AddListener(LevelComplete);

    public void LevelComplete()
    {
        gameObject.SetActive(true);

        TaskTreeData taskData = (TaskTreeData)SerializationController.ReadFile(new TaskTreeFile().GetFileName(), typeof(TaskTreeData));

        MoneyData moneyData = (MoneyData)SerializationController.ReadFile(new MoneyFile().GetFileName(), typeof(MoneyData));

        bool isPassed = taskData._points[_levelNum].IsPassed;

        if (isPassed) return;

        int money = taskData._points[_levelNum].Money;
        moneyData.Money += money;
        _moneyText.text = isPassed ? "0" : money.ToString();

        SerializationController.SaveFile(moneyData, new MoneyFile().GetFileName());

        taskData._points[_levelNum].SetIsPassedTrue();
        SerializationController.SaveFile(taskData, new TaskTreeFile().GetFileName());
    }

    public void ToMainButton() =>
        SceneManager.LoadScene("MainScene");
}

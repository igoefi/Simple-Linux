using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] TMP_Text _moneyText;
    [SerializeField] int _levelNum;

    public CompleteLevel() =>
        DialogueController.EndDialogue.AddListener(LevelComplete);

    public void LevelComplete()
    {
        gameObject.SetActive(true);

        TaskTreeData taskData = (TaskTreeData)SerializationController.ReadFile(new TaskTreeFile().GetFileName(), typeof(TaskTreeData));
        taskData._points[_levelNum].SetIsPassedTrue();
        SerializationController.SaveFile(taskData, new TaskTreeFile().GetFileName());

        _moneyText.text = taskData._points[_levelNum].Money.ToString();
        MoneyData moneyData = (MoneyData)SerializationController.ReadFile(new MoneyFile().GetFileName(), typeof(MoneyData));
        moneyData.Money += taskData._points[_levelNum].Money;
        SerializationController.SaveFile(moneyData, new MoneyFile().GetFileName());
    }

    public void ToMainButton() =>
        SceneManager.LoadScene("MainScene");
}

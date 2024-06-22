using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance => instance;
    private static UIManager instance;

    public GameObject questionPanel;
    public TMP_Text questionText;
    public Button[] answerButtons;
    public GameObject[] chanceHeart;
    public Sprite falseHeart;
    public Sprite trueHeart;

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("Only 1 UIManager allow to exist!");
        instance = this;
    }

    public void DisplayQuestion(string question, string[] answers, int chances)
    {
        questionPanel.SetActive(true);
        questionText.text = question;

        if (answers.Length != answerButtons.Length)
        {
            Debug.LogError("The number of answers provided does not match the number of answer buttons.");
            return;
        }

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < answers.Length)
            {
                answerButtons[i].GetComponentInChildren<TMP_Text>().text = answers[i];
                answerButtons[i].onClick.RemoveAllListeners();
                int index = i; // Capture the index to avoid closure issue
                answerButtons[i].onClick.AddListener(() => GameManager.Instance.OnSubmitAnswer(answers[index]));
            }
            else
            {
                Debug.LogError($"Answer Button {i} is out of bounds for the provided answers.");
            }
        }
    }

    public void UpdateChances(int chances)
    {
        chanceHeart[chances].GetComponent<Image>().sprite = falseHeart;
    }

    public void HideQuestionPanel()
    {
        ResetHeart();
        questionPanel.SetActive(false);
    }

    public void ResetHeart()
    {
        foreach (var item in chanceHeart)
        {
            item.GetComponent<Image>().sprite = trueHeart;
        }
    }

}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Paused,
        Playing
    }

    public static GameManager Instance => instance;
    private static GameManager instance;

    private GameState gameState = GameState.Playing;

    private GameObject currentAnimal;
    private int chances = 3;
    private string correctAnswer;

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("Only 1 GameManager allow to exist!");
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ShowQuestion(GameObject animal, string question, string[] answers, string correct)
    {
        UpdateGameState(GameState.Paused);
        currentAnimal = animal;
        correctAnswer = correct;
        chances = 3;
        UIManager.Instance.DisplayQuestion(question, answers, chances);
    }

    public void OnSubmitAnswer(string selectedAnswer)
    {
        if (selectedAnswer == correctAnswer)
        {
            UpdateGameState(GameState.Playing);
            CatchAnimal();
        }
        else
        {
            chances--;
            UIManager.Instance.UpdateChances(chances);
            if (chances <= 0)
            {
                UpdateGameState(GameState.Playing);
                AnimalRunsAway();
            }
        }
    }

    private void CatchAnimal()
    {
        if (currentAnimal != null)
        {
            AnimalMovement animalMovement = currentAnimal.GetComponent<AnimalMovement>();
            if (animalMovement != null)
            {
                animalMovement.CaptureAnimal();
            }
            UIManager.Instance.HideQuestionPanel();
            FarmManager.Instance.AddAnimalToFarm(currentAnimal);
            currentAnimal = null;
        }
        // Logic to catch the animal
    }

    private void AnimalRunsAway()
    {
        UIManager.Instance.HideQuestionPanel();
        // Logic to make the animal run away
    }

    private void UpdateGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Paused:
                HandlePausedState();
                break;
            case GameState.Playing:
                HandlePlayingState();
                break;
        }
    }

    private void HandlePausedState()
    {
        Time.timeScale = 0f;
        gameState = GameState.Paused;
    }

    private void HandlePlayingState()
    {
        Time.timeScale = 1f;
        gameState = GameState.Playing;
    }
}

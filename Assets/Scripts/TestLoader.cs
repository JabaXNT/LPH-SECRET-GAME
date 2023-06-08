using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TestLoader : MonoBehaviour
{
    public static bool isVisible = false;
    public Text questionText;
    public Button answer1Button;
    public Button answer2Button;
    public Button answer3Button;
    public Button answer4Button;
    public Button nextQuestionButton;
    private List<string> questions = new List<string>();
    private List<string[]> answers = new List<string[]>();
    private string TestNumber;
    private List<int> rightAnswerIndex = new List<int>(); // Изменено: правильные ответы теперь хранятся в списке int
    private int currentTestResults = 0;
    private int currentQuestion = 0;
    private int currentRightAnswer = 0;
    private bool answered;
    private SummaryData objectData;
    public bool imageDisplay;
    private void Start()
    {
        objectData = SummaryData.currentChapter;
        if (objectData == null)
        {
            LoadTest("testFinal");
        }
        else 
        {
            Debug.Log(objectData.testPath);
            LoadTest(objectData.testPath);
        }
        DisplayQuestion();
    }

    private void LoadTest(string fileName)
    {
        string filePath = Path.Combine("Assets/Tests/", fileName + ".txt");
        string[] lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i += 6)
        {
            questions.Add(lines[i]);
            answers.Add(new string[4] { lines[i + 1], lines[i + 2], lines[i + 3], lines[i + 4] });
            rightAnswerIndex.Add(int.Parse(lines[i + 5]) - 1);
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = questions[currentQuestion];
        answer1Button.GetComponentInChildren<Text>().text = answers[currentQuestion][0];
        answer2Button.GetComponentInChildren<Text>().text = answers[currentQuestion][1];
        answer3Button.GetComponentInChildren<Text>().text = answers[currentQuestion][2];
        answer4Button.GetComponentInChildren<Text>().text = answers[currentQuestion][3];
        currentRightAnswer = rightAnswerIndex[currentQuestion];
        // Reset button colors and disable answer buttons
        answer1Button.image.color = Color.clear;
        answer2Button.image.color = Color.clear;
        answer3Button.image.color = Color.clear;
        answer4Button.image.color = Color.clear;
        answer1Button.interactable = true;
        answer2Button.interactable = true;
        answer3Button.interactable = true;
        answer4Button.interactable = true;
        nextQuestionButton.gameObject.SetActive(false);
    }


    public void CheckAnswer(int answerIndex)
    {
        if (!answered)
        {
            answered = true;
            if (answerIndex == currentRightAnswer)
            {
                Debug.Log("Correct!");
                switch (answerIndex)
                {
                    case 0:
                        answer1Button.image.color = Color.green;
                        break;
                    case 1:
                        answer2Button.image.color = Color.green;
                        break;
                    case 2:
                        answer3Button.image.color = Color.green;
                        break;
                    case 3:
                        answer4Button.image.color = Color.green;
                        break;
                }
                currentTestResults++;
                TestResults.numCorrectAnswers++; // заполнение прогресс бара на главном экране не работает...
            }
            else
            {
                Debug.Log("Incorrect!");
                switch (answerIndex)
                {
                    case 0:
                        answer1Button.image.color = Color.red;
                        break;
                    case 1:
                        answer2Button.image.color = Color.red;
                        break;
                    case 2:
                        answer3Button.image.color = Color.red;
                        break;
                    case 3:
                        answer4Button.image.color = Color.red;
                        break;
                }

                switch (currentRightAnswer)
                {
                    case 0:
                        answer1Button.image.color = Color.green;
                        break;
                    case 1:
                        answer2Button.image.color = Color.green;
                        break;
                    case 2:
                        answer3Button.image.color = Color.green;
                        break;
                    case 3:
                        answer4Button.image.color = Color.green;
                        break;
                }
            }

            answer1Button.interactable = false;
            answer2Button.interactable = false;
            answer3Button.interactable = false;
            answer4Button.interactable = false;

            nextQuestionButton.gameObject.SetActive(true);
        }
    }

    public void NextQuestion()
    {
        currentQuestion++;

        if (currentQuestion >= questions.Count)
        {
            // Hide answer buttons and display test completion message
            answer1Button.gameObject.SetActive(false);
            answer2Button.gameObject.SetActive(false);
            answer3Button.gameObject.SetActive(false);
            answer4Button.gameObject.SetActive(false);

            // Set test completion message
            questionText.text = "Тест пройден: " + currentTestResults + "/" + questions.Count + " Правильно";
            isVisible = true;
            nextQuestionButton.GetComponentInChildren<Text>().text = "Вернуться в главное меню";
            nextQuestionButton.onClick.AddListener(() =>
            {
                imageDisplay = false;
                SceneManager.LoadScene("MainScreen");
            });
        }
        else
        {
            answered = false;
            answer1Button.interactable = true;
            answer2Button.interactable = true;
            answer3Button.interactable = true;
            answer4Button.interactable = true;

            nextQuestionButton.gameObject.SetActive(false);

            DisplayQuestion();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;

    public bool gamePlaying {  get; private set; }

    public List<QuestionAndAnswer> QnA;
    public GameObject[] option;
    public int currentQuestion;
    public Image questionImage;

    public GameObject Quizpanel;
    public GameObject GOPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;


    int totalQuestions = 0;
    public int score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        totalQuestions = QnA.Count;
        GOPanel.SetActive(false);
        generateQuestion();
        gamePlaying = false;

        BeginGame();
    }

    private void BeginGame()
    {
        gamePlaying = true;
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Quizpanel.SetActive(false);
        GOPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswer()
    {
        for (int i = 0; i < option.Length; i++)
        {
            option[i].GetComponent<AnswerScript>().isCorrect = false;
            option[i].transform.GetChild(0).GetComponent<Image>().sprite = QnA[currentQuestion].Answer[i];

            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                option[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            questionImage.sprite = QnA[currentQuestion].spriteQuestion;
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of Question");
            GameOver();
        }
       
    }

}

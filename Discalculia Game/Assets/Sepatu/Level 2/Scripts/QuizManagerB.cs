using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManagerB : MonoBehaviour
{
    public static QuizManagerB Instance;

    public List<QuestionAndAnswerB> QnA;
    public GameObject[] option;
    public int currentQuestion;
    private int numOfRepeats;

    public GameObject QuizPanel;
    public GameObject GOPanel;

    public TMP_Text QuestionTxt;
    public AudioSource src;

    int totalQuestion = 0;

    private string nama;
    private string tittle = "Sepatu";
    public string level;
    public string question;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        totalQuestion = QnA.Count;
        GOPanel.SetActive(false);
        QuizPanel.SetActive(true);
        generateQuestion();
        //SoundManager.singleton.PlaySound();
    }

    public void AddData()
    {
        nama = PlayerPrefs.GetString("name");
        Debug.Log("Player name is: " + nama);
        StartCoroutine(DatabaseManager.InsertData(nama, totalQuestion, tittle, level, question));
    }

    /*public void Retry()
    {
        //back to the first question
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/

    public void GameOver()
    {
        GOPanel.SetActive(true);
        QuizPanel.SetActive(false);
    }

    public IEnumerator correct(AudioClip Clip)
    {
        src.clip = Clip;
        src.Play();
        QnA.RemoveAt(currentQuestion);
        yield return new WaitForSeconds(3.5f);
        generateQuestion();
    }

    public void incorrect(AudioClip Clip)
    {
        src.clip = Clip;
        src.Play();
        repeatQuestion();
    }

    void SetAnswers()
    {
        for(int i = 0; i < option.Length; i++)
        {
            option[i].transform.GetChild(0).GetComponent<Image>().sprite = QnA[currentQuestion].Answer[i];

            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                option[i].GetComponent<Answers>().isCorrect = true;
                option[i].GetComponent<Answers>().sound = QnA[currentQuestion].correctAudio;
            }
            else if (QnA[currentQuestion].WrongAnswer1 == i + 1)
            {
                option[i].GetComponent<Answers>().isCorrect = false;
                option[i].GetComponent<Answers>().sound = QnA[currentQuestion].incorrectAudio1;
            }
            else if (QnA[currentQuestion].WrongAnswer2 == i + 1)
            {
                option[i].GetComponent<Answers>().isCorrect = false;
                option[i].GetComponent<Answers>().sound = QnA[currentQuestion].incorrectAudio2;
            }
        }    
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            //ques.transform.GetChild(0).GetComponent<Image>().sprite = QnA[currentQuestion].quesAudio;
            //quesSound.clip = QnA[currentQuestion].questionSoundClip;
            currentQuestion = Random.Range(0, QnA.Count); //randomized question
            QuestionTxt.text = QnA[currentQuestion].Question; //set question
            QuestionSound();
            SetAnswers();        
        }
        else
        {
            AddData();
            Debug.Log("Out of Questions");
            GameOver();
        }
    }

    public void QuestionSound()
    {
        src.clip = QnA[currentQuestion].quesAudio;
        src.Play();
    }

    void repeatQuestion()
    {
        numOfRepeats++;
        Debug.Log(numOfRepeats);

        if(QnA.Count > 0)
        {
            //currentQuestion = currentQuestion;
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();        
        }
    }
}

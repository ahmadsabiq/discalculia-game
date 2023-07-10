using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] option;
    public int currentQuestion;

    public UnityEngine.UI.Text QuestionTxt;

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswer()
    {
        for (int i = 0; i < option.Length; i++)
        {
            option[i].GetComponent<AnswerScript>().isCorrect = false;
            option[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answer[i];

            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                option[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswer();

       
    }

}

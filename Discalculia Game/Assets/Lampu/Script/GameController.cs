using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Button Option
    public LampController[] sequence;
    private List<LampController> Answers = new();
    public List<SwitchSprite> SwitchSprites = new();

    // Panel
    public GameObject Quizpanel; // Soal Lampu
    public GameObject Starpanel; // Hebat


    // "Pengulangan soal"
    public TMP_Text questionText;

    public bool questionLampsRunning = false;

    public Button buttonRepeat;
    public Button buttonJawab;

    public AudioSource repeatSfx;

    private int numAttempt = 0;

    void Start()
    {
        ResetLamp();
        StartCoroutine(QuestionLamps());
    }

    private void ResetLamp()
    {
        foreach (var lamp in sequence)
        {
            lamp.TurnOff();
        }
    }

    private IEnumerator QuestionLamps()
    {
        questionLampsRunning = true;
        questionText.text = "Perhatikan urutan lampu yang menyala!";
        buttonRepeat.interactable = false;
        buttonJawab.interactable = false;
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(1f);
            foreach (var lamp in sequence)
            {
                lamp.TurnOn();
                yield return new WaitForSeconds(1f);
                lamp.TurnOff();
            }
        }
        questionText.text = "Ayo nyalakan lampu sesuai urutan tadi ya!";
        buttonRepeat.interactable = true;
        buttonJawab.interactable = true;
        questionLampsRunning = false;
    }

    public void AddAnswer(LampController lamp)
    {
        Answers.Add(lamp);
    }
    public void CheckAnswer()
    {
        bool answerTrue = true;
        if (Answers.Count == sequence.Length)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] != Answers[i])
                {
                    answerTrue = false;
                }
            }
        }
        else
        {
            answerTrue = false;
        }

        if (answerTrue == false)
        {
            StartCoroutine(RepeatQuestion());
        }
        else
        {
            print("Correct Answer");
            Starpanel.SetActive(true);
            Quizpanel.SetActive(false);
        }
    }

    public void Repeat()
    {
        StartCoroutine(QuestionLamps());
        Debug.Log("Button Clicked");
        totalAtt();
    }

    public IEnumerator RepeatQuestion()
    {
        StopCoroutine(QuestionLamps());
        Answers.Clear();
        ResetLamp();
        foreach(var Switch in SwitchSprites)
        {
            Switch.ButtonOff();
        }
        repeatSfx.Play();   
        yield return new WaitForSeconds(1f);    
        Repeat();
    }

    public void totalAtt()
    {
        numAttempt++;
        Debug.Log(numAttempt);
    }
}


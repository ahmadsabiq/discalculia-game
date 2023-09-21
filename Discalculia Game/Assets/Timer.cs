using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public int countDownTimer;
    public TMP_Text countDownText;
    public Image timeImage;

    private void Start()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while (countDownTimer > 0)
        {
            countDownText.text = countDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countDownTimer--;
        }
        countDownText.text = "Mulai!";
        yield return new WaitForSeconds(0f);
        countDownText.gameObject.SetActive(true);
        timeImage.gameObject.SetActive(true);
    }
}
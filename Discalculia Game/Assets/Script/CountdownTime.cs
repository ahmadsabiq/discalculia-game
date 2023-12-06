using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountdownTime : MonoBehaviour
{
    public int countdownTime;
    public Text countdownTxt;

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownTxt.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        countdownTxt.text = "Mulai!";

        yield return new WaitForSeconds(1f);

        countdownTxt.gameObject.SetActive(false);
    }
}

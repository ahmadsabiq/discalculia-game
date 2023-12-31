using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Belanja3 : MonoBehaviour
{
    public int jmlApel, jmlMelon, jmlJeruk;

    private string playerName;

    public counter Counter;
    public Button button;
    public AudioSource wrongSound;
    public AudioSource rightSound;
    public GameObject AnsPanel;
    public GameObject GOpanel;
    private int numOfRepeats;

    public string nama;
    private string tittle = "Belanja";
    public string level;
    public string question;

    // Start is called before the first frame update
    public void Start()
    {
        if (button == null)
        {
            button = GetComponent<Button>();
        }

        playerName = PlayerPrefs.GetString("name");
        Debug.Log("Player name is: " + playerName);

        button.onClick.AddListener(PlayClickSound);

    }

    public void AddData()
    {
        playerName = PlayerPrefs.GetString("name");
        Debug.Log("Player name is: " + playerName);
        StartCoroutine(DatabaseManager.InsertData(playerName, numOfRepeats, tittle, level, question));
        Debug.Log("InsertData coroutine called.");
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void PlayClickSound()
    {
        if (Counter.apelAmount == jmlApel && Counter.melonAmount == jmlMelon && Counter.jerukAmount == jmlJeruk)
        {
            rightSound.Play();
            
        }

        else
        {
            wrongSound.Play();
        }
            
    }

    public void Clicked()
    {
        if (Counter.apelAmount == jmlApel && Counter.melonAmount == jmlMelon && Counter.jerukAmount == jmlJeruk)
        {
            AddData();
            Debug.Log("Correct answer!");
            AnsPanel.SetActive(false);
            GOpanel.SetActive(true);

        }
        else
        {
            Debug.Log("Wrong answer!");
            numOfRepeats++;
            Debug.Log(numOfRepeats);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerName : MonoBehaviour
{
    public string saveName;
    public TMP_Text inputText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetName()
    {
        saveName = inputText.text;
        PlayerPrefs.SetString("name", saveName);
        Debug.Log("Nama " + saveName + " tersimpan");
    }
}
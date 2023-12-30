using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerName : MonoBehaviour
{
    public string saveName;
    public TMP_Text inputText;
    public TMP_Text ErrorMessage;

    // Start is called before the first frame update
    void Start()
    {
        ErrorMessage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetName()
    {
        if (inputText.text != null && inputText.text.Length > 0)
        {
            saveName = inputText.text;
            PlayerPrefs.SetString("name", saveName);
            ErrorMessage.text = "Tersimpan"; // Set the error message
            ErrorMessage.gameObject.SetActive(true);
            Debug.Log("Nama " + saveName + " tersimpan");
        }
        else
        {
            ErrorMessage.text = "Nama Anak harus diisi dan disimpan"; // Set the error message
            ErrorMessage.gameObject.SetActive(true);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scene : MonoBehaviour
{
    public playerName PM;
    public string saveName;
    public GameObject InputPanel;
    public GameObject MenuPanel;
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

    public void Clicked()
    {
        if (PM.saveName != null && PM.saveName.Length > 0)
        {
            InputPanel.SetActive(false);
            MenuPanel.SetActive(true);
            ErrorMessage.gameObject.SetActive(false);
        }
        else
        {
            InputPanel.SetActive(true);
            MenuPanel.SetActive(false);
            ErrorMessage.text = "Nama Anak harus diisi dan disimpan"; // Set the error message
            ErrorMessage.gameObject.SetActive(true);
        }
    }
}

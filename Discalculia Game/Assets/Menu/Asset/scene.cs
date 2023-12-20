using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scene : MonoBehaviour
{
    public playerName PM;
    public string saveName;
    public GameObject InputPanel;
    public GameObject MenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else
        {
            InputPanel.SetActive(true);
            MenuPanel.SetActive(false);
        }
    }
}

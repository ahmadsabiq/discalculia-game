using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampController : MonoBehaviour
{

    public Sprite defaultLamp;
    public Sprite colorLamp;

    public Image img;

    public bool lampActive;

    public void Switch()
    {
        TurnOn();
        lampActive = true;
    }


    // Start is called before the first frame update
    public void TurnOn()
    {
        img.sprite = colorLamp;    
    }

    public void TurnOff() 
    { 
        img.sprite = defaultLamp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

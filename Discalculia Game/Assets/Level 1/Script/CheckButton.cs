using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void checkButton(){
        if(this.gameObject.tag == "falseAns"){
            Debug.Log("Salah");
        }
        else {
            Debug.Log("Benar");
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

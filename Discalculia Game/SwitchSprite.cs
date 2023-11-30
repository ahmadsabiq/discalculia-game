using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public Image uiImage;

public class SwitchSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        uiImage = GetComponent<Image>();
        uiImage.sprite = Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite()
    {

    }
}

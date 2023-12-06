using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Image lamp_off;
    public Sprite lamp_on;

    public float currentTime = 0f;
    public float startingTime = 3f;

    void Start()
    {
        currentTime = startingTime;
    }

    void Countdown()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    void Update()
    {
        Countdown();
        if (currentTime == 0)
        {
            lamp_off.sprite = lamp_on;
        }
        
    }

    public int _spriteId;

    public int spriteId
    {
        get { return _spriteId; }
    }

    public void ChangeSprite(int id, Sprite Image)
    {
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = Image;
    }
}

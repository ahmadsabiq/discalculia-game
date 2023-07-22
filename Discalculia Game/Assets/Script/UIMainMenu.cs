using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button mulai;
    void Start()
    {
        mulai.onClick.AddListener(StartNewGame);
    }

    private void StartNewGame()
    {
        ScenesManager.instance.LoadNewGame();
    }
}

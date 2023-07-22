using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField] Button backMenu;
    void Start()
    {
        backMenu.onClick.AddListener(LoadMainMenu);
    }

    private void LoadMainMenu()
    {
        ScenesManager.instance.LoadMainMenu();
    }
}

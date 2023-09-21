using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    bool flag;
    public SoundManager sm;
    string NamaScene;

    public void Update()
    {
        if (flag && !sm.SoundChg)
        {
            flag = false;
            SceneManager.LoadScene(NamaScene);
        }
    }

    public void ChangeScene(string sceneName)
    {
        sm.Button2();
        NamaScene = sceneName;
        flag = true;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public int lv = 0;
    private static ScenesManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    public void ScenesChanges(int lv)
    {
        this.lv = lv;
        SceneManager.LoadScene(0);
    }
    public void GotoTitle(int op)
    {
        SceneManager.LoadScene(op);
        Destroy(gameObject);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
               UnityEditor.EditorApplication.isPlaying = false;
        #else
               Application.Quit(); // 어플리케이션 종료
        #endif
   }
}

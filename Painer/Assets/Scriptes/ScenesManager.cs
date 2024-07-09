using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public int lv = 0;
    public int stage = 0;

    //이 두개는 타이틀 메뉴에서만 사용
    public GameObject titleUI;
    public SaveSpwanSystem Save;

    public GameObject savespawnpoint = null;
    private static ScenesManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        while (Save == null) Save = GameObject.Find("SaveSpawnpoint").GetComponent<SaveSpwanSystem>();
    }
    public void SetStage(int st)
    {
        stage = st;
        bool x = false;
        if (stage == 1)
        {
            if (Save.savestage >= 1) Save.savespawnpoint = new Vector3(4.739999f, 6.325f, -9.795877f);
            else
            {
                titleUI.GetComponent<TitleScreenUI>().Systemanno();
                x = true;
            }
        }
        else if (stage == 2)
        {
            if (Save.savestage >= 2) Save.savespawnpoint = new Vector3(-0.8929472f, 6.323884f, 54.2f);
            else
            {
                titleUI.GetComponent<TitleScreenUI>().Systemanno();
                x = true;
            }
        }
        else Save.savespawnpoint = new Vector3(4.739999f, 6.325f, -9.795877f);
        if(x==false) titleUI.GetComponent<TitleScreenUI>().ModeUI();
    }

    public void Modesetting(int lv)
    {
        this.lv = lv;
        Save.savelevel = lv;
        SceneManager.LoadScene(0);
    }
    public void Continuegame()
    {
        lv = Save.savelevel;
        SceneManager.LoadScene(0);
    }
    public void GotoTitle(int op, GameObject obj, GameObject player)
    {
        SaveSpwanSystem save = GameObject.Find("SaveSpawnpoint").GetComponent<SaveSpwanSystem>();
        save.savespawnpoint = new Vector3(obj.transform.position.x,obj.transform.position.y+1, obj.transform.position.z);
        if(lv==1) save.savelifes = player.GetComponent<PlayerSystem>().playerlifes;
        Debug.Log(save.savespawnpoint);
        Debug.Log(save.savelifes);
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

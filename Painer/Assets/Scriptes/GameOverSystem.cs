using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameOverSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject ev;
    public GameObject freecam;
    public GameObject key;
    public GameObject Screeneffect;
    public GameObject intend;
    public GameObject button;
    public GameObject SpawnSystem;
    public TextMeshProUGUI deathtext;
    public TextMeshProUGUI lifes;
    
    public ScenesManager scenes;

    // Start is called before the first frame update
    void Awake()
    {

        while (scenes == null)
        {
            scenes = GameObject.Find("ScenesManager").GetComponent<ScenesManager>();
        }
            if (scenes.lv == 1)
            {
                player.GetComponent<PlayerSystem>().playerlifes = 3;
                lifes.gameObject.SetActive(true);
            }
        
        else lifes.gameObject.SetActive(false);
        Screeneffect.transform.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
    }
  
    public void GameReset()
    {
        Screeneffect.GetComponent<ScreenEffect>().fadeln(0);
        PlayerSystem p = player.GetComponent<PlayerSystem>();
        CameraMove camo = p.cam;
        p.gameObject.SetActive(true);
        p.speed = 4.3f;
        p.isjumping = false;
        p.notmoving = false;
        p.setjumppossible(true);
        p.settempJumpPower(0f);
        p.jumpPower = 12;
        for(int i = 0; i < ev.transform.childCount; i++)
        {
            ev.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < freecam.transform.childCount; i++)
        {
            FreeCameraSystem camera = freecam.transform.GetChild(i).transform.GetChild(0).GetComponent<FreeCameraSystem>();
            freecam.transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
            camera.isdisposed = false;
            camera.isworked = false;
        }
        for (int i = 0; i < key.transform.childCount; i++)
        {
            key.transform.GetChild(i).GetComponent<KeyBlockSystem>().isopened = false;
            key.transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
            key.transform.GetChild(i).transform.GetChild(1).gameObject.SetActive(true);
        }
        for(int i = 0; i<intend.transform.childCount; i++)
        {
            intend.transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
            intend.transform.GetChild(i).GetComponent<IntendBlock>().cooltime = true;
        }
        for (int i = 0; i < button.transform.childCount; i++)
        {
            if(button.transform.GetChild(i).GetComponent<ButtonSystem>().isnotreset == false) button.transform.GetChild(i).GetComponent<ButtonSystem>().Buttonwork(1);
        }
        if (p.playerlifes == 0 && scenes.lv == 1)
        {
            p.transform.position = new Vector3(5.16f, 7.76f, -9.7f);
            p.spawnpoint = GameObject.Find("Startpoint");
            ResetSpawnpoint();
            p.playerlifes = 3;
        }
        else p.transform.position = new Vector3(p.spawnpoint.transform.position.x, p.spawnpoint.transform.position.y + 1, p.spawnpoint.transform.position.z);
        p.Dead = false;
        camo.ChangeCameraMode(p.spawnpointvalue);
        transform.gameObject.SetActive(false);
    }

    public void ResetSpawnpoint()
    {
        for(int i = 0; i<SpawnSystem.transform.childCount; i++)
        {
            SpawnSystem.transform.GetChild(i).GetComponent<SpawnPointSystem>().Setonce(false);
        }
    }
}

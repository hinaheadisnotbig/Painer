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
    public TextMeshProUGUI deathtext;


    // Start is called before the first frame update
    void Awake()
    {
        Screeneffect.transform.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
    }
  
    public void GameReset()
    {
        Screeneffect.GetComponent<ScreenEffect>().fadeln(0);
        PlayerSystem p = player.GetComponent<PlayerSystem>();
        CameraMove camo = p.cam;
        p.gameObject.SetActive(true);
        p.speed = 4.5f;
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
        p.transform.position = new Vector3(p.spawnpoint.transform.position.x, p.spawnpoint.transform.position.y+1, p.spawnpoint.transform.position.z);
        p.Dead = false;
        camo.ChangeCameraMode(p.spawnpointvalue);
        transform.gameObject.SetActive(false);
    }
}

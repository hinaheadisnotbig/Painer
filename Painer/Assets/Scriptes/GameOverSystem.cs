using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSystem : MonoBehaviour
{
    public PlayerSystem p;
    public GameObject ev;
    public GameObject freecam;
    public GameObject key;
    // Start is called before the first frame update
    void Awake()
    {
        transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(p.Dead == true) StartCoroutine(GameReset());
    }
    IEnumerator GameReset()
    {
        p.speed = 5f;
        p.isjumping = false;
        p.notmoving = false;
        p.jumppossible = true;
        p.tempJumpPower = 0f;
        p.jumpPower = 20;
        for(int i = 0; i < ev.transform.childCount; i++)
        {
            ev.transform.GetChild(i).gameObject.SetActive(true);
        }
        freecam.transform.gameObject.SetActive(true);
        freecam.GetComponent<FreeCameraSystem>().isdisposed = false;
        freecam.GetComponent<FreeCameraSystem>().isworked = false;
        for (int i = 0; i < key.transform.childCount; i++)
        {
            key.transform.GetChild(i).gameObject.SetActive(true);
        }
        yield return null;
    }
}

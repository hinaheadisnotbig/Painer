using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class CameraMove : MonoBehaviour
{
    public int cameraMode = 0;
    public GameObject BG;
    public GameObject BG2;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        ChangeCameraMode(0);
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraMode == 0)
        {
            BG.SetActive(true);
            BG2.SetActive(false);
            transform.position = Player.transform.GetChild(0).transform.position + new Vector3(9, 0, 0);
        }
        if (cameraMode == 1)
        {
            BG.SetActive(false);
            BG2.SetActive(true);
            transform.position = Player.transform.GetChild(0).transform.position + new Vector3(0, 2, -4);
        }
        transform.LookAt(Player.transform.GetChild(0).transform, Vector3.up);
           
        
    }

     public void ChangeCameraMode(int mode)
    {
        cameraMode = mode;
        Player.GetComponent<PlayerSystem>().MovePlayer(mode);
    }
}

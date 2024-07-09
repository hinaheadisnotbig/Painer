using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class SpawnPointSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject anno;
    public int cameramode = 0;
    CameraMove cam;

    private bool once = false;
    public bool test = false;
    private void Start()
    {
        cam = player.GetComponent<PlayerSystem>().cam;
        if (test)
        {
            player.transform.position = transform.position;
            cam.ChangeCameraMode(cameramode);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            if (once == false)
            {
                if (anno != null)
                {
                    anno.SetActive(true);
                    anno.GetComponent<SpawnAnno>().Dis(1f, 0);
                }
                player.GetComponent<PlayerSystem>().spawnpoint = gameObject;
                player.GetComponent<PlayerSystem>().spawnpointvalue = cameramode;
                once = true;
            }
        }
    }

    public void Setonce(bool once)
    {
        this.once = once;
    }
    public bool Getonce()
    {
        return once;
    }
}

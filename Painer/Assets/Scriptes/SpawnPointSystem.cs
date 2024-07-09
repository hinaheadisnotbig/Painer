using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPointSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject anno;

    public SaveSpwanSystem save;
    public int stagevalue = 0;

    CameraMove cam;
    public int cameramode = 0;

    private bool once = false;
    public bool test = false;
    private void Start()
    {
        while(save == null) save = GameObject.Find("SaveSpawnpoint").GetComponent<SaveSpwanSystem>();
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
                if (save != null) save.savestage = stagevalue;
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

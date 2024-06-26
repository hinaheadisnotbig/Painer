using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject anno;
    public int cameramode = 0;

    private bool once = false;
    public bool test = false;
    private void Start()
    {
        if (test) player.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            if (once == false)
            {
                if (anno != null)
                {
                    anno.gameObject.SetActive(true);
                    anno.GetComponent<SpawnAnno>().Dis(1f);
                }
                player.GetComponent<PlayerSystem>().spawnpoint = gameObject;
                player.GetComponent<PlayerSystem>().spawnpointvalue = cameramode;
                once = true;
            }
        }
    }
}

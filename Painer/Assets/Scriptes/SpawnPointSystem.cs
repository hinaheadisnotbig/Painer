using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointSystem : MonoBehaviour
{
    public GameObject player;
    public bool test = false;
    private void Start()
    {
        if(test) player.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            player.GetComponent<PlayerSystem>().spawnpoint = gameObject;
        }
    }
}

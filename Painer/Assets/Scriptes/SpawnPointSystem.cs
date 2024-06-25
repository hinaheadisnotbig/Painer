using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointSystem : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
        player.transform.position = transform.position;
    }
}

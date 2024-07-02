using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoJumpSystem : MonoBehaviour
{
    public GameObject player;
    PlayerSystem playerSystem;
    // Start is called before the first frame update
    void Start()
    {
        playerSystem = player.GetComponent<PlayerSystem>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (playerSystem.getjumppossible() == false)
        {
            playerSystem.PlayerDead();
        }
    }
}

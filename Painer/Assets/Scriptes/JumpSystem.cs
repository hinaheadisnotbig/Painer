using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem : MonoBehaviour
{
    GameObject player;
    PlayerSystem playerSystem;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
        playerSystem = player.GetComponent<PlayerSystem>();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ground" &&  playerSystem.isjumping) playerSystem.isjumping = false;

        if (other.transform.CompareTag("jumpblock"))
        {
            playerSystem.settempJumpPower(playerSystem.jumpPower);
            playerSystem.isjumping = false;
            playerSystem.jumpPower = other.gameObject.GetComponent<JumpBlock>().Jumpvaule;
        }

    }

    private void OnTriggerExit(Collider other)
    {
       if (other.transform.tag == "Ground" && !playerSystem.isjumping)  playerSystem.isjumping = true;
       if (other.transform.CompareTag("jumpblock"))  playerSystem.jumpPower =  playerSystem.gettempJumpPower();   
    }
}

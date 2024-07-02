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
        else if (other.transform.tag == "Intendblock" && playerSystem.isjumping) playerSystem.isjumping = false;
        else if (other.transform.CompareTag("jumpblock"))
        {
            playerSystem.settempJumpPower(playerSystem.jumpPower);
            playerSystem.isjumping = false;
            playerSystem.jumpPower = other.gameObject.GetComponent<JumpBlock>().Jumpvaule;
        }
        else if(other.transform.CompareTag("TP_g"))
        {
            other.transform.parent.GetComponent<TPblock>().tpb(player, 2);
        }
        else if (other.transform.CompareTag("TP_r"))
        {
            other.transform.parent.GetComponent<TPblock>().tpb(player, 1);
        }
        else if (other.transform.CompareTag("button"))
        {
            other.transform.parent.transform.parent.GetComponent<ButtonSystem>().Buttonwork(0);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Ground" && playerSystem.isjumping) playerSystem.isjumping = false;
        else if (other.transform.tag == "Intendblock" && playerSystem.isjumping) playerSystem.isjumping = false;
        else if (other.transform.CompareTag("jumpblock")) playerSystem.isjumping = false;
 
    }

    private void OnTriggerExit(Collider other)
    {
       if (other.transform.tag == "Ground" && !playerSystem.isjumping)  playerSystem.isjumping = true;
       else if (other.transform.tag == "Intendblock" && !playerSystem.isjumping) playerSystem.isjumping = true;
       else if (other.transform.CompareTag("jumpblock"))
        {
            playerSystem.isjumping = true;
            playerSystem.jumpPower = playerSystem.gettempJumpPower();
        }
        
    }
}

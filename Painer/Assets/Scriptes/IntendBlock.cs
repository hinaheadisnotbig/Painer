using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IntendBlock : MonoBehaviour
{
    public GameObject block;
    PlayerSystem player;
    public bool isdisapperblock = false;
    public bool cooltime = true;
    public float disappervalue = 1f;
    public float respawnvalue = 1f;
    private void Start()
    {
        if (isdisapperblock == false)
        {
            block.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && cooltime)
        {
            player = other.GetComponent<PlayerSystem>();
            if (isdisapperblock) StartCoroutine(deadtotime(disappervalue, respawnvalue));
            else if (!isdisapperblock)
            {
                cooltime = false;
                block.SetActive(true);
            }
        }
    }

    IEnumerator deadtotime(float t, float r)
    {
        cooltime = false;
        yield return new WaitForSeconds(t);
        block.GetComponent<BoxCollider>().enabled = false;
        block.SetActive(false);
        player.isjumping = true;
        yield return new WaitForSeconds(r);
        block.GetComponent<BoxCollider>().enabled = true;
        block.SetActive(true);
        cooltime = true;
    }
}

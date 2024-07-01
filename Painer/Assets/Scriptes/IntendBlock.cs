using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntendBlock : MonoBehaviour
{
    public GameObject block;
    public bool isdisapperblock = false;
    public bool cooltime = true;
    public float disappervalue = 1f;
    public float respawnvalue = 1f;
    private void Start()
    {
       if(isdisapperblock==false)  block.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && cooltime)
        {
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
        block.SetActive(false);
        yield return new WaitForSeconds(r);
        block.SetActive(true);
        cooltime = true;
    }
}

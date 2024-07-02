using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TPblock : MonoBehaviour
{
    public GameObject tpblock;
    public GameObject tpedblock;
    private bool ispossibletp = true;

    private void Start()
    {
        ispossibletp = true;
    }

    public void tpb(GameObject player, int op)
    {
        StartCoroutine(tptoblock(player, op));
    }
    IEnumerator tptoblock(GameObject player, int op)
    {
        if (ispossibletp)
        {
            ispossibletp = false;
            if (op == 1) player.transform.position = new Vector3(tpblock.transform.position.x, tpblock.transform.position.y + 1, tpblock.transform.position.z);
            else if (op == 2) player.transform.position = new Vector3(tpedblock.transform.position.x, tpedblock.transform.position.y + 1, tpedblock.transform.position.z);
            yield return new WaitForSeconds(1.5f);
            ispossibletp=true;
        }
    }
}

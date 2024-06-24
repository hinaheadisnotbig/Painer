using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;


public class MoveBlock : MonoBehaviour
{
   public GameObject Moveblock;
   public GameObject S;
   public GameObject E;
   public bool roundturn = false;
    public float blockspeed = 0.01f;


    private void Start()
    {
        S.gameObject.SetActive(false);
        E.gameObject.SetActive(false);
    }
    void Update()
    {
      
       if(roundturn == false) Moveblock.transform.position = Vector3.MoveTowards(Moveblock.transform.position, E.transform.position, blockspeed);
       else if(roundturn==true) Moveblock.transform.position = Vector3.MoveTowards(Moveblock.transform.position, S.transform.position, blockspeed);
       if(roundturn == false && E.transform.position == Moveblock.transform.position) roundturn = true;
       else if (roundturn == true && S.transform.position == Moveblock.transform.position) roundturn = false;
    }
 
}

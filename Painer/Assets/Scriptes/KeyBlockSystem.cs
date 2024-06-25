using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBlockSystem : MonoBehaviour
{
    public bool isopened = false;
    public GameObject keydoor;
    private void Update()
    {
        if(isopened==true) keydoor.gameObject.SetActive(false);
    }

}

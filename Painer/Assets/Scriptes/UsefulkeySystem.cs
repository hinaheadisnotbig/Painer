using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsefulkeySystem : MonoBehaviour
{
    public GameObject keySystem;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) {
            keySystem.GetComponent<KeyBlockSystem>().isopened = true;
            Debug.Log(keySystem.GetComponent<KeyBlockSystem>().isopened);
            gameObject.SetActive(false);
        }
       
    }
}

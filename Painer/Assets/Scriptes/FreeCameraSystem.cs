using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraSystem : MonoBehaviour
{
    public GameObject target;
    public GameObject Startplace;
    public GameObject firstStartplace;
    public GameObject target2;
    public GameObject cam;
    public int setmode = 0;
    public bool cam2 = false;
    public bool isworked = false;
    public bool isdisposed = false;
    public float Cameraspeed = 0.01f;

    private void Start()
    {
        target.gameObject.SetActive(false);
        target2.gameObject.SetActive(false);
        firstStartplace.gameObject.SetActive(false);
        Startplace.gameObject.SetActive(false);
    }
    void Update()
    {
        if (isworked == true && isdisposed==false)
        {
            StartCoroutine(StartZoom());
            isdisposed = true;
        }
    }
    
    

    IEnumerator StartZoom()
    {
        CameraMove c = cam.GetComponent<CameraMove>();
        c.ChangeCameraMode(setmode);
        c.freecam = gameObject;
        c.target = target;
        transform.position = firstStartplace.transform.position;
        c.isfreemode = true;
        Debug.Log("内风凭");
        while (target.transform.position != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Cameraspeed);
            yield return null;
        }
        if (cam2)
        {
            c.target = target2;
            transform.position = Startplace.transform.position;
            while (target2.transform.position != transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, Cameraspeed);
                yield return null;
            }
        }
        yield return null;
        Debug.Log("内风凭 场");
        c.isfreemode = false;
        transform.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) {
            isworked = true;
        }
    }
}

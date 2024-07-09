using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSpwanSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 savespawnpoint = Vector3.zero;
    public int savelifes = 0;
    public int savelevel = 0;
    public int savestage = 1;
    private static SaveSpwanSystem instance;

    private void Awake()
    {
        Debug.Log(savespawnpoint);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
}

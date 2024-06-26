using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnno : MonoBehaviour
{
    private void Start()
    {
        transform.gameObject.SetActive(false);
    }

    public void Dis(float t)
    {
        StartCoroutine(display(t));
    }
    // Start is called before the first frame update
    public IEnumerator display(float t)
    {
        yield return new WaitForSeconds(t);
        transform.gameObject.SetActive(false);
    }
}


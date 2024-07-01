using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnno : MonoBehaviour
{
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    public void Dis(float t, int child)
    {
        StartCoroutine(display(t, child));
    }
    // Start is called before the first frame update
    public IEnumerator display(float t, int child)
    {
        transform.GetChild(child).gameObject.SetActive(true);
        yield return new WaitForSeconds(t);
        transform.GetChild(child).gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}


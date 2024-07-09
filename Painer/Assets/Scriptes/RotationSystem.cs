using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSystem : MonoBehaviour
{
    private float y = -187f;
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(Rotation());
        
    }

    IEnumerator Rotation()
    {
        while (true)
        {
            for(int i = 0; i < 1025; i++)
            {
                y += 0.015f;
                transform.rotation = Quaternion.Euler(2.47f, y, -0.333f);
                yield return null;
            }
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < 1025; i++)
            {
                y -= 0.015f;
                transform.rotation = Quaternion.Euler(2.47f, y, -0.333f);
                yield return null;
            }
            yield return new WaitForSeconds(1.2f);
        }
    }
}

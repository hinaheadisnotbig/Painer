using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonSystem : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject brige;
    public GameObject image_brige;
    public TextMeshPro button_Timer;

    public GameObject cam;

    public bool isnotreset = false;
    public bool istimer = false;
    public float disposingtimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Buttonwork(1); //0 - 눌림 1 - 안눌림
    }

    public void Buttonwork(int op)
    {
        if(op==0)
        {
        button1.SetActive(false);
        button2.SetActive(true);
        image_brige.SetActive(false);
        brige.SetActive(true);
            if (istimer == true)
            {
                Debug.Log("버튼 작동");
                button_Timer.gameObject.SetActive(true);
                StartCoroutine(Timerwork(disposingtimer));
            }
        }
        if (op == 1)
        {
            button1.SetActive(true);
            button2.SetActive(false);
            image_brige.SetActive(true);
            brige.SetActive(false);
            button_Timer.gameObject.SetActive(false);
        }
    }
    float parsedot(float val)
    {
        var str = val.ToString("0.00");
        return float.Parse(str);
    }

    IEnumerator Timerwork(float t)
    {
        for (float i = t; i > 0; i -= 0.1f)
        {
            button_Timer.text = parsedot(i) + "s";
            if (cam != null)
            {
                button_Timer.transform.LookAt(cam.transform);
                button_Timer.transform.rotation = cam.transform.rotation;
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
        Buttonwork(1);
        yield return null;
    }
}

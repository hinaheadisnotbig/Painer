using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenUI : MonoBehaviour
{
    Transform panel1;
    Transform panel2;
    private void Start()
    {
        panel1 = transform.GetChild(0);
        panel2 = transform.GetChild(1);
        TitleUI();
    }

    public void TitleUI()
    {
        panel1.transform.gameObject.SetActive(true);
        panel2.transform.gameObject.SetActive(false);
    }
    public void ModeUI()
    {
        panel1.transform.gameObject.SetActive(false);
        panel2.transform.gameObject.SetActive(true);
    }
}

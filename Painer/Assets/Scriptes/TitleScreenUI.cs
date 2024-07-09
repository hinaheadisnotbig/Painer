using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TitleScreenUI : MonoBehaviour
{
    Transform[] panel = new Transform[5];
    private void Start()
    {
        for(int i = 0; i < panel.Length; i++)
        {
            panel[i] = transform.GetChild(i);
        }
        TitleUI();
    }

    public void TitleUI()
    {
       
        for (int i = 0; i < panel.Length; i++)
        {
            if (i != 0) panel[i].gameObject.SetActive(false);
            else panel[i].gameObject.SetActive(true);
        }
    }
    public void ModeUI()
    {
        for (int i = 0; i < panel.Length; i++)
        {
            if (i != 1) panel[i].gameObject.SetActive(false);
            else panel[i].gameObject.SetActive(true);
        }
    }
    public void StageUI()
    {
        for (int i = 0; i < panel.Length; i++)
        {
            if (i != 2) panel[i].gameObject.SetActive(false);
            else panel[i].gameObject.SetActive(true);
        }
    }
    public void Stage2UI()
    {
        for (int i = 0; i < panel.Length; i++)
        {
            if (i != 3) panel[i].gameObject.SetActive(false);
            else panel[i].gameObject.SetActive(true);
        }
    }
    public void Systemanno()
    {
        StartCoroutine(SystemAnnoStart());
    }

    IEnumerator SystemAnnoStart()
    {
        panel[4].gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        panel[4].gameObject.SetActive(false);
        yield return null;
    }
}

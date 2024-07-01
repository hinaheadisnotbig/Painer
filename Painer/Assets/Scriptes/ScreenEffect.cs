using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenEffect : MonoBehaviour
{
    public GameObject FadePannel;
    public GameObject System;

    
 
    public void fadeln(int i)
    {
        if (i == 0) StartCoroutine(FadeInStart());
        else if(i == 1) StartCoroutine(FadeOutStart());
    }

    public IEnumerator FadeInStart()
    {
        FadePannel.SetActive(true);
        for (float f = 1f; f > 0; f -= 0.02f)
        {
            Color c = FadePannel.GetComponent<Image>().color;
            c.a = f;
            FadePannel.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1);
        //FadePannel.SetActive(false);
    }

    //페이드 인
    public IEnumerator FadeOutStart()
    {
        FadePannel.SetActive(true);
        for (float f = 0f; f < 1; f += 0.01f)
        {
            Color c = FadePannel.GetComponent<Image>().color;
            c.a = f;
            FadePannel.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        PlayerSystem player = System.GetComponent<GameOverSystem>().player.GetComponent<PlayerSystem>();
        player.deadcount++;
        System.GetComponent<GameOverSystem>().deathtext.text = "Death : " + player.deadcount;
        System.gameObject.SetActive(true);


    }
}

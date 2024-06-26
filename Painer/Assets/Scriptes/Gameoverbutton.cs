using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameoverbutton : MonoBehaviour
{
    public GameObject gameover;

    public void Gamereset()
    {
        gameover.GetComponent<GameOverSystem>().GameReset();
    }
}

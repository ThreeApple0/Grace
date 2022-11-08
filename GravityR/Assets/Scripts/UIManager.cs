using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject LobbyPn;
    public GameObject GamePn;
    public GameManager GM;
    public PlayerManager PM;
    public Text BestScoreTx;
    public Text LocalScoreTx;
    public Image joy1;
    public Image joy2;
    public int bestscore;

    // Start is called before the first frame update
    public void OnGameStartBt()
    {
        GM.IsGameing = true;

        BestScoreTx.enabled = false;
        LobbyPn.SetActive(false);

        joy1.enabled = true;
        joy2.enabled = true;

        GM.IsGameing = true;
        PM.IsGameing = true;
        LocalScoreTx.text = "0";
    }
    public void OnGameOver()
    {
        BestScoreTx.enabled = true;
        if (int.Parse(LocalScoreTx.text) > bestscore)
        {
            bestscore = int.Parse(LocalScoreTx.text);
            BestScoreTx.text = "best\n" + LocalScoreTx.text;
        }
        
        LobbyPn.SetActive(true);


        joy1.enabled = false;
        joy2.enabled = false;

        GM.IsGameing = false;
        PM.IsGameing = false;

        GM.Resett();
    }
}

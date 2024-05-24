using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InterfaceBehavior : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public Button restartButton;
    private FinishGame playerWon;

    private int hp;

    // Start is called before the first frame update
    void Start()
    {
        playerWon = GameObject.Find("FinalSpot").GetComponent<FinishGame>();

        hp = DamageManager.GetHp();
        hpText.text = "HP: " + hp;

    }

    // Update is called once per frame
    void Update()
    {
        hp = DamageManager.GetHp();
        DrawGameOver();
        DrawHp();
        DrawWin();
    }


    private void DrawHp() => hpText.text = "HP: " + hp;

    private void DrawGameOver()
    {
        if (!DamageManager.IsPlayerAlive()) 
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    private void DrawWin()
    {
        if (playerWon.isWin)
        {
            winText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        } 
    }
}

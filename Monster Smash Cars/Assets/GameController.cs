using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public GameObject[] player1Cars, player2Cars;
    public Text score1,score11, score2,score22;
    public  GameObject[] players;
    public RCC_CameraConfig p1, p2;
    int player1Points, player2Points;
    public Text timer1, timer2;
    float Timer;
    public GameObject levelEnd1, levelEnd2;
    public GameObject player1Won, player2Won, DRAW1, DRAW2, player1Lose, player2Lose;

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
        Timer = 120;
        player1Cars[PlayerPrefs.GetInt("Player1Car")].SetActive(true);
        player2Cars[PlayerPrefs.GetInt("Player2Car")].SetActive(true);
        players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            if (player.GetComponent<RCC_CameraConfig>()){
                if (player.GetComponent<RCC_CameraConfig>().player == 1) p1 = player.GetComponent<RCC_CameraConfig>();
                if (player.GetComponent<RCC_CameraConfig>().player == 2) p2 = player.GetComponent<RCC_CameraConfig>();
            }
        }
	}
    public void BackToMenu()
    {
        Application.LoadLevel(0);
    }
	// Update is called once per frame
	void Update () {
        Timer -= Time.deltaTime;
        timer1.text = "Time reamining: " + (int)Timer;
        timer2.text = "Time reamining: " + (int)Timer;
        if (Timer < 0)
        {
            if (player1Points > player2Points)
            {
                player1Won.SetActive(true);
                player2Lose.SetActive(true);
            }
            if (player2Points > player1Points)
            {
                player2Won.SetActive(true);
                player1Lose.SetActive(true);
              
            }

            if (player2Points == player1Points)
            {
                DRAW1.SetActive(true);
                DRAW2.SetActive(true);
            }

            levelEnd1.SetActive(true);
            levelEnd2.SetActive(true);
        }
        player1Points = p1.points;
        player2Points = p2.points;
        if (player1Points < 0) player1Points = 0;
        if (player2Points < 0) player2Points = 0;
        if (player1Points >= player2Points)
        {
            score1.text = "Player1 LEADING " + player1Points;
            score2.text = "Player2 SASAI " + player2Points;
            score11.text = "Player1 LEADING " + player1Points;
            score22.text = "Player2 SASAI " + player2Points;
        }
        else
        {
            score1.text = "Player2 LEADING " + player2Points;
            score2.text = "Player1 SASAI " + player1Points;
            score11.text = "Player2 LEADING " + player2Points;
            score22.text = "Player1 SASAI " + player1Points;
        }
        }
}

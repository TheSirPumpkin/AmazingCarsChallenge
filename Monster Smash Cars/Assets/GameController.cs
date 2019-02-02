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

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
        
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
	
	// Update is called once per frame
	void Update () {
       
        player1Points = p1.points;
        player2Points = p2.points;
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

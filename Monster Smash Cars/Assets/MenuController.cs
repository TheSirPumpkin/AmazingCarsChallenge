using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
    public GameObject[] player1Cars, player2Cars;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Player1Car", 0);
         PlayerPrefs.SetInt("Player2Car", 0);
        player1Cars[0].SetActive(true);
        player2Cars[0].SetActive(true);
    }
    void ChangeCar(bool next, int player)
    {
        if (player == 1)
        {
            if (next)
            {
                for (int i = 0; i < player1Cars.Length; i++)
                {
                    if (player1Cars[i].activeSelf == true)
                    {
                        if (i < player1Cars.Length - 1)
                        {
                            player1Cars[i].SetActive(false);
                            PlayerPrefs.SetInt("Player1Car", i + 1);
                            player1Cars[i + 1].SetActive(true);
                           
                          
                            return;
                        }
                        if (i >= player1Cars.Length - 1)
                        {
                            player1Cars[i].SetActive(false);
                            player1Cars[0].SetActive(true);
                            PlayerPrefs.SetInt("Player1Car", 0);
                            return;
                        }

                    }
                }
            }
            if (!next)
            {
                for (int i = player1Cars.Length - 1; i > -1; i--)
                {
                    if (player1Cars[i].activeSelf == true)
                    {
                        Debug.Log(i);
                        if (i > 0)
                        {
                            player1Cars[i].SetActive(false);
                            PlayerPrefs.SetInt("Player1Car", i - 1);
                            player1Cars[i - 1].SetActive(true);
                            
                            return;
                        }
                        if (i <= 0)
                        {
                            player1Cars[i].SetActive(false);
                            player1Cars[6].SetActive(true);
                            PlayerPrefs.SetInt("Player1Car", 6);
                            return;
                        }

                    }
                }
            }
        }

        if (player == 2)
        {
            if (next)
            {
                for (int i = 0; i < player2Cars.Length; i++)
                {
                    if (player2Cars[i].activeSelf == true)
                    {
                        if (i < player2Cars.Length - 1)
                        {
                            player2Cars[i].SetActive(false);
                            player2Cars[i + 1].SetActive(true);
                            PlayerPrefs.SetInt("Player2Car", i + 1);
                            return;
                        }
                        if (i >= player2Cars.Length - 1)
                        {
                            player2Cars[i].SetActive(false);
                            player2Cars[0].SetActive(true);
                            PlayerPrefs.SetInt("Player2Car", 0);
                            return;
                        }

                    }
                }
            }
            if (!next)
            {
                for (int i = player2Cars.Length - 1; i > -1; i--)
                {
                    if (player2Cars[i].activeSelf == true)
                    {
                        Debug.Log(i);
                        if (i > 0)
                        {
                            player2Cars[i].SetActive(false);
                            player2Cars[i - 1].SetActive(true);
                            PlayerPrefs.SetInt("Player2Car", i - 1);
                            return;
                        }
                        if (i <= 0)
                        {
                            player2Cars[i].SetActive(false);
                            player2Cars[6].SetActive(true);
                            PlayerPrefs.SetInt("Player2Car", 6);
                            return;
                        }

                    }
                }
            }
        }
    }
    public void PlayGame()
    {
        Application.LoadLevel(1);
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            ChangeCar(true,2);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            ChangeCar(false,2);

        if (Input.GetKeyDown(KeyCode.D))
            ChangeCar(true, 1);
        if (Input.GetKeyDown(KeyCode.A))
            ChangeCar(false, 1);

    }

  
}

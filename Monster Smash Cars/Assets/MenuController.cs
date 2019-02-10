using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
    public Color[] colors;
    public GameObject[] player1Cars, player2Cars;

    public void SetMode(int mode)
    {
        if (mode == 1) PlayerPrefs.SetInt("Single", 1);
                if (mode == 2) PlayerPrefs.SetInt("Single", 0);
    }
	void Start () {
       // PlayerPrefs.SetInt("Player1Car", 0);
       //  PlayerPrefs.SetInt("Player2Car", 0);
        player1Cars[PlayerPrefs.GetInt("Player1Car")].SetActive(true);
        player2Cars[PlayerPrefs.GetInt("Player2Car")].SetActive(true);
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
    void ChangeColor(bool next, int player)
    {
        if (player == 2)
        {
            //  foreach (GameObject car in player2Cars)
            //{
            if (next)
            {
                for (int j = 0; j < player2Cars.Length; j++)
                {
                    for (int i = 0; i < colors.Length; i++)
                    {
                        if (player2Cars[j].GetComponentInChildren<Renderer>().sharedMaterial.color == colors[i])
                        {
                            if (i < colors.Length - 1)
                            {
                                player2Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player2Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player2Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player2Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player2Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player2Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player2Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                // PlayerPrefs.SetInt("Player1Car", i + 1);



                                return;
                            }
                            if (i >= colors.Length - 1)
                            {
                                player2Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player2Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player2Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player2Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player2Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player2Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player2Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                // PlayerPrefs.SetInt("Player1Car", 0);
                                return;
                            }


                        }
                    }
                }
            }
            //ті хуй
            if (!next)
            {
                for (int j = player2Cars.Length-1; j > -1; j--)
                {
                    for (int i = colors.Length-1; i > -1; i--)
                    {
                        Debug.Log(j);
                        Debug.Log(i);
                        if (player2Cars[j].GetComponentInChildren<Renderer>().sharedMaterial.color == colors[i])
                        {
                            if (i >0)
                            {
                                player2Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player2Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player2Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player2Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player2Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player2Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player2Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                // PlayerPrefs.SetInt("Player1Car", i + 1);



                                return;
                            }
                            if (i <= 0)
                            {
                                player2Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player2Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player2Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player2Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player2Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player2Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player2Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                // PlayerPrefs.SetInt("Player1Car", 0);
                                return;
                            }


                        }
                    }
                }
            }

            //}
        }


        if (player == 1)
        {
            //  foreach (GameObject car in player2Cars)
            //{
            if (next)
            {
                for (int j = 0; j < player1Cars.Length; j++)
                {
                    for (int i = 0; i < colors.Length; i++)
                    {
                        if (player1Cars[j].GetComponentInChildren<Renderer>().sharedMaterial.color == colors[i])
                        {
                            if (i < colors.Length - 1)
                            {
                                player1Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player1Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player1Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player1Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player1Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player1Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player1Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                // PlayerPrefs.SetInt("Player1Car", i + 1);



                                return;
                            }
                            if (i >= colors.Length - 1)
                            {
                                player1Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player1Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player1Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player1Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player1Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player1Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player1Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                // PlayerPrefs.SetInt("Player1Car", 0);
                                return;
                            }


                        }
                    }
                }
            }

            if (!next)
            {
                for (int j = player1Cars.Length - 1; j > -1; j--)
                {
                    for (int i = colors.Length - 1; i > -1; i--)
                    {
                        Debug.Log(j);
                        Debug.Log(i);
                        if (player1Cars[j].GetComponentInChildren<Renderer>().sharedMaterial.color == colors[i])
                        {
                            if (i > 0)
                            {
                                player1Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player1Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player1Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player1Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player1Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player1Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player1Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                // PlayerPrefs.SetInt("Player1Car", i + 1);



                                return;
                            }
                            if (i <= 0)
                            {
                                player1Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player1Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player1Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player1Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player1Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player1Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player1Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                // PlayerPrefs.SetInt("Player1Car", 0);
                                return;
                            }


                        }
                    }
                }
            }

            //}
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ChangeColor(true, 2);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            ChangeColor(false, 2);


        if (Input.GetKeyDown(KeyCode.D))
            ChangeCar(true, 1);
        if (Input.GetKeyDown(KeyCode.A))
            ChangeCar(false, 1);
        if (Input.GetKeyDown(KeyCode.W))
            ChangeColor(true, 1);
        if (Input.GetKeyDown(KeyCode.S))
            ChangeColor(false, 1);



    }

  
}

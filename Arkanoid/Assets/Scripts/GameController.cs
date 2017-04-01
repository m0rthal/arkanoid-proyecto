using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

        //public GUIText scoreText;
        public GUIText vidasText;
        public int score;
        public int vidas = 3;
        bool nivel2 = false;
        bool nivel3 = false;
        bool nivel4 = false;
        bool boss = false;
        void Start()
        {
                if (score == 1950)
                {
                        nivel2 = true;
                }

                if (score == 3600)
                {
                        nivel3 = true;
                }
                if (score == 4730)
                {
                        nivel4 = true;
                }

                if (score == 5730)
                {
                        boss = true;
                }
                updateScore();
                updateVidas();
                
        }

        void Update()
        {
                if (score == 1950 && !nivel2)
                {
                        SceneManager.LoadScene("escena2");
                }

                if (score == 3600 && !nivel3)
                {
                        SceneManager.LoadScene("escena3");
                }

                if (score == 4730 && !nivel4)
                {
                        SceneManager.LoadScene("escena4");
                }

                if (score == 5730 && !boss)
                {
                        SceneManager.LoadScene("boss");
                }

                if (score == 6030)
                {
                        SceneManager.LoadScene("Win");
                }

                if (vidas == 0)
                {
                        SceneManager.LoadScene("gameover");
                }
        }

        public void addScore (int newScore)
        {
                score += newScore;
                updateScore();  
        }

        public void muerte()
        {
                vidas--;
                updateVidas();
        }

	void updateScore ()
        {
                //scoreText.text = "Score: " + score;
        }

        void updateVidas()
        {
                vidasText.text = "Vidas: " + vidas;
        }
}

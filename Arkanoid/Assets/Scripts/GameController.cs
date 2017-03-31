using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

        public GUIText scoreText;
        public GUIText vidasText;
        public int score;
        public int vidas = 3;
        bool nivel2 = false;
        void Start()
        {
                updateScore();
                updateVidas();
        }

        void Update()
        {

                if (score == 1950 && !nivel2)
                {
                        Resources.UnloadUnusedAssets();
                        SceneManager.LoadScene("escena2");
                }

                if(vidas == 0)
                {
                        SceneManager.LoadScene("escena");
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
                scoreText.text = "Score: " + score;
        }

        void updateVidas()
        {
                vidasText.text = "Vidas: " + vidas;
        }
}

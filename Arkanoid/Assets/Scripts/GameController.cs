using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

        public GUIText scoreText;
        public int score;
        void Start()
        {
                score = 0;
                updateScore();
        }

        public void addScore (int newScore)
        {
                score += newScore;
                updateScore();
        }

	void updateScore ()
        {
                scoreText.text = "Score: " + score;
        }
}

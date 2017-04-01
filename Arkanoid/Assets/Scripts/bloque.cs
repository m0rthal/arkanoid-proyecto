using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloque : MonoBehaviour
{
        public int score;
        private GameController gameController;

        void Start()
        {
                GameObject gameControllerObject = GameObject.FindWithTag("GameController");
                if (gameControllerObject != null)
                {
                        gameController = gameControllerObject.GetComponent<GameController>();
                }
                if (gameController == null)
                {
                        Debug.Log("no se encontro script");
                }
        } 

        void OnCollisionEnter2D(Collision2D col)
        {
                        gameController.addScore(score);
                        Destroy(gameObject);
        }
}

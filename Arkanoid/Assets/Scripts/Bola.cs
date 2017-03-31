using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour {
        public float speed = 100.0f;
        Vector2 a = new Vector2(0,12.4F);
        public GameObject barra;
        Touch toque;
        private bool jugando = false;
        private GameController gameController;
        // Use this for initialization
        void Start ()
        {
                GameObject gameControllerObject = GameObject.FindWithTag("GameController");
                if (gameControllerObject != null)
                {
                        gameController = gameControllerObject.GetComponent<GameController>();
                }


                GetComponent<Rigidbody2D>().position = barra.GetComponent<Rigidbody2D>().position + a;
        }

        void Update()
        {
                if (!jugando)
                {
                        GetComponent<Rigidbody2D>().position = barra.GetComponent<Rigidbody2D>().position + a;
                        for (var i = 0; i < Input.touchCount; ++i)
                        {
                                toque = Input.GetTouch(i);
                                if (toque.phase == TouchPhase.Began)
                                {
                                        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                                        jugando = true;
                                }
                        }
                } else
                {

                }
        }

        float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
        {
                // ascii art:
                //
                // 1  -0.5  0  0.5   1  <- x value
                // ===================  <- racket
                //
                return (ballPos.x - racketPos.x) / racketWidth;
        }
        private void OnCollisionEnter2D(Collision2D col)
        {
                if (col.gameObject.name == "racket")
                {
                        // Calculate hit Factor
                        float x = hitFactor(transform.position,
                                          col.transform.position,
                                          col.collider.bounds.size.x);

                        // Calculate direction, set length to 1
                        Vector2 dir = new Vector2(x, 1).normalized;

                        // Set Velocity with dir * speed
                        GetComponent<Rigidbody2D>().velocity = dir * speed;
                }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                Vector2 inicio;
                inicio.x = 0;
                inicio.y = -84;
                gameController.muerte();
                GetComponent<Rigidbody2D>().position = inicio;
                jugando = false;
                Start();
        }
}

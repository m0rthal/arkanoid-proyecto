using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour {
        public float velocidad = 150;
        void Update () {
                Touch toque;
                for (var i = 0; i < Input.touchCount; ++i)
                {
                        toque = Input.GetTouch(i);

                        // Get Horizontal Input
                        if (toque.phase == TouchPhase.Began)
                        {

                                if (toque.position.x > Screen.width / 2) {
                                        // Set Velocity (movement direction * speed)
                                        GetComponent<Rigidbody2D>().velocity = Vector2.right * 1 * velocidad;
                                }
                                else if (toque.position.x <= Screen.width / 2) {
                                        GetComponent<Rigidbody2D>().velocity = Vector2.left * 1 * velocidad;
                                }
                        } else if (toque.phase == TouchPhase.Ended) {
                                GetComponent<Rigidbody2D>().velocity = Vector2.right * 0 * velocidad;
                        }
                }
        }
}

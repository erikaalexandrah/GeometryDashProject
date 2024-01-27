using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [Tooltip("Jugador al cual la camara seguirá")]
    public Transform player; // Player al cual se seguirá
    [Tooltip("Distancia entre la cámara y el jugador")]
    public Vector3 offset; // Distancia entre la cámara y el jugador

    // Update se llama una vez por frame
    void Update()
    {
        if (player != null)
        {
            // Se establece la posición de la cámara para que siga al jugador
            // con el offset dado. Dando una cámara en tercera persona.
            transform.position = player.position + offset;
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento hacia adelante
    public float jumpForce = 7f; // Fuerza del salto
    private Rigidbody rb; // Referencia al componente Rigidbody
    private bool canJump; // Verifica si el jugador puede saltar

    // Start se llama antes del primer frame
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el componente Rigidbody
        canJump = true; // Inicialmente el jugador puede saltar
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Mover el cubo hacia adelante automáticamente
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Comprueba si el jugador ha presionado la tecla de salto y si puede saltar
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            // Aplica una fuerza hacia arriba para hacer saltar al cubo
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false; // El jugador ya no puede saltar hasta que toque el suelo de nuevo
        }
    }

    // OnCollisionEnter se llama cuando este collider/rigidbody comienza a tocar otro collider/rigidbody
    private void OnCollisionEnter(Collision collision)
    {
        // Comprueba si el cubo ha tocado el suelo
        if (collision.gameObject.CompareTag("Terrain"))
        {
            canJump = true; // El jugador puede saltar de nuevo
        }
        // Comprueba si el jugador ha chocado con un obstáculo
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject); // Destruye el objeto del jugador
            // Reinicia la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
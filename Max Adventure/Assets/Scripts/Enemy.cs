using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4f; // Velocidad de movimiento
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Darle movimiento
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con el jugador, le quita una vida
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PlayerHit(); // M�todo para reducir vidas del jugador
        }

        // Si colisiona con un proyectil, se desactiva
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            gameObject.SetActive(false);
        }
    }
}

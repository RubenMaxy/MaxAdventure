using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4f; // Velocidad de movimiento
    Rigidbody2D rb;
    public float jumpForce = 5f; // Fuerza de salto
    public Transform groundCheck; // Objeto que verifica el suelo
    public LayerMask groundLayer; // Capa del suelo
    public float coyoteTime = 0.3f;

    private float coyoteTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        //Darle movimiento
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            Jump();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con el jugador, le quita una vida
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PlayerHit(); // Método para reducir vidas del jugador
        }

        // Si colisiona con un proyectil, se desactiva
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            gameObject.SetActive(false);
        }
    }

    private bool EstaEnSuelo()
    {
        // Lanzar un raycast para verificar el suelo
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.5f, groundLayer);
        return hit;

    }

    private void Jump()
    {
        if (!EstaEnSuelo() && coyoteTimer > 0) { 

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            coyoteTimer = 0;

        }  else if (EstaEnSuelo())
        {
            coyoteTimer = coyoteTime; // reinicia el tiempo si está en el suelo
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si entra al trigger de la caida, se desactiva
        if (collision.gameObject.CompareTag("Caida"))
        {
            gameObject.SetActive(false);
        }
    }
}

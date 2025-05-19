using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 20f; //Velocidad de movimiento, se modificar� en el inspector
    [SerializeField] private Transform firePoint; //Punto de salida del proyectil
    [SerializeField] private LayerMask ground;
    [SerializeField] private GameObject projectilePrefab; //Referencia al prefab del proyectil
    [SerializeField] private float jumpForce = 10f; //Fuerza que se aplica al salto del personaje. Se modificar� desde el inspector.

    private float movement = 0f; //Se inicia en el inspector
    private Vector2 startPos; //Posicion inicial
    private float coyoteTimer;


    private float orientation;

    public float coyoteTime = 0.2f;
    public Animator animator;
    public Rigidbody2D rb; //Se inicia en el inspector
    public BoxCollider2D bc;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        animator.SetFloat("movement", movement* speed);
        if (movement < 0)
        {
            transform.localScale= new Vector3(-7.591f,7,1);
            orientation = -7.591f;
        } else
        {
            transform.localScale = new Vector3(7.591f, 7, 1);
            orientation = 7.591f;
        }
        Jump();
        Shot();
    }

    private void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Determina dirección inicial
            Vector2 shootDirection = EstaEnSuelo() ? firePoint.right : Vector2.down;

            // Si orientation es menor a 0, invertir la dirección
            if (orientation < 0)
            {
                shootDirection = EstaEnSuelo() ? -firePoint.right : Vector2.down;
            }

            // Crea el proyectil y le asigna la dirección correcta en la que debe moverse
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rbProjectile = projectile.GetComponent<Rigidbody2D>();
            Proyectil proyectilScript = projectile.GetComponent<Proyectil>();

            // Aplica velocidad basada en la dirección del PJ
            if (rbProjectile != null)
            {
                proyectilScript.SetDirection(shootDirection);
            }
        }
    }

    bool EstaEnSuelo()
    {
        //Esto emite una caja para comprobar si está colisionando o no. Se dice de donde sale la caja, la dimension, el �ngulo, la direcci�n, la distancia que debe recorrer la caja y la mascara de la capa
        RaycastHit2D raycastHit2D= Physics2D.BoxCast(bc.bounds.center, new Vector2(bc.size.x, bc.size.y), 0f, Vector2.down, 0.8f, ground);
        return raycastHit2D.collider != null;
    }
    //M�todo que hace saltar al personaje. Comprueba si se pulsa una tecla y aplica una fuerza de salto.
    void Jump()
    {
        animator.SetBool("estaEnSuelo", EstaEnSuelo() );
        if (Input.GetKeyDown(KeyCode.UpArrow) && coyoteTimer > 0) 
        {
            Debug.Log("Salto activado");
            //Aplica la fuerza al salto, el segundo argumento indica que tipo de fuerza es, en este caso un impulso.
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.CrossFade("jump", 0.1f);
            Debug.Log("Valor de 'jump' en el Animator: " + animator.GetBool("jump"));
            StartCoroutine(ResetJumpAnimation());
        } else if (EstaEnSuelo())
        {
            coyoteTimer = coyoteTime; // reinicia el tiempo si está en el suelo
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
        }
    }

    IEnumerator ResetJumpAnimation()
    {
        while (!EstaEnSuelo()) // Espera hasta que el personaje esté en el suelo
        {
            yield return null; // Espera un frame antes de volver a comprobar
        }

        animator.SetBool("jump", false);
    }

    //Método que gestiona el movimiento a derecha o izquierda del personaje.
    void Movement()
    {
        movement = Input.GetAxisRaw("Horizontal") * speed;

        rb.linearVelocityX = movement * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Caida"))
        {
            GameManager.instance.GameOver();
        }

        if ((collision.CompareTag("Finish") && GameManager.instance.CurrentScene()== "Bloody Mary"))
        {
            GameManager.instance.LoadLevel("Win");
        }

        if (collision.CompareTag("Finish"))
        {
            GameManager.instance.LoadLevel("Bloody Mary");
        }
    }
}

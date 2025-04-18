using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 20f; //Velocidad de movimiento, se modificar� en el inspector
    public Rigidbody2D rb; //Se inicia en el inspector
    public CapsuleCollider2D bc;
    public LayerMask suelo;

    public float fuerzaSalto; //Fuerza que se aplica al salto del personaje. Se modificar� desde el inspector.
    private float movement = 0f; //Se inicia en el inspector
    private Vector2 startPos; //Posicion inicial

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movimiento();
        salto();
    }


    bool estaEnSuelo()
    {
        //Esto emite una caja para comprobar si est� colisionando o no. Se dice de donde sale la caja, la dimension, el �ngulo, la direcci�n, la distancia que debe recorrer la caja y la mascara de la capa
        RaycastHit2D raycastHit2D= Physics2D.BoxCast(bc.bounds.center, new Vector2(bc.size.x, bc.size.y), 0f, Vector2.down, 0.59f, suelo);
        return raycastHit2D.collider != null;
    }
    //M�todo que hace saltar al personaje. Comprueba si se pulsa una tecla y aplica una fuerza de salto.
    void salto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaEnSuelo()) 
        {
            //Aplica la fuerza al salto, el segundo argumento indica que tipo de fuerza es, en este caso un impulso.
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    //M�todo que gestiona el movimiento a derecha o izquierda del personaje.
    void movimiento()
    {
        movement = Input.GetAxisRaw("Horizontal");

        rb.linearVelocityX = movement * speed;
    }


    /*
     //M�todo que gestiona resetear al personaje en caso de morir. Aun no usado.
    public void Reset()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPos;
    }
    */
}

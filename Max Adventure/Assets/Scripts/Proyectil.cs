using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float lifeTime = 3f;

    private void Start()
    {
        Destroy(gameObject, lifeTime); // Autodestruir después de un tiempo
    }

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime; // Mover hacia adelante
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.CompareTag("Player")))
        {
            Destroy(gameObject); // Destruir al impactar un enemigo
        }
    }
}

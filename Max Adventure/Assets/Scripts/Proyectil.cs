using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float lifeTime = 3f;
    private Vector2 shootDirection;
    private void Start()
    {
        Destroy(gameObject, lifeTime); // Autodestruir después de un tiempo
    }

    private void Update()
    {
        transform.position += (Vector3)shootDirection * speed * Time.deltaTime; //Mover

        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.CompareTag("Player")))
        {
            Destroy(gameObject); // Destruir al impactar un enemigo
        }
    }

    public void SetDirection(Vector2 shootDirection)
    {
        this.shootDirection = shootDirection;
    }
}

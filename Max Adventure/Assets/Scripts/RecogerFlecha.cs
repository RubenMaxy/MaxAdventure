using UnityEngine;

public class RecogerFlecha : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().RecibirMunicion(); // Llama el método en el jugador
            Destroy(gameObject); // Destruye la flecha después de recogerla
        }
    }
}

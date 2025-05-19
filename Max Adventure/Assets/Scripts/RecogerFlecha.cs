using UnityEngine;

public class RecogerFlecha : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().RecibirMunicion(); // Llama el m�todo en el jugador
            Destroy(gameObject); // Destruye la flecha despu�s de recogerla
        }
    }
}

using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform player; // El objeto Transform del jugador
    public float offset = 0; // La distancia de la cámara al jugador. Para que aparezca mas a la derecha o izquierda en la pantalla el Player

    private void LateUpdate() // Se ejecuta después de todos los update, para evitar problemas de movimiento
    {
        if (player != null)
        {
            // Calcula la nueva posición de la cámara
            Vector3 newPosition = new Vector3(player.position.x + offset, transform.position.y, transform.position.z);

            // Actualiza la posición de la cámara
            transform.position = newPosition;
        }
    }
}

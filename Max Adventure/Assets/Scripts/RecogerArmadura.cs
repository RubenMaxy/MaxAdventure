using UnityEngine;

public class RecogerArmadura : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.EquipArmor();
            Destroy(gameObject); // Destruye la flecha después de recogerla
        }
    }
}

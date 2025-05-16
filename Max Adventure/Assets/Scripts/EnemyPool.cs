using UnityEngine;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 5;
    public float spawnInterval = 3f;
    public Transform spawnPoint; // Punto base de spawn
    public float maxGroundCheckDistance = 10f; // Distancia para comprobar el suelo
    public LayerMask groundLayer; // Define qu� cuenta como suelo
    public float speed = 4f; // Velocidad de movimiento

    private List<GameObject> enemyPool = new List<GameObject>();

    private void Start()
    {
        // Crear un pool inicial de enemigos desactivados
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
       
        // Inicia el proceso de generaci�n de enemigos
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = spawnPoint.position;
        RaycastHit2D hit = Physics2D.Raycast(spawnPosition, Vector2.down, maxGroundCheckDistance, groundLayer);

        if (hit.collider != null) // Hay suelo
        {
            spawnPosition.y = hit.point.y; // Ajusta la posici�n al suelo detectado

            foreach (GameObject enemy in enemyPool)
            {
                if (!enemy.activeInHierarchy)
                {
                    enemy.transform.position = spawnPosition;
                    enemy.SetActive(true);

                    //Darle movimiento
                    Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
                    }
                    return;
                }
            }

            // Si todos los enemigos est�n activos, crea uno nuevo
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemyPool.Add(newEnemy);
        }
    }
    //Crear un script para el enemigo con las colisiones y el movimiento
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con el jugador, le quita una vida
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PlayerHit(); // M�todo para reducir vidas del jugador
        }

        // Si colisiona con un proyectil, se desactiva en el pool
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            gameObject.SetActive(false);
        }
    }
}

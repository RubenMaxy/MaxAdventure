using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerLives = 1; // Vida base
    public bool hasArmor = false; // Indica si el jugador tiene armadura

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EquipArmor()
    {
        hasArmor = true;
        playerLives = 2;
        Debug.Log("¡Has conseguido una armadura! Vidas: " + playerLives);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver"); // Carga la pantalla de Game Over 
    }

    public void PlayerHit()
    {
        if (hasArmor)
        {
            hasArmor = false;
            playerLives = 1;
            Debug.Log("Perdiste la armadura, ahora tienes " + playerLives + " vida.");
        }
        else
        {
            GameOver();
        }
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu"); // Carga el menú principal
    }
}

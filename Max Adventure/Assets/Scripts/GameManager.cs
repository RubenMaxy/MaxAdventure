using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static event System.Action<bool> OnArmorChanged;  //Evento que avisa a la UI de que debe activar o no el icono de armadura.
    public static event System.Action<int> OnArrowCountChanged; //Evento que avisa a la UI de que debe activar o no el icono de la flecha y la cantidad que hay

    public bool hasArmor = false; // Indica si el jugador tiene armadura
    public int proyectilesRestantes;
    public int maxProyectiles = 5; // Número máximo de proyectiles

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(instance.gameObject); // Destruye la instancia anterior si existe
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        proyectilesRestantes = maxProyectiles;
    }

    public void EquipArmor()
    {
        hasArmor = true;
        OnArmorChanged?.Invoke(hasArmor); // Notifica a la UI
    }

    public void UpdateArrowCount(int proyectilesRestantes)
    {
        this.proyectilesRestantes = proyectilesRestantes;
        OnArrowCountChanged?.Invoke(proyectilesRestantes); // Notifica a la UI
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
            OnArmorChanged?.Invoke(hasArmor); // Notifica a la UI
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

    public string CurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        return currentScene;
    }
}

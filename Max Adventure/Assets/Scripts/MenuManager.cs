using UnityEngine;


public class MenuManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        GameManager.instance.LoadLevel("MainMenu");
    }

    public void StartGame()
    {
        GameManager.instance.LoadLevel("Inicio");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartPlaying()
    {
        GameManager.instance.LoadLevel("Green Faery");
    }
}

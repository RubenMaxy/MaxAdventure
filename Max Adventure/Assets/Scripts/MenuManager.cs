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

    public void History()
    {
        GameManager.instance.LoadLevel("Historia");
    }

    public void Credits()
    {
        GameManager.instance.LoadLevel("Creditos");
    }
}

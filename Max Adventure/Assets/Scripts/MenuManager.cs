using UnityEngine;


public class MenuManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        GameManager.instance.LoadLevel("MainMenu");
    }

    public void StartGame()
    {
        GameManager.instance.LoadLevel("Green Faery");
    }

}

using UnityEngine;

public class BajarSubirTexto : MonoBehaviour
{
    public float speed = 2.0f;
    public Camera mainCamera;

    public void MoveUp()
    {
        mainCamera.transform.position += Vector3.up * speed;
    }

    public void MoveDown()
    {
        mainCamera.transform.position += Vector3.down * speed;
    }

    public void Back()
    {
        GameManager.instance.LoadLevel("MainMenu");
    }
}

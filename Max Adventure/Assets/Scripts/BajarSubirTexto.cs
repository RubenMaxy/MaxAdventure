using TMPro;
using UnityEngine;

public class BajarSubirTexto : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float speed = 150f;

    public void MoveUp()
    {
        textMeshPro.rectTransform.anchoredPosition += Vector2.down * speed;
    }

    public void MoveDown()
    {
        textMeshPro.rectTransform.anchoredPosition += Vector2.up * speed;
    }

    public void Back()
    {
        GameManager.instance.LoadLevel("MainMenu");
    }
}

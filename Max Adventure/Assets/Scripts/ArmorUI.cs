using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArmorUI : MonoBehaviour
{
    public Image armorIcon; // Icono de la UI
    public TextMeshProUGUI arrowText;
    public Image arrowIcon;

    void Start()
    {
        UpdateArmorUI(GameManager.instance.hasArmor);
        UpdateArrowUI(GameManager.instance.proyectilesRestantes);
        GameManager.OnArmorChanged += UpdateArmorUI;
        GameManager.OnArrowCountChanged += UpdateArrowUI;

    }

    void OnDestroy()
    {
        GameManager.OnArmorChanged -= UpdateArmorUI;
        GameManager.OnArrowCountChanged -= UpdateArrowUI;
    }

    void UpdateArmorUI(bool hasArmor)
    {
        armorIcon.gameObject.SetActive(hasArmor);
    }

    void UpdateArrowUI(int arrowCount)
    {
        arrowText.text = arrowCount.ToString();
        arrowIcon.gameObject.SetActive(arrowCount > 0); // Oculta si no hay flechas
    }
}

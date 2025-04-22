using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadFondo;
    private Vector2 offset;
    private Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset = velocidadFondo * Time.deltaTime;
        material.mainTextureOffset += offset;
    }

}

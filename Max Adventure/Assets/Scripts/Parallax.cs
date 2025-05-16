using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform target; // Referencia a la cámara
    [SerializeField] private ParallaxLayer[] layers; // Capas del fondo

    [System.Serializable]
    public class ParallaxLayer
    {
        public SpriteRenderer layerSprite;
        public float parallaxFactor;
    }

    private Vector2 previousTargetPosition;

    private void Start()
    {
        if (target != null)
        {
            previousTargetPosition = target.position;
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 deltaMovement = (Vector2)target.position - previousTargetPosition;

            foreach (var layer in layers)
            {
                Material material = layer.layerSprite.material;
                Vector2 targetOffset = deltaMovement * layer.parallaxFactor;
                material.mainTextureOffset += targetOffset * Time.fixedDeltaTime;
            }

            previousTargetPosition = target.position;
        }
    }
}

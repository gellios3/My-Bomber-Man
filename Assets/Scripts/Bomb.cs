using UnityEngine;

public class Bomb : MonoBehaviour
{
    /// <summary>
    /// Bomb count down
    /// </summary>
    [SerializeField] private float _countdown = 2f;

    /// <summary>
    /// Bomb explosion radius in tile 
    /// </summary>
    [SerializeField] private int _radius = 2;

    private void Update()
    {
        _countdown -= Time.deltaTime;

        if (!(_countdown <= 0f))
            return;
        FindObjectOfType<MapDestroyer>().Explode(transform.position, _radius);
        Destroy(gameObject);
    }
}
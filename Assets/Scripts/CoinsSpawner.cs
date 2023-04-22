using UnityEngine;
using Random = UnityEngine.Random;

public class CoinsSpawner : MonoBehaviour
{
    public static CoinsSpawner Instance { get; private set; }

    [SerializeField] private Rigidbody _coinPrefab;
    [SerializeField] private float _spawnForce = 2f;
    
    private void Awake()
    {
        Instance = this;
    }

    public void Spawn(Vector3 position, int count)
    {
        for (var i = 0; i < count; i++)
        {
            var coin = Instantiate(_coinPrefab, position, Quaternion.identity);
            var force = Random.insideUnitSphere;
            force.y = Mathf.Abs(force.y);

            coin.AddForce(force.normalized * _spawnForce, ForceMode.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp = 1;
    [SerializeField] private int _minCoins = 1;
    [SerializeField] private int _maxCoins = 3;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _attackRange = 1f;

    public void Damage(int value)
    {
        _hp -= value;

        if (_hp <= 0)
        {
            CoinsSpawner.Instance.Spawn(transform.position, Random.Range(_minCoins, _maxCoins + 1));
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance == null)
            return;
        
        var direction = Player.Instance.transform.position - transform.position;
        transform.position += direction.normalized * (_speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, Player.Instance.transform.position) < _attackRange)
        {
            Destroy(gameObject);
            Destroy(Player.Instance.gameObject);
        }
    }
}

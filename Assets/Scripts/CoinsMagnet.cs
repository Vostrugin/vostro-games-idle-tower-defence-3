using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class CoinsMagnet : MonoBehaviour
{
    [SerializeField] private float _magnetForce = 5f;
    [SerializeField] private float _distanceToCollect = .25f;
    [SerializeField] private LayerMask _layerMask;
    
    private List<GameObject> _coinsInRange = new List<GameObject>();
    private Ray _raycastRay;
    private RaycastHit _raycastHit;
    
    void Update()
    {
        _coinsInRange.RemoveAll(x => x == null);
        
        foreach (var coin in _coinsInRange)
        {
            coin.transform.position = Vector3.MoveTowards(
                coin.transform.position, 
                transform.position,
                _magnetForce * Time.deltaTime);
            
            if (Vector3.Distance(coin.transform.position, transform.position) < _distanceToCollect)
            {
                Destroy(coin);
                EconomyController.Instance.Balance += 1;
            }
        }
    }

    private void FixedUpdate()
    {
        _raycastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_raycastRay, out _raycastHit, 100, _layerMask))
        {
            var hitPosition = _raycastHit.point;
            transform.position = hitPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            _coinsInRange.Add(other.gameObject);
        }
    }
}

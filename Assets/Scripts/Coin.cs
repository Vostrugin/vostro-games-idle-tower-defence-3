using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 300;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), _rotationSpeed * Time.deltaTime);
    }
}

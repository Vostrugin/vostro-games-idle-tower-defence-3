using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class EconomyController : MonoBehaviour
    {
        public static EconomyController Instance { get; private set; }
        
        public int Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnBalanceChanged?.Invoke();
            }
        }
        
        public UnityEvent OnBalanceChanged;

        private int _balance;

        private void Awake()
        {
            Instance = this;
        }
    }
}
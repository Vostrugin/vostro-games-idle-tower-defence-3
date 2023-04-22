using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class CoinsPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private CanvasGroup _highlight;
        [SerializeField] private float _animationSpeed;

        public void UpdateValue()
        {
            _text.text = EconomyController.Instance.Balance.ToString();
            _highlight.alpha = 1;
        }
        
        private void Update()
        {
            if (_highlight.alpha > 0)
            {
                _highlight.alpha -= Time.deltaTime * _animationSpeed;
            }
        }
    }
}
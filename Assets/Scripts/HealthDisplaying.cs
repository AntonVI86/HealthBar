using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplaying : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private float _fillSpeed;
    [SerializeField] private Image _fill;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _finishColor;

    private void Awake()
    {
        _healthBar.maxValue = _playerHealth.MaxHealth;
    }

    private void OnEnable()
    {
        _playerHealth.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChanged -= OnHealthChanged;
    }

    public void OnHealthChanged(float health) 
    {
        StopAllCoroutines();
        StartCoroutine(ChangeHealthValue());
    }

    private IEnumerator ChangeHealthValue() 
    {
        while (_healthBar.value != _playerHealth.CurrentHealth) 
        {
            float normalizeValue = _playerHealth.CurrentHealth / _playerHealth.MaxHealth;

            _fill.color = Color.Lerp(_finishColor, _startColor, normalizeValue);
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _playerHealth.CurrentHealth, _fillSpeed * Time.deltaTime); 
            
            yield return null;
        }
    }
}

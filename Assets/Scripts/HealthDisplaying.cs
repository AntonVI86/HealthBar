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

    public void OnChangedHealthValue() 
    {
        StartCoroutine(ChangeHealthValue());
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor() 
    {
        float normValue = _playerHealth.CurrentHealth / _playerHealth.MaxHealth;
        _fill.color = Color.Lerp(_finishColor, _startColor, normValue);
        yield return null;
    }

    private IEnumerator ChangeHealthValue() 
    {
        while (_healthBar.value != _playerHealth.CurrentHealth) 
        {            
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _playerHealth.CurrentHealth, _fillSpeed * Time.deltaTime);           
            yield return null;
        }
    }
}

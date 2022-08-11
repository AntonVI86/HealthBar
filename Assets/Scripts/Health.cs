using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event UnityAction<float> HealthChanged;

    private float _currentHealth;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;


    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage) 
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth);
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
    }

    public void Heal(float healPower)
    {
        _currentHealth += healPower;
        HealthChanged?.Invoke(_currentHealth);
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
    }
}

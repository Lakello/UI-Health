using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HealthView _view;
    [SerializeField] private float _currentValue;

    public float CurrentValue { get { return _currentValue; } }
    private int _maxHealth => _player.MaxHealth;

    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        _currentValue = _maxHealth;
        HealthChanged?.Invoke(_currentValue);
    }

    public void TryTakeDamage(int value)
    {
        if (value > 0 && _currentValue > 0)
        {
            float newHealth = _currentValue;
            newHealth -= value;

            ChangeHealth(newHealth);
        }
    }

    public void TryTreatment(int value)
    {
        if (value > 0 && _currentValue < _maxHealth)
        {
            float newHealth = _currentValue;
            newHealth += value;

            ChangeHealth(newHealth);
        }
    }

    private void ChangeHealth(float newHealth)
    {
        _currentValue = Mathf.Clamp(newHealth, 0, _maxHealth);

        HealthChanged?.Invoke(_currentValue);
    }
}

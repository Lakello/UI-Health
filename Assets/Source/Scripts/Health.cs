using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _currentValue;

    private int _maxHealth => _player.MaxHealth;

    [SerializeField] private UnityEvent<int> _healthChanged;

    private void Start()
    {
        _currentValue = _maxHealth;
        _healthChanged?.Invoke(_currentValue);
    }

    public void TryChangeHealth(int value)
    {
        if ((value == 0) == false)
        {
            _currentValue += value;
            _currentValue = Mathf.Clamp(_currentValue, 0, _maxHealth);

            _healthChanged?.Invoke(_currentValue);
        }
    }
}

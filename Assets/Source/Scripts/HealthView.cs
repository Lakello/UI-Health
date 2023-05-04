using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private float _maxDelta = 1;

    private Coroutine _changeHealthViewCoroutine;

    private float _currentHealth => _health.CurrentValue;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    public void OnHealthChanged(float newHealth)
    {
        if (_changeHealthViewCoroutine != null)
        {
            StopCoroutine(_changeHealthViewCoroutine);
        }

        float targetHealth = newHealth / _player.MaxHealth;

        _changeHealthViewCoroutine = StartCoroutine(ChangeHealthView(targetHealth));
    }

    private IEnumerator ChangeHealthView(float targetValue)
    {
        float currentValue = _healthBar.value;

        while (currentValue != targetValue)
        {
            currentValue = Mathf.MoveTowards(currentValue, targetValue, _maxDelta);

            _healthBar.value = currentValue;
            _healthText.text = _currentHealth.ToString();

            yield return null;
        }
    }
}

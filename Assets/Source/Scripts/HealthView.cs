using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private float _maxDelta = 1;

    private Coroutine _changeHealthViewCoroutine;
     
    public void OnHealthChanged(int value)
    {
        if ((_changeHealthViewCoroutine == null) == false)
        {
            StopCoroutine(_changeHealthViewCoroutine);
        }

        _changeHealthViewCoroutine = StartCoroutine(ChangeHealthView(value));
    }

    private IEnumerator ChangeHealthView(float targetValue)
    {
        float currentValue = _healthBar.value * _player.MaxHealth;

        while ((currentValue == targetValue) == false)
        {
            currentValue = Mathf.MoveTowards(currentValue, targetValue, _maxDelta);

            _healthBar.value = currentValue / _player.MaxHealth;
            _healthText.text = currentValue.ToString();

            yield return null;
        }
    }
}

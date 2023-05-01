using System;
using UnityEngine;
using UnityEngine.Events;

public class ChangeHealthButton : MonoBehaviour
{
    private const int InvertInt = -1;

    [SerializeField] private int _damage = -10;
    [SerializeField] private int _treatment = 10;

    [SerializeField] private UnityEvent<int> _damaging;
    [SerializeField] private UnityEvent<int> _cureing;

    public void OnChangedDamageField(string value)
    {
        _damage = GetIntFromString(value) * InvertInt;
    }

    public void OnChangedTreatmentField(string value)
    {
        _treatment = GetIntFromString(value);
    }

    public void OnClickAttackButton()
    {
        _damaging?.Invoke(_damage);
    }

    public void OnClickTreatmentButton()
    {
        _cureing?.Invoke(_treatment);
    }

    private int GetIntFromString(string value)
    {
        return Int32.Parse(value);
    }
}

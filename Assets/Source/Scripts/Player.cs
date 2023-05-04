using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    public int MaxHealth { get { return _maxHealth; } }
}

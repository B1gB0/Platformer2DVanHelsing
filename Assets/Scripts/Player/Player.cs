using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _health;

    private PlayerMovement _playerMovement;
    private Weapon _currentWeapon;
    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    public float Money { get; private set; }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _currentWeapon = _weapons[0];
        _currentHealth = _health;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _playerMovement.Velocity.x == 0)
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddMoney(float money)
    {
        Money += money;

        Debug.Log(Money);
    }
}

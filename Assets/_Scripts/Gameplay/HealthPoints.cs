using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public System.Action<int> OnHealthChanged;
    public System.Action OutOfHealthPoints;

    [SerializeField] private BalloonsPool _balloonsPool;
    [Space]
    [SerializeField] private int startHealhPoints;

    private int _healthPoints;
    public int healthPoints
    {
        get => _healthPoints;
        private set
        {
            _healthPoints = value;

            OnHealthChanged?.Invoke(_healthPoints);

            if (_healthPoints == 0)
                OutOfHealthPoints?.Invoke();
        }
    }

    private void Start()
    {
        List<Balloon> balloons = _balloonsPool.pool.GetAllFreeElements();
        foreach (var ballon in balloons)
        {
            ballon.OnDrop += n => RemoveHealthPoint(n);
        }

        GameState.Instance.OnNewGame += NewGame;
    }

    private void RemoveHealthPoint(int damage)
    {
        healthPoints -= damage;
    }

    private void NewGame()
    {
        healthPoints = startHealhPoints;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public System.Action<int> OnValueChanged;

    [SerializeField] private BalloonsPool _balloonsPool;

    private int _pointsNumber;
    public int pointsNumber
    {
        get => _pointsNumber;
        private set
        {
            _pointsNumber = value;

            if (pointsNumber > PlayerPrefs.GetInt("BestScore", 0))
                PlayerPrefs.SetInt("BestScore", pointsNumber);

            OnValueChanged?.Invoke(_pointsNumber);
        }
    }

    private void Awake()
    {
        pointsNumber = 0;
    }

    private void Start()
    {
        List<Balloon> balloons = _balloonsPool.pool.GetAllFreeElements();
        foreach (var ballon in balloons)
        {
            ballon.OnPop += b => AddPoints(b.pointsValue);
        }

        GameState.Instance.OnNewGame += NewGame;
    }

    private void NewGame()
    {
        pointsNumber = 0;
    }

    private void AddPoints(int addedPoints)
    {
        pointsNumber += addedPoints;
    }
}

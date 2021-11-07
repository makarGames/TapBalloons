using UnityEngine;

public class BalloonsPool : MonoBehaviour
{
    [SerializeField] private int _poolCount = 50;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Balloon _balloonPrefab;
    [SerializeField] private Transform _balloonParent;

    public PoolMono<Balloon> pool { get; private set; }

    private void Awake()
    {
        pool = new PoolMono<Balloon>(_balloonPrefab, _poolCount, _balloonParent ?? transform);
        pool.autoExpand = _autoExpand;

        GameState.Instance.OnNewGame += KillAllBalloons;
    }

    public Balloon CreateBalloon(Vector3 position)
    {
        Balloon balloon = pool.GetFreeElement();
        balloon.transform.position = position;
        balloon.GetComponent<ItemMover>().LaunchingFall();
        return balloon;
    }

    public void KillAllBalloons()
    {
        var balloons = pool.GetAllElements();

        foreach (var balloon in balloons)
        {
            if (balloon.gameObject.activeInHierarchy)
                balloon.gameObject.SetActive(false);
        }
    }
}

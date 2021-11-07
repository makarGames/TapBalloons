using UnityEngine;

public class VfxEsplosionPool : MonoBehaviour
{
    [SerializeField] private int _poolCount = 10;
    [SerializeField] private bool _autoExpand = true;
    [SerializeField] private VfxExplosion _explosionPrefab;
    [SerializeField] private Transform _explosionParent;

    private PoolMono<VfxExplosion> _pool;

    private void Awake()
    {
        _pool = new PoolMono<VfxExplosion>(_explosionPrefab, _poolCount, _explosionParent ?? transform);
        _pool.autoExpand = _autoExpand;
    }

    public VfxExplosion CreateExplosion(Vector3 position)
    {
        VfxExplosion explosion = _pool.GetFreeElement();
        explosion.transform.position = position;
        return explosion;
    }
}

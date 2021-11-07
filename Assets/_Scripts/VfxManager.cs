using System.Collections.Generic;
using UnityEngine;

public class VfxManager : MonoBehaviour
{
    [SerializeField] private VfxEsplosionPool _explosionsPool;
    [SerializeField] private BalloonsPool _balloonsPool;

    private void Start()
    {
        List<Balloon> balloons = _balloonsPool.pool.GetAllFreeElements();
        foreach (var ballon in balloons)
        {
            ballon.OnPop += b => Explode(b.transform.position, b.currentColor);
        }
    }

    private void Explode(Vector3 position, Color color)
    {
        VfxExplosion explosion = _explosionsPool.CreateExplosion(position);
        explosion.color = color;
    }
}

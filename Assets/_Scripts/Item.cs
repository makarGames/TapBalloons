using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item fields")]
    [SerializeField] private int _pointsValue = 10;
    [SerializeField] private int _damageValue = 1;

    public int pointsValue => _pointsValue;
    public int damageValue => _damageValue;
}

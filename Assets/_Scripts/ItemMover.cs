using UnityEngine;
using DG.Tweening;

public class ItemMover : MonoBehaviour
{
    public System.Action OnItemDropped;

    private Difficulty _difficulty;

    private float _targetHeight;
    private float _speed = 1f;

    private void Awake()
    {
        _difficulty = Difficulty.Instance;
        _targetHeight = -Camera.main.orthographicSize - 1f;
    }

    public void LaunchingFall()
    {
        _speed = _difficulty.balloonSpeed;

        float speedOffset = Random.Range(-50f, 25f);
        _speed = _speed * (1f + speedOffset / 100f);

        float duration = Mathf.Abs(_targetHeight / _speed);
        transform.DOMoveY(_targetHeight, duration).SetEase(Ease.Linear).OnComplete(() => Finish()).SetId("itemMoving");
    }

    private void Finish()
    {
        OnItemDropped?.Invoke();
    }

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }
}

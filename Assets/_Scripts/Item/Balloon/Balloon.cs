using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(ItemMover))]
[RequireComponent(typeof(ItemClick))]
public class Balloon : Item
{
    public System.Action<Balloon> OnPop;
    public System.Action<int> OnDrop;

    [Header("Balloon fields")]
    [SerializeField] private MeshRenderer _renderer;

    [Header("Pop properties")]
    [SerializeField] [Range(1f, 3f)] private float _expansionRatio = 1.75f;
    [SerializeField] [Range(0.01f, 0.6f)] private float _expansionTime = 0.1f;
    [SerializeField] [Range(0.01f, 0.6f)] private float _compressionTime = 0.07f;

    private ItemMover _mover;
    private ItemClick _click;

    public Color currentColor { get; private set; }

    private void Awake()
    {
        _mover = GetComponent<ItemMover>();
        _mover.OnItemDropped += Drop;

        _click = GetComponent<ItemClick>();
        _click.OnClicked += Pop;
    }

    private void OnEnable()
    {
        SetNewColor();
        SetNewScale();
    }

    private void Pop()
    {
        OnPop?.Invoke(this);
        Death();
    }

    private void SetNewColor()
    {
        Color[] colors = ColorsContainer.balloonColors;
        Material material = _renderer.material;

        currentColor = colors[Random.Range(0, colors.Length)];
        material.color = currentColor;

        _renderer.material = material;
    }

    private void SetNewScale()
    {
        float scaleRatio = 1 + (Random.Range(-10f, 10f) / 100f);

        transform.localScale = new Vector3(scaleRatio, scaleRatio, scaleRatio);
    }

    private void Drop()
    {
        OnDrop?.Invoke(damageValue);
        gameObject.SetActive(false);
    }

    private void Death()
    {
        Sequence popAnimation = DOTween.Sequence();
        popAnimation.Append(transform.DOScale(transform.localScale * _expansionRatio, _expansionTime));
        popAnimation.Append(transform.DOScale(Vector3.zero, _compressionTime));
        popAnimation.AppendCallback(() => gameObject.SetActive(false));
    }
}

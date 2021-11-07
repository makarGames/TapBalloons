using UnityEngine;
using DG.Tweening;

public class PointNumberText : MonoBehaviour
{
    [SerializeField] private PointCounter _pointCounter;
    [SerializeField] private TMPro.TMP_Text _pointNumber;

    private Animation addingAnimation;

    private int _pointsNumber;
    private int pointsNumber
    {
        get => _pointsNumber;
        set
        {
            _pointsNumber = value;
            _pointNumber.text = _pointsNumber.ToString();
        }
    }

    private void Start()
    {
        addingAnimation = GetComponent<Animation>();
        _pointCounter.OnValueChanged += n => PointsAddition(n);
        pointsNumber = 0;
    }

    private void PointsAddition(int newPointsValue)
    {
        addingAnimation.Play();
        DOTween.To(() => pointsNumber, x => pointsNumber = x, newPointsValue, 0.4f).SetEase(Ease.InQuad);
    }
}

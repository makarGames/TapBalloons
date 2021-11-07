using UnityEngine;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [Header("Canvas group based")]
    [SerializeField] private MenuWindow _menuWindow;
    [SerializeField] private GameWindow _gameWindow;
    [Space]
    [SerializeField] private PointCounter _pointCounter;
    [SerializeField] private HealthPoints _healthPoints;

    private int currentScore
    {
        get => int.Parse(_menuWindow.currentScore.text);
        set
        {
            _menuWindow.currentScore.text = value.ToString();
        }
    }

    private void Awake()
    {
        _menuWindow.Enable(true);
        _menuWindow.continueGame.interactable = false;

        _gameWindow.Enable(false);
    }

    private void Start()
    {
        _menuWindow.newGame.onClick.AddListener(NewGame);
        _menuWindow.continueGame.onClick.AddListener(ContinueGame);

        _gameWindow.pauseButton.onClick.AddListener(PauseGame);

        _menuWindow.bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        _menuWindow.loseText.enabled = false;

        _healthPoints.OnHealthChanged += n => RemoveHealthPointImage(n);
        _healthPoints.OutOfHealthPoints += LoseGame;

        currentScore = 0;
    }

    private void NewGame()
    {
        _gameWindow.Enable(true, 0.1f);
        _menuWindow.Enable(false, 0.1f);

        currentScore = 0;
        _menuWindow.loseText.enabled = false;
    }

    private void PauseGame()
    {
        _menuWindow.bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        DOTween.To(() => currentScore, x => currentScore = x, _pointCounter.pointsNumber, 0.4f).SetEase(Ease.InQuad);

        _gameWindow.Enable(false, 0.1f);
        _menuWindow.Enable(true, 0.1f);

        _menuWindow.continueGame.interactable = true;
    }

    private void ContinueGame()
    {
        _gameWindow.Enable(true, 0.1f);
        _menuWindow.Enable(false, 0.1f);
    }

    private void RemoveHealthPointImage(int newHPvalue)
    {
        for (int i = 0; i < _gameWindow.healthImages.Count; i++)
        {
            _gameWindow.healthImages[i].enabled = i < newHPvalue;
        }
    }

    private void LoseGame()
    {
        PauseGame();

        DOTween.To(() => currentScore, x => currentScore = x, _pointCounter.pointsNumber, 1f).SetEase(Ease.InQuad);

        _menuWindow.continueGame.interactable = false;
        _menuWindow.loseText.enabled = true;
    }
}

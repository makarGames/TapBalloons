using UnityEngine;
using DG.Tweening;

public class GameState : MonoBehaviour
{
    #region Singleton
    private static GameState _instance;

    public static GameState Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameState>();

                if (_instance == null)
                {
                    var go = new GameObject("[GameState Handler]");
                    _instance = go.AddComponent<GameState>();
                }
            }

            return _instance;
        }
    }
    #endregion

    public System.Action OnNewGame;

    [SerializeField] private MenuWindow _menuWindow;
    [SerializeField] private GameWindow _gameWindow;
    [SerializeField] private HealthPoints _healthPoints;

    public bool IsPaused { get; private set; }

    private void Start()
    {
        _menuWindow.newGame.onClick.AddListener(NewGame);
        _menuWindow.continueGame.onClick.AddListener(ContinueGame);

        _gameWindow.pauseButton.onClick.AddListener(PauseGame);

        _healthPoints.OutOfHealthPoints += PauseGame;

        IsPaused = true;
    }

    private void NewGame()
    {
        OnNewGame?.Invoke();
        IsPaused = false;
    }

    private void PauseGame()
    {
        IsPaused = true;
        DOTween.Pause("itemMoving");
    }

    private void ContinueGame()
    {
        IsPaused = false;
        DOTween.Play("itemMoving");
    }
}

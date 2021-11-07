using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BalloonsPool))]
public class BalloonsLauncher : MonoBehaviour
{
    private BalloonsPool _pool;
    private Difficulty _difficulty;
    private GameState _gameState;

    private float _sideOffset;
    private float _heightOffset;
    private Vector3 _startPosition;
    private Vector2 _sideBorders;

    private Camera _mainCamera;

    private void Awake()
    {
        _pool = GetComponent<BalloonsPool>();

        _difficulty = Difficulty.Instance;
        _gameState = GameState.Instance;

        _mainCamera = Camera.main;
        _sideBorders = new Vector2(_mainCamera.orthographicSize * _mainCamera.aspect - 0.5f, _mainCamera.orthographicSize);
    }

    private void Start()
    {
        StartCoroutine(DelayedLaunchBalloon());
    }

    private void LaunchBalloon()
    {
        _startPosition = new Vector3(Random.Range(-_sideBorders.x, _sideBorders.x), _sideBorders.y, 0f);

        _pool.CreateBalloon(_startPosition);
        StartCoroutine(DelayedLaunchBalloon());
    }

    private IEnumerator DelayedLaunchBalloon()
    {
        yield return new WaitWhile(() => _gameState.IsPaused);
        yield return new WaitForSeconds(_difficulty.balloonLaunchDelay);
        yield return new WaitWhile(() => _gameState.IsPaused);

        LaunchBalloon();
    }
}

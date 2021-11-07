using UnityEngine;

public class Difficulty : MonoBehaviour
{
    #region Singleton
    private static Difficulty _instance;

    public static Difficulty Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Difficulty>();

                if (_instance == null)
                {
                    var go = new GameObject("[Difficulty Handler]");
                    _instance = go.AddComponent<Difficulty>();
                }
            }

            return _instance;
        }
    }
    #endregion

    [SerializeField] [Range(1f, 30f)] private float _difficultyRatio = 4f;

    private float _balloonSpeed;
    public float balloonSpeed
    {
        get => Mathf.Log(_difficultyStep, _difficultyRatio) + 1f /* 1  _difficultyStep  Mathf.Pow(_difficultyStep, 2) */;
    }

    private float _balloonLaunchDelay;
    public float balloonLaunchDelay
    {
        get => 1f / (Mathf.Log(_difficultyStep, _difficultyRatio) + 1) /* 1 1f / _difficultyStep Mathf.Pow(_difficultyStep, 2) */;
    }

    private float timer = 0f;

    private float _difficultyStep;

    private void Start()
    {
        GameState.Instance.OnNewGame += StartTimer;
    }

    public void StartTimer()
    {
        timer = 0f;

        _difficultyStep = 1f;
    }

    private void Update()
    {
        if (!GameState.Instance.IsPaused)
        {
            float deltaTime = Time.deltaTime;
            timer += deltaTime;

            if (timer >= _difficultyStep * 10f)
            {
                _difficultyStep += 0.1f;
            }
        }
    }
}

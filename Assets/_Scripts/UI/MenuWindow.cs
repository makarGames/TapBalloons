using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuWindow : CanvasGroupBased
{
    [Header("Buttons")]
    [SerializeField] private Button _newGame;
    [SerializeField] private Button _continueGame;

    [Header("Score")]
    [SerializeField] private TMP_Text _bestScore;
    [SerializeField] private TMP_Text _currentScore;

    [Space]
    [SerializeField] private TMP_Text _loseText;

    public Button newGame => _newGame;
    public Button continueGame => _continueGame;

    public TMP_Text bestScore => _bestScore;
    public TMP_Text currentScore => _currentScore;

    public TMP_Text loseText => _loseText;
}

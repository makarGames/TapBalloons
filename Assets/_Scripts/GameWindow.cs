using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameWindow : CanvasGroupBased
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private List<Image> _healthImages;

    public Button pauseButton => _pauseButton;
    public List<Image> healthImages => _healthImages;
}
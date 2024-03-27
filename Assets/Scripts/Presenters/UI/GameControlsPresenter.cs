using Solitaire.Models;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Solitaire.Presenters
{
    public class GameControlsPresenter : OrientationAwarePresenter
    {
        [SerializeField] Button _buttonOptions;
        [SerializeField] Button _buttonHome;
        [SerializeField] Button _buttonMatch;
        [SerializeField] Button _buttonUndo;
        [SerializeField] Button _buttonHint;

        [Inject] readonly GameControls _gameControls;
        [Inject] readonly GamePopup _gamePopup;

        RectTransform _rectOptions;
        RectTransform _rectHome;
        RectTransform _rectMatch;
        RectTransform _rectUndo;
        RectTransform _rectHint;
        RectTransform _rectLeaderboard;

        private void Awake()
        {
            _rectOptions = _buttonOptions.GetComponent<RectTransform>();
            _rectHome = _buttonHome.GetComponent<RectTransform>();
            _rectMatch = _buttonMatch.GetComponent<RectTransform>();
            _rectUndo = _buttonUndo.GetComponent<RectTransform>();
            _rectHint = _buttonHint.GetComponent<RectTransform>();
        }

        protected override void Start()
        {
            base.Start();

            _gamePopup.OptionsCommand.BindTo(_buttonOptions).AddTo(this);
            _gameControls.HomeCommand.BindTo(_buttonHome).AddTo(this);
            _gamePopup.MatchCommand.BindTo(_buttonMatch).AddTo(this);
            _gameControls.UndoCommand.BindTo(_buttonUndo).AddTo(this);
            _gameControls.HintCommand.BindTo(_buttonHint).AddTo(this);
        }

        protected override void OnOrientationChanged(bool isLandscape)
        {
        }
    }
}

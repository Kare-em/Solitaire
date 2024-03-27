using Solitaire.Models;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

namespace Solitaire.Presenters
{
    public class PopupMatchPresenter : OrientationAwarePresenter
    {
        [SerializeField] Button _buttonRestart;
        [SerializeField] Button _buttonNewMatch;
        [SerializeField] RectTransform _panelRect;

        [Inject] readonly Game _game;

        RectTransform _rectRestart;
        RectTransform _rectNewMatch;
        RectTransform _rectContinue;

        private void Awake()
        {
            _rectRestart = _buttonRestart.GetComponent<RectTransform>();
            _rectNewMatch = _buttonNewMatch.GetComponent<RectTransform>();
        }

        protected override void Start()
        {
            base.Start();

            // Bind commands
            _game.RestartCommand.BindTo(_buttonRestart).AddTo(this);
            _game.NewMatchCommand.BindTo(_buttonNewMatch).AddTo(this);
        }

        protected override void OnOrientationChanged(bool isLandscape)
        {
          }
    }
}

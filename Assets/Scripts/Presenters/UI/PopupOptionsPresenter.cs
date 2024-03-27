using Solitaire.Models;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Solitaire.Presenters
{
    public class PopupOptionsPresenter : OrientationAwarePresenter
    {
        [SerializeField] Button _buttonClose;
        [SerializeField] Toggle _toggleDraw;
        [SerializeField] Toggle _toggleAudio;
        [SerializeField] TextMeshProUGUI _labelRestart;
        [SerializeField] RectTransform _panelRect;

        [Inject] readonly Options _options;

        protected override void Start()
        {
            base.Start();

            _options.CloseCommand.BindTo(_buttonClose).AddTo(this);
            _options.AudioEnabled.BindTo(_toggleAudio).AddTo(this);
        }

        protected override void OnOrientationChanged(bool isLandscape)
        {
        }
    }
}

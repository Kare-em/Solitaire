using DG.Tweening;
using Solitaire.Models;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Solitaire.Presenters
{
    public class HomePresenter : OrientationAwarePresenter
    {
        [SerializeField] Button _buttonNewMatch;
        [SerializeField] Button _buttonOptions;

        [Inject] readonly Game _game;
        [Inject] readonly GamePopup _gamePopup;
        [Inject] readonly GameState _gameState;

        RectTransform _rectLeaderboard;
        Sequence _sequenceCards;
        Sequence _sequenceSuitsCenter;
        Sequence _sequenceSuitsLeft;
        Sequence _sequenceSuitsRight;

        public void Quit()
        {
            Application.Quit();
        }
        private void Awake()
        {
        }

        protected override void Start()
        {
            base.Start();

            _game.NewMatchCommand.BindTo(_buttonNewMatch).AddTo(this);
            _gamePopup.OptionsCommand.BindTo(_buttonOptions).AddTo(this);

            // Play animation sequence on state change
            _gameState.State.Where(state => state == Game.State.Home).Subscribe(_ => 
                PlayAnimationSequence(_orientation.State.Value == Orientation.Landscape)).AddTo(this);
        }

        protected override void OnOrientationChanged(bool isLandscape)
        {

          

            PlayAnimationSequence(isLandscape);
        }

        private void PlayAnimationSequence(bool isLandscape)
        {
            AnimateCards(ref _sequenceCards);
        }

        private void AnimateCards(ref Sequence sequence)
        {
            if (sequence == null)
            {
                sequence = DOTween.Sequence();
                sequence.SetAutoKill(false);
            }
            else
            {
                sequence.Restart();
            }
        }

        private void AnimateSuits(ref Sequence sequence, RectTransform rectSuits, bool isReverse)
        {
            if (sequence == null)
            {
                sequence = DOTween.Sequence();
                sequence.SetAutoKill(false);
                sequence.AppendInterval(1f);

                for (int i = isReverse ? rectSuits.childCount - 1 : 0;
                    isReverse ? i >= 0 : i < rectSuits.childCount;
                    i += isReverse ? -1 : 1)
                {
                    Transform rect = rectSuits.GetChild(i);
                    rect.transform.localScale = Vector3.zero;

                    sequence.Append(rect.DOScale(Vector3.one, 0.125f).SetEase(Ease.InCubic))
                        .Append(rect.DOPunchScale(Vector3.one * 0.5f, 0.125f).SetEase(Ease.OutCubic));
                }
            }
            else
            {
                sequence.Restart();
            }
        }
    }
}

using Solitaire.Services;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Solitaire.Presenters
{
    public class GameInfoPresenter : OrientationAwarePresenter
    {
        [SerializeField] TextMeshProUGUI _labelPoints;
        [SerializeField] TextMeshProUGUI _labelMoves;
        [SerializeField] RectTransform _rectPoints;
        [SerializeField] RectTransform _rectTime;
        [SerializeField] RectTransform _rectMoves;

        [Inject] readonly IPointsService _pointsService;
        [Inject] readonly IMovesService _movesService;

        protected override void Start()
        {
            base.Start();

            _pointsService.Points.SubscribeToText(_labelPoints).AddTo(this);
            _movesService.Moves.SubscribeToText(_labelMoves).AddTo(this);
        }

        protected override void OnOrientationChanged(bool isLandscape)
        {
           }
    }
}

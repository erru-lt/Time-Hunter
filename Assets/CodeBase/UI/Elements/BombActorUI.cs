using Assets.CodeBase.GameLogic.BombLogic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.UI.Elements
{
    public class BombActorUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeText;
        private Bomb _bomb;

        [Inject]
        public void Construct(Bomb bomb)
        {
            _bomb = bomb;
        }

        private void Update()
        {
            _timeText.SetText(_bomb.Duration.ToString("F1"));
        }
    }
}

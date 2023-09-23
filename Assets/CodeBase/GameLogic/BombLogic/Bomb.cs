using UnityEngine;

namespace Assets.CodeBase.GameLogic.BombLogic
{
    public class Bomb : MonoBehaviour
    {
        public float Duration => _duration;
        [SerializeField] private float _duration;

        private void Update()
        {
            DecreaseDuration();
        }

        public void IncreaseDuration(float timeValue)
        {
            _duration += timeValue;
        }

        private void DecreaseDuration()
        {
            _duration -= Time.deltaTime;

            if(_duration < 0 )
            {
                Explode();
            }
        }

        private void Explode()
        {
            Debug.Log("explosion. game over");
        }
    }
}

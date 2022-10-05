using UnityEngine;
using Game.Data;

namespace Game.Gameplay
{
    public class Spawn : MonoBehaviour
    {
        [SerializeField] private Source _source;
        [SerializeField] private Transform _gameFiled;
        [SerializeField] private Cinemachine.CinemachineVirtualCamera _virtCamera;

        private Vector2 _sizeGameFiled;
        private Vector2 _tmp;

        private BoxCollider2D _collider;
        private float _radius;
        private int _index;

        public Player Player { get; set; }

        private void Awake()
        {
            _sizeGameFiled.x = _gameFiled.localScale.x / 2;
            _sizeGameFiled.y = _gameFiled.localScale.y / 2;
            SetSpawnBody();
            Player = FindObjectOfType<Player>();
            _virtCamera.Follow = Player.transform;
        }

        private void SetSpawnBody()
        {
            _collider = _source.Coin.GetComponent<BoxCollider2D>();
            _radius = _collider.size.x + _collider.size.y / 2;
            SpawnBody(_collider, _source.MaxCoins);

            _index = 0;
            _collider = _source.Spike.GetComponent<BoxCollider2D>();
            _radius = _collider.size.x + _collider.size.y / 2;
            SpawnBody(_collider, _source.MaxSpike);

            _index = 0;
            _collider = _source.Player.GetComponent<BoxCollider2D>();
            _radius = _collider.size.x + _collider.size.y / 2;
            SpawnBody(_collider, 1);
        }

        private void SpawnBody(BoxCollider2D body, int max)
        {
            _tmp.x = Random.Range(-(_sizeGameFiled.x - _radius), _sizeGameFiled.x - _radius);
            _tmp.y = Random.Range(-(_sizeGameFiled.y - _radius), _sizeGameFiled.y - _radius);

            if (Physics2D.OverlapBoxAll(_tmp, body.size, 1).Length == 1)
            {
                Instantiate(body).transform.position = _tmp;
                _index++;
            }

            if (_index != max)
                SpawnBody(body, max);
        }
    }
}
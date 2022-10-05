using System.Collections.Generic;
using Game.Gameplay;
using UnityEngine;
using System.Linq;
using Game.Data;
using System;

public class Player : MonoBehaviour
{
    public event Action Dead;

    [SerializeField] private GameRules _rules;
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _self;
    [SerializeField] private LineRenderer _line;

    private List<Vector3> _direction;
    private Coin _coin;
    private Spike _spike;

    private void Start()
    {
        _direction = new List<Vector3>();
        _self.color = _rules.Color;
        _camera = Camera.main;
    }

    private void Move()
    {
        if (_direction.Count > 0)
            if (Vector3.Distance(_direction.FirstOrDefault(), transform.position) > .1f)
                transform.position = Vector3.Slerp(transform.position, _direction.FirstOrDefault(), _rules.Speed * Time.deltaTime);
            else
                _direction.Remove(_direction.FirstOrDefault());
    }

    private void DrawRote()
    {
        if (_direction?.Count > 0)
        {
            _line.startColor = Color.red;
            _line.positionCount = _direction.Count;
            for (int i = 0; i < _direction.Count; i++)
                _line.SetPosition(i, _direction[i]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out _coin)) _rules.Coins++;
        if (collision.TryGetComponent(out _spike))
        {
            Dead?.Invoke();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            _direction.Add(pos);
        }

        Move();
        DrawRote();
    }
}

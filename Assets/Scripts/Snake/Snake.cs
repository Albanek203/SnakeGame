using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Snake : MonoBehaviour {
    [SerializeField]
    private SnakeHead _head;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _tailSpringiness;
    [SerializeField]
    private int _tailSize;

    private SnakeInput _snakeInput;
    private TailGenerator _tailGenerator;
    private List<Segment> _tail;

    public event UnityAction<int> SizeUpdated;

    private void Start() {
        _tailGenerator = GetComponent<TailGenerator>();
        _snakeInput = GetComponent<SnakeInput>();
        _tail = _tailGenerator.Generate(_tailSize);
        SizeUpdated?.Invoke(_tail.Count);
    }

    private void OnEnable() {
        _head.BlockCollided += OnBlockCollided;
        _head.BonusPickUp += OnBonusPickUp;
    }

    private void OnDisable() {
        _head.BlockCollided -= OnBlockCollided;
        _head.BonusPickUp -= OnBonusPickUp;
    }

    private void FixedUpdate() {
        Move(_head.transform.position + _head.transform.up * (_speed * Time.fixedDeltaTime));
        _head.transform.up = _snakeInput.GetDirectionToClick(_head.transform.position);
    }

    private void Move(Vector3 nextPosition) {
        var prevPosition = _head.transform.position;
        foreach (var tailSegment in _tail) {
            var position = tailSegment.transform.position;
            var tempPosition = position;
            position = Vector2.Lerp(position, prevPosition, _tailSpringiness * Time.fixedDeltaTime);
            tailSegment.transform.position = position;
            prevPosition = tempPosition;
        }
        _head.Move(nextPosition);
    }

    private void OnBlockCollided() {
        var deletedSegment = _tail[_tail.Count - 1];
        _tail.Remove(deletedSegment);
        Destroy(deletedSegment.gameObject);
        SizeUpdated?.Invoke(_tail.Count);
    }

    private void OnBonusPickUp(int bonusValue) {
        _tail.AddRange(_tailGenerator.Generate(bonusValue));
        SizeUpdated?.Invoke(_tail.Count);
    }
}
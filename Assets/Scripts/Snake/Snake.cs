using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {
    [SerializeField]
    private SnakeHead _head;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _tailSpringiness;

    private SnakeInput _snakeInput;
    private TailGenerator _tailGenerator;
    private List<Segment> _tail;

    private void Start() {
        _tailGenerator = GetComponent<TailGenerator>();
        _snakeInput = GetComponent<SnakeInput>();
        _tail = _tailGenerator.Generate();
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
}
using UnityEngine;
using Random = UnityEngine.Random;

public class Wall : MonoBehaviour {
    [SerializeField]
    private Vector2Int _scaleValueRange;

    private int _scaleValue;

    private void Start() {
        _scaleValue = Random.Range(_scaleValueRange.x, _scaleValueRange.y);
        print(_scaleValue);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + _scaleValue - 0.5f
                                         , transform.localScale.z);
    }
}
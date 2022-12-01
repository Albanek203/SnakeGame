using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour {
    [SerializeField]
    private Vector2Int _destroyPriceRange;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private int _destroyPrice;
    private int _filling;
    

    public event UnityAction<int> FillingProgress;

    private int LeftToFill => _destroyPrice - _filling;
    public int Filling => _filling;


    private void Start() {
        _spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        _destroyPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);
        FillingProgress?.Invoke(LeftToFill);
    }

    public void Fill() {
        _filling++;
        FillingProgress?.Invoke(LeftToFill);
        if (_filling == _destroyPrice) Destroy(gameObject);
    }
}
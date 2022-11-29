using System.Collections.Generic;
using UnityEngine;

public class TailGenerator : MonoBehaviour {
    [SerializeField]
    private Segment _segmentTemplate;
    [SerializeField]
    private int _tailSize;

    public List<Segment> Generate() {
        var tail = new List<Segment>();
        for (var i = 0; i < _tailSize; i++) { tail.Add(Instantiate(_segmentTemplate, transform)); }
        return tail;
    }
}
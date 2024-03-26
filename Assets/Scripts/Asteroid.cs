using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float _maxSpeed = 7f;
    private float _minSpeed = 2f;

    private float _speed;

    private void Start()
    {
        var random = new System.Random();
        _speed = (float)random.NextDouble() * _maxSpeed + _minSpeed;
    }

    void Update()
    {
        transform.position += _speed * Time.deltaTime * Vector3.down;
    }
}

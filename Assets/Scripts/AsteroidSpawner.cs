using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _asteroidPrefab;

    [SerializeField]
    private Camera _camera;

    private System.Random _random = new System.Random();

    private float _xMin, _xMax, _yMin, _yMax;

    void Start()
    {
        CalculateBounds();
        // for (int i = 0; i < 10; i++)
        // {
        SpawnAsteroid();
        // }
    }

    public void SpawnAsteroid()
    {
        float x = (float)_random.NextDouble() * _xMax + _xMin;
        float y = _yMax + 2;
        Debug.Log($"Spawning asteroid at {x},{y}");
        Instantiate(_asteroidPrefab, new Vector3(x, y, 0), new Quaternion());
    }

    private void CalculateBounds()
    {
        float camHeight = 2 * _camera.orthographicSize;
        float camWidth = camHeight * _camera.aspect;

        _xMin = _camera.transform.position.x - camWidth / 2;
        _xMax = _camera.transform.position.x + camWidth / 2;
        _yMin = _camera.transform.position.y - camHeight / 2;
        _yMax = _camera.transform.position.y + camHeight / 2;

        Debug.Log($"{_xMin}, {_xMax}, {_yMin}, {_yMax}");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool isActive = false;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject[] enemiesObject;

    [SerializeField] private float _spawnInterval;
    private int _spawnCount = 0;
    [SerializeField] private int _maxSpawnAmount;

    [SerializeField] private int _mixX;
    [SerializeField] private int _maxX;
    [SerializeField] private int _mixY;
    [SerializeField] private int _maxY;

    [SerializeField] private float _height;

    private float _currentSpawnTimer;
    private void Update()
    {
        if (isActive)
        {
            _currentSpawnTimer += Time.deltaTime;
            enemiesObject = GameObject.FindGameObjectsWithTag("Enemy");
            _spawnCount = enemiesObject.Length;
            if (_currentSpawnTimer >= _spawnInterval && _spawnCount < _maxSpawnAmount)
            {
                var enemyInstance = Instantiate(_enemyPrefab);

                var newPosition = GenerateStartPosition();

                enemyInstance.transform.position = newPosition;

                _currentSpawnTimer = 0;
            }
        }
    }
    
    private Vector3 GenerateStartPosition()
    {
        var startPos = new Vector3(Random.Range(_mixX, _maxX), _height, Random.Range(_mixY, _maxY));

        return startPos;
    }

    public void activateSpawner()
    {
        isActive = true;
    }
    public void deactivateSpawner()
    {
        isActive = false;
    }
    public void enemyDeath()
    {
        _spawnCount--;
    }
}

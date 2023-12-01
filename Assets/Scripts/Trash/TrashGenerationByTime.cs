using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGenerationByTime : MonoBehaviour
{
    [SerializeField] private TrashFactory trashFactory;

    [SerializeField] private int _minTrash = 5;
    [SerializeField] private int _maxTrash = 15;
    [SerializeField] private int _trashPerSpawn = 1;
    [SerializeField] private float _spawnRate = 5f;

    private int _currentTrash = 0;

    void Start()
    {
        StartCoroutine(IncreaseTrashOverTime());
    }

    IEnumerator IncreaseTrashOverTime()
    {
        for (int i = 0; i < _maxTrash; i++)
        {
            yield return new WaitForSeconds(_spawnRate);
            SpawnTrash();
        }
    }

    void SpawnTrash()
    {
        if (_currentTrash < _maxTrash)
        {
            for (int i = 0; i < _trashPerSpawn; i++)
            {
                trashFactory.Generate(Vector3.zero);
                _currentTrash++;
            }
        }
    }
}

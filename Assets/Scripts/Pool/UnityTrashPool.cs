using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class UnityTrashPool : Pool
{
    [SerializeField] Factory trashFactory;

    private IObjectPool<Transform> _trashPool;

    void Start()
    {
        _trashPool = new ObjectPool<Transform>(CreateNewTrash, OnGettingTrash, OnReleasingTrash, OnDestroyingTrash);
    }

    private Transform CreateNewTrash()
    {
        return trashFactory.Generate(Vector3.zero);
    }

    private void OnGettingTrash(Transform trash)
    {
        trash.gameObject.SetActive(true);
    }

    private void OnReleasingTrash(Transform trash)
    {
        trash.gameObject.SetActive(false);
    }

    private void OnDestroyingTrash(Transform trash)
    {
        Destroy(trash.gameObject);
    }

    public override Transform Get(Vector3 position)
    {
        Transform trash = _trashPool.Get();
        trash.position = position;
        trash.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        return trash;
    }

    public override void Release(Transform element)
    {
        _trashPool.Release(element);
    }
}

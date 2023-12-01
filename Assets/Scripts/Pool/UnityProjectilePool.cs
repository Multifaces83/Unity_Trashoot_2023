using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class UnityProjectilePool : Pool
{
    [SerializeField] Factory projectilesFactory;

    private IObjectPool<Transform> _projectilesPool;

    void Start()
    {
        _projectilesPool = new ObjectPool<Transform>(CreateNewProjectile, OnGettingProjectile, OnReleasingProjectile, OnDestroyingProjectile);
    }

    private Transform CreateNewProjectile()
    {
        return projectilesFactory.Generate(Vector3.zero);
    }

    private void OnGettingProjectile(Transform projectile)
    {
        projectile.gameObject.SetActive(true);
    }

    private void OnReleasingProjectile(Transform projectile)
    {
        projectile.gameObject.SetActive(false);
    }

    private void OnDestroyingProjectile(Transform projectile)
    {
        Destroy(projectile.gameObject);
    }

    public override Transform Get(Vector3 position)
    {
        Transform projectile = _projectilesPool.Get();
        projectile.position = position;
        //projectile.rotation = Quaternion.identity;
        projectile.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        return projectile;
    }

    public override void Release(Transform element)
    {
        _projectilesPool.Release(element);
    }
}

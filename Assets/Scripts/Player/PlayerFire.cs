using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour, IFire
{
    [SerializeField] private PlayerInputCustom playerInputCustom;
    [SerializeField] private Pool projectilePool;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;

    [SerializeField] private float _rateOfFire = 0.5f;
    private float _nextFireTime;


    void Start()
    {
        _nextFireTime = 0f;
    }
    void Update()
    {
        if (playerInputCustom.fire && Time.time > _nextFireTime)
        {
            _nextFireTime = Time.time + _rateOfFire;
            Fire();
        }
    }

    public void Fire()
    {
        Transform newProjectile = projectilePool.Get(projectileSpawnPoint.position);
        newProjectile.rotation = Quaternion.LookRotation(transform.forward, transform.up);
        projectilePrefab.Add(newProjectile);

        Vector2 spawnDirection = projectileSpawnPoint.up;
        Debug.Log("Spawn Direction: " + spawnDirection);
    }
}

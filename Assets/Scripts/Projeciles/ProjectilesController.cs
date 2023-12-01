using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesController : MonoBehaviour, IProjectile
{
    [SerializeField] protected Rigidbody2D _rigidbody2D;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _lifeTime;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _knockback;
    [SerializeField] protected float _knockbackRadius;
    [SerializeField] protected LayerMask _layerMask;
    [SerializeField] protected GameObject _impactEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        _rigidbody2D.velocity = direction * _speed;
        Destroy(gameObject, _lifeTime);
    }
}

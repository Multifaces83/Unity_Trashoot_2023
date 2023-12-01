using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //[SerializeField] private GameObject _spawnPoint;
    [SerializeField] private Pool projectilePool;
    [SerializeField] private float _speed = 10f;

    [SerializeField] private float duration = 2f;

    private List<Transform> projectiles;

    private List<Transform> toRemove;

    void Start()
    {
        projectiles = new List<Transform>();
        toRemove = new List<Transform>();

    }

    public void Add(Transform t)
    {
        projectiles.Add(t);
        StartCoroutine(ReturnToPoolAfterDelay(t.gameObject, duration));

        Rigidbody2D _rb = t.GetComponent<Rigidbody2D>();
        if (_rb != null)
        {
            //rb.AddForce = Vector2.up * _speed;
            _rb.AddForce(t.up * _speed, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        toRemove.Clear();

        foreach (Transform t in projectiles)
        {
            //t.position += Vector3.up * _speed * Time.fixedDeltaTime;
        }

        if (toRemove.Count > 0)
        {
            projectiles.RemoveAll(t => toRemove.Contains(t));
        }
    }

    IEnumerator ReturnToPoolAfterDelay(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        projectilePool.Release(go.transform);
        projectiles.Remove(go.transform);
    }
}

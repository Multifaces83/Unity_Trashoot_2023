using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] private Pool trashPool;
    [SerializeField] private float _speed = 10f;

    [SerializeField] private float duration = 2f;
    [SerializeField] private GameObject _player;

    private List<Transform> trash;

    private List<Transform> toRemove;

    void Start()
    {
        trash = new List<Transform>();
        toRemove = new List<Transform>();
    }

    public void Add(Transform t)
    {
        trash.Add(t);
    }

    void FixedUpdate()
    {
        toRemove.Clear();

        foreach (Transform t in trash)
        {
            // Calculez la direction vers la position du joueur
            Vector3 directionToPlayer = (_player.transform.position - t.position).normalized;

            // Déplacez le déchet dans la direction du joueur
            t.Translate(directionToPlayer * _speed * Time.fixedDeltaTime);
        }

        if (toRemove.Count > 0)
        {
            trash.RemoveAll(t => toRemove.Contains(t));
        }
    }
}

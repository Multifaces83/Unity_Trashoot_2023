using UnityEngine;

public class ProjectileFatory : Factory
{
    [SerializeField] private GameObject _projectilePrefab;

    public override Transform Generate(Vector3 position)
    {
        GameObject go = Instantiate(_projectilePrefab);
        go.transform.position = position;
        //go.transform.rotation = Quaternion.identity;
        return go.transform;
    }
}
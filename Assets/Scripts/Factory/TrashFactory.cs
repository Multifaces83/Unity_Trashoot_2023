using UnityEngine;

public class TrashFactory : Factory
{
    [SerializeField] private GameObject[] _trashPrefab;



    public override Transform Generate(Vector3 position)
    {
        if (_trashPrefab.Length == 0)
        {
            return null;
        }

        GameObject go = Instantiate(_trashPrefab[Random.Range(0, _trashPrefab.Length)]);
        float randomX = Random.Range(-1f, 1f) * Camera.main.orthographicSize * Camera.main.aspect;
        float randomY = Random.Range(-1f, 1f) * Camera.main.orthographicSize;

        int randomDirection = Random.Range(0, 4);

        switch (randomDirection)
        {
            case 0: //Up
                go.transform.position = new Vector2(randomX, Camera.main.orthographicSize + 1f);
                break;
            case 1: //Down
                go.transform.position = new Vector2(randomX, -Camera.main.orthographicSize - 1f);
                break;
            case 2: //Left
                go.transform.position = new Vector2(-Camera.main.orthographicSize * Camera.main.aspect - 1f, randomY);
                break;
            case 3: //Right
                go.transform.position = new Vector2(Camera.main.orthographicSize * Camera.main.aspect + 1f, randomY);
                break;

        }
        return go.transform;
    }
}

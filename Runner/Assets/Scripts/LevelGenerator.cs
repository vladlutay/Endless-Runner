using UnityEngine;
using System.Collections.Generic;

enum Direction { LEFT, STRAIGHT, RIGHT }

public class LevelGenerator : MonoBehaviour
{
    private const int minDir = 0;
    private const int maxDir = 3;
    private const int roadNum = 3;
    private const int startPrefabIndex = 1;
    private const int angleOffset = 90;

    public GameObject[] roads = new GameObject[roadNum];
    public Transform startPos;


    private GameObject newstraightRoad;
    private Vector3 currentPos;
    private GameObject currentPrefab;
    private float currentAngleZ = 0;
    private float oldAngleZ = 0;
    private Queue<GameObject> dataRoads = new Queue<GameObject>();

    private void Awake()
    {

        for (int i = 0; i < roadNum; i++)
            roads[i].transform.rotation = Quaternion.identity;
    }

    private void Start()
    {
        currentPos = startPos.position;
        currentPrefab = roads[startPrefabIndex];
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            CreatePlatform();
        }
    }

    public void CreatePlatform()
    {
        newstraightRoad = Instantiate(currentPrefab, currentPos, currentPrefab.transform.rotation);
        newstraightRoad.transform.SetParent(startPos);
        dataRoads.Enqueue(newstraightRoad);
        // Set the next position
        int way = new System.Random().Next(minDir, maxDir);
        currentPos = newstraightRoad.transform.GetChild(way).position;
        currentPrefab = roads[way];
        if(way == (int)Direction.LEFT || way == (int)Direction.RIGHT)
        {
            oldAngleZ = currentAngleZ;
            SetCorrectAngle((Direction)way);
            currentPrefab.transform.rotation = Quaternion.Euler(0, 0, oldAngleZ);
            return;
        }
        currentPrefab.transform.rotation = Quaternion.Euler(0, 0, currentAngleZ);
    }

    private void SetCorrectAngle(Direction _dir)
    {
        switch (_dir)
        {
            case Direction.LEFT:
                    currentAngleZ += angleOffset;
                break;

            case Direction.RIGHT:
                    currentAngleZ -= angleOffset;
                break;
        }
    }
}

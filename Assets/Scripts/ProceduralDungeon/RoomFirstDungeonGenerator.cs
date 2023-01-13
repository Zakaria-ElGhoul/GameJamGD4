using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomFirstDungeonGenerator : SimpleRandomWalkDungeonGenerator
{
    public static RoomFirstDungeonGenerator current;

    [Space(10)]
    [Range(4, 400)][SerializeField] private int minRoomWidth = 4;
    [Range(4, 400)][SerializeField] private int minRoomHeight = 4;

    [Space(10)]
    [Range(20, 1000)][SerializeField] private int dungeonWidth = 20;
    [Range(4, 1000)][SerializeField] private int dungeonHeight = 20;

    [Space(10)]
    [Range(1, 10)][SerializeField] private int minEnemySpawnCount = 2;
    [Range(1, 10)][SerializeField] private int maxEnemySpawnCount = 3;

    [Space(10)]
    [Range(0, 10)][SerializeField] private int offset = 5;

    [Space(10)]
    [SerializeField] private Vector2Int dungeonCorridorWidthOffset;

    [Space(10)]
    [SerializeField] private bool randomWalkRooms = false;

    [Space(10)]
    [Header("GameObject References")]
    [Space(10)]
    [SerializeField] private GameObject[] enemyGameObject;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject endPoint;

    [Space(10)]
    [Header("Camera Variables")]
    [Space(10)]
    [SerializeField] private GameObject cam;
    [SerializeField] private float camOffset;

    [Space(10)]
    [Header("Enemy Data")]
    [Space(10)]
    [SerializeField] private List<int> randomEnemySpawnCount = new List<int>();
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private List<Vector2Int> pos = new List<Vector2Int>();
    [SerializeField] private int sum;
    [SerializeField] public float progress;
    [SerializeField] public bool isDone;

    void Awake()
    {
        current = this;
    }

    void Start()
    {
        tilemapVisualizer.Clear();
        CreateRooms();
    }

    protected override void RunProceduralGeneration()
    {
        CreateRooms();
    }

    private void CreateRooms()
    {
        var roomsList = ProceduralGenerationAlgorithms.BinarySpacePartitioning(new BoundsInt((Vector3Int)startPosition, new Vector3Int(dungeonWidth, dungeonHeight, 2)), minRoomWidth, minRoomHeight);

        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();

        if (randomWalkRooms)
        {
            floor = CreateRoomsRandomly(roomsList);
        }
        else
        {
            floor = CreateSimpleRooms(roomsList);
        }


        List<Vector2Int> roomCenters = new List<Vector2Int>();
        foreach (var room in roomsList)
        {
            roomCenters.Add((Vector2Int)Vector3Int.RoundToInt(room.center));
        }

        HashSet<Vector2Int> corridors = ConnectRooms(roomCenters);
        floor.UnionWith(corridors);

        tilemapVisualizer.PaintFloorTiles(floor);
        WallGenerator.CreateWalls(floor, tilemapVisualizer);
    }

    private HashSet<Vector2Int> CreateRoomsRandomly(List<BoundsInt> roomsList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        for (int i = 0; i < roomsList.Count; i++)
        {
            var roomBounds = roomsList[i];
            var roomCenter = new Vector2Int(Mathf.RoundToInt(roomBounds.center.x), Mathf.RoundToInt(roomBounds.center.y));
            var roomFloor = RunRandomWalk(randomWalkParameters, roomCenter);

            if (roomsList[i] == roomsList[^1])
            {
                endPoint.transform.position = new Vector3(roomCenter.x, roomCenter.y, 0);
            }
            else if (roomsList[i] == roomsList[1])
            {
                player.transform.position = new Vector3(roomCenter.x, roomCenter.y, 0);
                cam.transform.position = new Vector3(roomCenter.x, roomCenter.y, camOffset);
            }

            foreach (var position in roomFloor)
            {
                if (position.x >= (roomBounds.xMin + offset) && position.x <= (roomBounds.xMax - offset) && position.y >= (roomBounds.yMin - offset) && position.y <= (roomBounds.yMax - offset))
                {
                    floor.Add(position);
                }
            }
        }
        return floor;
    }

    private HashSet<Vector2Int> ConnectRooms(List<Vector2Int> roomCenters)
    {
        HashSet<Vector2Int> corridors = new HashSet<Vector2Int>();
        var currentRoomCenter = roomCenters[Random.Range(0, roomCenters.Count)];
        roomCenters.Remove(currentRoomCenter);

        while (roomCenters.Count > 0)
        {
            Vector2Int closest = FindClosestPointTo(currentRoomCenter, roomCenters);
            roomCenters.Remove(closest);
            HashSet<Vector2Int> newCorridor = CreateCorridor(currentRoomCenter, closest);
            HashSet<Vector2Int> newCorridor1 = CreateCorridor(currentRoomCenter + dungeonCorridorWidthOffset, closest + dungeonCorridorWidthOffset);
            currentRoomCenter = closest;
            corridors.UnionWith(newCorridor);
            corridors.UnionWith(newCorridor1);
        }
        return corridors;
    }

    private HashSet<Vector2Int> CreateCorridor(Vector2Int currentRoomCenter, Vector2Int destination)
    {
        HashSet<Vector2Int> corridor = new HashSet<Vector2Int>();
        var position = currentRoomCenter;
        corridor.Add(position);
        while (position.y != destination.y)
        {
            if (destination.y > position.y)
            {
                position += Vector2Int.up;
            }
            else if (destination.y < position.y)
            {
                position += Vector2Int.down;
            }
            corridor.Add(position);
        }
        while (position.x != destination.x)
        {
            if (destination.x > position.x)
            {
                position += Vector2Int.right;
            }
            else if (destination.x < position.x)
            {
                position += Vector2Int.left;
            }
            corridor.Add(position);
        }
        return corridor;
    }

    private Vector2Int FindClosestPointTo(Vector2Int currentRoomCenter, List<Vector2Int> roomCenters)
    {
        Vector2Int closest = Vector2Int.zero;
        float distance = float.MaxValue;
        foreach (var position in roomCenters)
        {
            float currentDistance = Vector2.Distance(position, currentRoomCenter);
            if (currentDistance < distance)
            {
                distance = currentDistance;
                closest = position;
            }
        }
        return closest;
    }

    private HashSet<Vector2Int> CreateSimpleRooms(List<BoundsInt> roomsList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();

        randomEnemySpawnCount.Clear();
        enemies.Clear();
        pos.Clear();

        foreach (var room in roomsList)
        {
            randomEnemySpawnCount.Add(Random.Range(minEnemySpawnCount, maxEnemySpawnCount + 1));

            for (int col = offset; col < room.size.x - offset; col++)
            {
                for (int row = offset; row < room.size.y - offset; row++)
                {
                    Vector2Int position = (Vector2Int)room.min + new Vector2Int(col, row);

                    floor.Add(position);

                    for (int i = 0; i < roomsList.Count; i++)
                    {
                        var roomBounds = roomsList[i];
                        var roomCenter = new Vector2Int(Mathf.RoundToInt(roomBounds.center.x), Mathf.RoundToInt(roomBounds.center.y));

                        if (roomsList[i] == roomsList[^1])
                        {
                            endPoint.transform.position = new Vector3(roomCenter.x, roomCenter.y, 0);
                        }
                        else if (roomsList[i] == roomsList[1])
                        {
                            player.transform.position = new Vector3(roomCenter.x, roomCenter.y, 0);
                            cam.transform.position = new Vector3(roomCenter.x, roomCenter.y, camOffset);
                        }
                    }
                }
            }
        }

        foreach (int value in randomEnemySpawnCount)
        {
            sum += value;
        }

        for (int i = 0; i < roomsList.Count; i++)
        {
            // getting the Room Center
            var roomBounds = roomsList[i];
            var roomCenter = new Vector2Int(Mathf.RoundToInt(roomBounds.center.x), Mathf.RoundToInt(roomBounds.center.y));

            // adding the position of the middle of the room, unless it is the first or last room
            if (roomsList[i] != roomsList[^1] && roomsList[i] != roomsList[1])
            {
                pos.Add(roomCenter);
            }
        }

        StartCoroutine(SpawnEnemies());

        return floor;
    }
    IEnumerator SpawnEnemies()
    {
        int k = 0;
        while (k < sum)
        {
            //Adding the enemies to a list to keep count on them
            enemies.Add(enemyGameObject[Random.Range(0, enemyGameObject.Length - 1)]);

            //Adding a random offset per enemy, had to convert from a Vector 2 to 3 because instantiating gets done with a vector 3
            int spawnPointXOffset = Random.Range(-5, 5);
            int spawnPointYOffset = Random.Range(-5, 5);
            Vector3 spawnPosition = new Vector3(spawnPointXOffset, spawnPointYOffset, 0);

            //Instatiating all the enemies
            Instantiate(enemies[k], new Vector3(pos[k % pos.Count].x + spawnPosition.x, pos[k % pos.Count].y + spawnPosition.y), Quaternion.identity);
            yield return new WaitForSeconds(0f);

            progress = ((float)k / (float)sum);

            k++;
        }
        yield return new WaitForSeconds(0.5f);

        isDone= true;
    }
}
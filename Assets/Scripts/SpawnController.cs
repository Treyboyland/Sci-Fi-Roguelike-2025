using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController
{
    int currentRound;

    List<EnemySpawnData> enemies;

    [SerializeField]
    float secondsBetweenSpawnGroups;

    [SerializeField]
    float secondsBetweenSpawns;

    float spawnTimer = 0;

    bool canSpawn;

    static Player player;


    [Serializable]
    public struct EnemySpawnData
    {
        public Enemy Enemy;
        public Vector2Int RoundRestriction;
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] float distanceToSpawn = 50f;

    [SerializeField] Transform startPart;
    [SerializeField] List<Transform> partList;
    [SerializeField] GameObject player;

    Vector3 lastEndPos;

    private void Awake()
    {
        lastEndPos = startPart.Find("EndPosition").position;
        Transform lastLevelPartTransform;
        int amountOfParts = 5;
        for (int i = 0; i < amountOfParts; i++)
        {
            SpawnPart();
        }

    }


    private void Update()
    {
        PlayerDistanceCheck();
    }

    void SpawnPart()
    {
        Transform nextPart = partList[Random.Range(0, partList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(nextPart, lastEndPos);
        lastEndPos = lastLevelPartTransform.Find("EndPosition").position;

    }

    private Transform SpawnLevelPart(Transform part, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(part, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    void PlayerDistanceCheck()
    {
        if (Vector3.Distance(player.transform.position, lastEndPos) < distanceToSpawn)
        {
            SpawnPart();
        }

    }
}

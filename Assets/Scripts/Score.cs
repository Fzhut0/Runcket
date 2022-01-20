using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject player;

    public Text score;
    float distance;
    int roundedDistance;
    void Update()
    {
        HandleScore();
    }


    void HandleScore()
    {
        distance = Vector3.Distance(player.transform.position, target.transform.position) / 10;
        roundedDistance = Mathf.RoundToInt(distance);
        score.text = roundedDistance.ToString();
    }
}

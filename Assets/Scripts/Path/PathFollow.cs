using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PathFollow : MonoBehaviour
{
    [SerializeField] private Transform[] points;

    [SerializeField] private float moveSpeed;

    private int _pointIndex;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[_pointIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (_pointIndex <= points.Length - 1)
        {

            transform.position = Vector2.MoveTowards(transform.position, points[_pointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            if (transform.position == points[_pointIndex].transform.position)
            {
                _pointIndex += 1;
            }

        }

    }
}

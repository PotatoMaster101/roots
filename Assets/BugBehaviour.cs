using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBehaviour : MonoBehaviour
{
    public const float MovementSpeed = 3;
    public Vector3 MovementDirection = Vector3.left;
    // Update is called once per frame
    void Update()
    {
        transform.position += MovementDirection * MovementSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    switch(Random.Range(1, 5))
        {
            case 1:
                MovementDirection = Vector3.left;
                break;
            case 2:
                MovementDirection = Vector3.right;
                break;
            case 3:
                MovementDirection = Vector3.up;
                break;
            case 4:
                MovementDirection = Vector3.down;
                break;
        }
    }
}

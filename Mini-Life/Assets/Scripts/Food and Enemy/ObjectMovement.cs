using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    Vector2 movementDirection;
    float speed;    
    Vector2 spawnPosition;

    private void OnEnable()
    {
        spawnPosition = transform.position;

        movementDirection = GenerateMovementDirection();

        speed = Random.Range(0.2f, 0.6f);
    }
        

    void Update()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    //determine movement direction based on spawn position
    private Vector2 GenerateMovementDirection()
    {
        float xMovement, yMovement;
        float xRange = 8f;
        float yRange = 5f;

        //if spawned at the top - move downside
        if (spawnPosition.y > 0)
        {
            yMovement = Random.Range(-yRange, 0);
        }
        //if spawned at the bottom - move up
        else
        {
            yMovement = Random.Range(0, yRange);
        }

        // if spawned at right side - move left
        if (spawnPosition.x > 0)
        {
            xMovement = Random.Range(-xRange, 0);
        }
        // if spawned at left side - move right
        else
        {
            xMovement = Random.Range(0, xRange);
        }

        return new Vector2(xMovement, yMovement);
    }
}

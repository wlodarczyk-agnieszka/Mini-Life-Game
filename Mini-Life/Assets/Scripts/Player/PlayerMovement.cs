using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public delegate void OnUseEnergyByMoving();
    public event OnUseEnergyByMoving PlayerUseEnergy;

    [Header("Speed & Distance")]
    public float speed = 20;
    public float totalDistance = 0;
    public float distancePerEnergyUnit = 2f;

    Vector2 oldPos;


    void Start()
    {
        oldPos = transform.position;
    }

    void Update()
    {
        PlayerMove();

        CalculateDistanceTravelled();
    }

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if(transform.position.x > 8.5f)
        {
            transform.position = new Vector2(8.5f, transform.position.y);
        }

        if (transform.position.x < -8.5f)
        {
            transform.position = new Vector2(-8.5f, transform.position.y);
        }

        if(transform.position.y > 4.6f)
        {
            transform.position = new Vector2(transform.position.x, 4.6f);
        }

        if (transform.position.y < -4.6f)
        {
            transform.position = new Vector2(transform.position.x, -4.6f);
        }
    }

    void CalculateDistanceTravelled()
    {
        Vector2 distanceVector = (Vector2)transform.position - oldPos;
        float distanceThisFrame = distanceVector.magnitude;
        totalDistance += distanceThisFrame;
        oldPos = transform.position;

        // Use energy every distancePerEnergyUnit travelled
        if (totalDistance >= distancePerEnergyUnit)
        {
            PlayerUseEnergy.Invoke();
            totalDistance = 0;
        }
    }

}
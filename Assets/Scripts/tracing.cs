using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracing : MonoBehaviour
{
    public Transform[] planets;
    private int actualPlanet = 0;
    public Vector3 offset;
    private float timer = 0.0f;
    private const float timerMax = 10.0f;
    public managerSystem managerSystem;
    public Vector3 lastCamPos;
    bool changeTime;
    int input;
    public Transform ship;
    bool inShip;
    void Start()
    {
        planets = managerSystem.getPlanets();
        changeTime = true;
        timer = 0;
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.O) && !changeTime)
        {
            changeTime = true;
            timer = 0;
            actualPlanet++; 
            lastCamPos = transform.position;
            if (actualPlanet >= planets.Length)
                actualPlanet = 0;
        }
        if (!changeTime)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                input = 0;
                inShip = false;
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                input = 1;
                inShip = false;
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                input = 2;
                inShip = false;
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                input = 3;
                inShip = false;
            }
            if (Input.GetKey(KeyCode.Alpha5))
            {
                input = 4;
                inShip = false;
            }
            if (Input.GetKey(KeyCode.Alpha6))
            {
                input = 5;
                inShip = false;
            }
            if (Input.GetKey(KeyCode.Alpha7))
            {
                input = 6;
                inShip = false;
            }
            if (Input.GetKey(KeyCode.Alpha8))
            {
                input = 7;
                inShip = false;
            }
            if (Input.GetKey(KeyCode.Alpha9))
            {
                input = 8;
                inShip = false;
            }
            if (Input.GetKey(KeyCode.Alpha0))
            {
                input = 9;
                inShip = true;
            }
            if (input > -1)
            {
                changeTime = true;
                timer = 0;
                actualPlanet = input;
                lastCamPos = transform.position;
                if (actualPlanet >= planets.Length)
                    actualPlanet = 0;

            }
        }

    }
    void LateUpdate()
    {
        if (planets.Length <= 0)
            return;
        if (changeTime)
            timer += Time.deltaTime;
        if (timer > timerMax)
        {
            if (changeTime)
            {
                actualPlanet = actualPlanet % planets.Length;
                lastCamPos = transform.position;
            } 
            changeTime = false;
            input = -1;
        }

        Vector3 newPos;
        if (!inShip)
        {
            newPos = planets[actualPlanet].position + offset;
        }
        else
        {
            newPos = ship.position + offset;
        }

        transform.position = Vector3.Lerp(lastCamPos,newPos,timer/timerMax);
    }
}

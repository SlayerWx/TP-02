using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float radius = 0;
    float angle = 90;
    public float speed = 0;
    public float rotateSpeed = 0;
    public Transform Sun;
    private void Start()
    {
        radius = transform.position.x;
        if (speed == 0)
        {
            speed = Random.Range(1.0f, 4.0f);
        }
        if (rotateSpeed == 0)
        {
            rotateSpeed = Random.Range(2.0f, 3.0f);
        }
    }
    void Update()
    {
        if (Sun != null)
        {
            angle += Time.deltaTime * speed;
            Vector3 newPos = Vector3.zero;

            newPos.x = Sun.position.x + radius * Mathf.Cos(angle + Mathf.Deg2Rad);
            newPos.z = Sun.position.z + radius * Mathf.Sin(angle + Mathf.Deg2Rad);
            transform.position = newPos;
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }   
    public void SetSun(Transform newSun)
    {
        Sun = newSun;
    }
}

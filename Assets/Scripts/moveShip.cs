using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShip : MonoBehaviour
{
    float horizontal = 0.0f;
    float vertical = 0.0f;
    public float speed;
    private Rigidbody myRB;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 lastPosition = transform.position;
        Vector3 wantedPosition = transform.position + new Vector3(horizontal, 0, vertical) * Time.deltaTime;
        float angle = myAngle(lastPosition,wantedPosition);
        Quaternion currentR = transform.rotation;
        Quaternion newR = Quaternion.Euler(0, angle, 0);
        Quaternion finalR = Quaternion.Lerp(currentR,newR,rotateSpeed*Time.deltaTime);
        if(Mathf.Abs(horizontal) > 0.001f || Mathf.Abs(vertical) > 0.001f)
        transform.rotation = finalR;
        myRB.velocity = new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);

    }
    float myAngle(Vector3 from, Vector3 to)
    {
        Vector3 dir = to - from;
        float angle = Vector3.Angle(Vector3.forward, dir);
        if(Vector3.Cross(Vector3.forward, dir).y <0)
        {
            angle = 360 - angle;
        }
        return angle;
    }
}

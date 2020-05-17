using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoriteMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float maximumSpawnHeight;
    public float minimumSpawnHeight;
    public float downPoint;
    public float radius;
    public float speed;
    public bool raining;
    void OnEnable()
    {
        MyStart();
    }
    // Update is called once per frame
    void Update()
    {
        if (downPoint > transform.position.y && raining)
        {
            MyStart();
        }
        if (downPoint > transform.position.y && !raining)
        {
            transform.gameObject.SetActive(false);
        }
        transform.position = new Vector3(transform.position.x, 
                                         transform.position.y - speed * Time.deltaTime, 
                                         transform.position.z);

    }
    void MyStart()
    {
       transform.position = new Vector3(Random.Range(radius*-1, radius),
                              Random.Range(minimumSpawnHeight, maximumSpawnHeight),
                              Random.Range(radius*-1, radius));
    }
    public void SetRainingActivate(bool w)
    {
        raining = w;
    }
}

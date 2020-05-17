using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerSystem : MonoBehaviour
{
    private float distance = 17;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject[] planets;
    [SerializeField]
    private Material[] materialPlanets;
    private float scalePlanet = 0.0f;
    [SerializeField]
    private Transform ship;
    public float minDistance;
    public float nivelTransparencia; //0 to 1
    public GameObject light;
    public GameObject meteorite;
    private GameObject[] meteorRain;
    public float timeBetweenRain;
    public float timeOfRain;
    void Awake()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            planets[i] = Instantiate(prefab, new Vector3(transform.position.x + (distance * i), transform.position.y, transform.position.z)
                                        , Quaternion.identity, transform);
            planets[i].GetComponent<MeshRenderer>().material = materialPlanets[i];
            scalePlanet = Random.Range(1.0f, 5.0f);
            if (i == 0)
            {
                scalePlanet *= 2;
            }
            planets[i].transform.localScale = new Vector3(scalePlanet, scalePlanet, scalePlanet);

            if (i != 0)
            {
                planets[i].GetComponent<movement>().SetSun(planets[0].GetComponent<Transform>());
            }
        }
        Instantiate(light, planets[0].transform, true);
        meteorRain = new GameObject[20];
        for (int i = 0; i < meteorRain.Length; i++)
        {
            meteorRain[i] = Instantiate(meteorite, Vector3.zero, Quaternion.identity, transform);
        }
        StartCoroutine(RainOfMeteorite());
    }
    void LateUpdate()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            if (Vector3.Distance(ship.position, planets[i].transform.position) < minDistance)
            {
                materialPlanets[i].color = new Color(
                    materialPlanets[i].color.r,
                    materialPlanets[i].color.g,
                    materialPlanets[i].color.b,
                    nivelTransparencia);
            }
            else
            {
                materialPlanets[i].color = new Color(
                   materialPlanets[i].color.r,
                   materialPlanets[i].color.g,
                   materialPlanets[i].color.b,
                   1.0f);
            }
        }
    }
    public Transform[] getPlanets()
    {
        Transform[] planetsTransform = new Transform[planets.Length];
        for (int i = 0; i < planets.Length; i++)
        {
            planetsTransform[i] = planets[i].transform;
        }
        return planetsTransform;
    }
    IEnumerator RainOfMeteorite()
    {
        while (true)
        {
            for (int i = 0; i < meteorRain.Length; i++)
            {
                meteorRain[i].GetComponent<meteoriteMove>().SetRainingActivate(false);
            }
            yield return new WaitForSeconds(timeBetweenRain);
            for (int i = 0; i < meteorRain.Length; i++)
            {
                meteorRain[i].SetActive(true);
                meteorRain[i].GetComponent<meteoriteMove>().SetRainingActivate(true);
            }
            yield return new WaitForSeconds(timeOfRain);
        }

    }
}

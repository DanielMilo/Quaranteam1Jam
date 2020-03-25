using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diminishLightWhenPlayerDrawsNear : MonoBehaviour
{
    Light light;
    Vector3 initialPlayerLocation;
    float initialDistance;
    GameObject player;

    float initialIntensity;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        initialIntensity = light.intensity;
        player = GameObject.FindGameObjectWithTag("Player");
        initialPlayerLocation = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        initialDistance = (initialPlayerLocation - transform.position).magnitude;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float currDistance = (player.transform.position - transform.position).magnitude;
        float ratio = currDistance / initialDistance;
        light.intensity = initialIntensity * ratio;
        Debug.Log("ratio: " + ratio + " intensity: " + light.intensity);
    }
}

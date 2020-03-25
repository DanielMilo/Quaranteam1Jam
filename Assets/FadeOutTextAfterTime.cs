using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FadeOutTextAfterTime : MonoBehaviour
{
    [SerializeField] float timer;
    Text text;
    float initialtime;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        initialtime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > initialtime + timer)
        {
            text.enabled = false;
            initialtime = 30000;
        }
        
    }
}


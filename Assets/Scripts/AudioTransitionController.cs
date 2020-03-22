using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransitionController : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mixer != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                mixer.FindSnapshot("Initial").TransitionTo(3f);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                mixer.FindSnapshot("1-1").TransitionTo(3f);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                mixer.FindSnapshot("2-1").TransitionTo(3f);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                mixer.FindSnapshot("3-1").TransitionTo(3f);
            }
        }
    }

    public void TransitionTo(string name, float time)
    {
        mixer.FindSnapshot(name).TransitionTo(time);
    }
}

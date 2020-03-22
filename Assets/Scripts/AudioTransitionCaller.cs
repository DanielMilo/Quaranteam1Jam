using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTransitionCaller : MonoBehaviour
{
    private AudioTransitionController controller;

    [SerializeField] string SnapshotName;
    [SerializeField] float TransitionLength;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioTransitionController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AudioTransitionCaller::OnCollisionEnter");
        if (other.gameObject.tag == "Player")
        {
            controller.TransitionTo(SnapshotName, TransitionLength);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

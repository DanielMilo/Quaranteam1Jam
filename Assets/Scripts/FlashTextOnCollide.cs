using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class FlashTextOnCollide : MonoBehaviour
{
    public static Coroutine currentFlashText;

    [SerializeField] Text UIText;
    [SerializeField] string text;
    [SerializeField] float flashDuration;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        StopCoroutine(currentFlashText);

        StartCoroutine("flashText");
    }

    private IEnumerable flashText()
    {
        UIText.enabled = true;

        UIText.text = text;

        float startTime = Time.time;
        while (Time.time < startTime + flashDuration)
        {
            yield return null;
        }

        UIText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


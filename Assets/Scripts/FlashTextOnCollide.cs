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
        if(currentFlashText != null)
        {
            StopCoroutine(currentFlashText);
        }

        Debug.Log("hi2");
        currentFlashText = StartCoroutine(flashText());
    }

    private IEnumerator flashText()
    {
        Debug.Log("before");
        UIText.enabled = true;

        UIText.text = text;

        yield return new WaitForSeconds(flashDuration);

        UIText.enabled = false;
        Debug.Log("after");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


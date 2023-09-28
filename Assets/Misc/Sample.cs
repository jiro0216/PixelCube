using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    public float sphereRadius;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void WarningNoise()
    {
        // Play a noise if an object is within the sphere's radius.
        if (Physics.CheckSphere(transform.position, sphereRadius))
        {
            audioSource.Play();
        }
    }
}
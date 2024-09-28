using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MenuLight : MonoBehaviour
{
    public Light2D light2D;  // R�f�rence � la Light2D
    public float minIntensity = 0.5f;  // Intensit� minimale
    public float maxIntensity = 1.5f;  // Intensit� maximale
    public float fluctuationSpeed = 1f;  // Vitesse de fluctuation

    private float time;

    void Start()
    {
        if (light2D == null)
        {
            // R�cup�rer automatiquement la Light2D si elle n'est pas assign�e
            light2D = GetComponent<Light2D>();
        }
    }

    void Update()
    {
        // Calcule l'intensit� avec la fonction Sin sans interpolation lin�aire
        time += Time.deltaTime * fluctuationSpeed;
        float range = maxIntensity - minIntensity;
        light2D.intensity = minIntensity + (Mathf.Sin(time) + 1) / 2 * range;
    }

}

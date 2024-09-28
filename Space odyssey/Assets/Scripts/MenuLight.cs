using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MenuLight : MonoBehaviour
{
    public Light2D light2D;  // Référence à la Light2D
    public float minIntensity = 0.5f;  // Intensité minimale
    public float maxIntensity = 1.5f;  // Intensité maximale
    public float fluctuationSpeed = 1f;  // Vitesse de fluctuation

    private float time;

    void Start()
    {
        if (light2D == null)
        {
            // Récupérer automatiquement la Light2D si elle n'est pas assignée
            light2D = GetComponent<Light2D>();
        }
    }

    void Update()
    {
        // Calcule l'intensité avec la fonction Sin sans interpolation linéaire
        time += Time.deltaTime * fluctuationSpeed;
        float range = maxIntensity - minIntensity;
        light2D.intensity = minIntensity + (Mathf.Sin(time) + 1) / 2 * range;
    }

}

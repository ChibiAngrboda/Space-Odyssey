using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MenuLight : MonoBehaviour
{
    public Light2D light2D;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;
    public float transitionSpeed = 2f;

    private float targetIntensity;
    private float currentIntensity;
    // Start is called before the first frame update
    void Start()
    {
        light2D = gameObject.GetComponent<Light2D>();
        currentIntensity = light2D.intensity;
    }

    void Update()
    {
        // Transition vers l'intensit� cible de mani�re fluide
        currentIntensity = Mathf.Lerp(currentIntensity, targetIntensity, Time.deltaTime * transitionSpeed);
        light2D.intensity = currentIntensity;

        // Si proche de la cible, g�n�rer une nouvelle intensit� cible
        if (Mathf.Abs(currentIntensity - targetIntensity) < 0.01f)
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}

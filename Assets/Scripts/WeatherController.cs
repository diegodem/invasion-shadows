using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    public Light dayNightLight;
    public ParticleSystem rain;

    public Color colorLightDay;
    public Color colorLightNight;
    // Used to change the weather and time of the day. Not in use in this build
    void Start()
    {
        TurnDay();
        StopRain();
    }

    // Update is called once per frame
    public void TurnDay() {
        dayNightLight.intensity = 1.2f;
        dayNightLight.color = colorLightDay;
    }

    public void TurnNight() {
        dayNightLight.intensity = 0.7f;
        dayNightLight.color = colorLightNight;
    }

    public void StartRain() {
        rain.Play();
    }

    public void StopRain() {
        rain.Stop();
    }
}

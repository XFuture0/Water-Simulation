using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singletons<WaveManager>
{
    public float amplitude;
    public float frequency;
    public float wavelength;
    private float offect;
    private WaveManager()
    {
        
    }
    private void Update()
    {
        offect += Time.deltaTime * frequency;
    }
    public float GetWaveHeight(float x)
    {
        return amplitude * Mathf.Sin(x / wavelength + offect);
    }
}

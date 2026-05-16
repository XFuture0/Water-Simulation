using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singletons<WaveManager>
{
    [SerializeField] private List<WaveData> WaveDatas;
    private WaveManager()
    {
        
    }
    private void Update()
    {
        foreach (var wave in WaveDatas)
        {
            wave.offect += Time.deltaTime * wave.frequency;
        }
    }
    public float GetWaveHeight(Vector2 position, bool IsAaccessible = false)
    {
        float MixedWave = 0;
        if (!IsAaccessible)
        {
            foreach (var wave in WaveDatas)
            {
                if(!wave.IsVisible)
                {
                    continue;
                }
                if(wave.direction == WaveDirection.X)
                {
                    MixedWave += wave.amplitude * Mathf.Sin(position.x / wave.wavelength + wave.offect + wave.wavebasepos);
                }
                else if(wave.direction == WaveDirection.Z)
                {
                    MixedWave += wave.amplitude * Mathf.Sin(position.y / wave.wavelength + wave.offect + wave.wavebasepos);
                }
            }
        }
        else
        {
            foreach (var wave in WaveDatas)
            {
                if(!wave.IsVisible)
                {
                    continue;
                }
                if(!wave.IsAaccessible)
                {
                    continue;
                }
                if(wave.direction == WaveDirection.X)
                {
                    MixedWave += wave.amplitude * Mathf.Sin(position.x / wave.wavelength + wave.offect + wave.wavebasepos);
                }
                else if(wave.direction == WaveDirection.Z)
                {
                    MixedWave += wave.amplitude * Mathf.Sin(position.y / wave.wavelength + wave.offect + wave.wavebasepos);
                }
            }
        }
        return MixedWave;
    }
}

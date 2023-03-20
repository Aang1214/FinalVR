using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderControl : MonoBehaviour
{
    public Material material;
    public float noiseStrength = 1f;
    public float cutoffHeight = .5f;
    // Update is called once per frame
    void Update()
    {
        material.SetFloat("_NoiseStrength", Mathf.PerlinNoise(Time.time, 0) * noiseStrength);
        material.SetFloat("_Cuoff_Height", Mathf.PerlinNoise(Time.time, 0));
    }
}

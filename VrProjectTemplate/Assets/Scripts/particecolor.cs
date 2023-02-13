using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class particecolor : MonoBehaviour
{
    public Slider colorSlider;
    public Material particleMaterial;
    // Start is called before the first frame update
    void Start()
    {
        colorSlider.onValueChanged.AddListener(ChangeParticleColor);
    }

    private void ChangeParticleColor(float value)
    {
        particleMaterial.color = Color.Lerp(Color.red, Color.blue, value);
    }
}

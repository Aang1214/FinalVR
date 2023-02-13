using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cubecolorchanger : MonoBehaviour
{
    public Slider colorSlider;
    public Material cubeMaterial;
    // Start is called before the first frame update
    void Start()
    {
        colorSlider.onValueChanged.AddListener(ChangeCubeColor);
    }

    private void ChangeCubeColor(float value)
    {
        cubeMaterial.color = Color.Lerp(Color.red, Color.blue, value);
    }
}

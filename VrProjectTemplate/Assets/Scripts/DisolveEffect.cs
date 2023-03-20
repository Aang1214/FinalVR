using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisolveEffect : MonoBehaviour
{
    public Material dissolveMaterial;
    private float initialCutoffHeight;
    private float dissolveTimer = 0f;

    private void Awake()
    {
        initialCutoffHeight = dissolveMaterial.GetFloat("_Cuoff_Height");
    }

   public void StartDissolveEffect()
    {
        StartCoroutine(DecreaseCutoffHeightOverTime(-1, 10));
    }

    private IEnumerator DecreaseCutoffHeightOverTime(float newCutoffHeight, float duration)
    {
        for (dissolveTimer = 0f; dissolveTimer < duration; dissolveTimer += Time.deltaTime)
        {
            float t = dissolveTimer/duration;
            float cutoffHeight = Mathf.Lerp(initialCutoffHeight, newCutoffHeight, t);
            dissolveMaterial.SetFloat("_Cuoff_Height", newCutoffHeight);
            yield return null;
        }
        dissolveMaterial.SetFloat("_Cuoff_Height", newCutoffHeight);
    }
    public void ResetDissolveEffect()
    {
        StopAllCoroutines();
        dissolveTimer = 0f;
        dissolveMaterial.SetFloat("_Cuoff_Height", initialCutoffHeight);
    }
}

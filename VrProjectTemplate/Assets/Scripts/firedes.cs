using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firedes : MonoBehaviour
{
    public float FireHealth = 100f;
    public ParticleSystem part;
    public ParticleSystem fire;
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        fire = GetComponent<ParticleSystem>();
    }
    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            FireHealth -= 1f;
            /*Vector3 obejctLocalScale = other.transform.localPosition;
            obejctLocalScale.y -= 0.01f;
            other.transform.localPosition = obejctLocalScale;*/
            other.transform.localPosition -= new Vector3(0, 0.01f, 0);
            if (FireHealth <= 0)
            {
                other.SetActive(false);
            }
        }
    }
}


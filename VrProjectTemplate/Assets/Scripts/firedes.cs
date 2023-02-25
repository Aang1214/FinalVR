using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firedes : MonoBehaviour
{
    public float FireHealth = 100f;
    public ParticleSystem part;
    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }
    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            FireHealth -= 1f;
            other.transform.localScale -= new Vector3(0f, 0.3f, 0f);
            if (FireHealth <= 0)
            {
                other.SetActive(false);
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class firedes : MonoBehaviour
{
 public bool IsOnFire = true;
  
    public ParticleSystem part;
    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }
    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            other.SetActive(false);
        }
    }
}


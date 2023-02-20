using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class firedes : MonoBehaviour
{
 public bool IsOnFire = true;
 public float OnFire = 100f;
 public TextMeshProUGUI countFire;
 private int count;
  
    public ParticleSystem part;
    void Start()
    {
        count = 0;
        part = GetComponent<ParticleSystem>();
    }
    void SetCountText()
    {
        countFire.text = "Fire " + count.ToString();
        if (count >= 8)
        {
            
        }
    }
    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            OnFire -= 1f;
            other.transform.localScale -= new Vector3(0.1f, 0.3f, 0.1f);
            if (OnFire <= 0)
            {
                other.SetActive(false);
                count = count + 1;
            }
        }
    }
}


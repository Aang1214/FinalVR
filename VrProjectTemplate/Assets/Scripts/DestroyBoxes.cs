using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoxes : MonoBehaviour
{
    public GameObject box;
    List<GameObject> boxes;

    
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("axe"))
        {
            box.SetActive(false);
        }


    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBaby : MonoBehaviour
{
    public GameObject Baby;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("baby"))
            Baby.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

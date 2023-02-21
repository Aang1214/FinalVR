using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowMision : MonoBehaviour
{
    public GameObject writting;
    // Start is called before the first frame update
    void Start()
    {
        writting.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            writting.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            writting.SetActive(false);
        }
    }
}

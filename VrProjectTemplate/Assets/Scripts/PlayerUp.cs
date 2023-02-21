using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerUp : MonoBehaviour
{
    public GameObject water;
    private int up = 5;
    private Rigidbody rb;
    public bool upplease = false;
    private bool OnWater;
    public TextMeshProUGUI countText;
    private int count;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        upplease = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && upplease)
        {
            rb.velocity = Vector3.up * up;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            water.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            water.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ladder"))
        {
            upplease = true;
        }

    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("ladder"))
        {
            upplease = false;
        }
    }

}


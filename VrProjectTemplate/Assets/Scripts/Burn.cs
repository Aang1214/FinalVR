using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Burn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision others)
    {
        if (others.gameObject.CompareTag("Fire"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

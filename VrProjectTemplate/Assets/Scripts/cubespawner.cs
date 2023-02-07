using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawner : MonoBehaviour
{
	public GameObject cubePrefab;
	public Button spawnButton;
    // Start is called before the first frame update
    private void Start()
    {
     	spawnButton.onClick.AddListener(SpawnCube);   
    }

    // Update is called once per frame
    private void SpawnCube()
    {
        Instantiate(cubePrefab, transform.position, Quaternion.identity);
    }
}

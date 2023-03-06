using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;

    public int currentSceneIndex;

    private audioManager audioManager;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
 

    audioManager = GetComponentInChildren<audioManager>();
    currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

}
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddScore(1);
        }
    }
    public void AddScore(int points)
    {
        score+= points;
        audioManager.PlaySoundEffect("pointScored");
    }
    public void LoadNextLevel()
    {
        audioManager.PlaySoundEffect("levelLoad");
        float delay = audioManager.GetSoundEffectDuration("levelLoad");
        Invoke("LoadNextLevelDelayed", delay);
    }
    private void LoadNextLevelDelayed()
    {
        score = 0;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;

    public int currentSceneIndex;

    private bool isPaused = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private TMP_Text scoreText;

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

        pauseMenu = transform.Find("Menu").gameObject;
        scoreText = GetComponent<TMP_Text>();
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        score = 0;
        updateScore();
        currentSceneIndex = 0;
        SceneManager.LoadScene(currentSceneIndex);
    }
    private void updateScore()
    {
        scoreText.text = "Score " + score;
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

    public void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.persistentDataPath + "/gameData.dat");

        GameData gameData = new GameData (score, currentSceneIndex);
        formatter.Serialize(fileStream, gameData);
        fileStream.Close();
        Debug.Log("Game saved!");
    }
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gameData.dat")){ 
            BinaryFormatter formatter = new BinaryFormatter ();
            FileStream fileStream = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);
            GameData gameData = (GameData)formatter.Deserialize(fileStream);
            score = gameData.score;
            updateScore();
            currentSceneIndex = gameData.currentSceneIndex;
            SceneManager.LoadScene(currentSceneIndex);
            fileStream.Close();

            Debug.Log("Game loaded");
        }
        else
        {
            Debug.LogWarning("Save file not found");
        }
    }

    


}
[System.Serializable]
public class GameData
{
    public int score;
    public int currentSceneIndex;

    public GameData(int score, int currentSceneIndex)
    {
        this.score = score;
        this.currentSceneIndex = currentSceneIndex;
    }
}

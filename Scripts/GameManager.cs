using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //creating a list of objects called targets
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    private float spawnRate = 3.0f;
    private int score;
   
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget() {
        while (isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    }
    public void UpdateScore(int scoreToAdd)
    { score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver() {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
     public void RestartGame() {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty) {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        
        score = 0;
        UpdateScore(0);
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
    }
   


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public GameObject titleScreen;
    private float score ;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button button;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    public IEnumerator SpawnTarget()
    {
        while(true){
        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0, targets.Count);
        Instantiate(targets[index]);
        
        }
    }

    public void ScoreCounter(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score :" + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void StartGame(int difficulty)
    {
        StartCoroutine(SpawnTarget());
        spawnRate = spawnRate / difficulty;
        score = 0;
        scoreText.text = "Score: " + score;
        titleScreen.SetActive(false);
    }
}

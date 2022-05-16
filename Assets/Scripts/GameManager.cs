using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabs;
    private float spawnRate =  2.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI OverText;
    private int score = 0;
    public bool gameActive = false;

    public Button restartButton;
    public GameObject titleScreen;
    // Start is called before the first frame update

    public void StartGame(int diff)
    {
        gameActive = true;
        score = 0;
        //spawnRate = spawnRate / diff; (same as down)
        spawnRate /= diff;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
   public void GameOver()
    {
        gameActive = false;
        OverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    IEnumerator SpawnTarget()
    {
        while(gameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        }
    }

    public void UpdateScore(int scoreDelta)
    {
        score += scoreDelta;
        if(score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

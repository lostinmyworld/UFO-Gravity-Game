using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public GameObject enemyUFO;

    public GameObject[] availableObject;
    List<GameObject> objects;

    public Vector2 spawnValues;
    public int objectsCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text placeSubText;
    public Text placeText;
    public Text levelText;
    public Image coinImage;

    public GameObject RestartCanvas;
    public GameObject HUDCanvas;
    public GameObject HowToCanvas;

    private bool gameOver;
    private bool restart;

    private int score;

    public AudioSource HowToAudio;
    public AudioSource backgroundAudio;
    public AudioSource gameOverAudio;
    public AudioSource winningAudio;
    public AudioSource pickupSound;
    public AudioSource explosionSound;

    private int CURRENT_LEVEL = 0;

    void Start()
    {
        HowToAudio.Play();
        RestartCanvas.SetActive(false);
        HUDCanvas.SetActive(false);
        HowToCanvas.SetActive(true);

        coinImage.enabled = false;
        score = 0;
        gameOver = false;
        restart = false;
        placeText.text = "";
        levelText.text = "";
        scoreText.text = "";
        placeSubText.text = "";
        placeText.text = "";
        //StartCoroutine(SpawnWaves());
        //SetLevel();
    }

    void Update()
    {
        if (restart) {
            RestartCanvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        levelText.text = "";
        placeText.color = Color.yellow;
        placeText.text = "LEVEL " + CURRENT_LEVEL.ToString();
        yield return new WaitForSeconds(waveWait);
        placeText.text = "";
        levelText.text = "LEVEL " + CURRENT_LEVEL.ToString();
        //yield return new WaitForSeconds(startWait);
        //while (true) {
        for (int i = 0; i < CURRENT_LEVEL * objectsCount; i++) {
            Vector2 spawnPosition = new Vector2(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y));
            Quaternion spawnRotation = Quaternion.identity;
            int randomIndex = CURRENT_LEVEL < 3 ? Random.Range(0, availableObject.Length - 1)
                : Random.Range(0, availableObject.Length);
            Instantiate(availableObject[randomIndex], spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0, spawnWait));
        }
        if (!gameOver) {
            SetLevel();
        }
        if (gameOver) {
            placeSubText.text = "Press 'R' for restart";
            restart = true;
        }
        //}
    }

    public void StartGame()
    {
        HUDCanvas.SetActive(true);
        HowToAudio.Stop();
        HowToCanvas.SetActive(false);
        backgroundAudio.Play();
        SetLevel();
    }

    void SetLevel()
    {
        CURRENT_LEVEL++;
        if (CURRENT_LEVEL > 3) {
            Congratulate();
            return;
        }
        if (!gameOver)
            StartCoroutine(SpawnWaves());
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
        pickupSound.Play();
    }

    void UpdateScore()
    {
        coinImage.enabled = true;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        //backgroundAudio.Stop();
        placeText.color = Color.red;
        placeText.text = "Game Over";
        placeSubText.text = "Press 'R' for restart";
        restart = true;
        gameOver = true;
        explosionSound.Play();
        //gameOverAudio.Play();

    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Congratulate()
    {
        //backgroundAudio.Stop();
        placeSubText.text = "Congratulations!!";
        placeText.color = Color.green;
        placeText.text = "You win";
        RestartCanvas.SetActive(true);
        //winningAudio.Play();
    }
}

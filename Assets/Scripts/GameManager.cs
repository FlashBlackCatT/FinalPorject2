using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> targets;
    public bool isGameActive;
    private float _spawnRate = 1.5f;
    private int score;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _titleScreen;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObjects()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        _scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        _gameOverText.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
        isGameActive = false;
        _spawnRate = 1.5f;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        isGameActive = true;

        _spawnRate /= difficulty;

        StartCoroutine(SpawnObjects());
        score = 0;
        UpdateScore(0);
        _titleScreen.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelPanel;
    private GameObject[] allEnemies;
    public int enemyCount;
    private int initialEnemyCount;
    private float progressValue;
    [SerializeField] private GameObject enemyCountDisplay;
    [SerializeField] private GameObject progressBar;
    void Start()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("enemy");
        enemyCount = allEnemies.Length;
        initialEnemyCount = allEnemies.Length;
        progressValue = 0f;
    }

    void NextLevel()
    {
        nextLevelPanel.SetActive(true);
    }
    void ReduceEnemyCount()
    {
        enemyCount-=1;
    }

    void Update()
    {
        enemyCountDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = enemyCount.ToString();
        progressValue = ((float)initialEnemyCount - (float)enemyCount) / (float)initialEnemyCount;
        progressBar.GetComponent<Slider>().value = progressValue;
        Debug.Log(progressValue);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverPanel;
    [SerializeField]
    private Timer _timer;
    [SerializeField]
    private TextMeshProUGUI _timeText;
    [SerializeField]
    private GameObject _victoryPanel;
    [SerializeField]
    private PlayerMovement _playerMovement;
    public bool isGameOver;
    [SerializeField]
    private GameObject _oneStar;
    [SerializeField]
    private GameObject _twoStar;
    [SerializeField]
    private GameObject _threeStar;
    public string nextLevel;
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
        _timer.StopTimer();
        isGameOver = true; 
    }
    public void Victory()
    {
        _timeText.text = "Общее время: " + _timer.GetCurrentTime();
        _victoryPanel.SetActive(true);
        _timer.StopTimer();
        isGameOver = true;
        CalculateRating();
    }
    public void StartGame()
    {
        _timer.StartTimer();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void CalculateRating()
    {
        float percent = (float)GoldSystem.Instance.goldBank / GoldSystem.Instance.goldAmount * 100;
        if(percent > 66)
        {

        }
        else if(percent > 65)
        {
            _threeStar.SetActive(false);
        }
        else if(percent > 32)
        {
            _threeStar.SetActive(false);
            _twoStar.SetActive(false);
        }
        else
        {
            _threeStar.SetActive(false);
            _twoStar.SetActive(false);
            _oneStar.SetActive(false);
        }



    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

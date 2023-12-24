using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button winButton;
    public Button lossButton;

    [SerializeField] int maxItems = 4;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text itemText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text progressText;

    [SerializeField] List<Health> _heatlth;
    [SerializeField] List<EnemyBehavior> _heatlthOldVersion;

    private int _itemsCollected = 0;
    private int _playerHP = 10;
    private int _scoreEnemy = 0;

    void Start()
    {
        itemText.text += _itemsCollected;
        healthText.text += _playerHP;
        scoreText.text += _scoreEnemy;

        for (int i = 0; i < _heatlth.Count; i++)
        {
            _heatlth[i].OnScoreChanged += OnScoreUpdate;
            _heatlthOldVersion[i].OnScoreOldVersionChanged += OnScoreUpdate;
        }
    }

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            itemText.text = "Items Collected: " + Items;

            if (_itemsCollected >= maxItems)
            {
                winButton.gameObject.SetActive(true);

                UpdateScene("You've found all the items!");

            }
            else
            {
                progressText.text = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;

            healthText.text = "Player Heath: " + HP;

            if (_playerHP <= 0)
            {
                lossButton.gameObject.SetActive(true);

                UpdateScene("You want another life with that?");
            }
            else
            {
                progressText.text = "Ouch ... that's got hurt.";
            }

            Debug.Log($"Lives: {_playerHP}");
        }
    }

    public int Score
    {
        get { return _scoreEnemy; }
        set
        {
            _scoreEnemy = value;

            scoreText.text = "Score Enemies: " + Score;

            Debug.Log($"Score: {_scoreEnemy}");
        }
    }

    public void OnScoreUpdate(int score)
    {
        Score += score;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);

        Time.timeScale = 1f;
    }

    public void UpdateScene(string updatedText)
    {
        progressText.text = updatedText;
        Time.timeScale = 0f;
    }
}

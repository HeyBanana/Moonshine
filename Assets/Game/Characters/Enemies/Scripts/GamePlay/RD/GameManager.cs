using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button winButton;
    [SerializeField] private Button lossButton;

    [SerializeField] private int maxItems = 4;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text itemText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text progressText;

    [SerializeField] private List<Health> _heatlth;
    [SerializeField] private List<EnemyBehavior> _heatlthOldVersion;

    private int _itemsCollected = 0;
    private int _playerHP = 10;
    private int _scoreEnemy = 0;

    private void Start()
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

    private int Items
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

    private int HP
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

    private int Score
    {
        get { return _scoreEnemy; }
        set
        {
            _scoreEnemy = value;

            scoreText.text = "Score Enemies: " + Score;

            Debug.Log($"Score: {_scoreEnemy}");
        }
    }

    private void OnScoreUpdate(int score)
    {
        Score += score;
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(0);

        Time.timeScale = 1f;
    }

    private void UpdateScene(string updatedText)
    {
        progressText.text = updatedText;
        Time.timeScale = 0f;
    }
}

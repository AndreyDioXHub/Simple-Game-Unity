using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private int _score;
    [SerializeField]
    private Text _scoreText;
    public bool Lock = true;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.HiHitMe += AddScore;
        EventManager.instance.EndGame += EndGame;
    }

    private void AddScore()
    {
        _score++;
        _scoreText.text = _score + "";
    }

    private void EndGame()
    {
        SceneManager.LoadScene("Game");
    }
}

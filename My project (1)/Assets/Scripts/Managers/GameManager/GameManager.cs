using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {


        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.R)&&_isGameOver) {
            SceneManager.LoadScene(1);
           

        }
    }

    public void GameOver()
    {

        _isGameOver= true;
        UIManager.Instance.GameOverUI();
    }


    }

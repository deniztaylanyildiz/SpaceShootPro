using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
   
        public static UIManager Instance { get; private set; }

        private void Awake()
        {
            

            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

        _scoreText.text = "Score: 0";
    }
    

    

    private void Start()
    {
        
    }
    public void UpDateScoreText(int a=10)
    {
        _scoreText.text = "Score: " + a;


    }
}

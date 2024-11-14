using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField] 
    private Image _hpempty;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _resetGameText;
    [SerializeField]
    private Sprite[] _hpSprites;
   
        public static UIManager Instance { get; private set; }

        private void Awake()
        {
            

            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
          

        _scoreText.text = "Score: 0";

        _hpempty.sprite = _hpSprites[3];
    }
    

    

    private void Start()
    {
       
    }
    public void UpDateScoreText(int a=10)
    {
        _scoreText.text = "Score: " + a;


    }
    public void Update() {
      
    }
    public void UpdateHP(int currentHp)
    {
        switch (currentHp)
        {
            case 0:
                _hpempty.sprite = _hpSprites[0];
                break;
            case 1:
                _hpempty.sprite = _hpSprites[1];
                break;
            case 2:
                _hpempty.sprite = _hpSprites[2];
                break;
            case 3:
                _hpempty.sprite = _hpSprites[3];
                break;
            default:
                _hpempty.sprite = _hpSprites[3];
                break;
        }

    }


     public void GameOverUI()
    {

       
              GameOverSequence();

   


    }

    void GameOverSequence()
    {
        StartCoroutine(GameOverFlickerRoutine());
        _gameOverText.gameObject.SetActive(true);
        _resetGameText.gameObject.SetActive(true);

    }
   
    IEnumerator GameOverFlickerRoutine()
    {


        while(true)
        {

            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5F);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5F);



        }

    }
}

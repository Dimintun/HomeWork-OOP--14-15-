using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _necessaryCountCoin;
    
    [SerializeField] private float _timeToLose;
    
    [SerializeField] private Player _player;

    [SerializeField] private List<GameObject> _coins;

    public TextMeshProUGUI _timerText; // создаем переменную типа Текста Интерфейса, по умолчанию является Сериализфиелдом, потому не забудь закидывать ассет текста в поле.

    private KeyCode _restartKey = KeyCode.R;

    private bool _isActive;

    private float _time = 0;
    private int _previousTimeValue = 0;

    private string _winMassage = "Вы победили";
    private string _looseMassage = "Вы проиграли";


    private void Awake()
    {
        _isActive = true;
        StartGame();
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(_restartKey))
            StartGame();

        if (_isActive == false)
            return;

        Timer();

        if (_player.CollectedCoins >= _necessaryCountCoin)
        {
            WinTheGame();
            _isActive = false;
        }
          
        if (_time >= _timeToLose)
        {
            GameOver();
            _isActive = false;
        }
         float cashTime = (int)Math.Round(_time); // для округления, решил не рисковать и не брать ту-же переменную, что и у тебя.
        _timerText.SetText("Time: " + cashTime); // ну тут все просто, лол.
    }
    private void Timer()
    {
        int currentTime;

       _time += Time.deltaTime;
        currentTime = (int)Math.Round(_time);
        if (currentTime != _previousTimeValue) //Сделал для округления (почему-то через парсинг никак не хочет)
                                               //и для убирания дубляжа в логах, но он всё равно вызывает его дважды
        Debug.Log(currentTime);
        else _previousTimeValue = currentTime;
    }
    private void StartGame()
    {
        _isActive = true;
        _player.NewGame();
        ActivateCoins();
        _time = 0;
    }
    public void GameOver()
    {
        _isActive = false;
        _player.Death();
        Debug.Log(_looseMassage);
    }
    private void WinTheGame()
    {
        _isActive = false;
        Debug.Log(_winMassage);
    }
    private void ActivateCoins()
    {
        foreach (GameObject coin in _coins)
            coin.SetActive(true);
    }
}

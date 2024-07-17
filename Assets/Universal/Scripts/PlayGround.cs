using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class PlayGround : GameBehaviour
{
    public enum Direction { North, South, West, East }
    public GameObject player;
    public float moveDistance = 2f;
    public float moveTweenTime = 0f;
    public Ease moveEase;
    public float shakeStrength;

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public Ease scoreEase;
    private int score = 0;
    public int scoreBonus = 100;

    [Header("Timer")]
    public Timer timer;
    public TMP_Text timerText;

    void Start()
    {
        //ExecuteAfterSeconds(2, () => { player.transform.localScale = Vector3.one * 2; });

        player.transform.position = _SAVE.GetLastCheckpoint();
        player.GetComponent<Renderer>().material.color = _SAVE.GetColor();
        highScoreText.text = "Highest Score: " + _SAVE.GetHighestScore().ToString();

        timer.StartTimer(0, TimerDirection.CountUp);

        print("Game Started");

        ExecuteAfterFrames(1, () => { print("player one frame later"); });
    }

    void Update()
    {
        timerText.text = timer.GetTime().ToString("F2");

        //Start time at 10
        timer.StartTimer(0, 10, true, TimerDirection.CountDown);

        if(Input.GetKeyDown(KeyCode.C))
        {
            if (timer.timerDirection == TimerDirection.CountUp)
            {
                timer.ChangeTimerDirection(TimerDirection.CountDown);

            }
            else
                timer.ChangeTimerDirection(TimerDirection.CountUp);
        }

        if (timer.TimeExpired())
            Debug.Log("TimeExpired");

        if (Input.GetKeyDown(KeyCode.P))
        {
            timer.ToggleTimerPause();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            MovePlayer(Direction.North);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MovePlayer(Direction.East);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MovePlayer(Direction.West);

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MovePlayer(Direction.South);

        }
    }

    void MovePlayer(Direction _direction)
    {
        switch (_direction)
        {
            case Direction.North:
                player.transform.DOMoveZ(player.transform.position.z + moveDistance, moveTweenTime).SetEase(moveEase).OnComplete(() =>
                { 
                    ShakeCamera();
                    IncreaseScore();
                   
        });
                break;

            case Direction.East:
                player.transform.DOMoveX(player.transform.position.x + moveDistance, moveTweenTime).SetEase(moveEase).OnComplete(() =>
                {
                    ShakeCamera();
                    IncreaseScore();
                });
                break;
            case Direction.West:
                player.transform.DOMoveX(player.transform.position.x - moveDistance, moveTweenTime).SetEase(moveEase).OnComplete(() =>
                {
                    ShakeCamera();
                    IncreaseScore();
                });
                break;
            case Direction.South:
                player.transform.DOMoveZ(player.transform.position.z - moveDistance, moveTweenTime).SetEase(moveEase).OnComplete(() =>
                {
                    ShakeCamera();
                    IncreaseScore();
                });
                break;
        }
        _SAVE.SetLastPosition(player.transform.position);
        ChangeColor();
    }

    void ShakeCamera()
    {
        Camera.main.DOShakePosition(moveTweenTime/2, shakeStrength);
    }

    void ChangeColor()
    {
        Color c = ColorX.GetRandomColour();
        _SAVE.SetColor(c);
        player.GetComponent < Renderer>().material.DOColor(c, moveTweenTime);
    }
    
    void IncreaseScore()
    {
        TweenX.TweenNumbers(scoreText, score, score + scoreBonus, 1, scoreEase, "F2");
        score = score + scoreBonus;
        _SAVE.SetScore(score);
    }

    public int health = 1000;

    public void Posion()
    {
        health -= 100;
        Debug.Log("Poisoned" + health);
    }

    public void AddHealth(int _health) =>
    
        health += _health;

    public void LoseHealth(int _health) =>

       health -= _health;

}

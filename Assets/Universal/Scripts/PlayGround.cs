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
    public Ease scoreEase;
    private int score = 0;
    public int scoreBonus = 100;

    void Start()
    {
        //ExecuteAfterSeconds(2, () => { player.transform.localScale = Vector3.one * 2; });

        print("Game Started");

        ExecuteAfterFrames(1, () => { print("player one frame later"); });
    }

    void Update()
    {
 
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
                { ShakeCamera();
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

        ChangeColor();
    }

    void ShakeCamera()
    {
        Camera.main.DOShakePosition(moveTweenTime/2, shakeStrength);
    }

    void ChangeColor()
    {
        player.GetComponent < Renderer>().material.DOColor(ColorX.GetRandomColour(), moveTweenTime);
    }
    
    void IncreaseScore()
    {
        TweenX.TweenNumbers(scoreText, score, score + scoreBonus, 1, scoreEase, "F2");
        score = score + scoreBonus;
    }
}

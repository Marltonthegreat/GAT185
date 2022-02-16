using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RollerGameManager : Singleton<RollerGameManager>
{
    public enum State
    {
        TITLE,
        PLAYER_START,
        GAME,
        PLAYER_DEAD,
        GAME_ENDING,
        GAME_OVER_LOSE,
        GAME_OVER_WIN
    }

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawn;

    [SerializeField] GameObject mainCamera;

    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] TMP_Text scoreUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timeUI;
    [SerializeField] Slider healthBarUI;
    [SerializeField] [Min(0)] float gameTime = 0;

    [SerializeField] RollerAnimation[] animations;
    

    public float playerHealth { set { healthBarUI.value = value; } }

    public delegate void GameEvent();

    public event GameEvent startGameEvent;
    public event GameEvent winGameEvent;
    public event GameEvent stopGameEvent;

    int score = 0;
    int lives = 0;
    public State state = State.TITLE;
    public float stateTimer;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreUI.text = score.ToString("D6");
        }
    }

    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            livesUI.text = "Lives " + lives.ToString("D2");
        }
    }

    public float GameTime
    {
        get { return gameTime; }
        set
        {
            gameTime = value;
            timeUI.text = "<mspace=mspace36>" + gameTime.ToString("0") + "</mspace>";
        }
    }

    private void Start()
    {
        winGameEvent = CoinsCollected;
    }

    private void Update()
    {
        stateTimer -= Time.deltaTime;
        foreach (RollerAnimation animation in animations)
        {
            animation.DecrementTimer(Time.deltaTime);
            if (animation.Timer <= 0) animation.ResetTimer();
        }

        switch (state)
        {
            case State.TITLE:
                break;
            case State.PLAYER_START:
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    player.GetComponent<Health>().Damage(1000);
                    Lives++;
                }

                mainCamera.SetActive(false);
                Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);

                startGameEvent?.Invoke();

                state = State.GAME;
                break;
            case State.GAME:
                GameTime -= Time.deltaTime;

                if (GameTime <= 0)
                {
                    GameTime = 0;
                    state = State.GAME_OVER_LOSE;
                    loseScreen.SetActive(true);
                    stateTimer = 5;
                }

                break;
            case State.PLAYER_DEAD:
                if (stateTimer <= 0)
                {
                    state = State.PLAYER_START;
                }
                break;
            case State.GAME_ENDING:
                winGameEvent?.Invoke();
                break;
            case State.GAME_OVER_LOSE:
                if (stateTimer <= 0)
                {
                    state = State.TITLE;
                    loseScreen.SetActive(false);
                    titleScreen.SetActive(true);
                }
                break;
            case State.GAME_OVER_WIN:
                if (stateTimer <= 0)
                {
                    state = State.TITLE;
                    winScreen.SetActive(false);
                    titleScreen.SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    public void OnStartGame()
    {
        state = State.PLAYER_START;
        Score = 0;
        Lives = 2;
        GameTime = 60;

        titleScreen.SetActive(false);
    }

    public void OnStartTitle()
    {
        state = State.TITLE;
        titleScreen.SetActive(true);
        stopGameEvent?.Invoke();
    }

    public void OnPlayerDead()
    {
        mainCamera.SetActive(true);

        if (--Lives > 0)
        {
            state = State.PLAYER_DEAD;
            stateTimer = 3;
        }
        else
        {
            state = State.GAME_OVER_LOSE;
            stateTimer = 5;

            loseScreen.SetActive(true);
        }
        stopGameEvent?.Invoke();
    }

    public void CoinsCollected()
    {
        state = State.GAME_OVER_WIN;
        stateTimer = 5;

        winScreen.SetActive(true);
    }
}

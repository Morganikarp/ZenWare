using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MasterGameController : MonoBehaviour
{
    public GameObject TitleMenu;
    public GameObject[] Countdown;
    public GameObject GameMenu;
    public GameObject RetryMenu;
    public GameObject CircleObj;
    public GameObject[] Microgames;
    public AnimationClip[] MonkStates;
    public TMP_Text ScoreText;

    GameCircleScript CircleGCS;
    Animator Ani;

    GameObject currentGame;
    GameObject nextGame;

    public bool TitleMusic;
    public bool StartSFX;
    public bool GameMusic;
    public bool EndSFX;
    bool EndBuffer;

    public float Score;
    public bool Title;
    public bool Play;
    public bool StartUp;
    public bool Lost;
    public bool End;
    public int Hits;

    void Start()
    {
        CircleGCS = CircleObj.GetComponent<GameCircleScript>();
        Ani = GetComponent<Animator>();

        GameMenu.SetActive(false);
        RetryMenu.SetActive(false);
        Score = 0;
        Title = true;
        Play = false;
        StartUp = false;
        Lost = false;
        End = false;

        TitleMusic = true;
        StartSFX = false;
        GameMusic = false;
        EndSFX = false;
    }

    void Update()
    {
        if (Title == true)
        {
            TitleController();
        }
        

        if (Play == true && End == false)
        {
            if (StartUp == true)
            {
                StartUp = false;
                StartCoroutine("StartUpController");
            }

            if (CircleGCS.NewGame == true && End == false)
            {
                GameController();
            }
        }

        if (End == true)
        {
            RetryController();
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    void TitleController()
    {
        if (Input.GetKeyDown("space"))
        {
            StartUp = true;
            Play = true;
            Title = false;
            TitleMenu.SetActive(false);
        }
    }

    void GameController()
    {
        if (Lost == true)
        {
            Dmg();

            if (Hits >= 3)
            {
                Play = false;
                End = true;
            }
        }

        else if (Lost == false)
        {
            Score += 1;
            ScoreText.text = Score.ToString();
        }

        nextGame = Microgames[Random.Range(0, Microgames.Length)];

        while (currentGame == nextGame)
        {
            nextGame = Microgames[Random.Range(0, Microgames.Length)];
        }

        if (Score >= 7)
        {
            while (nextGame == Microgames[4] && currentGame == nextGame)
            {
                nextGame = Microgames[Random.Range(0, Microgames.Length - 1)];
            }
        }

        currentGame.SetActive(false);
        nextGame.SetActive(true);
        currentGame = nextGame;
        CircleGCS.NewGame = false;
        Lost = false;
    }

    void RetryController()
    {
        if (EndBuffer == true)
        {
            EndBuffer = false;
            EndSFX = true;
        }
        currentGame.SetActive(false);
        CircleObj.SetActive(false);
        RetryMenu.SetActive(true);

        if (Input.GetKeyDown("space"))
        {
            RetryMenu.SetActive(false);
            TitleMusic = true;
            End = false;
            StartUp = true;
            Play = true;
        }
    }

    void Dmg()
    {
        Hits += 1;
        Ani.SetInteger("Hits", Hits);
    }

    IEnumerator StartUpController()
    {
        EndBuffer = true;
        Lost = false;
        End = false;
        Hits = 0;
        Score = 0;
        ScoreText.text = Score.ToString();
        Ani.SetInteger("Hits", 0);
        StartSFX = true;
        GameMenu.SetActive(false);

        Countdown[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        Countdown[0].SetActive(false);
        Countdown[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        Countdown[1].SetActive(false);
        Countdown[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        Countdown[2].SetActive(false);

        GameMusic = true;
        currentGame = Microgames[Random.Range(0, Microgames.Length)];
        currentGame.SetActive(true);
        CircleObj.SetActive(true);
        GameMenu.SetActive(true);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;


public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    [SerializeField] private GameObject mainMenu;

    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;

    public bool PlayerActive
    {
        get { return playerActive; }
    }

    //getters and setters
    public bool GameOver
    {
        get { return gameOver; }
    }

    public bool GameStarted
    {
        get { return gameStarted; }
    }



    //singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        Assert.IsFalse(mainMenu);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerCollided()
    {
        gameOver = true;
    }

    public void PlayerStartedGame()
    {
        playerActive = true;
    }

    public void EnterGame()
    {
        mainMenu.SetActive(false);
        gameStarted = true;
    }
}

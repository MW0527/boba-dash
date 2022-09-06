using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatemanager : MonoBehaviour
{
    [SerializeField]
    private int gameover_scene;
    private static GameStatemanager instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(instance);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    enum GAMESTATE
    { 
        MAINMENU,
        PLAYING,
        PAUSED,
        GAMEOVER
    }
    private static GAMESTATE game_state;

    public static void Play(int scene) //takes an index of the scene
    //hook up to main menu play button
    //also restart button
    {
        game_state = GAMESTATE.PLAYING;
        SceneManager.LoadScene(scene);
    }
    public static void Home(int scene)
    //hook up to button that goes to main menu
    {
        game_state = GAMESTATE.MAINMENU;
        SceneManager.LoadScene(scene);
    }
    public static void GameOver()
    {
        game_state = GAMESTATE.GAMEOVER;
        SceneManager.LoadScene(instance.gameover_scene);
    }

    public static void TogglePause()
    //hook up to in-game pause button and resume button AND
    //when press escape key
    {
        if (game_state == GAMESTATE.PLAYING)
        {
            game_state = GAMESTATE.PAUSED;
            Time.timeScale = 0; //pause the game
        }
        else if (game_state == GAMESTATE.PAUSED)
        {
            game_state = GAMESTATE.PLAYING;
            Time.timeScale = 1; //resume playing
        }
    }

    public static void Quit()
    {
        Application.Quit();
    }
}

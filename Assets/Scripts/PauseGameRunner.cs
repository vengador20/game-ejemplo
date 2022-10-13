using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameRunner : MonoBehaviour
{
    [SerializeField]
    private bool gameRunning = false;

    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        //evitar rotacion que el juego se pueda jugar en horizontal
        Screen.orientation = ScreenOrientation.Portrait;

        button = GameObject.Find("IniciarJuego");
        //juego pausado al empezar el juego
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
           ChangeGameRunningState();
        }

        //button.onClick.AddListener(() => disabledButton());

    }

    public void ChangeGameRunningState()
    {
        //gameRunning = !gameRunning;

        if (gameRunning)
        {
            //juego corriendo
            Debug.Log("corriendo");
            Time.timeScale = 1;

            //reanudar audio
            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource audio in audios)
            {
                audio.Play();
            }
        }
        else
        {
            //juego pausado
            Debug.Log("pausado");
            Time.timeScale = 0;

            //pausar audio
            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource audio in audios)
            {
                audio.Pause();
            }
        }
        gameRunning = !gameRunning;
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }

    public void DisabledButton()
    {
        button.gameObject.SetActive(false);
    }

    public void GameRunning()
    {
        gameRunning = true;
        Time.timeScale = 1;
    }
}

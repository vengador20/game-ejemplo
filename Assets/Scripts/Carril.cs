using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Carril : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textoIntentos;
    [SerializeField] public GameObject menuGameEnd;
    [SerializeField] public GameObject menuNextGameEnd;
    //public TextMes
    public Image Image;
    private Rigidbody2D Rigidbody2D;
    private SpriteRenderer Sprite;
    private Sprite Spr;
    //private int intentos = 3;
    //private int aciertos = 0;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Image = GameObject.Find("ImageCambiante").GetComponent<Image>();
        //textoIntentos = gameObject.GetComponent<TextMeshProUGUI>();

        //Sprite = GameObject.GetComponent<SpriteRenderer>();
        Sprite = gameObject.GetComponent<SpriteRenderer>();
        //menuGameEnd.SetActive(true);
        //Sprite.sprite;
        //Sprite.sprite;

    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if (player != null)
        {
            if (Sprite.sprite.ToString() == Image.sprite.ToString())
            {
                Debug.Log("Imagen correcta si es la imagen");
                player.aciertos += 1;


                //textoIntentos.text = "Itentos :" + aciertos;
                if (player.aciertos == 1)//5
                {
                    Debug.Log("Tienes 20 monedas");
                    Debug.Log("Se ha terminado la partida y has ganado");
                    Time.timeScale = 0;
                    if(player.levelOne == true)
                    {
                        EndGame(true);
                    }
                    
                    //menuEndPlay();
                }
            }
            else {
                Debug.Log("Imagen Incorrecta");
                player.intentos -= 1;
                textoIntentos.text = $"Intentos: {player.intentos}";

                if (player.intentos == 0)
                {
                    Debug.Log("El juegos ha terminado");
                    Time.timeScale = 0;
                    EndGame(false);
                    //menuEndPlay();
                }
            }
        }
    }


    //private void menuEndPlay()
    //{
    //    menuGameEnd.SetActive(true);
    //    //LeanTween.scale(menuEnd, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack);
    //    //LeanTween.alpha(menuEndFondo, 0.5f, 0.5f);
    //    //LeanTween.alpha(menuEnd, 1f, 0.5f);
    //}

    private void EndGame(bool nextEnd)
    {
        menuGameEnd.SetActive(true);

        //si es true gano y si es falso perdio
        menuNextGameEnd.SetActive(nextEnd);
        //if (nextEnd == true)
        //{ menuNextGameEnd.SetActive(true); }
        //else { menuNextGameEnd.SetActive(false); }
    }

}

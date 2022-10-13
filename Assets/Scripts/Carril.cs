using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Carril : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textoIntentos;
    //public TextMes
    public Image Image;
    private Rigidbody2D Rigidbody2D;
    private SpriteRenderer Sprite;
    private Sprite Spr;
    private int intentos = 3;
    private int aciertos = 0;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Image = GameObject.Find("ImageCambiante").GetComponent<Image>();
        //textoIntentos = gameObject.GetComponent<TextMeshProUGUI>();

        //Sprite = GameObject.GetComponent<SpriteRenderer>();
         Sprite = gameObject.GetComponent<SpriteRenderer>();
        //Sprite.sprite;
        //Sprite.sprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if(player != null)
        {
            if (Sprite.sprite.ToString() == Image.sprite.ToString())
            {
                Debug.Log("Imagen correcta si es la imagen");
                aciertos += 1;
                //textoIntentos.text = "Itentos :" + aciertos;
                if (aciertos == 5)
                {
                    Debug.Log("Tienes 20 monedas");
                    Debug.Log("Se ha terminado la partida y has ganado");
                }
            }else{
                Debug.Log("Imagen Incorrecta");
                intentos -= 1;
                textoIntentos.text = $"Intentos: {intentos}";

                if (intentos == 0)
                {
                    Debug.Log("El juegos ha terminado");
                }
            }
        }
    }
}

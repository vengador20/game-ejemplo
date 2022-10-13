using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //publicos
    public float speed;
    public float speedMov;
    public GameObject highway;
    public GameObject[] formas;
    public SpriteRenderer[] formasSprite;
    public Sprite[] formasArr;

    public Image Image;

    public Transform start;
    public Transform end;

    //privados
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool MoveLeft;
    private bool MoveRight;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        //formasSprite[0] = formasSprite[0].GetComponent<SpriteRenderer>();
        //triangulo.sprite = "";
        //changeFormas();
        Image = GameObject.Find("ImageCambiante").GetComponent<Image>();
        
        //Image.sprite = formasArr[1];
        
        MoveLeft = false;
        MoveRight = false;
        changeFormas();
    }

    //cuando se presiona el boton izquierdo
    public void PointerDownLeft()
    {
        MoveLeft = true;
    }

    //cuando  no se presiona el boton izquierdo
    public void PointerUpLeft()
    {
        MoveLeft = false;
    }

    //cuando se presiona el boton derecho
    public void PointerDownRight()
    {
        MoveRight = true;
    }

    //cuando  no se presiona el boton derecho
    public void PointerUpRight()
    {
        MoveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal = Input.GetAxisRaw("Horizontal");
        Movement();
        MovementHighway();
        InfiniteHighway();
    }

    //carretera en movimiento infinito
    void MovementHighway()
    {
        highway.transform.position = new Vector3(highway.transform.position.x,highway.transform.position.y - 0.8f * Time.deltaTime, highway.transform.position.z);
        foreach (var item in formas)
        {
            item.transform.position = new Vector3(item.transform.position.x,item.transform.position.y-0.8f* Time.deltaTime,item.transform.position.z);
        }
    }

    void InfiniteHighway()
    {
        if(highway.transform.position.y <= start.position.y)
        {
            highway.transform.position = new Vector3(highway.transform.position.x,end.transform.position.y,highway.transform.position.z);
            foreach (var item in formas)
            {
                item.transform.position = new Vector3(item.transform.position.x, end.transform.position.y,item.transform.position.z);
            }
            //cada vez que pasa el personaje por una forma se actualiza a diferente forma
            changeFormas();
        }
    }
    public void Movement()
    {
        
        //si se presiona el boton izquierdo
        if (MoveLeft)
        {
            Horizontal = -speedMov;
        }

        //si se presiona el boton derecho
        else if(MoveRight)
        {
            Horizontal = speedMov;
        }
        else{
            Horizontal = 0;
        }
    }

    private void FixedUpdate() 
    {
        Rigidbody2D.velocity = new Vector2(Horizontal,Rigidbody2D.velocity.y);
    }

    void changeFormas()
    {
        var numeros = new List<int>();
        //Iteramos hasta que la lista tenga 10 elementos
        while (numeros.Count < 3)
        {
            
            int numeroAleatorio = new Random().Next(0, 4);

            //S�lo si el n�mero generado no existe en la lista se agrega
            if (!numeros.Contains(numeroAleatorio))
            {
                numeros.Add(numeroAleatorio);
                //Debug.Log(numeroAleatorio);
            }
        }


        int imageAleatorio = new Random().Next(0,2);
        Image.sprite = formasArr[numeros[imageAleatorio]];

        //Debug.Log(Image.sprite);
        
        int i = 0;
        foreach(var item in formasSprite)
        {
            //Debug.Log(numeros[i]);
            item.sprite = formasArr[numeros[i]];
            i++;
        }


    }

    void collisionImage()
    {
        // if (Image.sprite == )
        // {
            
        // }
    }
}

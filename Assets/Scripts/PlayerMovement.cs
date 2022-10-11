using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //publicos
    public float speed;
    public float speedMov;
    public GameObject highway;
    public GameObject[] formas;
    public SpriteRenderer[] formasSprite;
    public Sprite[] formasArr;

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
        formasSprite[0] = formasSprite[0].GetComponent<SpriteRenderer>();
        //triangulo.sprite = "";
        //changeFormas();
        MoveLeft = false;
        MoveRight = false;
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
        changeFormas();
        //triangulo.
        jugadorFigura();
    }

    //jugador esta en la figura
    void jugadorFigura()
    {
        
    }

    //carretera en movimiento infinito
    void MovementHighway()
    {
        highway.transform.position = new Vector3(highway.transform.position.x,highway.transform.position.y - 0.8f * Time.deltaTime,transform.position.z);
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
        formasSprite[0].sprite = formasArr[1];
    }
}

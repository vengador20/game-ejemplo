using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carril : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
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
            Debug.Log("paso la figura");
        }
    }
}

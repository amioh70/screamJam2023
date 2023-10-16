using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charakter : MonoBehaviour
{
    public float speed = 0.5f;
    public Vector2 targetPos;
    public bool isMoving;
    static public float sanity = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sanity);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider.gameObject.tag== "ground")
            {
                // Position des Spielers ver�ndern
                //player.transform.position = hit.point;
                targetPos = new Vector2(hit.point.x,gameObject.transform.position.y);
                // isMoving wahr damit sich spieler bewegt
                isMoving = true;
                // �berpr�fe ob sprite flip notwendig
                CheckSpriteFlip();
            }

            else if (hit.collider.gameObject.tag== "door")
            {
                targetPos = new Vector2(hit.point.x, gameObject.transform.position.y);
                hit.collider.gameObject.GetComponent<door>().useDoor();
            }
        }
    }

    public void IncreaseSanity()
    {
        sanity++;
    }

    private void FixedUpdate()
    {
        //�berpr�fe ob Spieler sich bewegt
        if (isMoving)
        {
            //Spieler an Zielort bef�redern
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);
            //Ist der Spieler am Zielort?
            if (transform.position.x == targetPos.x && transform.position.y == targetPos.y)
            {
                //Spieler am Zielort? => isMoving aus
                isMoving = false;

            }

        }
    }

    void CheckSpriteFlip()
    {
        if (transform.position.x > targetPos.x)
        {
            //Nach links blicken
            transform.localScale = new Vector2(-1,1);
        }
        else
        {
            //Nach rechts
            transform.localScale = new Vector2(1, 1);
        }
    }

}

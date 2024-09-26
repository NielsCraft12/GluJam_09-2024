using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    Vector3 Pos;
    Vector3 direction;
    Rigidbody2D rb;
    bool walingLeft = true;
    Vector3 forceDirection;




    // Start is called before the first frame update
   protected virtual void Start()
    {
        forceDirection = Vector3.left;
        direction = transform.TransformDirection(Vector2.left) * 1;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
       
        rb.AddForce(forceDirection / 9, ForceMode2D.Impulse);
        if (walingLeft )
        {
            Pos = new Vector3(transform.position.x + -0.5f, transform.position.y, transform.position.z);
        }
        else
        {
            Pos = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
        }

        RaycastHit2D hit = Physics2D.Raycast(Pos, direction, .1f);
 
        if (hit && hit.collider.name != "Box" && hit.collider.name != "Player" && !hit.collider.CompareTag("Enemy"))
        {
            Rotate();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(Pos, direction);
    }



    private void Rotate()
    {

        if (walingLeft) 
        {
            walingLeft = false;
        }
        else
        {
            walingLeft = true;
        }


        if (!walingLeft) 
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            
            direction = transform.TransformDirection(Vector2.right) * 1;
            forceDirection = Vector3.right;


        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
           
            direction = transform.TransformDirection(Vector2.left) * 1;
            forceDirection = Vector3.left;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInfo.Instance.DamagePoints++;
            Rotate();
        }
        if (collision.gameObject.name == "Box")
        {
            Destroy(gameObject);
        }


    }



}

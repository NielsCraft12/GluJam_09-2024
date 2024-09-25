using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    Rigidbody2D rb;



    // Start is called before the first frame update
   protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        rb.AddForce(Vector3.left, ForceMode2D.Impulse);
    }
}

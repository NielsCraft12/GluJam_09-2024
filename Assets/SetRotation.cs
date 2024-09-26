using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{
    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint( Input.mousePosition );

        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.localPosition = new Vector2(Mathf.Clamp(mouse.x, -2, 2), Mathf.Clamp(mouse.y, -2, 2));
    }
}

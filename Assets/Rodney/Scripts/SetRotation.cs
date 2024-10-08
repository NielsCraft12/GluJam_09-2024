using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{
    void Update()
    {
        // The box outline follows the mouse within a certain range
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
        transform.localPosition = new Vector3(Mathf.Clamp(mouse.x, -2, 2), Mathf.Clamp(mouse.y, -2, 2), -0.1f);

        // The box outline always stays rotated upright
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}

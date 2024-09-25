using Unity.VisualScripting;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    float yPos;

    private void Update()
    {
        if(yPos >= -3.5f)
        {
            yPos = playerTransform.position.y + 1.5f;
        }
        else
        {
            yPos = -3.6f;
        }
        
        transform.position = new Vector3(playerTransform.position.x, yPos, playerTransform.position.z - 10);

        if(playerTransform.position.y <= -12)
        {
            PlayerInfo.Instance.DamagePoints++;
        }
    }
}

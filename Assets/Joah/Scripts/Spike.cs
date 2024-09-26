using UnityEngine;

public class Spike : MonoBehaviour
{
    float timer = 0;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(timer <= 0)
            {
                PlayerInfo.Instance.DamagePoints++;
                timer = 5;
            }
            if(timer > 0)
            {
                timer -= Time.deltaTime * 5;
            }
        }
    }
}

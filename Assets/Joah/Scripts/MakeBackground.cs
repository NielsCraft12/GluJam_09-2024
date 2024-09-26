using UnityEngine;
using UnityEngine.UI;

public class MakeBackground : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Image background;

    private void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Image newTile = Instantiate(background, canvas.transform);
                Vector3 spawnPos = new Vector3(newTile.transform.position.x + i * 240, 0 + j * 240, 0);
                newTile.transform.position = spawnPos;
            }
        }
    }
}

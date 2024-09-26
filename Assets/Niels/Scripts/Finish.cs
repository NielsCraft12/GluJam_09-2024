using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    string NextLevelName;
    int endHP;
    bool hasFinsihed = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hasFinsihed)
        {
            PlayerInfo.Instance.DamagePoints = endHP;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(NextLevel());
            hasFinsihed = true;
            endHP = PlayerInfo.Instance.DamagePoints;
            animator.SetTrigger("IsPressed");
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(NextLevelName);
        PlayerInfo.Instance.isPaused = true;
    }
}

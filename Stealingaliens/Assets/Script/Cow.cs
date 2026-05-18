using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    private GameObject player;
    private ScoreManager scoreManager;
    public AudioClip collectSound;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            scoreManager.score += 1;
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, 3f);
            }
            Destroy(this.gameObject);
        }
    }
}

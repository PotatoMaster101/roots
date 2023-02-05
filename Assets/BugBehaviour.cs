using UnityEngine;
using UnityEngine.SceneManagement;

public class BugBehaviour : MonoBehaviour
{
    public const float MovementSpeed = 3;
    public Vector3 MovementDirection = Vector3.left;

    // Update is called once per frame
    void Update()
    {
        transform.position += MovementDirection * MovementSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            OnCollidingPlayer(collision);
        }
        else if (collision.gameObject.tag == "Trail")
        {
            OnCollidingRoot(collision);
        }
        else
        {
            OnCollidingRock(collision);
        }
    }

    void OnCollidingRock(Collision2D collision)
    {
        // Move slightly away from the wall
        transform.position += MovementDirection * MovementSpeed * Time.deltaTime;

        // Workaround to trigger collision again if we are stuck in a corner
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;

        Random.InitState(System.DateTime.Now.Millisecond);
        switch(Random.Range(1, 5))
        {
            case 1:
                MovementDirection = Vector3.left;
                break;
            case 2:
                MovementDirection = Vector3.right;
                break;
            case 3:
                MovementDirection = Vector3.up;
                break;
            case 4:
                MovementDirection = Vector3.down;
                break;
        }
    }

    void OnCollidingPlayer(Collision2D collision)
    {
        SceneManager.LoadScene("GameOverSceneLose");
    }

    void OnCollidingRoot(Collision2D collision)
    {
        SceneManager.LoadScene("GameOverSceneLose");
    }
}

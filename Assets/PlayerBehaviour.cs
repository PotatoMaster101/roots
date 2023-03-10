using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public const float MovementSpeed = 3;
    public Vector3 PreviousPosition { get; set; }
    public Vector3 PreviousTrailPosition { get; set; } = new Vector3(100,100,100);
    public GameObject trailPrefab;

    // Update is called once per frame
    void Update()
    {
        PreviousPosition = transform.position;

        if (Input.GetKey("a"))
            transform.position += Vector3.left * MovementSpeed * Time.deltaTime;
        if (Input.GetKey("d"))
            transform.position += Vector3.right * MovementSpeed * Time.deltaTime;
        if (Input.GetKey("w"))
            transform.position += Vector3.up * MovementSpeed * Time.deltaTime;
        if (Input.GetKey("s"))
            transform.position += Vector3.down * MovementSpeed * Time.deltaTime;

        if (transform.position != PreviousPosition)
        {
            SpawnTrail();
        }
    }

    void SpawnTrail()
    {
        Debug.Log($"Moved: {PreviousPosition} to {transform.position}");
        if (Vector3.Distance(PreviousTrailPosition, transform.position) > 3)
        {
            Instantiate(trailPrefab, PreviousTrailPosition, Quaternion.identity);
            PreviousTrailPosition = transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "Trail")
      {
          Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      }
    }
}

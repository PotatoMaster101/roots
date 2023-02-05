using UnityEngine;

public class TrailBehaviour : MonoBehaviour
{
    public const float MovementSpeed = 3;
    public Vector3 PreviousPosition { get; set; }

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
    }
}

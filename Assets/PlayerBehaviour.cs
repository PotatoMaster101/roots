using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public const float MovementSpeed = 3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
            transform.position -= Vector3.right * MovementSpeed * Time.deltaTime;
        if (Input.GetKey("d"))
            transform.position += Vector3.right * MovementSpeed * Time.deltaTime;
        if (Input.GetKey("w"))
            transform.position += Vector3.up * MovementSpeed * Time.deltaTime;
        if (Input.GetKey("s"))
            transform.position -= Vector3.up * MovementSpeed * Time.deltaTime;
    }
}

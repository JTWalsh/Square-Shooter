using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public float amountToMove;
    public float CameraSpeed;
    public float minimum;
    public float maximum;

    public KeyCode right;
    public KeyCode left;
    public KeyCode up;
    public KeyCode down;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(right))
        {
            //float amountToMove = Input.GetAxisRaw("Horizontal") * CameraSpeed * Time.deltaTime;
            transform.Translate(Vector3.right * amountToMove * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minimum, maximum), transform.position.y, transform.position.z);
        }
        if (Input.GetKey(left))
        {
            //float amountToMove = Input.GetAxisRaw("Horizontal") * CameraSpeed * Time.deltaTime;
            transform.Translate(-Vector2.right * amountToMove * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minimum, maximum), transform.position.y, transform.position.z);
        }
        if (Input.GetKey(up))
        {
            //float amountToMove = Input.GetAxisRaw("Vertical") * CameraSpeed * Time.deltaTime;
            transform.Translate(Vector2.up * amountToMove * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minimum, maximum), transform.position.z);
        }
        if (Input.GetKey(down))
        {
            //float amountToMove = Input.GetAxisRaw("Vertical") * CameraSpeed * Time.deltaTime;
            transform.Translate(-Vector2.up * amountToMove * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minimum, maximum), transform.position.z);
        }
    }
}

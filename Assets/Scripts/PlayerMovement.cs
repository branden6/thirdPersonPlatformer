using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8.0f;
    public float jumpForce = 8.0f;
    private float horizontalInput, forwardInput;
    private Rigidbody rigidbodyPlayer;
    public bool isOnGround;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the player's input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //movement forward/backwards/left/right
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        //check if player is on the ground, ground tagged with "Ground"
        //player jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround){
            rigidbodyPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision){
        //make sure jump can only be used once
        if (collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }
    }
}

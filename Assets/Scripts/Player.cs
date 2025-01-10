using UnityEngine;

public class Player : MonoBehaviour
{

    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidBodyPlayer;
    private int superJumpsRemaining;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBodyPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            jumpKeyWasPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");

    }
    private void FixedUpdate(){
        Vector3 velocity = rigidBodyPlayer.linearVelocity;
        velocity.x = horizontalInput*2;
        rigidBodyPlayer.linearVelocity = velocity;

        if(jumpKeyWasPressed){
            float jumpPower = 7f;
            if(superJumpsRemaining>0){
                jumpPower *=2;
                superJumpsRemaining--;
            }
            rigidBodyPlayer.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }
}

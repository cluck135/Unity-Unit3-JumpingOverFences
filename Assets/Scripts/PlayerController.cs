using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    public bool isOnGround;
    public bool gameOver;
    public float jumpForce= 10;
    public float gravityModifier = 1;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Fence")) {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }    
}

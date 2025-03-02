using System;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] GameObject[] playerComponents;
    [SerializeField] float thrustForce = 0.01f;
    [SerializeField] float thrustForceIncrease = 0.1f;
    //[SerializeField] bool thrusterOn = false;
    [SerializeField] Vector2 thrustDirection = new Vector2(0, 0);
    [SerializeField] Vector2 currentDirection = new Vector2(0, 0);
    //[SerializeField] float thrustAngle = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotation();
        PlayerThrust();
        PlayerJump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Laser")) { return; }

        Debug.Log("Player Collision");
        foreach (GameObject playerComponent in playerComponents) 
        {
            Debug.Log("Enabling Collider");
            playerComponent.GetComponent<Collider2D>().enabled = true;
        }

    }

    private void PlayerJump()
    {
        if (Mathf.Abs(transform.position.x) > 9.1f) { transform.position = new Vector2(-transform.position.x,  transform.position.y); };
        if (Mathf.Abs(transform.position.y) > 5.1f) { transform.position = new Vector2( transform.position.x, -transform.position.y); };
    }
    private void PlayerRotation()
    {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal"));
    }

    private void PlayerThrust()
    {
        if (Input.GetKey(KeyCode.LeftControl ) || Input.GetKey(KeyCode.RightControl))
        {
            //thrusterOn = true;
            thrustDirection = new Vector2( Mathf.Cos((transform.eulerAngles.z + 90) * Mathf.Deg2Rad)
                                         , Mathf.Sin((transform.eulerAngles.z + 90) * Mathf.Deg2Rad)
                                         
                                         );
            currentDirection = thrustDirection + currentDirection;
            //rb.AddForce(thrustDirection * thrustForce);
        }
        transform.Translate(currentDirection * Time.deltaTime * thrustForce, Space.World);
    }
}

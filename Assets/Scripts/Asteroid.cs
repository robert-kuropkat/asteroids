using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] GameObject[] asteroidComponents;
    [SerializeField] Vector2 thrustDirection = new Vector2(0, 0);
    [SerializeField] Vector2 currentDirection = new Vector2(0, 0);
    [SerializeField] float thrustForce = 0.001f;
    public bool thrusterOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector2(-transform.position.x, -transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Collider2D>().enabled) { thrusterOn = true; }
        //AsteroidThrust();
        //AsteroidJump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Asteroid")
           || collision.transform.CompareTag("AsteroidSide")) { return; }

        if (  collision.transform.CompareTag("Laser")
           || collision.transform.CompareTag("Player"))
        {
            Debug.Log("Asteroid Collision");
            foreach (GameObject asteroidComponent in asteroidComponents)
            {
                Debug.Log("Enabling Child Collider");
                asteroidComponent.GetComponent<Collider2D>().enabled = true;
         
            }
        }

        GetComponent<Collider2D>().enabled = false;

    }

    private void AsteroidThrust()
    {
        if (thrusterOn)
        {
            //thrusterOn = true;
            thrustDirection = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90) * Mathf.Deg2Rad)
                                         , Mathf.Sin((transform.eulerAngles.z + 90) * Mathf.Deg2Rad)

                                         );
            currentDirection = thrustDirection + currentDirection;
            //rb.AddForce(thrustDirection * thrustForce);
        }
        transform.Translate(currentDirection * Time.deltaTime * thrustForce);
    }


    private void AsteroidJump()
    {
        if (Mathf.Abs(transform.position.x) > 9.1f) { transform.position = new Vector2(-transform.position.x, transform.position.y); };
        if (Mathf.Abs(transform.position.y) > 5.1f) { transform.position = new Vector2(transform.position.x, -transform.position.y); };
    }


}

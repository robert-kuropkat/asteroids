using UnityEngine;

public class ShipSide : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float blastForce = .05f;
    [SerializeField] bool hasCollided = false;
    [SerializeField] float rotationDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rotationDirection = Mathf.Sign(transform.rotation.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (hasCollided) { transform.Rotate(0,0,rotationDirection * 1f); }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasCollided = true;
        rb.AddForce(new Vector2(rotationDirection, 1) * blastForce, ForceMode2D.Impulse); 
    }
}

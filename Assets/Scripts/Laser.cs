using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float laserSpeed = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * laserSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) { return; }

        Destroy(this.gameObject, 0.1f);
    }

}

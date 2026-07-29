using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    public Rigidbody rb;
    public float damage = 50f;
    public float bullet_speed = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * bullet_speed;

           
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        Destroy(gameObject);
    }
}

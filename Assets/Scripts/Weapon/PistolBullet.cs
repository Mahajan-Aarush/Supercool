using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    public Rigidbody rb;
    public float damage = 50f;
    public float bullet_speed = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bullet_speed, ForceMode.Impulse);

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {

           
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.takeDamage(50);
                 
            }


            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    public float damage = 50f;
    public float bullet_speed = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bullet_speed * Time.deltaTime;
        
    }
}

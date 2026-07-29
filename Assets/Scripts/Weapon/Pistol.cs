using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject PistolBullet;
    public Transform BulletSpawner;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(PistolBullet, BulletSpawner.position, BulletSpawner.rotation);
            
        }
        
    }
}

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
            shoot();
            
        }
        
    }
    void shoot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        RaycastHit hit;
        Vector3 targetPositon;

        if (Physics.Raycast(ray, out hit))
        {
            targetPositon = hit.point;
        }
        else
        {
            targetPositon = ray.GetPoint(1000f);
        }

        Vector3 direction = (targetPositon - BulletSpawner.position).normalized;

        Instantiate(PistolBullet, BulletSpawner.position, Quaternion.LookRotation(direction));
    }
}

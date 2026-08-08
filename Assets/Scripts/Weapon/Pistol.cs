using UnityEngine;

public class Pistol : MonoBehaviour
{
    public PlayerCamera playerCamera;
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
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;
        Vector3 targetPositon;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            targetPositon = hit.point;
        }
        else
        {
            targetPositon = ray.GetPoint(75f);
        }

        Vector3 direction = (targetPositon - BulletSpawner.position).normalized;

        GameObject currentbullet = Instantiate(PistolBullet, BulletSpawner.position, Quaternion.identity);
        currentbullet.transform.forward = direction;

        playerCamera.ShakeCamera(0.02f, 0.01f);
    }
}

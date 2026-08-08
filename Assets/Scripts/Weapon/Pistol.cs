using UnityEngine;

public class Pistol : MonoBehaviour
{
    public PlayerCamera playerCamera;
    public GameObject PistolBullet;
    public Transform BulletSpawner;
    

    // roational sway
    [Header ("Rotational Sway")]
    [SerializeField] float sway_amount = 8f;
    [SerializeField] float sway_speed = 5f;
    Quaternion original_rotation;

    // positional sway
    [Header ("Positional Sway")]
    Vector3 original_position;
    [SerializeField] Transform hand_transform;
    [SerializeField] Transform Playertransform;

    void Start()
    {
        original_rotation = transform.localRotation;
        original_position = transform.localPosition;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
            
        }


        sway();       
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

       // playerCamera.ShakeCamera(0.02f, 0.01f);
    }


    void sway()
    {
        //rotational sway
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Quaternion target_rotation = original_rotation * Quaternion.Euler(-mouseY * sway_amount, mouseX * sway_amount, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, target_rotation, sway_speed * Time.deltaTime);

        // positional sway (doesn't work properly yet)
        Vector3 target_position = hand_transform.localPosition;

        transform.localPosition = Vector3.Lerp(transform.localPosition, target_position, sway_speed * Time.deltaTime);
    }
}

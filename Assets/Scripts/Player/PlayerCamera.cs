using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    public Transform playerbody;

    [Header("LookAround")]
    float xRotation = 0f;
    public float MouseSensi = 200f;

    [Header("CameraShake")]
    Vector3 originalPosition;

    [Header("CameraJump")]
    Vector3 Camera_position = new Vector3(0, 0.6f, 0);
    Vector3 Land_cam_position = new Vector3(0, 0.2f, 0);



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        originalPosition = transform.localPosition;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensi * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerbody.Rotate(Vector3.up * mouseX);

    }


    public void ShakeCamera(float duration, float strength)
    {
        StartCoroutine(CameraShake(duration, strength));
    }
    IEnumerator CameraShake(float duration, float strength)
    {
        float time = 0;

        while (time < duration)
        {
            float x = Random.Range(-strength, strength);
            float y = Random.Range(-strength, strength);

            transform.localPosition = originalPosition + new Vector3(x, y, 0);

            time += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }

    public void jumpeffect()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, Land_cam_position, 5f * Time.deltaTime);
    }
    public void landingeffect()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, Camera_position, 3f * Time.deltaTime);
    }

        
    

}

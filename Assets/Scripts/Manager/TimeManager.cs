using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float SlowdownRate = 0.05f;



    public void SlowMotion()
    {
        Time.timeScale = SlowdownRate;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
    public void NormalTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}

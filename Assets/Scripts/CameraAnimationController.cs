using Unity.VisualScripting;
using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{
    public Camera cam;
    private Animator ani;

    private void Start()
    {
        ani = cam.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("A"))
        {
            ani.SetTrigger("At A");
        }

        if (collision.gameObject.CompareTag("B"))
        {
            ani.SetTrigger("At B");
        }

        if (collision.gameObject.CompareTag("C"))
        {
            ani.SetTrigger("At C");
        }
    }
}

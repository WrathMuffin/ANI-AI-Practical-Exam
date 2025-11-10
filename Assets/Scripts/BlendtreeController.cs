using UnityEngine;
using DitzelGames.FastIK;

public class BlendtreeController : MonoBehaviour
{
    public Animator ani;
    [SerializeField] FastIKFabric iKFab;

    private bool isGrab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani = GetComponent<Animator>();

        iKFab.enabled = false;

        ani.SetLayerWeight(3, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // walking
        if (Input.GetMouseButtonDown(0))
        {
            ani.SetLayerWeight(1, 1f);
            //ani.SetFloat("Blend", 0f);
        }

        // bow pose
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ani.SetFloat("Actions", 0f);
        }

        // sword pose
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ani.SetFloat("Actions", 1f);
        }

        // Grab object
        if (Input.GetKeyDown(KeyCode.E) && isGrab)
        {
            iKFab.enabled = true;
            ani.SetLayerWeight(3, 1f);
        }

        // Sneak pose
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ani.SetLayerWeight(2, 1f);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ani.SetLayerWeight(2, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bow"))
        {
            isGrab = true;
        }

        if (other.CompareTag("Shield"))
        {
            isGrab = true;
        }

        if (other.CompareTag("MouseTarget"))
        {
            ani.SetLayerWeight(0, 1f);
            ani.SetLayerWeight(1, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bow"))
        {
            isGrab = false;
        }
        if (other.CompareTag("Shield"))
        {
            isGrab = false;
        }

        if (other.CompareTag("MouseTarget"))
        {
            ani.SetLayerWeight(0, 0f);
            ani.SetLayerWeight(1, 1f);
        }
    }
}
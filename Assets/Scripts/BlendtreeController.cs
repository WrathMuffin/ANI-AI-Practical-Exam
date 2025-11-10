using UnityEngine;
using DitzelGames.FastIK;
using Unity.VisualScripting;

public class BlendtreeController : MonoBehaviour
{
    public Animator ani;
    public GameObject handTarget;
    public GameObject hand;

    [SerializeField] FastIKFabric iKFab;

    private bool isGrab, isBowEqipped, isShieldEquipped;
    private GameObject currentWeapon;

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
            isBowEqipped = true;
            isShieldEquipped = false;
            ani.SetFloat("Actions", 0f);

            Debug.Log("Bow equipped!");
        }

        // shield pose
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ani.SetLayerWeight(3, 1f);
            ani.SetFloat("Actions", 1f);

            Debug.Log("Shield equipped!");
        }

        // Grab object
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isGrab)
            {
                iKFab.enabled = true;
                ani.SetLayerWeight(3, 1f);

                currentWeapon.GetComponent<Animator>().enabled = false;
                handTarget.transform.position = currentWeapon.transform.position;
                currentWeapon.transform.position = hand.transform.position;
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            currentWeapon.gameObject.SetActive(false);
            iKFab.enabled = false;
            ani.SetLayerWeight(3, 0f);
        }

        // Sneak pose
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ani.SetLayerWeight(2, 1f);
        }

        // crouch or sneak
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
            currentWeapon = other.gameObject;

            Debug.Log("Bow grabbed!");
        }

        if (other.CompareTag("Shield"))
        {
            isGrab = true;
            currentWeapon = other.gameObject;

            Debug.Log("Shield grabbed!");
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
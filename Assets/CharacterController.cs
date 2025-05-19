using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    [SerializeField] private GameObject mobileControlsCanvas;

#if UNITY_EDITOR || UNITY_STANDALONE
    private Vector2 moveInput;
#endif

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

#if UNITY_ANDROID
        if (mobileControlsCanvas != null)
            mobileControlsCanvas.SetActive(true);
#else
        if (mobileControlsCanvas != null)
            mobileControlsCanvas.SetActive(false);
#endif
    }

    private void FixedUpdate()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        Vector3 movement = new Vector3(moveInput.x, 0f, 0f);
        rb.AddForce(movement * speed);
#endif
    }

#if UNITY_EDITOR || UNITY_STANDALONE
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
#endif
}
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get RB
        rb = GetComponent<Rigidbody>();
        //add listener
        inputManager.OnMove.AddListener(MovePlayer);
    }
    //apply left right to player
    private void MovePlayer(Vector2 direction)
    {
        Vector3 moveDirection = new(direction.x,0f,direction.y);
        rb.AddForce(moveDirection*speed,ForceMode.Force);
    }
}

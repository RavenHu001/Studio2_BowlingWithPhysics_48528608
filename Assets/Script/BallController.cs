using UnityEngine;
using UnityEngine.Events;

public class BallCOntroller : MonoBehaviour
{
    //variable for detected ball is lunched
    private bool isLunched = false;
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;

    private Rigidbody ballRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set reference of RB in code instead in Unity
        ballRb = GetComponent<Rigidbody>();
        //Set listener of press space in code 
        inputManager.onSpacePressed.AddListener(LaunchBall);
    }
    private void LaunchBall() 
    {
        //detect islunched
        if (isLunched) return;
        //not lunched, lunch
        isLunched = true;

        //when listener is activated, run add force to ballRB
        ballRb.AddForce(transform.forward*force,ForceMode.Impulse);
    }
}

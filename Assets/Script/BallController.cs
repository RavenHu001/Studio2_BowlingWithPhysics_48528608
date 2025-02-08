using UnityEngine;
using UnityEngine.Events;

public class BallCOntroller : MonoBehaviour
{
    //variable for detected ball is lunched
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    //add transform of ballAnchor
    [SerializeField] private Transform ballAnchor;
    //add transform of indicator
    [SerializeField] private Transform launchIndicator;

    private bool isLunched;
    private Rigidbody ballRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set reference of RB in code instead in Unity
        ballRb = GetComponent<Rigidbody>();
        //Set listener of press space in code 
        inputManager.onSpacePressed.AddListener(LaunchBall);
        //Set parent and local position
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        //set to kinematic when ball is hold
        ballRb.isKinematic = true;
    }
    private void LaunchBall() 
    {
        //detect islunched
        if (isLunched) return;
        //not lunched, lunch
        isLunched = true;
        //set parent to null when ball lunched
        transform.parent = null;
        //set not isKinematic when ball lunched
        ballRb.isKinematic=false;

        //when listener is activated, run add force to ballRB
        //ballRb.AddForce(transform.forward*force,ForceMode.Impulse);

        //update the add force in indicator's direction
        ballRb.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        //disable the launchIndicator
        launchIndicator.gameObject.SetActive(false);
    }
}

using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        //1.get RB of ball
        Rigidbody ballRB = triggeredBody.GetComponent<Rigidbody>();
        //2.get original veolocity Mangitude of ball
        float velocityMangitude = ballRB.linearVelocity.magnitude;
        //reset the liner and angular velocity
        ballRB.linearVelocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;
        //add force in forward direction of gutter,velocityMangitude is for keep realistic
        ballRB.AddForce(transform.forward*velocityMangitude,ForceMode.VelocityChange);
    }
}

using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent onSpacePressed = new UnityEvent();
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            onSpacePressed?.Invoke();
        }
        //detact a and d
        Vector2 input = Vector2.zero;
        if (Input.GetKeyUp(KeyCode.A)) 
        {
            input += Vector2.left;
        }
        if (Input.GetKeyUp(KeyCode.D)) 
        { 
            input += Vector2.right; 
        }
        OnMove?.Invoke(input);
    }
}

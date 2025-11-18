using UnityEngine;

public class draggingMovement : MonoBehaviour
{
    public Rigidbody2D selectedObject;
    Vector3 offset;
    Vector3 mousePosition;
    public float maxSpeed=10;
    Vector2 mouseForce;
    Vector3 lastPosition;
    private bool dragging;

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (selectedObject)
        {
            mouseForce = (mousePosition - lastPosition) / Time.deltaTime;
            mouseForce = Vector2.ClampMagnitude(mouseForce, maxSpeed);
            lastPosition = mousePosition;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject)
            {
                dragging = true;
            }
            offset = selectedObject.transform.position - mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {

            selectedObject.velocity = Vector2.zero;
            selectedObject.AddForce(mouseForce, ForceMode2D.Impulse);
            dragging = false;
        }
    }

    void FixedUpdate()
    {
        if (dragging)
        {
            selectedObject.MovePosition(mousePosition + offset);
        }
    }

}


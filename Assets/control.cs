using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class control : MonoBehaviour
{
    public GameManager _gm;
    public float power = 5f;
    Rigidbody2D rb;
    Vector2 DragStartPos;
    private Vector3 mousePosition;
    public float rotationSpeed = 1f;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.GetComponent<LineRenderer>().enabled = true;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 DragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 _velocity = (- DragStartPos + DragEndPos) * power;
            
            mousePosition = Input.mousePosition;
            transform.eulerAngles = new Vector3(0, 0, GetAngle() * rotationSpeed);


        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 DragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 _velocity = (DragStartPos - DragEndPos)* power;
            rb.velocity = _velocity;
            transform.GetComponent<control>().enabled = false;
            transform.GetComponent<LineRenderer>().enabled = false;

            StartCoroutine(Disappear());
            _gm.GetComponent<GameManager>().WrapFail();

        }

    }

    private float GetAngle()
    {
        Vector3 offset = Camera.main.WorldToScreenPoint(transform.position) - mousePosition;
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        return angle;
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }

   
}

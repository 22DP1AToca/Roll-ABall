using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

   
    private float movementX;
    private float movementY;
    private int count;

    public float speed = 0;

    public TextMeshProUGUI countText;
    public GameObject winGameObject;


    void Start()
    {
        SetCountText();
        count = 0;
        rb = GetComponent<Rigidbody>();
        winGameObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            winGameObject.GetComponent<TextMeshProUGUI>().text = "You lose";
            winGameObject.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
       
        }
  
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if(count >= 12)
        {
            winGameObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
}
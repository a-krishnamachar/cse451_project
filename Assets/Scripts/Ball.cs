using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    Rigidbody rb;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        if(Camera.main != null)
		{
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            movement = moveVertical * cameraForward + moveHorizontal * Camera.main.transform.right;
		}

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
      if(other.gameObject.layer == LayerMask.NameToLayer("KillZone")) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
    }
}

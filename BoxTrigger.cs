using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxTrigger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PointText;

    static int Point = 0;

    Rigidbody rb;

    Transform transf;

    float vertical;

    float horizontal;

    float jumpForce = 10f;

    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        rb.AddRelativeForce(0, 0, vertical * 4f);
        transf.Rotate(0, horizontal, 0);

        if(Input.GetKeyDown("space") && isGrounded == true){
            rb.drag = 2;
            rb.angularDrag = 2;
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "ground");{
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision col){
        if(col.gameObject.tag == "ground");{
            isGrounded = false;
        }

        if(col.gameObject.tag == "bad"){
            Destroy(col.gameObject);
            Point = Point + 1;
            PointText.text = Point + "";
        }
    }
}

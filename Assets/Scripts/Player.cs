using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool hideCursor = false;
    public float moveSpeed = 10f, maxVelocity = 20f;
    private Rigidbody rigid;
    public float rotationSpeed = 90f;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //Should the cursor be hidden
        if(hideCursor)
        {
            //hide it
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        Move(inputH, inputV);

        float inputR = Input.GetAxis("Mouse X");
        Rotate(inputR);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Did we hit an item?
        Item item = other.GetComponent<Item>();
        if(item)
        {
            //collect it!
            item.Collect();
        }
    }
    public void Move(float inputH, float inputV)
    {
        Vector3 velocity = rigid.velocity;
        Vector3 direction = new Vector3(inputH, 0,inputV) *moveSpeed;
        velocity = new Vector3(direction.x, velocity.y, direction.z);
        //Localspace Vector Conversion(Player facing to Main Camera Direction)
        Transform camTransform = Camera.main.transform;
        Vector3 camEuler = camTransform.eulerAngles;
        
        //Localise the direction of input to the Camera Y angle(degree)
        velocity = Quaternion.Euler(0f, camEuler.y, 0f) * velocity;

        rigid.velocity = velocity;

    }
    public void Rotate(float inputR)
    {
        //Rotating using Rigidbody (using Physics)
        float angle = inputR * rotationSpeed * Time.deltaTime;
        Quaternion rotation = rigid.rotation * Quaternion.AngleAxis(angle, Vector3.up);
        rigid.MoveRotation(rotation);

        // Rotating object forcibly (using Translate) #nofilter
        //transform.Rotate(Vector3.up, inputR * rotationSpeed * Time.deltaTime);
    }
}

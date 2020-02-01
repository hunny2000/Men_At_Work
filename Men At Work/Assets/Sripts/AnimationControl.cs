using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator Anim;
    public Rigidbody rb;
    public float speed;
    [SerializeField] private Transform cam;
    public float Maxvelocity;
    float Maxtime = 0f;
    bool climb = false;
    //m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
    //m_Move = v* m_CamForward + h* m_Cam.right;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Slope")
        {
            Debug.Log("yup");
            climb = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Slope")
        {
            climb = false;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Vector3.zero;
    }

    void Update()
    {
        //rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -rb.mass / Time.fixedDeltaTime, rb.mass / Time.fixedDeltaTime),  Mathf.Clamp(rb.velocity.y, -rb.mass / Time.fixedDeltaTime, 0f), Mathf.Clamp(rb.velocity.z, -rb.mass / Time.fixedDeltaTime, rb.mass / Time.fixedDeltaTime));
        
        Maxtime += Time.deltaTime;
        
        if ( Maxtime > 5f)
        {
            Anim.SetFloat("Duration", Maxtime);
        }
        if (Maxtime > 10f)
        {
            Anim.SetFloat("Duration", 0f);
            Maxtime = 0f;
        }
        UpdateAnimation();
    }
    void FixedUpdate()
    {
        Move();  
    }

    

    void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horixontal = Input.GetAxis("Horizontal");

        Vector2 input = new Vector2(horixontal, vertical);

        Quaternion Rot_Temp = cam.transform.rotation;
        Rot_Temp.x = 0f;
        Rot_Temp.z = 0f;

        /*Vector3 Pos_Temp = cam.forward.normalized * input.y + cam.right.normalized * input.x;
        Pos_Temp.y = 0f;

        this.transform.position += (Pos_Temp) * Time.deltaTime * speed;
        Debug.Log(Pos_Temp);

        this.transform.rotation = Rot_Temp;*/
       
        if (Input.GetKey(KeyCode.W) )
        {

            Vector3 Pos_Temp = cam.forward.normalized * input.y + cam.right.normalized * input.x;
            Pos_Temp.y = 0f; ;

            //rb.AddForce((Pos_Temp) * Time.deltaTime * speed, ForceMode.VelocityChange);
            this.transform.position += (Pos_Temp) * Time.deltaTime * speed;
            //Debug.Log(Pos_Temp);

            this.transform.rotation = Rot_Temp;
        }
         if (Input.GetKey(KeyCode.S) && transform.rotation.y != 0f)
        {
            Vector3 Pos_Temp = cam.forward.normalized * input.y + cam.right.normalized * input.x;
            Pos_Temp.y = 0f;

            //rb.AddForce((Pos_Temp) * Time.deltaTime * speed, ForceMode.VelocityChange);
            this.transform.position += (Pos_Temp) * Time.deltaTime * speed;
            //Debug.Log(Pos_Temp);

            this.transform.rotation = Rot_Temp * Quaternion.Euler(0f, 180f, 0f);

        }
         if (Input.GetKey(KeyCode.D))
        {
            Vector3 Pos_Temp = cam.forward.normalized * input.y + cam.right.normalized * input.x;
            Pos_Temp.y = 0f;

            //rb.AddForce((Pos_Temp) * Time.deltaTime * speed, ForceMode.VelocityChange);
            this.transform.position += (Pos_Temp) * Time.deltaTime * speed;
            //Debug.Log(Pos_Temp);

            this.transform.rotation = Rot_Temp * Quaternion.Euler(0f, 90f, 0f);


        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 Pos_Temp = cam.forward.normalized * input.y + cam.right.normalized * input.x;
            Pos_Temp.y = 0f;

            //rb.AddForce((Pos_Temp) * Time.deltaTime * speed, ForceMode.VelocityChange);
            this.transform.position += (Pos_Temp) * Time.deltaTime * speed;
            //Debug.Log(Pos_Temp);

            this.transform.rotation = Rot_Temp * Quaternion.Euler(0f, -90f, 0f);

        }
               
        
    }

    void UpdateAnimation()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) && climb == false) 
        {

            Anim.SetInteger("Run", 1);
        }
        else
        {
            Anim.SetInteger("Run", 0);
        }

        if (climb == true)
        {
            Anim.SetBool("Climb", climb);
        }
        else
        {
            Anim.SetBool("Climb",climb);
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            Anim.SetBool("Jump", true);
        }
        else
        {
            Anim.SetBool("Jump", false);
        }

        if (Input.GetMouseButton(1))
        {
            Anim.SetBool("Swing", true);
        }
        else
        {
            Anim.SetBool("Swing", false);
        }


        if (Input.GetMouseButton(0))
        {
            Anim.SetBool("Punch", true);
        }
        else
        {
            Anim.SetBool("Punch", false);
        }
    }
}

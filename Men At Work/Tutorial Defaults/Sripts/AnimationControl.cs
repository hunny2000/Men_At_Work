using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator Anim;
    //public Rigidbody rb;
    public float speed;
    [SerializeField] private Transform cam;
    

    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horixontal = Input.GetAxis("Horizontal");

        Vector2 input = new Vector2(horixontal, vertical);

        /*Vector3 moveHorizontal = transform.right * horixontal;
        Vector3 moveVertical = transform.forward * vertical;

        Vector3 movement = (moveVertical + moveHorizontal).normalized * speed;

        rb.MovePosition(rb.position + movement * Time.deltaTime);*/
        //Debug.Log(cam.transform.rotation.y);
        //rb.transform.rotation = Quaternion.Euler(0f, cam.transform.rotation.y, 0f);
        
        Quaternion Rot_Temp = cam.transform.rotation;
        Rot_Temp.x = 0f;
        Rot_Temp.z = 0f;
        this.transform.rotation = Rot_Temp;


        if (Input.GetKey(KeyCode.W))
        {
            //forward
            //rb.transform.position += Vector3.forward * speed;
            ///rb.AddForce(Vector3.forward, ForceMode.Force);
            ///rb.MoveRotation(Quaternion.Euler(new Vector3(0f, 0f, 0f)));
            /*if (transform.position.y == 90f|| transform.position.y == -90f)
            {
                rb.transform.rotation = cam.rotation;
            }*/
            Vector3 Pos_Temp = cam.forward.normalized * input.y + cam.right.normalized * input.x;
            Pos_Temp.y = 0f;

            this.transform.position += (Pos_Temp) * Time.deltaTime * speed;
        }
        /*if (Input.GetKey(KeyCode.S) && transform.rotation.y != 0f)
        {
            //backwared
            //rb.transform.position += Vector3.back * speed;
            ///rb.AddForce(Vector3.back, ForceMode.Force);
            ///rb.MoveRotation(Quaternion.Euler(new Vector3(0f, 360f, 0f)));

            this.transform.position += (cam.forward.normalized * input.y + cam.right.normalized * input.x) * Time.deltaTime * speed;
        }*/
        if (Input.GetKey(KeyCode.D) )
        {
            //right
            this.transform.position += Vector3.right.normalized * speed * Time.deltaTime;
            //rb.transform.position += Vector3.right * speed;
            this.transform.rotation = Quaternion.Euler(0f, cam.rotation.y + (90f), 0f);
            //cam.rotation = Quaternion.Euler(0f, cam.rotation.y + (90f), 0f);

            //this.transform.position += (cam.forward.normalized * input.y + cam.right.normalized * input.x) * Time.deltaTime * speed;
            //this.transform.LookAt(this.transform.position + Vector3.one);

        }
        if (Input.GetKey(KeyCode.A))
        {
            //left
            this.transform.position += Vector3.left.normalized * speed *Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0f, cam.rotation.y + (-90f), 0f);
            //cam.rotation = Quaternion.Euler(0f, cam.rotation.y + (-90f), 0f);
            //this.transform.position += (cam.forward.normalized * input.y + cam.right.normalized * input.x) * Time.deltaTime * speed;
            //this.transform.LookAt(this.transform.position + Vector3.one);
        }

        
    }
    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A)) 
        {
            
            Anim.SetInteger("Run", 1);
        }
        else
        {
            Anim.SetInteger("Run", 0);
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

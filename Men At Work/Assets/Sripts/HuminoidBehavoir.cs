using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuminoidBehavoir : MonoBehaviour
{
    public Transform Player;
    float speed = 100f;
    // float rotSpeed = 5f;
    public Vector3 direction;
    public Rigidbody rb;
    public GameObject RagHuman;
    bool condition = true;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();

        direction = Player.position - this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            while (condition)
            {
                Instantiate(RagHuman, this.transform.position, this.transform.rotation);
                condition = false;
            }       
            Destroy(this.gameObject);
        }
    }
    private void LateUpdate()
    {
        Vector3 Lookat = new Vector3(Player.position.x, 0, Player.position.z);
        //Vector3 Lookat = new Vector3(Player.position.x, this.transform.position.y, Player.position.z);

        this.transform.LookAt(Lookat);

        direction = Lookat - this.transform.position;

        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

        Debug.DrawRay(this.transform.position, direction, Color.red);

        //Debug.Log(Vector3.Distance(this.transform.position, Lookat));

        if (Vector3.Distance(this.transform.position, Lookat) < 100f)
        {
            rb.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode.VelocityChange);

            //this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            //Debug.Log(direction.normalized * speed * Time.deltaTime);

            //cc.Move(direction.normalized * speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}

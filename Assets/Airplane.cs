using System;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] float enginePower = 20f;
    [SerializeField] float liftBooster = 0.5f;
    [SerializeField] float drag = 0.001f;
    [SerializeField]  float angularDrag = 0.001f;
    [SerializeField]  float yawPower = 50f;
    [SerializeField]  float pitchPower = 50f;
    [SerializeField]  float rollPower = 30f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

     void FixedUpdate()
    {
        //add Thrust (Engine Power)
        //Pressing Spacebar applies force in the forward d
        // Simulates engine thrust, making the airplane acc
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePower);
        }
         //2. Lift force - Simulates how airplanes gain altitude
         Vector3 lift = Vector3.Project(vector: rb.linearVelocity, onNormal: transform.forward);
         rb.AddForce(transform.up * lift.magnitude * liftBooster);
         
         // 3. Drag (Air Resitance) - Prevent infinite acceleration
         rb.linearDamping = rb.linearVelocity.magnitude * drag;
         rb.angularDamping = rb.linearVelocity.magnitude * angularDrag;
         
         //4.Rotation Controls - Pitch, Yaw, and Roll
         float yaw = Input.GetAxis("Horizontal") * yawPower; // left/Right (A/D)
         float pitch = Input.GetAxis("Vertical") * pitchPower; // Nose Up/Down (w/s)
         float roll = Input.GetAxis("Roll") * rollPower; // Roll(Q/E)
         
         rb.AddTorque(transform.up * yaw); // Yaw (Turn left/right
         rb.AddTorque(transform.right * pitch); // Pitch (Nose Up/down)
         rb.AddTorque(transform.forward * roll); // Roll (Tilting)

    }
    }

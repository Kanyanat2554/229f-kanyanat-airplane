using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float enginePower = 20f;
    [SerializeField] float liftBooster = 0.5f;
    [SerializeField] float drag = 0.001f;
    [SerializeField] float angularDrag = 0.001f;
    [SerializeField] float yawPower = 50f;
    [SerializeField] float pitchPower = 50f;
    [SerializeField] float rollPower = 30f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Add thrust make airplane move forward
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePower);
        }

        //Add lift force make airplane lift
        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        //Add Drag prevents infinite acceleration
        rb.linearDamping = rb.linearVelocity.magnitude * drag;
        rb.angularDamping = rb.linearVelocity.magnitude * angularDrag;

        //Rotation Controls - Pitch, Yaw, Roll
        float yaw = Input.GetAxis("Horizontal") * yawPower; //Left/Right Q,E
        float pitch = Input.GetAxis("Vertical") * pitchPower; //Nose Up/Down W,S
        float roll = Input.GetAxis("Roll") * rollPower; //Roll A,D

        rb.AddTorque(transform.up * yaw); //Yaw left/right
        rb.AddTorque(transform.right * pitch); // Pitch Nose up/down
        rb.AddTorque(transform.forward * roll); // Roll Tilting
    }
}

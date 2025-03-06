using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float enginePower = 20f;
    [SerializeField] float liftBooster = 0.5f;
    [SerializeField] float drag = 0.001f;
    [SerializeField] float angularDrag = 0.001f;

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
    }
}

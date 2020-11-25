using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xmin, xmax, zmin, zmax;
}

public class PlayerControler : MonoBehaviour {

    private Rigidbody rb;
    public int speed;
    public Boundary boundary;
    public float tilt;
    public GameObject shot;
    public Transform shotSpwan;
    public float fireRate;

    private float nextFire=0.0f;
    private AudioSource ad;

	void Start () {
        rb = GetComponent<Rigidbody>();
        ad = GetComponent<AudioSource>();
        if (SystemInfo.deviceType != DeviceType.Desktop)
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
	}

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpwan.position, shotSpwan.rotation);
            ad.Play();
        }
    }

	void FixedUpdate () {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector3 move = new Vector3(x, 0.0f, y);
            rb.velocity = move * speed;
        }
        else
        {
            Vector3 move = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);
            rb.velocity = move * speed;
        }
        rb.position = new Vector3(
        Mathf.Clamp(rb.position.x, boundary.xmin, boundary.xmax),
        0.0f,
        Mathf.Clamp(rb.position.z, boundary.zmin, boundary.zmax)
        );
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * (-tilt));
	}
}

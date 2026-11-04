using UnityEngine;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{
    private GameManager gm;
    private Rigidbody rb;
    public ParticleSystem boom;
    [Header("Movement values")]
    public float speedMax=7f;
    public float speedMin=5f;
    public float torqueMax=25f;
    public float torqueMin=5f;
    float leftBorder = -5f;
    float rightBorder = 5f;
    float bottomPos=0f;
    [Header("Target points value")]
    public int pointValue;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindAnyObjectByType<GameManager>();

    }
    void Start()
    {
        transform.position = RandomPos();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), ForceMode.Impulse);
    }

    private Vector3 RandomTorque()
    {
        return Vector3.up * Random.Range(-0.5f, 0.5f) * Random.Range(torqueMin, torqueMax);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(speedMin, speedMax);
    }

    private Vector3 RandomPos()
    {
        return new Vector3(Random.Range(leftBorder, rightBorder), bottomPos, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 pos= Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(pos);
            Debug.DrawRay(ray.origin,ray.direction*100f,Color.red,2f);
            if(Physics.Raycast(ray,out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    Instantiate(boom,transform.position,transform.rotation);
                    gm.updateScore(pointValue);

                    Destroy(gameObject);

                }
            }
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
   
    public new Rigidbody2D rigidbody { get; private set; }

    public Bullet bulletPrefab;
    public float thrustSpeed = 2f;
    public bool thrusting { get; private set; }
    public float turnDirection { get; private set; } = 0f;
    public float rotationSpeed = 0.1f;
    public float respawnDelay = 3f;
    public float respawnInvulnerability = 3f;
    public ParticleSystem ps;
    


    private void Awake()
    {
        ps.Stop();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // Turn off collisions for a few seconds after spawning to ensure the
        // player has enough time to safely move away from asteroids
        gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        Invoke(nameof(TurnOnCollisions), respawnInvulnerability);
    }

    private void Update()
    {
        

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            TurnLeft();

        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        {
            TurnRight();

        } else 
        {
            StopTurning();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        Thrusting();

        if (thrusting){
            MoveForward();
            ps.Play();
        }

        if (turnDirection != 0f){
            rigidbody.AddTorque(rotationSpeed * turnDirection);
        }
    }

    
    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Project(transform.up);
    }

    private void TurnOnCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = 0f;
            gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDeath(this);
        }
    }
    public void TurnLeft()
    {
        turnDirection = 1f;
    }
    public void TurnRight()
    {
        turnDirection = -1f;
    }
    public void StopTurning()
    {
        turnDirection = 0f;
        ps.Stop();
    }
    public void MoveForward()
    {
        rigidbody.AddForce(transform.up * thrustSpeed);
    }
    public void Thrusting()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
    }
    
    
}

using UnityEngine;

public class Ball : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }

    public float speed = 10f;

    [Header("Som")]
    public AudioClip bounceClip;
    private AudioSource audioSource;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        this.rigidbody.linearVelocity = Vector2.zero;
        this.transform.position = Vector3.zero;

        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.rigidbody.AddForce(force.normalized * this.speed);

    }
    private void FixedUpdate()
    {
        if (rigidbody.linearVelocity.magnitude != 0)
        {
            rigidbody.linearVelocity = rigidbody.linearVelocity.normalized * speed * Time.fixedDeltaTime;
        }
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bounceClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(bounceClip);
        }
    }
}


using UnityEngine;

public class BallSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colidiu com: " + collision.gameObject.name);
        audioSource.Play();
    }

}

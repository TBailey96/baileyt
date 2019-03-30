using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{

    public Rigidbody2D rb;
    public AudioSource hop;
    public AudioSource squash;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Hop();
            rb.MovePosition(rb.position + Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Hop();
            rb.MovePosition(rb.position + Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Hop();
            rb.MovePosition(rb.position + Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Hop();
            rb.MovePosition(rb.position + Vector2.down);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Car")
        {
            Squash();
            Debug.Log("WE LOST!");
            HealthController.health -= 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void Hop()
    {
        hop.Play();
    }
    private void Squash()
    {
        squash.Play();
    }
}
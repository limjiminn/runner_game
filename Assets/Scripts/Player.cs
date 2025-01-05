using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;

    [Header("References")]
    public Rigidbody2D PlayerRigidBody;

    public Animator PlayAnimator;

    public BoxCollider2D PlayerCollider;

    public GameObject fever;

    private bool isGrounded = true;

    public bool isInbvincible = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            PlayAnimator.SetInteger("state", 1);
        }
    }
    public void KillPlayer()
    {
        PlayerCollider.enabled = false;
        PlayAnimator.enabled = false;
        PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
    }

    void Hit()
    {
        GameManager.Instance.Lives -= 1;
        
    }

    void Heal()
    {
        GameManager.Instance.Lives = Mathf.Min(3, GameManager.Instance.Lives += 1) ;
    }
    void StartInvincible()
    {
        isInbvincible = true;
        fever.SetActive(true);
        PlayAnimator.SetInteger("state", 3);
        Invoke("StopInvincible", 5f);
    }

    void StopInvincible()
    {
        PlayAnimator.SetInteger("state", 4);
        fever.SetActive(false);
        isInbvincible = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            if (!isGrounded)
            {
                PlayAnimator.SetInteger("state", 2);
            }
            isGrounded = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (!isInbvincible)
            {
            Destroy(collision.gameObject);
            Hit();
            }
           
        }
        else if (collision.gameObject.tag == "food")
        {
            Destroy(collision.gameObject);
            Heal();
        }
        else if (collision.gameObject.tag == "golden")
        {
            Destroy(collision.gameObject);
            StartInvincible();
        }
    }
}

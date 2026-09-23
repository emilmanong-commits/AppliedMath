using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeReference] private float moveSpeed = 5.0f;

    [Header("Attack Settings")]
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float nextAttackTime = 0.0f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ActionInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void ActionInputs()
    {
        //(WASD / Arrow Keys / Left Stick)
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Attack Input (Left Mouse Button or Spacebar)
        if (Input.GetButtonDown("Fire1") && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void Move()
    {
        rb.MovePosition(rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);

        if (moveInput.sqrMagnitude > 0)
        {
            Debug.Log("Walk");
        }
    }

    private void Attack()
    {
        Debug.Log("Player triggered an attack!");

        Debug.Log("[Asset Pending] Play Attack Animation, instantiate slash VFX particle, and play swing SFX.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Point"))
        {
            GameManager.Instance.AddCoin(1);

            Destroy(collision.gameObject);
        }
    }
}


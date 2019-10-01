using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;   
    public int attackDamage = 10;   

    Animator anim;                        
    GameObject player;
    public int currentHealth;
    public int startHealth = 40;
    private bool hold = true;
    private bool isDie = true;
    PlayerHealth playerHealth;                 
    bool playerInRange;                 
    float timer;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        currentHealth = startHealth;
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (playerInRange && currentHealth > 0)
        {
            if (GameControl.instance.isAtt() > 82)
            {
                if(timer >= timeBetweenAttacks)
                {
                    anim.SetTrigger("Attack");
                    Attack();
                }
                hold = true;
            }
            else
            {
                if (hold)
                {
                    anim.SetTrigger("TakeDamage");
                    hold = false;
                    currentHealth -= playerHealth.attack();
                }
            }
        }
        else if (currentHealth <= 0)
        {
            if (isDie)
            {
                isDie = false;
                anim.SetTrigger("Die");
            }
            if ((player.transform.position.x - transform.position.x > 30))
                Destroy(gameObject);
        }
        else
            hold = true;
    }

    void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
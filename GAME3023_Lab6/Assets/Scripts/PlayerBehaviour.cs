using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 3.0f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Image healthBar;

    [SerializeField] static float playerHealth;
    const int maxHealth = 100;
    const int minHealth = 0;

    Vector2 movement;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerHealth / 100f;
        playerHealth = Mathf.Clamp(playerHealth, minHealth, maxHealth);


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if (playerHealth < 1)
        {
            Debug.Log("Player Dies!");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0;
            Destroy(collision);
            SceneManager.LoadScene("EncounterScene", LoadSceneMode.Additive);
        }
    }

    static public void DamagePlayer(float damage)
    {
        playerHealth -= damage;
    }

    static public void HealPlayer(float healing)
    {
        playerHealth += healing;
    }
}
    

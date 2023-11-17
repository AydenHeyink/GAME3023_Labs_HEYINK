using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Item
{
    private string name;
    private int damage;
    private int stamina;

    public Item(string name, int damage, int stamina)
    {
        this.name = name;
        this.damage = damage;
        this.stamina = stamina;
    }

    public string GetName()
    {
        return name;
    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetStamina()
    {
        return stamina;
    }
}

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 3.0f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Image healthBar;

    static public AsyncOperation EncounterScene;
    static public AsyncOperation GameScene;

    Vector2 movement;
    public Animator anim;

    static private bool isSceneEnc;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.health = PlayerStats.maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    static public bool GetEncBool()
    {
        return isSceneEnc;
    }



    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = PlayerStats.health / 100f;
        PlayerStats.health = Mathf.Clamp(PlayerStats.health, PlayerStats.minHealth, PlayerStats.maxHealth);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
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
            //Enemy.SetType(1);
            EncounterScene = SceneManager.LoadSceneAsync("EncounterScene", LoadSceneMode.Additive);
            EncounterScene.allowSceneActivation = true;
        }

    }

    static public void AddNew(string name, int dam, int stam)
    {
        PlayerStats.items.Add(new Item(name, dam, stam));
    }
}
    

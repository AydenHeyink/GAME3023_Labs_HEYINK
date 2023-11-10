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

    [SerializeField] static float playerHealth;
    const int maxHealth = 100;
    const int minHealth = 0;

    static Item sword = new Item("Sword", 40, 50);
    static Item dagger = new Item("Dagger", 20, 10);
    static Item fists = new Item("Fists", 10, 5);
    static Item throwingKnives = new Item("Throwing Knives", 5, 10);

    static List<Item> items = new List<Item>() 
        { sword, dagger, fists, throwingKnives};

    Vector2 movement;
    public Animator anim;
    [SerializeField] Canvas buttonCanvas;
    [SerializeField] GameObject butPref;

    static private bool isSceneEnc;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    static public bool GetEncBool()
    {
        return isSceneEnc;
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
        if (Input.GetKeyDown(KeyCode.T))
        {
            EncounterManager.EndEncounter();
            UnloadButtons();
        }   
    }

    public void LoadButtons()
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject button = Instantiate(butPref) as GameObject;

            button.transform.SetParent(GetCanvas().transform, false);
            button.gameObject.GetComponentInChildren<Text>().text = items[i].GetName();
            button.gameObject.transform.position = new Vector3(250, 80 * i, 0);

            Item item = items[i];
            button.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(item));

            gameObject.SetActive(true);
        }
    }

    public void OnButtonClick(Item i)
    {
        string tempName = i.GetName();
        int tempDam = i.GetDamage();
        int tempStam = i.GetStamina();

        Debug.Log(tempName);
        Debug.Log(tempDam);
        Debug.Log(tempStam);
    }

    public void UnloadButtons()
    {
        foreach (GameObject button in GameObject.FindGameObjectsWithTag("buttonClone"))
        {
            Destroy(button);
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
            //Enemy.SetType(1);
            LoadButtons();
            SceneManager.LoadScene("EncounterScene", LoadSceneMode.Additive);
        }

    }

    static public void AddNew(string name, int dam, int stam)
    {
        items.Add(new Item(name, dam, stam));
    }

    public Canvas GetCanvas()
    {
        return buttonCanvas;
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
    

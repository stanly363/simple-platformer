using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    // Variables
    public float Speed;
    public float jumpPower;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    private Rigidbody2D Player;
    public Transform GroundCheck;
    public float GroundCheckDistance;
    public LayerMask Ground;
    public bool isGrounded;
    public bool isNearCrate;
    public float DistanceToCrate;
    public LayerMask Crate;
    public KeyCode Interact;
    public GameObject Pistol;
    public GameObject Rocket;
    public GameObject MiniGun;
    public GameObject Sniper;
    private GameObject crateGun;
    

    void Start()
    {
        Player = GetComponent<Rigidbody2D>();// Sets the player object equal to the player variable
        
    }
    void Update()
    {
        // Checks if the player is on the ground by drawing an invisible circle collider around the player
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckDistance, Ground); 
        // Checks if the player is near a crate by drawing an invisible circle collider around the player
        isNearCrate = Physics2D.OverlapCircle(GroundCheck.position, DistanceToCrate, Crate);
        // Checks the input of the player
        if (Input.GetKey(left))
        {
            Player.velocity = new Vector2(-Speed, Player.velocity.y); // Moves player left
            Player.transform.localScale = new Vector2(-1, 1);// Rotates player image to face left
            GetComponent<Animator>().SetBool("Walk", true);
        } else if (Input.GetKey(right)) 
        {
            Player.velocity = new Vector2(Speed, Player.velocity.y); // Moves player right
            Player.transform.localScale = new Vector2(1, 1); // Rotates player image to face right
            GetComponent<Animator>().SetBool("Walk", true);
        } else 
        { Player.velocity = new Vector2(0, Player.velocity.y); // Stops the player if no input is detected
          GetComponent<Animator>().SetBool("Walk", false);
        }
        GameObject[] Weapons = new GameObject[3];
        Weapons[0] = Rocket;
        Weapons[1] = MiniGun;
        Weapons[2] = Sniper;
        crateGun = Weapons[Random.Range(0, 3)];
        if (Input.GetKey(jump) && isGrounded)
        {
            Player.velocity = new Vector2(Player.velocity.x, jumpPower); // Player jumps up
        }
        if (Input.GetKey(Interact) && isNearCrate)
        {   
            
            FindObjectOfType<Crateremover>().removeCrate();                          
            Pistol.gameObject.SetActive(false);
            crateGun.gameObject.SetActive(true);
            StartCoroutine(RocketTimer());
             
            IEnumerator RocketTimer()
            {
                yield return new WaitForSeconds(8);
                Rocket.gameObject.SetActive(false);
                Sniper.gameObject.SetActive(false);
                MiniGun.gameObject.SetActive(false);
                Pistol.gameObject.SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public GameObject player; // variable for storing player
    public Vector3 playerPos; //variable for storing player position
    Rigidbody rb; // variable for storing RigidBody
    public Vector3 playerDirection; // variable for storing the player's distance from the zombie
    public Vector3 zombieMoveDirection; //variable for storing the direction zombie moves in
    public float zombieMoveSpeed; // variable for storing desired zombie move speed
    public Vector3 playerDistance; // variable for storing the zombie's distance from the player;
    public bool zombieAlive = true;
    public float zombieHealth = 80f;
    private float zombieDamage = 0.05f;
    public GameObject zombieHealthBar;
    public float zombieHealthBarScale;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // assigns Rigidbody to our variable
        player = GameObject.Find("Player");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        playerPos = player.transform.position; // gets position of player
        playerDirection = (playerPos - transform.position).normalized; // gets the player is in relation to zombie
        // new Vector3: sets a float to Vector3 (rigidBody.velocity requires Vector3 to work)
        zombieMoveDirection = new Vector3(playerDirection.x, 0f, playerDirection.z); // gets the desired direction we want the zombie to move, y is zero here because we don't want the zombie flying up or down
        playerDistance = playerPos - transform.position; //subtracts zombie position from player position to get the total distance
        
        

        if(zombieAlive)
        {
            moveZombie();
            zombieHealthBarScale = (0.046f * (zombieHealth / 80f));
            zombieHealthBar.transform.localScale = new Vector3(zombieHealthBarScale, 0.0001f, 0.006000001f);
            attackPlayer();
        }
        else
        {
            zombieHealthBar.SetActive(false);
        }
    }
    private void moveZombie() // function for moving zombie
    {
        
        // Vector3.magnitude: returns full length of the vector(x*x+y*y+z*z)
        if(playerDistance.magnitude > 1 && zombieAlive) // checks if player is more than 1 meter away
        {
            transform.rotation = Quaternion.LookRotation(zombieMoveDirection);
            // rigidBody.velocity: The velocity vector of the rigidbody; It represents the rate of change of Rigidbody position
            rb.velocity = (zombieMoveDirection * zombieMoveSpeed); // makes zombie move towards player at desired speed
            
        }
        
        
    }

    public void attackPlayer()
    {
        if(playerDistance.magnitude < 2.5f)
        {
            playerScript playerPerson = player.transform.GetComponent<playerScript>();
            playerPerson.takeDamage(zombieDamage);
        }
    }

    
    public void zombieTakeDamage (float amount)
    {
        zombieHealth -= amount;
        if(zombieHealth <= 0f)
        {
            zombieAlive = false;
            transform.Rotate (-90f, 0f, 0f);
            Invoke("Destroyer", 10);
        }
    }

    void Destroyer()
    {
        Destroy(gameObject);

    }
}

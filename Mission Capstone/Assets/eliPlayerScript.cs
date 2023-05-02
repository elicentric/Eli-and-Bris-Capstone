using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject deadText;
    public GameObject playerBody;
    public GameObject healthBar;
    public float healthBarScale;
    public float health = 100f;
    public bool alive = true;
    Collider playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        health = 100f;
        alive = true;
        playerCollider = GetComponentInChildren<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)
        {
            healthBarScale = (1.586509f * (health / 100f));
            healthBar.transform.localScale = new Vector3(healthBarScale, 1f, 1f);
        }
        else
        {
            healthBar.SetActive(false);
        }
        
        if(alive == false && transform.rotation.eulerAngles.y < 90f)
        {
            playerCollider.enabled = false; 
            playerBody.transform.Rotate(10f * Time.deltaTime, 0f , 0f);
            
        }

    }

    public void takeDamage(float amount)
    {
        health -= amount;
        if(health < 1f)
        {
            alive = false;
            playerDeath();
            
        }
    }
    void playerDeath()
    {
        crosshair.SetActive(false);
        deadText.SetActive(true);
    }
}

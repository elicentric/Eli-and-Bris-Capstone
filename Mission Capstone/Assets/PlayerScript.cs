using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerScript : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject frontTextObject;
    public TextMeshProUGUI frontText;
    public GameObject playerBody;
    public GameObject healthBar;
    public float healthBarScale;
    public float health = 100f;
    public bool alive = true;
    public Quaternion target;
    CharacterController cc;
    public GameObject deathScreen;
    public TextMeshProUGUI scoreText;
    public GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Invoke("noText", 5.0f);
        health = 100f;
        alive = true;
        cc = GetComponent<CharacterController>();
        
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
        
        if(alive == false)
        {
            Quaternion target = Quaternion.Euler(-90f, 0, transform.rotation.eulerAngles.z);
            cc.enabled = false; 
            Physics.IgnoreLayerCollision(0,6, true);
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }

    }

    public void takeDamage(float amount)
    {
        health -= amount;
        if(health < 0f)
        {
            alive = false;
            playerDeath();
            
        }
    }
    void playerDeath()
    {
        crosshair.SetActive(false);
        deathScreen.SetActive(true);
        gun.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    void noText()
    {
        frontText.text = " ";
    }
}

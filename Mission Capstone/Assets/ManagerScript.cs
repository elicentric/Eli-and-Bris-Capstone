using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerScript : MonoBehaviour
{
    public GameObject player;
    public new Camera camera;
    public GameObject zombiePrefab;
    private Vector3 zombiePos;
    public Vector2 zombieRange;
    public Vector2 zombieNoGo;
    private float side;
    public int waveNumber;
    public Text waveText;
    public GameObject waveTextObject;
    public GameObject cameraControl;

    CameraController cameraScript;
    playerScript pScript;
    

    
    // Start is called before the first frame update
    void Start()
    {
        CameraController cameraScript = player.transform.GetComponentInChildren<CameraController>();
        playerScript pScript = player.transform.GetComponent<playerScript>();
        waveCall();
    }
    //poo

    void waveCall()
    {
        waveTextObject.SetActive(true);
        for(int i = 0; i < waveNumber;)
        {
            Instantiate(zombiePrefab, randomPos(), Quaternion.identity);
            i++;
        }
        waveText.text = "Wave " + (waveNumber - 2);
        Invoke("noText", 5.0f);
        waveNumber++;
        
    }

    // Update is called once per frame
    void Update()
    {
        playerScript pScript = player.transform.GetComponent<playerScript>();
        if(GameObject.Find("Zombie(Clone)") == null)
        {
            waveCall();
        }

        if(pScript.alive == false)
        {
            cameraControl.SetActive(false);
        }
    }

    void noText()
    {
        waveTextObject.SetActive(false);
    }
    Vector3 randomPos()
    {
        
        float rX = Random.Range(zombieRange.x, zombieNoGo.x);
        float rZ  = Random.Range(zombieRange.y, zombieNoGo.y);
        side = Random.Range(-1, 1);
        if(side >= 0)
        {
            rX = -rX;
            rZ = -rZ;
        }
        Debug.Log(new Vector3(rX, 0, rZ));
        return new Vector3(rX, 0, rZ);


    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(player.transform.position, new Vector3(-zombieRange.x, 0.5f, zombieRange.y));
        Gizmos.color = Color.red;
        Gizmos.DrawCube(player.transform.position, new Vector3(-zombieNoGo.x, 0.5f, zombieNoGo.y));
}
    
}

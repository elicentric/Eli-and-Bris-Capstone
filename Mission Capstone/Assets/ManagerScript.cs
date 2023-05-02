using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject zombiePrefab;
    private Vector3 zombiePos;
    public Vector2 zombieRange;
    public Vector2 zombieNoGo;
    private float side;
    public int waveNumber;
    public Text waveText;
    public GameObject waveTextObject;
    // Start is called before the first frame update
    void Start()
    {
       
        waveCall();
    }

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
        if(GameObject.Find("Zombie(Clone)") == null)
        {
            waveCall();
        }
    }

    void noText()
    {
        waveTextObject.SetActive(false);
    }
    Vector3 randomPos()
    {
        
        float rX = Random.Range(zombieNoGo.x, zombieRange.x);
        float rZ  = Random.Range(zombieNoGo.y, zombieRange.y);
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

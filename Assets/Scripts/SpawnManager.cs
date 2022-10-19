using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fence;
    private float targetTime;
    private Vector3 fencePosition = new Vector3(25, 0 ,2);
    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        targetTime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime < 0) {
            SpawnFence();
            targetTime = Random.Range(2, 5);
        }
    }
    void SpawnFence() {
        if (playerControllerScript.gameOver == false) {
            Instantiate(fence, fencePosition, fence.transform.rotation);    
        }
    }
}

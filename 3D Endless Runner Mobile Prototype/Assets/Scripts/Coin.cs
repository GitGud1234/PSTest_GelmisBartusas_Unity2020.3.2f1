using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0,0,80 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && Hearts.health == 3)
        {
            PlayerManager.numCoin +=2;
            Destroy(gameObject);
        } else {
            PlayerManager.numCoin +=1;
            PlayerManager.gainHP += 1;
            Destroy(gameObject);

            if (PlayerManager.gainHP % 50 == 0) 
            {
                Hearts.health +=1;
            }
        }
    }  
}

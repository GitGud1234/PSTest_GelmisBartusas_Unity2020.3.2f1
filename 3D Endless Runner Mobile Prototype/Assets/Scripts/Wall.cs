using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
        private void OnTriggerEnter(Collider other) 
    {
        
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Hearts.health -=1;
            PlayerManager.numCoin -=10;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : MonoBehaviour
{
    private OxygenSpawner spawner;

    public void SetSpawner(OxygenSpawner spawner)
    {
        this.spawner = spawner;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spawner.OnOxygenTankCollected();

            Destroy(gameObject);
        }
    }
}

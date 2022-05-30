using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    [SerializeField] List<Spawner> spawners = new List<Spawner>();

    private void OnTriggerEnter2D(Collider2D other) {
      if (other.gameObject.tag == "Player") {
        ActivateSpawners();
        Destroy(gameObject, 2f);
      }
    }

    void ActivateSpawners() {
      for(int i = 0; i < spawners.Count; i++) {
        spawners[i].Activate();
      }
    }
}

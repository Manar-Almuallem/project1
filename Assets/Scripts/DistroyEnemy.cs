using UnityEngine;

public class DestroyEnemyOnEnter : MonoBehaviour
{
    private GameObject enemyInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInRange = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") && other.gameObject == enemyInRange)
        {
            enemyInRange = null;
        }
    }

    private void Update()
    {
        if (enemyInRange != null && Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(enemyInRange);
            enemyInRange = null;
        }
    }
}

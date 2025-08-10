using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyWatcher : MonoBehaviour
{
    [SerializeField] string nextSceneName = "NextScene"; // Set your scene name in the Inspector

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            
            SceneManager.LoadScene(nextSceneName);
        }
    }
}

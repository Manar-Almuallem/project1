using System.Collections;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    private GameObject[] rmObjects;
    private GameObject[] smObjects;

    void Start()
    {
        // Find and deactivate RM objects
        rmObjects = GameObject.FindGameObjectsWithTag("RM");
        foreach (GameObject obj in rmObjects)
        {
            obj.SetActive(false);
        }

        // Start the coroutine
        StartCoroutine(HideObjectsAfterDelay());
    }

    IEnumerator HideObjectsAfterDelay()
    {
        // Wait 4 seconds
        yield return new WaitForSeconds(2f);

        // Find and deactivate SM objects
        smObjects = GameObject.FindGameObjectsWithTag("SM");
        foreach (GameObject obj in smObjects)
        {
            obj.SetActive(false);
        }

        // Wait another 4 seconds
        yield return new WaitForSeconds(2f);

        // Reactivate RM objects
        foreach (GameObject obj in rmObjects)
        {
            obj.SetActive(true);
        }

        // Wait another 4 seconds
        yield return new WaitForSeconds(3f);

        // Deactivate SM objects again
        foreach (GameObject obj in rmObjects)
        {
            obj.SetActive(false);
        }
    }
}

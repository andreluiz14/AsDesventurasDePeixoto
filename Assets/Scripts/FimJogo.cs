using UnityEngine;
using UnityEngine.SceneManagement;

public class FimJogo : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("final");
        }
    }
}

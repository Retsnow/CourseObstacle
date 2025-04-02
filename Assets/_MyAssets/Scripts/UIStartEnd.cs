using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartEnd : MonoBehaviour
{
    public void DebutJeu()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(noScene + 1);
    }
}

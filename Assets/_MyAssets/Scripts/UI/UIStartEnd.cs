using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartEnd : MonoBehaviour
{
    [SerializeField] GameObject _panelPrincipal = default;
    [SerializeField] GameObject _panelInstruction = default;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            Destroy(gameManager);
        }
    }

    public void DebutJeu()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(noScene + 1);
    }

    public void Quitter()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying= false;
#else
        Application.Quit();
#endif
    }

    public void ToggleInstructions()
    {
        bool toggle = _panelPrincipal.activeSelf;

        _panelPrincipal.SetActive(!toggle);
        _panelInstruction.SetActive(toggle);
    }
}

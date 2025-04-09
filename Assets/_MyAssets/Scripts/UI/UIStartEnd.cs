using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class UIStartEnd : UI
{
    [Header("Scène Début")]
    [SerializeField] GameObject _panelPrincipal = default;
    [SerializeField] GameObject _panelInstruction = default;
    [SerializeField] GameObject _boutonDemarrer = default;
    [SerializeField] GameObject _boutonRetourInstructions = default;


    [Header("Scène Fin")]
    [SerializeField] TMP_Text _txtTemps = default(TMP_Text);
    [SerializeField] TMP_Text _txtCollisions = default(TMP_Text);
    [SerializeField] TMP_Text _txtPointage = default(TMP_Text);

    private bool _instructionsON;

    private void Start()
    {
        

        if (GameManager.Instance != null && SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            AffichageResultat();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_boutonDemarrer);
        }
        DestructionGameManager();
    }

    private static void DestructionGameManager()
    {
        if (GameManager.Instance != null && SceneManager.GetActiveScene().buildIndex == 0)
        {
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            Destroy(gameManager);
        }
    }

    private void AffichageResultat()
    {
        _txtTemps.text = "Temps: " + (GameManager.Instance.TempFinal - GameManager.Instance.TempsDepart).ToString("f2") + " sec.";
        _txtCollisions.text = "Collisions: " + GameManager.Instance.Score;
        float total = (GameManager.Instance.TempFinal - GameManager.Instance.TempsDepart) + GameManager.Instance.Score;
        _txtPointage.text = "Pointage final: " + total.ToString("f2") + " sec.";
    }

    public void ToggleInstructions()
    {
        bool toggle = _panelPrincipal.activeSelf;

        _panelPrincipal.SetActive(!toggle);
        _panelInstruction.SetActive(toggle);

        if (!_instructionsON)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_boutonRetourInstructions);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);

        }
    }
}

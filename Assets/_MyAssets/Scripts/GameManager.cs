using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float _tempsNiveau1;  // Taleau
    private int _collisionsNiveau1; // Tableau

    private float _tempsDepart;
    public float TempsDepart => _tempsDepart;
    private int _score;
    public int Score => _score;

    // *** singleton ***
    public static GameManager Instance;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    

    private void Start()
    {
        _score = 0;
        _tempsDepart = Time.time;
    }

    public void UpdateScore()
    {
        _score += 1;
        UIManager.Instance.UpdateScore(_score);
    }

    public void SetNiveau1(float temps)
    {
        _tempsNiveau1 = temps - _tempsDepart;
        _collisionsNiveau1 = _score;
    }

    public void FinPartie()
    {
        float pointageNiveau1 = _tempsNiveau1 + _collisionsNiveau1;

        float tempsNiveau2 = Time.time - _tempsNiveau1;
        int collisionsNiveau2 = _score - _collisionsNiveau1;
        float pointageNiveau2 = tempsNiveau2 + collisionsNiveau2;

        float pointageFinal = pointageNiveau1 + pointageNiveau2;
        Debug.Log("----- Fin de partie -----");
        Debug.Log("Collisions niveau 1 = " + _collisionsNiveau1);
        Debug.Log("Temps niveau 1 : " + _tempsNiveau1.ToString("f2") + " secondes");
        Debug.Log("Pointage niveau 1 : " + pointageNiveau1.ToString("f2") + " secondes");
        Debug.Log("***********************************************************");
        Debug.Log("Collisions niveau 2 = " + collisionsNiveau2);
        Debug.Log("Temps niveau 2 : " + tempsNiveau2.ToString("f2") + " secondes");
        Debug.Log("Pointage niveau 2 : " + pointageNiveau2.ToString("f2") + " secondes");
        Debug.Log("***********************************************************");
        Debug.Log("Pointage Final : " + pointageFinal.ToString("f2") + " secondes");
    }


}

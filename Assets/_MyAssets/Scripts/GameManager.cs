using UnityEngine;

public class GameManager : MonoBehaviour
{

    

    private float _tempsDepart;
    public float TempsDepart => _tempsDepart;
    private int _score;
    public int Score => _score;

    private float _tempFinal;
    public float TempFinal => _tempFinal;

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

    public void SetNiveau(float temps)
    {
        
    }

   


}

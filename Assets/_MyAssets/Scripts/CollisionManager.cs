using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] private Material _material = default(Material);

    private bool _isHit = false;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (!_isHit && this.gameObject.tag != "Objective")
            {
                GameManager.Instance.UpdateScore();
                GetComponent<MeshRenderer>().material = _material;
                _isHit = true;
            }
            else if (this.gameObject.tag == "Objective" && !_isHit)
            {
                int noScene = SceneManager.GetActiveScene().buildIndex;
                    if (noScene == SceneManager.sceneCountInBuildSettings - 1)
                    {
                        _gameManager.FinPartie();
                        collision.gameObject.SetActive(false); // Désactive le joueur sur la scène
                    }
                    else
                    {
                        GameManager.Instance.SetNiveau1(Time.time);
                        SceneManager.LoadScene(noScene + 1);
                    }

                
            }
        }
        
    }
}


using UnityEngine;

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
                Debug.Log("Fin partie !!! / Hits = " + GameManager.Instance.Score);
                collision.gameObject.SetActive(false); // Désactive le joueu sur la scène
            }
        }
        
    }
}


using UnityEngine;

public class Player : MonoBehaviour
{
    private float _playerSpeed = 10f;

    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(dirX, 0f, dirZ);

        // Mormalise mon Vecteur avec une valeur maximale de 1
        direction.Normalize();
        
        transform.Translate(direction * Time.deltaTime * _playerSpeed);


    }

}

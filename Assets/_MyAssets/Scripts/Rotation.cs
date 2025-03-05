using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _angleRotation = 1f;

    private void Update()
    {
        transform.Rotate(0f, _angleRotation * Time.fixedDeltaTime, 0f);
    }
}

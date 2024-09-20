using UnityEngine;

public class WeaponView : MonoBehaviour
{
    private BoxCollider2D             _boxCollider2D;
    private System.Action<GameObject> _hitCallback;
    public  void                      Setup(System.Action<GameObject> hitCallback) => _hitCallback = hitCallback;

    public void EnableCollider(bool isEnable) => _boxCollider2D.enabled = isEnable;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _hitCallback ? .Invoke(other.gameObject);
        }
    }
}

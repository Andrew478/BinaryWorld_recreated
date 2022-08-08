using UnityEngine;
using UnityEngine.Events;

public class Damageble : MonoBehaviour, IDamageble
{
    public UnityEvent OnDamage;
    public void TakeDamage()
    {
        OnDamage.Invoke();
        Destroy(gameObject);
    }
}

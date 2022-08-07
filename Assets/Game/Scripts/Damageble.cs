using UnityEngine;

public class Damageble : MonoBehaviour, IDamageble
{
    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int _maximumHealth = 100;

    int _currentHealth = 0;

    override public string ToString()
    {
        return _currentHealth + " / " + _maximumHealth;
    }

    public bool IsDead { get { return _currentHealth <= 0; } }

    void Start()
    {
        _currentHealth = _maximumHealth;
    }

    public void Damage(int damageValue)
    {
        _currentHealth -= damageValue;

        if (_currentHealth <= 0)
        {

            if (tag == "Player")
            {
                Animator a = GetComponentInChildren<Animator>();
                Destroy(a);
            }
            else
            {
                Animation a = GetComponentInChildren<Animation>();
                a.Stop();
            }

            Destroy(GetComponent<RifleWeeapon>());
            Destroy(GetComponent<PlayerMovement>());
            Destroy(GetComponent<PlayerAnimator>());
            Destroy(GetComponent<CharacterController>());
            Destroy(GetComponent<EnemyMovement>());
            Destroy(GetComponentInChildren<EnemyAttack>());

            Ragdoll r = GetComponent<Ragdoll>();
            if (r != null)
            {
                r.OnDeath();
            }
        }
    }

}

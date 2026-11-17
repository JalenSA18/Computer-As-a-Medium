using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMagic : MonoBehaviour
{
    public Animator animator;
    public PlayerMana PlayerMana;

    void Update()
    {
        Magic();
    }

    void Magic()
    {
        
        {
            if (Keyboard.current.rKey.wasPressedThisFrame && PlayerMana.mana >= 10)
            {
                PlayerMana.mana -= 10;
                animator.SetTrigger("magic");
            }
        }
    }
}
        
// Player Mana
using UnityEngine;
using TMPro;

public class PlayerMana : MonoBehaviour
{
    public int mana = 100;
    public TMP_Text manaText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manaText.text = "Mana: " + mana;
    }

    // Update is called once per frame
    void Update()
    {
        manaText.text = "Mana: " + mana;
    }
}

// Player Magic
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

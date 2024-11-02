using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public Text organicWasteCounterText;
    public Image healthBar;
    public float movementSpeed = 3.0f;
    public int playerLife = 100;
    public int organicWasteCollected = 0;
    public int organicWasteToNextLevel = 30;

    private Vector2 movement = new Vector2();
    private Rigidbody2D rb2D;
    private Animator animator;
    private string animationState = "AnimationState";

    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idSouth = 5
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        UpdateOrganicWasteCounter();
        UpdateHealthBar();
    }

    void Update()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharStates.idSouth);
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        rb2D.velocity = movement * movementSpeed;
    }

    public void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = playerLife / 100f;
        }
    }

    public void UpdateOrganicWasteCounter()
    {
        if (organicWasteCounterText != null)
        {
            organicWasteCounterText.text = "Recolectada: " + organicWasteCollected + "/30";
        }
    }

    public void ReduceLife(int amount)
    {
        playerLife -= amount;
        UpdateHealthBar();
    }
}

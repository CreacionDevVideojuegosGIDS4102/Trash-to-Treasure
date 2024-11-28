using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Para cambiar de escena.

public class MovementController : MonoBehaviour
{
    public Text organicWasteCounterText;
    public Image healthBar;
    public GameObject winPanel; // Asocia tu panel desde el inspector.
    public float movementSpeed = 3.0f; // Controla la velocidad del jugador.
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

        if (winPanel != null)
        {
            winPanel.SetActive(false); // Asegúrate de que el panel esté oculto al inicio.
        }
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
            organicWasteCounterText.text = "Recolectada: " + organicWasteCollected + "/" + organicWasteToNextLevel;
        }

        // Si recolectaste toda la basura orgánica, muestra el mensaje de victoria.
        if (organicWasteCollected >= organicWasteToNextLevel)
        {
            ShowWinPanel();
        }
    }

    public void ReduceLife(int amount)
    {
        playerLife -= amount;
        UpdateHealthBar();
    }

    public void CollectOrganicWaste()
    {
        organicWasteCollected++;
        UpdateOrganicWasteCounter();
    }

    private void ShowWinPanel()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0; // Pausa el juego mientras se muestra la ventana.
        }
    }

    // Métodos para los botones.
    public void GoToNextLevel()
    {
        Time.timeScale = 1; // Reactiva el tiempo del juego.
        SceneManager.LoadScene("LevelTwo"); // Cambia por el nombre de tu escena.
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1; // Reactiva el tiempo del juego.
        SceneManager.LoadScene("Menú"); // Cambia por el nombre de tu menú.
    }
}

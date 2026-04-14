using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;
    private float horizontalInput;
    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction pauseAction;
    private InputAction despauseAction;
    private InputAction invisibleAction;
    private IEnumerator coroutine;
    [SerializeField] private GameObject painelPause;
    [SerializeField] private GameObject iconePause;
    MoveForward animal;
    int vida = 3;
    public TextMeshProUGUI vidaText;
    

    // Start is called before the first frame update
    void Start()
    {
        painelPause.SetActive(false);
        animal = GameObject.FindGameObjectWithTag("animal").GetComponent<MoveForward>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        // movimenta o player para esquerda e direita a partir da entrada do usu�rio
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        // mant�m o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }
        // dispara comida ao pressionar barra de espa�o
        if (fireAction.WasPerformedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        if(pauseAction.WasPerformedThisFrame())
        {
            Pause();

        } else if(despauseAction.WasPerformedThisFrame())
        {
            Despause();
        }

        FicarInvisivel();
        if(vida<=0)
        {
            Destroy(gameObject);
        }
        
    }

    public void MoveEvent(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }

    //public void FireEvent(InputAction.CallbackContext context)
    //{
        //if (context.performed)
        //{
       //     Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
     //   }
        //Debug.Log("pizza");
   // }

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }
    
    public void Pause()
    {
        
        InputActions.FindActionMap("UI").Enable();
        InputActions.FindActionMap("Player").Disable();
        painelPause.SetActive(true);
        iconePause.SetActive(false);
        animal.Parar();
        Debug.Log("esc");
    }

    public void Despause()
    {
        InputActions.FindActionMap("UI").Disable();
        InputActions.FindActionMap("Player").Enable();
        painelPause.SetActive(false);
        iconePause.SetActive(true);
        animal.Andar();
        Debug.Log("UI");
        
    }

    public void Menu()
    {
        Debug.Log("sair");
        SceneManager.LoadScene("Menu");
    }

    public void FicarInvisivel()
    {
        if (invisibleAction.WasPerformedThisFrame())
        {
            print("invisivel");
            transform.localScale = Vector3.zero;
            coroutine = WaitAndPrint(2.0f);
            StartCoroutine(coroutine);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        vida-=1;
        print(vida);
    }

      public void AddScore(int points)
    {
        vida += points;
        VidaTexto();
    }

    void VidaTexto()
    {
        vidaText.text = "Vida: " + vida;
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        print("Coroutine ended: " + Time.time + " seconds");
        transform.localScale = Vector3.one;
    }

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Jump");
        pauseAction = InputSystem.actions.FindAction("Pause");
        despauseAction = InputSystem.actions.FindAction("PauseUI");
        invisibleAction = InputSystem.actions.FindAction("Invisivel");
    } 
}

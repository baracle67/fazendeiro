using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    // Start is called before the first frame update
    void Start()
    {
        painelPause.SetActive(false);
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
        Debug.Log("esc");
    }

    public void Despause()
    {
        InputActions.FindActionMap("UI").Disable();
        InputActions.FindActionMap("Player").Enable();
        painelPause.SetActive(false);
        iconePause.SetActive(true);
        Debug.Log("UI");
        
    }

    public void Sair()
    {
        Debug.Log("sair");
        Application.Quit();
    }

    private void FicarInvisivel()
    {
        if (invisibleAction.WasPerformedThisFrame())
        {
            print("invisivel");
            transform.localScale = Vector3.zero;
            coroutine = WaitAndPrint(2.0f);
            StartCoroutine(coroutine);
        }
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

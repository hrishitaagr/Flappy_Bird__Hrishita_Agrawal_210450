
// using UnityEngine;

// public class Flappingo : MonoBehaviour
// {
//     private SpriteRenderer spriteRenderer;
//     public Sprite[] sprites;
//     private int spriteIndex;
//     private Vector3 direction;
//     public float gravity= -9.8f;
//     public float strength=5f;

//     public AudioClip jumpSound;
//     public AudioClip gameOverSound;
//     public AudioClip scoreSound;
   

//     private void Awake(){
//         spriteRenderer= GetComponent<SpriteRenderer>();
//     }
//     private void Start(){
//         InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
//     }

//     private void OnEnable()
//     {
//         Vector3 position = transform.position;
//         position.y = 0f;
//         transform.position = position;
//         direction = Vector3.zero;
//     }
//     private void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
//             direction=Vector3.up * strength;
//              FindObjectOfType<Sound>().PlaySound(jumpSound);
//         }
//         direction.y += gravity* Time.deltaTime;
//         transform.position += direction * Time.deltaTime;
//     }
//     private void AnimateSprite()
//     {
//         spriteIndex++;
//         if(spriteIndex>=sprites.Length){
//             spriteIndex=0;
//         }
//         spriteRenderer.sprite=sprites[spriteIndex];

//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if(other.gameObject.tag == "Obstacle"){
//             FindObjectOfType<GameManager>().GameOver();
//             FindObjectOfType<Sound>().PlaySound(gameOverSound);
//         }
//         else if(other.gameObject.tag == "Scoring"){
//             FindObjectOfType<GameManager>().IncreaseScore();
//              FindObjectOfType<Sound>().PlaySound(scoreSound);
//         }
//     }


// }




using UnityEngine;

public class Flappingo : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    public AudioClip jumpSound;
    public AudioClip gameOverSound;
    public AudioClip scoreSound;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (spriteRenderer != null)
        {
            InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        }
        else
        {
            Debug.LogError("SpriteRenderer is not assigned!");
        }
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
private Sound sound;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
         
            Sound.instance.PlaySound(jumpSound);
        
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        if (spriteRenderer != null && sprites != null && sprites.Length > 0)
        {
            spriteIndex++;
            if (spriteIndex >= sprites.Length)
            {
                spriteIndex = 0;
            }
            spriteRenderer.sprite = sprites[spriteIndex];
        }
        else
        {
            Debug.LogError("SpriteRenderer or sprites array is not properly initialized!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        
            Sound.instance.PlaySound(gameOverSound);
        
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            
            Sound.instance.PlaySound(scoreSound);
        
        }
    }
}




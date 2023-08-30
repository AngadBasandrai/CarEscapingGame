using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Rigidbody rb;
    public Camera mainCam;
    public Camera secondCam;
    public Camera thirdCam;
    public int cameraSwitch;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        LevelCounter.level = int.Parse(SceneManager.GetActiveScene().name.Substring(5)) + 1;
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (cameraSwitch == 0)
            {
                agent.SetDestination(agent.destination + (Vector3.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * 25));
            }
            else
            {
                agent.SetDestination(agent.destination + (transform.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * 25));
            }
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (cameraSwitch == 0)
            {
                agent.SetDestination(agent.destination + (Vector3.forward * Input.GetAxisRaw("Vertical") * Time.deltaTime * 25));
            }
            else
            {
                agent.SetDestination(agent.destination + (transform.forward * Input.GetAxisRaw("Vertical") * Time.deltaTime * 25));
            }
        }
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            if (!agent.isStopped)
            {
                agent.SetDestination(transform.position);
                agent.isStopped = true;
                agent.ResetPath();
            }
        }

        if (Input.GetButtonDown("CameraSwitch"))
        {
            cameraSwitch = cameraSwitch + 1;
            cameraSwitch %= 3;
        }
        if (cameraSwitch == 0)
        {
            mainCam.gameObject.SetActive(true);
            secondCam.gameObject.SetActive(false);
            thirdCam.gameObject.SetActive(false);
        }
        else if (cameraSwitch == 1)
        {
            mainCam.gameObject.SetActive(false);
            secondCam.gameObject.SetActive(true);
            thirdCam.gameObject.SetActive(false);
        }
        else
        {
            mainCam.gameObject.SetActive(false);
            secondCam.gameObject.SetActive(false);
            thirdCam.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("LevelFail");
        }
        if (collision.gameObject.tag == "End")
        {
            SceneManager.LoadScene("LevelComplete");
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(PlayerPrefs.GetString("User") + "Level", LevelCounter.level);
    }
}

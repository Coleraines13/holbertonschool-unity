using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    
    private Vector3 offset;

    public GameObject player;
    public float turnSpeed = 5.0f;

    public Toggle InvertedYMode;
    public bool isInverted = false;
    private int inverted;

    // Start is called before the first frame update
    void Start()
    {
        if (InvertedYMode)
            isInverted = true;
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInverted)
                    inverted = -1;
        else
                    inverted = 1;
        //If tap button rigth of mouse is actived rotation
        if(Input.GetMouseButton(1))
        {
            Debug.Log("Active Rotation");
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis((Input.GetAxis("Mouse Y") * inverted) * turnSpeed, Vector3.left) * offset;
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
        }
        else
        {
            Debug.Log("Desactive Rotation");
            transform.position = player.transform.position + offset;
        }
    }
}
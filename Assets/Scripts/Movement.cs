using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {

    public float speed = 5f;
    public float sensitivity = 3.5f;
    public float maxLookAngleDown = 45f;
    public float maxLookAngleUp = -60f;

	void Update()
	{
        float deltaX = Input.GetAxisRaw("Horizontal");
        float deltaZ = Input.GetAxisRaw("Vertical");

        float rotationDeltaX = Input.GetAxisRaw("Mouse Y");
        float rotationDeltaY = Input.GetAxisRaw("Mouse X");
        
        Vector3 moveX = transform.right * deltaX;
        Vector3 moveZ = transform.forward * deltaZ;
        Vector3 rotateX = new Vector3(rotationDeltaX, 0f, 0f) * sensitivity * -1;
        Vector3 rotateY = new Vector3(0f, rotationDeltaY, 0f) * sensitivity;
        
        Vector3 velocity = (moveX + moveZ).normalized * speed;
        if(velocity != Vector3.zero || rotateX != Vector3.zero || rotateY != Vector3.zero)
        {
            CmdMovePlayer(velocity, rotateX, rotateY);
        }
        
	}
    
    [Command]
    void CmdMovePlayer(Vector3 velocity, Vector3 rotateX, Vector3 rotateY)
    {
        transform.position = transform.position + velocity * Time.fixedDeltaTime;
        transform.rotation = transform.rotation * Quaternion.Euler(rotateY);
        Transform headTransform = transform.FindChild("Head").transform;
        Quaternion newHeadRotation = headTransform.rotation * Quaternion.Euler(rotateX);
        Quaternion maxDown = Quaternion.Euler(new Vector3(maxLookAngleDown, 0f, 0f));
        Quaternion maxUp = Quaternion.Euler(new Vector3(maxLookAngleUp, 0f, 0f));
        
        if(newHeadRotation.x < maxDown.x && newHeadRotation.x > maxUp.x)
        {
            headTransform.rotation = newHeadRotation;
        }
    }
}


using UnityEngine;

[ExecuteInEditMode]
public class ARCameraLight : MonoBehaviour
{
	public Transform directionReference;
	public bool tiltLock = true;

	private Quaternion lookRot;
	private Vector3 euler;
	
	private void Update()
	{
		lookRot = Quaternion.LookRotation(directionReference.position - Camera.main.transform.position);
		euler = lookRot.eulerAngles;
		if (tiltLock) euler.x = transform.eulerAngles.x;
		transform.eulerAngles = euler;
	}
}
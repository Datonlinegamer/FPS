
using UnityEngine;

public class CameraRecoil : MonoBehaviour
{
    public static CameraRecoil Instance;
    private Vector3 Currentrotation;
    private Vector3 Targetrotation;

    [SerializeField] private float recoilX;
    [SerializeField] private float recoilY;
	[SerializeField] private float recoilZ;

    [SerializeField] private float snappiness;
    [SerializeField] private float returnSpeed;
    void Start()
    {
        Instance = this;
        
    }

    void setReooilrotation()
    {
        Targetrotation = Vector3.Lerp(Targetrotation, Vector3.zero, returnSpeed * Time.deltaTime);
        Currentrotation = Vector3.Slerp(Currentrotation, Targetrotation,snappiness * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(Currentrotation);
    }

    public void Recoilfire()
    {
        Targetrotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
            
    }
 
    void Update()
    {
        setReooilrotation();
    }
}

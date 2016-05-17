using UnityEngine;
using System.Collections;



[RequireComponent(typeof(Photon.MonoBehaviour))]
public class Shotter : Photon.MonoBehaviour
{
    public const int SHOT_GROUP = 0;

    public string shotPrefName = "Bullet";

    [SerializeField]
    private float weaponCoolDown = 1.0f;

    private float lastShootTime = float.MaxValue;

    private Photon.MonoBehaviour networkIdentity;

    protected virtual void Awake()
    {
        networkIdentity = GetComponent<Photon.MonoBehaviour>();
    }

    protected virtual void Update()
    {
        if (!networkIdentity.photonView.isMine) return;
        if (Input.GetMouseButton(0) && lastShootTime > weaponCoolDown)
        {
            lastShootTime = 0;
            CmdShoot();
        }
        lastShootTime += Time.deltaTime;
    }

    private void CmdShoot()
    {
        //Bullet bulletClone = Instantiate(bulletPrefab);
        //bulletClone.transform.position = transform.position + (transform.forward * 1.0f);
        //bulletPrefab.transform.rotation = transform.rotation;

        PhotonNetwork.Instantiate(shotPrefName, transform.position, transform.rotation, SHOT_GROUP);

    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkIdentity))]
public class CharacterWeaponController : NetworkBehaviour {

    [SerializeField]
    private float weaponCoolDown = 1.0f;

    private float lastShootTime = float.MaxValue;

    [SerializeField]
    private Bullet bulletPrefab;

    private NetworkIdentity networkIdentity;

    protected virtual void Awake() {
        networkIdentity = GetComponent<NetworkIdentity>();
    }

    protected virtual void Update() {
        if (!networkIdentity.isLocalPlayer) return;
        if(Input.GetMouseButton(0) && lastShootTime > weaponCoolDown) {
            lastShootTime = 0;
            CmdShoot();
        }
        lastShootTime += Time.deltaTime;
    }

    [Command]
    private void CmdShoot() {
        Bullet bulletClone = Instantiate(bulletPrefab);
        bulletClone.transform.position = transform.position+(transform.forward*1.0f);
        bulletPrefab.transform.rotation = transform.rotation;

        NetworkServer.Spawn(bulletClone.gameObject);
    }
}

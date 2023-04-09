using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    // Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, realoadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    bool isShooting, isReadyToShoot, isReloading;

    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    // Graphics
    //public TextMeshProUGUI text;

    public void Awake()
    {
        bulletsLeft = magazineSize;
        isReadyToShoot = true;
    }

    public void Update()
    {
        MyInput();

        // Set Text
        // text.SetText(bulletsLeft + " / " + magazineSize);
    }

    public void MyInput()
    {
        if(allowButtonHold)
        {
            isShooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            isShooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !isReloading)
        {
            Reload();
        }

        // Shoot
        if(isReadyToShoot && isShooting && !isReloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    public void Shoot()
    {
        isReadyToShoot = false;

        // Spread

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        // Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward = new Vector3(x,y,0); 


        // Raycast
        // note : changer la position du raycast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if(rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<Zombie>().TakeDamage(damage);
            }
        }

        bulletsLeft--;
        bulletsShot--;
        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    public void ResetShot()
    {
        isReadyToShoot = true;
    }

    public void Reload()
    {
        isReloading = true;

        Invoke("ReloadFinished", realoadTime);
    }

    public void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        isReloading = false;
    }
}

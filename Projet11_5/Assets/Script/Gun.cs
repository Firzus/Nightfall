using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 20f;
    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(player.transform.position, player.transform.forward, out hit, range))
        {
            Debug.DrawLine(player.transform.position, hit.transform.position, Color.green, 5f);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}

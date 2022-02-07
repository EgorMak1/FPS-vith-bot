using UnityEngine;

public class Gun : MonoBehaviour
{
    //private float nextTimeToFire = 0f; for fast fire
    public float fireRate = 15f;

    public int damage = 10;
    public float range = 100f;
    public Camera fpsCam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))// && Time.time>=nextTimeToFire) add fast fire
        {
            //nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        void Shoot()
        {
            RaycastHit hit;

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                CharacterStats enemy = hit.transform.GetComponent<CharacterStats>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
    }
}

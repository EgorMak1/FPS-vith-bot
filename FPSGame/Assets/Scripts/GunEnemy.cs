using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    //private float nextTimeToFire = 0f; for fast fire
    public float fireRate = 15f;

    public int damage = 10;
    public float range = 100f;
    public GameObject playerTarget;

    void Start()
    {
    }
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))// && Time.time>=nextTimeToFire) add fast fire
        //{
        //    //nextTimeToFire = Time.time + 1f / fireRate;
        //    Shoot();
        //}
    }
  
    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name+"AAAAAAAA");
            CharacterStats enemy = hit.transform.GetComponent<CharacterStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}

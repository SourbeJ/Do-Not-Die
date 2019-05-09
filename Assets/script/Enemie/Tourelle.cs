using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourelle : MonoBehaviour {

    public GameObject Player;
    public GameObject Pivot;
    public GameObject bulletPrefab;
    public GameObject[] SpawnBullet;
    GameObject Bullet;

    public int Level;

    public float TimeShoot = 2;
    public float TimeReload = 2;
    public float distance = 15f;
    public float time;
    public float timeReload;
    float angle;
    public bool Shoot = false;
    public bool Explosif;
   

    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");

        if (Level == 2)
        {
            TimeShoot = 0.5f;
        }
    
    }
	
	void Update () {

        

        if (Level == 0)
        {
            time += Time.deltaTime;
            if (Vector2.Distance(Player.transform.position, transform.position) < distance)
            {
                if (time >= TimeShoot)
                {
                    time = 0;
                    Bullet = Instantiate(bulletPrefab, Pivot.transform.position, SpawnBullet[0].transform.rotation);
                    Bullet.GetComponent<SpriteRenderer>().color = Pivot.GetComponentInChildren<SpriteRenderer>().color;
                    if (Explosif)
                        Bullet.GetComponent<Projectille>().Explosif = true;
                }
            }
            
        }

        if (Level == 1)
        {
            time += Time.deltaTime;
            if (Vector2.Distance(Player.transform.position, transform.position) < distance)
            {
                

                Vector2 direction = Player.transform.position - transform.position;
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Pivot.transform.rotation = rotation;

                if (time >= TimeShoot)
                {
                    time = 0;
                    Bullet = Instantiate(bulletPrefab, Pivot.transform.position, SpawnBullet[0].transform.rotation);
                    Bullet.GetComponent<SpriteRenderer>().color = Pivot.GetComponentInChildren<SpriteRenderer>().color;
                    if (Explosif)
                        Bullet.GetComponent<Projectille>().Explosif = true;
                }
            }
            
            

        }

        if (Level == 2)
        {
            time += Time.deltaTime;
            timeReload += Time.deltaTime;
            
            if (Vector2.Distance(Player.transform.position, transform.position) < distance)
            {

                

                Vector2 direction = Player.transform.position - transform.position;
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Pivot.transform.rotation = rotation;

                if (timeReload >= TimeReload)
                {
                    timeReload = 0;
                    Shoot = !Shoot;
                }

                if (time >= TimeShoot && Shoot)
                {
                    time = 0;
                    Bullet = Instantiate(bulletPrefab, Pivot.transform.position, SpawnBullet[0].transform.rotation);
                    Bullet.GetComponent<SpriteRenderer>().color = Pivot.GetComponentInChildren<SpriteRenderer>().color;
                    if (Explosif)
                        Bullet.GetComponent<Projectille>().Explosif = true;
                }
            }
            else
            {
                if (timeReload >= TimeReload && Shoot == true)
                {
                    timeReload = 0;
                    Shoot = !Shoot;
                }
            }

        }

        if (Level == 3)
        {
            time += Time.deltaTime;
            timeReload += Time.deltaTime;

            

            if (Vector2.Distance(Player.transform.position, transform.position) < distance)
            {
                

                Vector2 direction = Player.transform.position - transform.position;
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Pivot.transform.rotation = rotation;

                if (timeReload >= TimeReload)
                {
                    timeReload = 0;
                    Shoot = !Shoot;
                }

                if (time >= TimeShoot && Shoot)
                {
                    time = 0;
                    for (int i = 0; i < SpawnBullet.Length; i++)
                    {
                        Bullet = Instantiate(bulletPrefab, Pivot.transform.position, SpawnBullet[i].transform.rotation);
                        Bullet.GetComponent<SpriteRenderer>().color = Pivot.GetComponentInChildren<SpriteRenderer>().color;
                        if (Explosif)
                            Bullet.GetComponent<Projectille>().Explosif = true;
                    }

                }
            }
            else
            {
                if (timeReload >= TimeReload && Shoot == true)
                {
                    timeReload = 0;
                    Shoot = !Shoot;
                }
            }
            
                
        }

        if (Level == 4)
        {
            time += Time.deltaTime;
            timeReload += Time.deltaTime;

            

            if (Vector2.Distance(Player.transform.position, transform.position) < distance)
            {
                

                Vector2 direction = Player.transform.position - transform.position;
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Pivot.transform.rotation = rotation;

                if (timeReload >= TimeReload)
                {
                    timeReload = 0;
                    Shoot = !Shoot;
                }

                if (time >= TimeShoot && Shoot)
                {
                    time = 0;
                    for (int i = 0; i < SpawnBullet.Length; i++)
                    {
                        Bullet = Instantiate(bulletPrefab, Pivot.transform.position, SpawnBullet[i].transform.rotation);
                        Bullet.GetComponent<SpriteRenderer>().color = Pivot.GetComponentInChildren<SpriteRenderer>().color;
                        if (Explosif)
                            Bullet.GetComponent<Projectille>().Explosif = true;
                    }

                }
            }
            else
            {
                if (timeReload >= TimeReload && Shoot == true)
                {
                    timeReload = 0;
                    Shoot = !Shoot;
                }
            }
                
        }


    }
}

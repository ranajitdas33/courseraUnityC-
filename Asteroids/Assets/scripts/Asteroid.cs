using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;

    float asteroidScaleX;


    Vector3 asteroidScale;

    float colliderRadius;
    Vector3 moveDirection = new Vector3();

    private void Start()
    {
        asteroidScale = GetComponent<Transform>().localScale;
     

        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    // move direction of asteroid
    public void Initialize(Direction directtion)
    {
        float angle;
        //Vector3 moveDirection = new Vector3();
        switch (directtion)
        {
            case Direction.Left:
                moveDirection = new Vector3(-1, 0, 0);
                angle = Random.Range(165, 195);
                moveDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

                break;
            case Direction.Right:
                moveDirection = new Vector3(1, 0, 0);
                angle = Random.Range(-15, 15);
                moveDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
                break;
            case Direction.Up:
                moveDirection = new Vector3(0, 1, 0);
                angle = Random.Range(75, 105);
                moveDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

                break;
            case Direction.Down:
                moveDirection = new Vector3(0, -1, 0);
                angle = Random.Range(255, 285);
                moveDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

                break;
            default:
                break;
        }

        // Move force
        //const float MinImpulseForce = 1f;
        //const float MaxImpulseForce = 2f;

        //float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        //GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
        StartMoving(1f);
        
    }

    

    private void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Bullet")
        {
            AudioManager.Play(AudioClipName.AsteroidHit);
            transform.localScale =  asteroidScale / 2;
            asteroidScaleX = transform.localScale.x;
            asteroidScale = transform.localScale;

            float colliderRadiusHalf = colliderRadius / 2;
            colliderRadius = GetComponent<CircleCollider2D>().radius = colliderRadiusHalf;


            //small asteroid moving in random direction
            float xValue = Random.Range(-2 , 2 );
            float yValue = Random.Range(-2 , 2 );
            
            //small asteroid1
            GameObject ast1 = Instantiate(gameObject, transform.position,Quaternion.identity);
            ast1.GetComponent<Rigidbody2D>().AddForce( new Vector2(xValue, yValue) , ForceMode2D.Impulse);

            //small asteroid2
            Vector2 dirSmall = new Vector2(Mathf.Cos(Mathf.Deg2Rad * xValue), Mathf.Sin(Mathf.Deg2Rad * yValue));
            GameObject ast2 = Instantiate(gameObject, transform.position, Quaternion.identity);
            ast2.GetComponent<Rigidbody2D>().AddForce(dirSmall, ForceMode2D.Impulse);   

            Destroy(gameObject);        //destroy big asteroid
            Destroy(coll.gameObject);   //destroy bullet

            if (asteroidScaleX < 0.5f)
            {
                Debug.Log(asteroidScaleX);
                Destroy(ast1);
                Instantiate<GameObject>(prefabExplosion, transform.position, Quaternion.identity);
                Destroy(ast2);
                Instantiate<GameObject>(prefabExplosion, transform.position, Quaternion.identity);
            }
        }
        
    }

    void StartMoving(float angle)
    {
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 2f;

        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude * angle, ForceMode2D.Impulse);
    }
}

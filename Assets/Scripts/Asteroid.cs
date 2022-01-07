using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : SpaceObject, IDamage
{
    private const int MIN_DAMAGE = 5;
    private const int MAX_DAMAGE = 15;
    private const float MAX_DELETION = 300.0f;
    private const float MIN_SPEED = 0.2f;
    private const float MAX_SPEED = 0.8f;

    public GameObject ship;

    private Transform transformShip;
    private Transform transformAsteroid;
    private Vector3 normVecdMoment;
    private int damage;

    public int Damage { get => damage; }

    private void OnTriggerEnter(Collider other)
    {
        Death();
    }

    private void OnEnable()
    {
        damage = Random.Range(MIN_DAMAGE, MAX_DAMAGE);

        transformShip = ship.GetComponent<Transform>();
        transformAsteroid = gameObject.transform;
        var distance = GetDistanceAtoB(transformShip, transformAsteroid);

        normVecdMoment = (transformShip.position - transformAsteroid.position) / distance;

        speed = Random.Range(MIN_SPEED, MAX_SPEED);
    }

    private void FixedUpdate()
    {
        Motion();
    }

    private void Update()
    {
        transformShip = ship.GetComponent<Transform>();
        transformAsteroid = gameObject.transform;

        var vec = transformShip.position - transformAsteroid.position;

        if (vec.magnitude > MAX_DELETION)
        {
            Death();
        }
    }

    public override void Motion()
    {
        transform.position += normVecdMoment * speed;
    }
    public override bool Death()
    {
        Destroy(gameObject);
        return true;
    }

    private float GetDistanceAtoB(Transform a, Transform b)
    {
        transformShip = ship.GetComponent<Transform>();
        transformAsteroid = gameObject.transform;

        var vec = a.position - b.position;
        return vec.magnitude;
    }
}

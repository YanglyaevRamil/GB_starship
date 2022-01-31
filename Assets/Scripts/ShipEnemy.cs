using UnityEngine;

public class ShipEnemy : SpaceObject
{
    private ISpaceShipGun shipEnemyGun;
    public ShipEnemy(int helth, Transform transform, float speed, Vector3 direction, int ammunition, float gunRecoilTime) : base (helth, transform, speed, new Quaternion(), direction)
    {
        shipEnemyGun = new SpaceShipGun(ammunition, gunRecoilTime, 3.0f);
    }
    public bool Shooting()
    {
        return shipEnemyGun.Shot();
    }
}

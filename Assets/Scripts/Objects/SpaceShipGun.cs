public class SpaceShipGun : ISpaceShipGun
{
    private const float TIMER_TICK = 100.0f; // 0.1 sec
    public int Ammunition { get { return ammunition; } set { ammunition = value; } }
    public float GunReloadingTime { get { return gunReloadingTime; } }

    public float gunReloadingTime;
    private int ammunition;
    private bool emptyAmmunition;
    private GameTimer gameTimer;
    public SpaceShipGun(int ammunition, float gunRecoilTime, float gunReloadingTime)
    {
        this.ammunition = ammunition;
        emptyAmmunition = false;
        gameTimer = new GameTimer(TIMER_TICK, gunRecoilTime);

        this.gunReloadingTime = gunReloadingTime;
    }
    public bool Shot()
    {
        if (gameTimer.FlagStopWatch)
        {
            gameTimer.StartTimer();
            if (ammunition > 0)
            {
                ammunition--;
                emptyAmmunition = false;
            }
            else
            {
                emptyAmmunition = true;
            }

            return !emptyAmmunition;
        }
        else
        {
            return false;
        }
    }
}

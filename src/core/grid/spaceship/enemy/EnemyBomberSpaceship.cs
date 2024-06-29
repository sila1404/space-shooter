﻿namespace SpaceShooter.core
{
    public class EnemyBomberSpaceship : EnemySpaceship
    {
        public EnemyBomberSpaceship(
            GameGrid grid,
            int hp = 500,
            int concurrentLaserBlastsCount = 1,
            int laserBlastDamage = 100,
            int laserReloadFrequency = 1500,
            int missileCount = 20,
            int missileDamage = 200,
            int missileReloadFrequency = 10000,
            int scorePoints = 15
        ) : base(
            grid, 
            hp,
            concurrentLaserBlastsCount,
            laserBlastDamage,
            laserReloadFrequency,
            0,
            missileCount,
            missileDamage,
            missileReloadFrequency,
            scorePoints
        )
        {
            setSize(grid);
            setBounds(grid);
            initializeLocationX();
            initializeLocationY();
            Image = resources.Resources.img_enemy_bomber_spaceship;
        }
    }
}

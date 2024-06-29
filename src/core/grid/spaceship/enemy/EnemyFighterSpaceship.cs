﻿using SpaceShooter.utils;

namespace SpaceShooter.core
{
    public class EnemyFighterSpaceship : EnemySpaceship
    {
        public EnemyFighterSpaceship(
            GameGrid grid, 
            int hp = 500, 
            int concurrentLaserBlastsCount = 1, 
            int laserBlastDamage = 100, 
            int laserReloadFrequency = 1500, 
            int scorePoints = 5
        ) : base(
            grid,
            hp, 
            concurrentLaserBlastsCount, 
            laserBlastDamage, 
            laserReloadFrequency, 
            0, 
            0, 
            0, 
            0, 
            scorePoints
        )
        {
            setSize(grid);
            setBounds(grid);
            initializeLocationX();
            initializeLocationY();
            Image = resources.Resources.img_enemy_fighter_spaceship;
        }
    }
}

﻿using SpaceShooter.utils;

namespace SpaceShooter.core
{
    internal class HeroSpaceship : Spaceship, IControls
    {
        public bool GoUp { get; set; }
        public bool GoDown { get; set; }
        public bool GoLeft { get; set; }
        public bool GoRight { get; set; }

        public HeroSpaceship(
            GameGrid grid, 
            int hp = 700, 
            int concurrentLaserBlastsCount = 2, 
            int laserBlastDamage = 100, 
            int laserReloadFrequency = 500
        ) : base (grid, hp, concurrentLaserBlastsCount, laserBlastDamage, laserReloadFrequency, 0, 0, 0, 0)
        {
            setSize(grid);
            setBounds(grid);
            initializeLocationX();
            initializeLocationY();
            ResetControls();
            Image = resources.Resources.img_hero_spaceship;
        }

        public override void Move()
        {
            if (!IsActive)
                return; 

            updateDisplacement();
            moveHorizontally();
            moveVertically();
        }

        public override List<LaserBlast>? FireLaser(GameGrid grid) 
        {
            if (!IsActive || laserIsReloading())
                return null;

            List<HeroLaserBlast> laserBlasts = new List<HeroLaserBlast>();

            for (int i = 0; i < ConcurrentLaserBlastsCount; i++)
                laserBlasts.Add(new HeroLaserBlast(this, grid, i));
            lastLaserFireTimestamp = TimeManager.ElapsedGameTime;

            AudioPlayer.Player.PlaySound(fireLaserSoundFx);
            return laserBlasts.Cast<LaserBlast>().ToList();
        }

        public void ResetControls()
        {
            GoLeft = false;
            GoRight = false;
            GoUp = false;
            GoDown = false;
        }

        protected void updateDisplacement()
        {
            displacementX = 0;
            displacementY = 0;

            if (GoLeft) 
                displacementX -= absMaxDisplacement;

            if (GoRight) 
                displacementX += absMaxDisplacement;

            if (GoUp) 
                displacementY -= absMaxDisplacement;

            if (GoDown) 
                displacementY += absMaxDisplacement;
        }

        protected override void setBounds(GameGrid grid)
        {
            minX = grid.GetItemMinPossibleX();
            maxX = grid.GetItemMaxPossibleX(this);
            minY = grid.GetGridMiddleY() + Height;
            maxY = grid.GetItemMaxPossibleY(this);
        }

        protected override void initializeLocationX()
            => LocationX = (minX + maxX) / 2;

        protected override void initializeLocationY()
            => LocationY = (minY + maxY) / 2;
    }
}

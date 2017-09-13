using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game9
{
    class Enemy
    {
        Texture2D namlu, tank,t_bullet;
        Vector2 position,bulletposition;
        Vector2 origin;
        Rectangle visibleRect,namluRect,colisionRect;
        float rotation = 0;
        float bulletspeed = 20;

        private List<tankBullet> bullets;
        private float RotationAngle;
        int shootCooler = 0;
        int shootTimer = 70;


        public Enemy(Vector2 _position, Rectangle _visibleRect,Texture2D namlu, Texture2D tank,Texture2D bullet)
        {
            bullets = new List<tankBullet>();
            this.namlu = namlu;
            this.tank = tank;
            t_bullet = bullet;
            position = _position;
            visibleRect = _visibleRect;
             origin = new Vector2(namlu.Width, namlu.Height / 2f);
            namluRect = new Rectangle(0, 0, 244, 20);
           colisionRect = new Rectangle(position.ToPoint(),new Point(tank.Width,tank.Height));
        }
        private void updateBullets()
        {
            foreach (var bullet in bullets)
            {
                bullet.Update(colisionRect);
            }
        }

        private void shoot()
        {
            bulletPosition();
            bullets.Add(new tankBullet(new Vector2(position.X+120 , position.Y+65 ), new Rectangle(0, 0, 50, 50),bulletspeed-measureXaxis(), measureXaxis(), rotation));
        }
        public void bulletPosition()
        {
            Vector2 originBullet = new Vector2(position.X + 120, position.Y + 65);
            float angle = (RotationAngle / 1.25f) * 80;
            //positie van bulletstart moet hier berekend worden
        }
        public float measureXaxis()
        {
            float total;
            total = (RotationAngle / 1.50f) * bulletspeed;
            return total;
        }
        public void Draw(SpriteBatch video)
        {

            foreach (var bullet in bullets)
            {
                bullet.Draw(video, t_bullet);
            }
            Console.WriteLine((position.X + 150) + "");
            video.Draw(namlu, new Vector2(position.X + 150, position.Y + 65), namluRect, Color.White, rotation,origin,1, SpriteEffects.None, 0f);
            video.Draw(tank, position,visibleRect, Color.White);
          
        }
        
        
        public void Update(Hero hero,GameTime gameTime)
        {
            updateBullets();

       
            
            calculateRotation(hero);
            if ((position.X - hero.Position.X) < 1000)
                shootHero(hero);
           

        }
       
        public void calculateRotation(Hero hero)
        {
            RotationAngle = ((position.Y - hero.Position.Y) / 1865) * 4;
            if (RotationAngle > 1.25) RotationAngle = 1.25f;
            float circle = MathHelper.Pi * 2;
            rotation = RotationAngle % circle;
        }
        public void shootHero(Hero hero)
        {
            if (shootCooler > 0) shootCooler--;
            if (shootCooler < 0) shootCooler = 0;


            if (shootCooler == 0)
            {
                shoot();
                shootCooler = shootTimer;
            }


        }
    }
}
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
using Microsoft.Xna.Framework.Input.Touch;

namespace Game9
{
    class Hero : Block
    {
        TouchEventDetect touchEvent;

        private List<Bullet> bullets;

        int shootCooler = 0;
        int shootTimer = 20;

    

        int multiplier = 0;
        int maxMultiplier = 10;
        int fallSpeed = 5;

        int a = 0;
        int b = 5;

        int fallCooler = 0;
        int fallTimer = 5;


        int jumpSpeed = -3;
        int jumpCooler = 0;
        int jumpTimer = 6;

        int c = 0;
        int d = 2;

        private bool startFall = false;
        private bool canFall = true;

        bool jump = false;

        public Hero(Vector2 position, Rectangle visibleRect) : base(position, visibleRect)
        {
            touchEvent = new TouchEventDetect();
            bullets = new List<Bullet>();
            score = 0;
            speed = 0;
        }

        public void updateCanMove(bool down)
        {
            canFall = down;
        }

        public void Score()
        {
            score++;
        }
        public int score { get; set; }
        public void Update(TouchCollection touchCollection)
        {
            updateBullets();

            if (shootCooler > 0) shootCooler--;
            if (shootCooler < 0) shootCooler = 0;

            if (touchEvent.checkTouch(touchCollection) == 1)
            {
                startFall = true;
                jump = true;
                c = 0;
                jumpCooler = jumpTimer;
                if(shootCooler == 0)
                {
                    shoot();
                }
                shootCooler = shootTimer;
            }

            if (jump)
            {
                position.Y += jumpSpeed * jumpCooler;

                if (c > 0) c--;
                else if (c < 0) c = 0;
                else if (c == 0)
                {
                    c = d;

                    if (jumpCooler > 0) jumpCooler--;
                    else if (jumpCooler < 0) jumpCooler = 0;
                    else if (jumpCooler == 0)
                    {
                        jump = false;
                        jumpCooler = jumpTimer;
                        fallCooler = fallTimer;
                        multiplier = 0;
                        a = 0;
                    }
                }
            }
            else
            {
                if (startFall == false) return; //Dont do anything with fall if start fall isnt set to true
                if (canFall)
                {
                    if (fallCooler > 0) fallCooler--;
                    else if (fallCooler < 0) fallCooler = 0;
                    else if (fallCooler == 0)
                    {
                        if (a > 0) a--;
                        else if (a < 0) a = 0;
                        else if (a == 0)
                        {
                            a = b;
                            if(multiplier < maxMultiplier)
                                multiplier++;
                        }

                        position.Y += fallSpeed * multiplier;
                    }
                }
                else
                {

                }
            }

            position.X += speed; //And dont move until start
            updateCollition();
        }
        public int speed { get; set; }
        private void updateBullets()
        {
            foreach(var bullet in bullets)
            {
                bullet.Update();
            }
        }
        private void shoot()
        {
            bullets.Add(new Bullet(new Vector2(position.X + 30, position.Y + 30), new Rectangle(0, 0, 50, 50)));
        }
        private void updateCollition()
        {
            collictionRect.X = (int)position.X;
            collictionRect.Y = (int)position.Y;
        }
        public void Draw(SpriteBatch video, Texture2D texture, Texture2D hand, SpriteFont font, Texture2D t_bullet)
        {
            base.Draw(video, texture);

            foreach(var bullet in bullets)
            {
                bullet.Draw(video, t_bullet);
            }

            if (!startFall) video.Draw(hand, new Vector2(position.X - 275, position.Y + 275 + VisibleRect.Height));
            else video.DrawString(font, "SKOR: " + score, new Vector2(position.X - 50, 25), Color.White, 0f, new Vector2(), 7f, new SpriteEffects(), 0);
        }
    }
}
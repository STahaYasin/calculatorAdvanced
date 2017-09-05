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
using Microsoft.Xna.Framework.Input;
using Game9;

namespace Game9
{
    class Camera
    {
        public Matrix transform;
        Viewport view;
        Vector2 center;

        public float positie, positiex;
        public Camera(Viewport gameview)
        {
            view = gameview;
        }
        public void Update(Hero hero)
        {
            int ActualWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int ActualHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            int VirtualHeight = 1920;
            int VirtualWidth = 1080;
            var scalex = (float)ActualWidth / VirtualWidth;
            var scaleY = (float)ActualHeight / VirtualHeight;
            
            positiex = (int)(hero.Position.X * scalex) + (int)((hero.VisibleRect.Width / 2 - 420) * scalex);
            if (positiex > 0)
            {
                center = new Vector2(positiex, 0);

            }

            transform = Matrix.CreateScale(new Vector3(scalex, scaleY, 0)) *
                Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }

        public void Reset(Hero held)
        {

            center = new Vector2(0, 0);


            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }
    }
}
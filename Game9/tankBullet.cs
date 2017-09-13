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
    class tankBullet:Block
    {
        float moveX, moveY,rotation;
        Vector2 origin;
        Color color = Color.White;
        public tankBullet(Vector2 _position, Rectangle _visibleRect, float movementX, float movementY,float rot) : base(_position, _visibleRect)
        {
            moveX = movementX;
            moveY = movementY;
            rotation = rot;
         
        }

        public void Update(Rectangle visi)
        {
            position.X -= moveX;
            position.Y -= moveY;

            if (collictionRect.Intersects(visi))
            {
                color = Color.Red;
            }
            else color = Color.White;
        }
        public override void Draw(SpriteBatch video, Texture2D texture)
        {
            origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
            video.Draw(texture,position, VisibleRect,color , rotation, origin, 1, SpriteEffects.None, 0f);

        }
    }
}
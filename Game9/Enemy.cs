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
        Texture2D namlu, tank;
        Vector2 position;
        Rectangle visibleRect;
        public Enemy(Vector2 _position, Rectangle _visibleRect,Texture2D namlu, Texture2D tank)
        {
            this.namlu = namlu;
            this.tank = tank;
            position = _position;
            visibleRect = _visibleRect;
        }
        public void Draw(SpriteBatch video)
        {

        }
    }
}
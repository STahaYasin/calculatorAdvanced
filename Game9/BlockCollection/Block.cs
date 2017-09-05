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
    public abstract class Block
    {
        protected Vector2 position;
        public Vector2 Position { get { return position; } set { position = value; } }
        public Rectangle VisibleRect { get; set; }

        protected Rectangle collictionRect;

        public Rectangle CollitionRect()
        {
            return collictionRect;
        }

        public Block(Vector2 _position, Rectangle _visibleRect)
        {
            Position = _position;
            VisibleRect = _visibleRect;
            collictionRect = new Rectangle((int)position.X, (int)position.Y, VisibleRect.Width, VisibleRect.Height);
        }
        public virtual void Draw(SpriteBatch video, Texture2D texture)
        {
            video.Draw(texture, Position, VisibleRect, Color.White);
        }
    }
}
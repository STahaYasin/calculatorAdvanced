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

namespace Game9
{
    class Bullet : Block
    {
        public Bullet(Vector2 _position, Rectangle _visibleRect) : base(_position, _visibleRect)
        {
        }

        public void Update()
        {
            position.X += 15;
        }
    }
}
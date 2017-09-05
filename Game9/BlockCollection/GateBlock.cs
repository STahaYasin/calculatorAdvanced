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
    public class GateBlock : Block
    {
        public GateBlock(Vector2 _position, Rectangle _visibleRect) : base(_position, _visibleRect)
        {

        }
        public override void Draw(SpriteBatch video, Texture2D texture)
        {
            //base.Draw(video, texture); just dont draw :p
        }
    }
}
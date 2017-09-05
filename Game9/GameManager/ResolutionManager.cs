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
using Microsoft.Xna.Framework.Graphics;

namespace Game9
{
    class ResolutionManager
    {
        int Virtual;
        int actual;
        double scale;

        public ResolutionManager()
        {

        }
        public void Update()
        {
            actual = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Virtual = 1920;
            scale = (double)actual / (double)Virtual;
        }

        public double Scale
        {
            get { return scale; }
            set { scale = value; }
        }
    }
}
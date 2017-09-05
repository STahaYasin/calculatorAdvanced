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
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;

namespace Game9
{
    class TouchEventDetect
    {
        int touched = 0;
        int a = 0;
        ResolutionManager res;
        public TouchEventDetect()
        {
            res = new ResolutionManager();
        }
        public int checkTouch(TouchCollection touchCollection)
        {
            res.Update();
            if (touchCollection.Count > 0 && touchCollection[0].State == TouchLocationState.Pressed)
            {
                return 1;
            }
            return 0;
        }
    }
}
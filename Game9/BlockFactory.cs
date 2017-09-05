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
    static class BlockFactory
    {
        public static int BlockSize = 64;
        public static int BlockSizeHalf = BlockSize / 2;

        /*public static DrawingObject MakeBlockFromByte(byte option, Vector2 position, Rectangle visibleRect)
        {
            DrawingObject block = null;

            switch (option)
            {
                case 00: block = null; break;
                case 01: block = new Hero(position, visibleRect); break;
            }

            return block;
        }
        public static DrawingObject[] MakeBlockArrayFromByteArray(byte[] option)
        {
            throw new NotImplementedException();
        }
        public static DrawingObject[,] MakeBlockArrayFromByteArray(byte[,] option)
        {
            DrawingObject[,] block = new DrawingObject[option.GetLength(1), option.GetLength(0)];

            for(int x = 0; x < option.GetLength(0); x++)
            {
                for (int y = 0; y < option.GetLength(1); y++)
                {
                    Vector2 position = new Vector2(x * BlockSize, y * BlockSize);
                    Rectangle visibleRect = new Rectangle(0 * BlockSize, 0 * BlockSize, 1 * BlockSize, 1 * BlockSize);
                    block[x, y] = MakeBlockFromByte(option[x, y], position, visibleRect);
                }
            }

            return block;
        }*/
    }
}
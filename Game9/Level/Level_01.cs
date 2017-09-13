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
    class Level_01 : LevelManager
    {
        public override void makeByteList()
        {
            byteList = new List<byte[]>();

            addEmptyRows(5);

            for(int i = 0; i < 15; i++)
            {
                byte[] newArr = new byte[heightCount];
                int placeHolder = r.Next(1, newArr.Length - 3);

                for (int j = 0; j < newArr.Length; j++)
                {
                    if (j == placeHolder || j == placeHolder + 1 || j == placeHolder + 2) newArr[j] = 0;
                    else newArr[j] = 1;
                }

                byteList.Add(newArr);
                addEmptyRows(4);
            }
        }
        protected override void makeBlockList()
        {
            blockList = new List<Block[]>();

            addEmptyRows(10);

            for (int i = 0; i < 15; i++) //Aantal rijen die worden gemaakt tijdens het starten
            {
                makeRow();
            }
        }
        public override void addRow()
        {
            blockList.RemoveAt(0);
            makeRow();
        }
        private void makeRow()
        {
            Block[] newArr = new Block[heightCount];
            int placeHolder = r.Next(1, newArr.Length - 3);

            for (int j = 0; j < newArr.Length; j++)
            {
                int a = 0;

                if (j == placeHolder || j == placeHolder + 1 || j == placeHolder + 2) a = 0;
                else a = 1;

                Vector2 posHolder = new Vector2(lastPos * GameConf.BlockSize, j * GameConf.BlockSize);

                int y = 0;
                if (j == (placeHolder - 1)) y = 2;
                else if (j == (placeHolder + 3)) y = 0;
                else y = 1;

                Rectangle visHolder = new Rectangle(0, y * GameConf.BlockSize, GameConf.BlockSize, GameConf.BlockSize);

                switch (a)
                {
                    case 00: newArr[j] = new GateBlock(posHolder, visHolder); break;
                    case 01: newArr[j] = new StaticBlock(posHolder, visHolder); break;
                }
            }

            lastPos++;
            blockList.Add(newArr);
            addEmptyRows(4);
        }
        public override void addEmptyRows(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                //byteList.Add(new byte[heightCount]);
                blockList.Add(new Block[heightCount]);
                lastPos++;
            }
        }
    }
}
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
    public abstract class LevelManager
    {
        public int heightCount = 12;
        protected int lastPos = 0;
        protected Random r = new Random();
        protected List<byte[]> byteList;
        protected List<Block[]> blockList;
        public List<Block[]> getMap()
        {
            return blockList;
        }

        public LevelManager()
        {
            //this.makeByteList();
            this.makeBlockList();
            //this.convertToBlockList();
        }

        public abstract void makeByteList();
        protected abstract void makeBlockList();
        private void convertToBlockList()
        {
            blockList = new List<Block[]>();

            for(int x = 0; x < byteList.Count; x++)
            {
                Block[] newArr = new Block[byteList[x].Length];

                for(int y = 0; y < newArr.Length; y++)
                {
                    Vector2 posHolder = new Vector2(x * GameConf.BlockSize, y * GameConf.BlockSize);
                    Rectangle visHolder = new Rectangle(0, 0, 160, 160);

                    switch (byteList[x][y])
                    {
                        case 00: newArr[y] = null; break;
                        case 01: newArr[y] = new StaticBlock(posHolder, visHolder); break;
                    }
                }

                blockList.Add(newArr);
            }
        }
        public abstract void addRow();
        public virtual void Draw(SpriteBatch video, Texture2D texture, Texture2D wallpaper)
        {
            

            for(int i = 0; i < blockList.Count; i++)
            {
                for(int j = 0; j < blockList[i].Length; j++)
                {
                    if (blockList[i][j] == null) continue;
                    blockList[i][j].Draw(video, texture);
                }
            }
        }
    }
}
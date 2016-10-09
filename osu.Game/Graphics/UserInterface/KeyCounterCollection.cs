﻿//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Graphics.Containers;

namespace osu.Game.Graphics.UserInterface
{
    public class KeyCounterCollection : FlowContainer
    {
        public KeyCounterCollection()
        {
            Direction = FlowDirection.HorizontalOnly;
        }

        private List<KeyCounter> counters = new List<KeyCounter>();
        public IEnumerable<KeyCounter> Counters
        {
            get { return counters; }
            set
            {
                foreach (var k in value)
                    AddKey(k);
            }
        }

        public void AddKey(KeyCounter key)
        {
            counters.Add(key);
            key.IsCounting = this.IsCounting;
            key.FadeTime = this.FadeTime;
            key.KeyDownTextColor = this.KeyDownTextColor;
            key.KeyUpTextColor = this.KeyUpTextColor;
            base.Add(key);
        }

        public void ResetCount()
        {
            foreach (var counter in counters)
                counter.ResetCount();
        }

        public override bool Contains(Vector2 screenSpacePos) => true;

        //further: change default values here and in KeyCounter if needed, instead of passing them in every constructor
        private bool isCounting;
        public bool IsCounting
        {
            get { return isCounting; }
            set
            {
                if (value != isCounting)
                {
                    isCounting = value;
                    foreach (var child in counters)
                        child.IsCounting = value;
                }
            }
        }

        private int fadeTime = 0;
        public int FadeTime
        {
            get { return fadeTime; }
            set
            {
                if (value != fadeTime)
                {
                    fadeTime = value;
                    foreach (var child in counters)
                        child.FadeTime = value;
                }
            }
        }

        private Color4 keyDownTextColor = Color4.DarkGray;
        public Color4 KeyDownTextColor
        {
            get { return keyDownTextColor; }
            set
            {
                if (value != keyDownTextColor)
                {
                    keyDownTextColor = value;
                    foreach (var child in counters)
                        child.KeyDownTextColor = value;
                }
            }
        }

        private Color4 keyUpTextColor = Color4.White;
        public Color4 KeyUpTextColor
        {
            get { return keyUpTextColor; }
            set
            {
                if (value != keyUpTextColor)
                {
                    keyUpTextColor = value;
                    foreach (var child in counters)
                        child.KeyUpTextColor = value;
                }
            }
        }
    }
}
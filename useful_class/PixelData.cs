using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public struct PixelData
    {
        public byte blue;
        public byte green;
        public byte red;
        public byte alpha;

        public override string ToString()
        {
            return "(" + alpha.ToString() + ", " + red.ToString() + ", " + green.ToString() + ", " + blue.ToString() + ")";
        }
    }


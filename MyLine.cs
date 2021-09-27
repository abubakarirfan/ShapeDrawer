using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX, _endY;
        Line point;

        private Point2D _startPoint, _endPoint;
        public MyLine(Color clr, float startX, float startY, float endX, float endY) : base(clr)
        {
            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }

        // fix thiss
        public MyLine() : this(Color.Yellow, 0, 0, 250 , 100)
        {
        }

        public float EndX
        {
            get
            {
                return _endX;
            }
            set
            {
                _endX = value;
            }
        }
        public float EndY 
        {
            get
            {
                return _endY;
            }
            set
            {
                _endY = value;
            }
        }


        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }

            _startPoint.X = X;
            _startPoint.Y = Y;
            _endPoint.X = EndX;
            _endPoint.Y = EndY;


            point = SplashKit.LineFrom(_startPoint, _endPoint);
            SplashKit.DrawLine(Color, point);
        }

        public override void SaveTo(StreamWriter writer)
        {
            //writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(X);
            writer.WriteLine(Y);
            writer.WriteLine(EndX);
            writer.WriteLine(EndY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
            EndX = reader.ReadSingle();
            EndY = reader.ReadSingle();
        }


        public override void DrawOutline()
        {
            Color = Color.Black;
        }

        public override bool IsAt(Point2D pt)
        {
            
            if (SplashKit.PointOnLine(pt,point))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

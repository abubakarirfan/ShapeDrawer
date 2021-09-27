using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private static Dictionary<string, Type> _ShapeClassRegistry = new Dictionary<string, Type>();

        public static void RegisterShape(string name, Type t)
        {
            _ShapeClassRegistry[name] = t;
        }

        public static string GetKey(Type y)
        {
            foreach(string x in _ShapeClassRegistry.Keys)
            {
                if (_ShapeClassRegistry[x] == y)
                {
                    return x;
                }
            }
            return null;
        }


        public static Shape CreateShape(string name)
        {
            return (Shape)Activator.CreateInstance(_ShapeClassRegistry[name]);
        }

        private Color _color;
        private float _x, _y;

        private bool _selected;

        public Shape() : this (Color.Yellow)
        {   
        }

        public Shape(Color color)
        {
            _color = color;
        }


        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(GetKey(GetType()));
            writer.WriteColor(Color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        
        public virtual void LoadFrom(StreamReader reader)
        {
            Color = reader.ReadColor();
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
        }


        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        public abstract void DrawOutline();

        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);
        

    }
}

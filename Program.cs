using System;
using System.Collections.Generic;
using ShapeDrawer;
using SplashKitSDK;

public class Program
{
    private enum ShapeKind
    {
        Rectangle,
        Circle,
        Line
    }

    public static void Main()
    {
        Shape.RegisterShape("Rectangle", typeof(MyRectangle));
        Shape.RegisterShape("Circle", typeof(MyCircle));
        Shape.RegisterShape("Line", typeof(MyLine));

        new Window("Shape Drawer", 800, 600);

        ShapeKind kindToAdd = ShapeKind.Circle;

        Drawing myDrawing;

        myDrawing = new Drawing();

        do
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();

            
            myDrawing.Draw();

            if (SplashKit.KeyTyped(KeyCode.RKey))
            {
                kindToAdd = ShapeKind.Rectangle;
            }

            if (SplashKit.KeyTyped(KeyCode.CKey))
            {
                kindToAdd = ShapeKind.Circle;
            }

            if (SplashKit.KeyTyped(KeyCode.LKey))
            {
                kindToAdd = ShapeKind.Line;
            }

            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Shape newShape;

                if(kindToAdd == ShapeKind.Circle)
                { 
                    newShape = new MyCircle();
                }
                else if(kindToAdd == ShapeKind.Rectangle)
                {
                    newShape = new MyRectangle();
                }
                else
                {
                    newShape = new MyLine();
                }

                newShape.X = SplashKit.MouseX();
                newShape.Y = SplashKit.MouseY();
                myDrawing.AddShape(newShape);
            }

            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                myDrawing.Background = SplashKit.RandomRGBColor(255);
            }

            if (SplashKit.MouseClicked(MouseButton.RightButton))
            {
                myDrawing.SelectShapesAt(SplashKit.MousePosition());
            }

            if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
            {
                foreach (Shape s in myDrawing.SelectedShapes)
                {
                    myDrawing.RemoveShape(s);
                }
            }

            if (SplashKit.KeyTyped(KeyCode.SKey))
            {
                myDrawing.Save(@"E:\new\TestDrawing.txt");
            }

            if (SplashKit.KeyTyped(KeyCode.OKey))
            {
                try
                {
                    myDrawing.Load(@"E:\new\TestDrawing.txt");
                } catch (Exception e)
                {
                    Console.Error.WriteLine("Error loading file: {0}", e.Message);
                }
                
                
            }

            SplashKit.RefreshScreen();
        } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
    }
}

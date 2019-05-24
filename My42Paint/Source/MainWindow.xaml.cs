﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace My42Paint
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private enum MyShape
        {
            Rectangle,
            Ellipse,
            Line
        }

        private MyShape _currentShape = MyShape.Line;
        private Point _start;
        private Point _end;
        public MainWindow()
        {
            InitializeComponent();
        }

        //Select the shape used by user
        private void EllipseButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentShape = MyShape.Ellipse;
        }

        //Select the shape used by user
        private void LineButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentShape = MyShape.Line;
        }

        //Select the shape used by user
        private void RectangleButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentShape = MyShape.Rectangle;
        }

        //Get the position of the mouse when the user press the left button mouse and get the position
        private void DrawingSheet_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _start = e.GetPosition(this);
        }

        //Create and add a line oject to the canvas to draw a line
        private void DrawLine()
        {
            var line = new Line
            {
                Stroke = Brushes.Black,
                StrokeThickness = 3,
                X1 = _start.X,
                X2 = _end.X,
                Y1 = _start.Y - 50,
                Y2 = _end.Y - 50
            };
            DrawingSheet.Children.Add(line);
        }

        //Create and add a rectangle oject to the canvas to draw a rectangle
        private void DrawRectangle()
        {
            var rectangle = new Rectangle
            {
                Stroke = Brushes.Black,
                StrokeThickness = 3,
                
            };
            if (_end.X >= _start.X)
            {
                rectangle.SetValue(Canvas.LeftProperty, _start.X);
                rectangle.Width = _end.X - _start.X;
            }
            else
            {
                rectangle.SetValue(Canvas.LeftProperty, _end.X);
                rectangle.Width = _start.X - _end.X;
            }
            if (_end.Y >= _start.Y)
            {
                rectangle.SetValue(Canvas.TopProperty, _start.Y - 50);
                rectangle.Height = _end.Y - _start.Y;
            }
            else
            {
                rectangle.SetValue(Canvas.TopProperty, _end.Y - 50);
                rectangle.Height = _start.Y - _end.Y;
            }
            DrawingSheet.Children.Add(rectangle);
        }

        //Create and add a ellipse oject to the canvas to draw a ellipse
        private void DrawEllipse()
        {
            var ellipse = new Ellipse
            {
                Stroke = Brushes.Black,
                StrokeThickness = 3,
                Height = 10,
                Width = 10
            };
            if (_end.X >= _start.X)
            {
                ellipse.SetValue(Canvas.LeftProperty, _start.X);
                ellipse.Width = _end.X - _start.X;
            }
            else
            {
                ellipse.SetValue(Canvas.LeftProperty, _end.X);
                ellipse.Width = _start.X - _end.X;
            }
            if (_end.Y >= _start.Y)
            {
                ellipse.SetValue(Canvas.TopProperty, _start.Y - 50);
                ellipse.Height = _end.Y - _start.Y;
            }
            else
            {
                ellipse.SetValue(Canvas.TopProperty, _end.Y - 50);
                ellipse.Height = _start.Y - _end.Y;
            }
            DrawingSheet.Children.Add(ellipse);
        }

        //Draw the shape selected once the mouse left button is release
        private void DrawingSheet_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (_currentShape)
            {
                case MyShape.Line:
                    DrawLine();
                    break;
                case MyShape.Rectangle:
                    DrawRectangle();
                    break;
                case MyShape.Ellipse:
                    DrawEllipse();
                    break;
                default:
                    return;
            }
        }

        // Define the postion of the end of the drawing by getting 
        //the position of the mouse on the canvas when she is moving
        private void DrawingSheet_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _end = e.GetPosition(this);
            }
        }
    }
}

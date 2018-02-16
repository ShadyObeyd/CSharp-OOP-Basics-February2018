public class Rectangle
{
    public string Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double X { get; set; }
    public double Y { get; set; }

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.X = x;
        this.Y = y;
    }

    public bool Intersects(Rectangle rectangle)
    {
        if (rectangle.Y >= Y && rectangle.Y - rectangle.Height <= Y && rectangle.X <= X && rectangle.X + rectangle.Width >= X)
        {
            return true;
        }
        else if (rectangle.Y >= Y && rectangle.Y - rectangle.Height <= Y && rectangle.X >= X && rectangle.X <= X + Width)
        {
            return true;
        }
        else if (rectangle.Y <= Y && rectangle.Y >= Y - Height && rectangle.X <= X && rectangle.X + rectangle.Width >= X)
        {
            return true;
        }
        else if (rectangle.Y <= Y && rectangle.Y >= Y - Height && rectangle.X >= X && rectangle.X <= X + Width)
        {
            return true;
        }
        return false;
    }
}
using Godot;


public class Main : Label
{
    public override void _Ready()
    {
        GD.Print("Hello World!");
    }
    
    public int AddValues(int a, int b)
    {
        return a + b;
    }
}

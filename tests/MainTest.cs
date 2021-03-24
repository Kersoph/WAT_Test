using Godot;


public class MainTest : WAT.Test
{
    public override string Title()
    {
        return "Checks the main node";
    }
    
    [Test]
    public void IsLabel()
    {
        Main mainNode = new Main();
        Assert.IsType<Label>(mainNode);
        mainNode.Free();
    }
    
    [Test]
    public void CheckAdd()
    {
        Main mainNode = new Main();
        int result = mainNode.AddValues(2, 2);
        Assert.IsEqual(result, 4, "2 + 2 = 4"); 
        mainNode.Free();
    }
}

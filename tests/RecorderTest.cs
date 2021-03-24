using Godot;
using System;
using System.Threading.Tasks;
using Godot.Collections;

public class Hero : Node 
{
	public int Health = 100;
	
	public Hero()
	{
		
	}
}

public class Poison : Node
{
	public Hero Who;
	
	public Poison(Hero who)
	{
		Who = who;
		Who.AddChild(this);
	}
	
	public override void _Process(float delta)
	{
		if(Who != null && Who.Health > 0) 
		{ 
			Who.Health -= 1;
		}
	}
}

public class RecorderTest : WAT.Test
{
	public override String Title()
	{
		return "Recorder Test";
	}
	
	[Test]
	public async void WhenAHeroIsPoisonedTheirHealthChangesOverTime()
	{
		Hero _Hero = new Hero();
		Godot.Collections.Array Properties = new Godot.Collections.Array();
		Properties.Add("Health");
		Poison poison = new Poison(_Hero);
		WAT.Recorder recorder = Record(_Hero, Properties);
		AddChild(_Hero);
		recorder.Start();
		await ToSignal(UntilTimeout(1.0F), YIELD);
		recorder.Stop();
		Array<int> Health = new Array<int>(recorder.GetPropertyTimeline("Health"));
		Assert.IsLessThan(Health[Health.Count-1], Health[0]);
		
		RemoveChild(_Hero);
		_Hero.Free();
	}
	
	[Test]
	public void WhenAHeroIsPoisonedTheirHealthIs0After100Cycles()
	{
		Hero _Hero = new Hero();
		Poison _Poison = new Poison(_Hero);
		Simulate(_Hero, 100, 0.1F);
		
		Assert.IsEqual(0, _Hero.Health);
	}
}

using Godot;
using System;

public class ParameterizedTest : WAT.Test
{
	public override String Title()
	{
		return "Given The Addition Operator (Parameter Tests)";
	}
	
	[Test]
	[RunWith(2, 2, 4)]
	[RunWith(5, 3, 8)]
	[RunWith(7, 6, 13)]
	public void Add(int Addend, int Augend, int Result)
	{
		Describe(String.Format("When we add {0} to {1} we get {2}", Addend, Augend, Result));
		
		Assert.IsEqual(Result, Addend + Augend);
	}
}



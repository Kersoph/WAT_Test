using Godot;
using System;

public class FileTest : WAT.Test
{
	
	[Test]
	public void ThisFileExists()
	{
		Assert.FileExists("res://tests/basics/FileTest.cs");
	}
	
	[Test]
	public void ImaginaryFileDoesNotExist()
	{
		Assert.FileDoesNotExist("res://somefile.gd");
	}
	
	[Test]
	public void EmptyPathDoesNotExist()
	{
		Assert.FileDoesNotExist("");
	}
}

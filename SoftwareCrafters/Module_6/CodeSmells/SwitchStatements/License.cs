namespace SoftwareCrafters.Module_6.CodeSmells.SwitchStatements;

public class License
{
	private readonly int points;

	public License(int points) => this.points = points;

	public int Points => points;
}
using FluentAssertions;

namespace Tests.SoftwareCrafters.Module_1;

/*
* The dummies are objects that our SUT depends on, but they are never used.
* We don’t care about them because they are irrelevant to the test scope.
*/

public interface IDummy
{
    public void IrrelevantMethod();
}

public static class Dummy
{
    private static string output = "something";

    public static string Format(IDummy dummy)
    {
        // "IDummy" won't interfere in the expected result.
        dummy.IrrelevantMethod();

        return output;
    }
}

public class DummyTest
{
    public void Format()
    {
        // Notice as the parameter is irrelevant.
        var result = Dummy.Format(null);

        result.Should().Be("something");
    }
}
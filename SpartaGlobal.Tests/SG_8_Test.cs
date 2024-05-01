namespace SpartaGlobal.Tests;

public class SG_8_Test
{
    /*  ==================================== Test Case Contents =======================================
     *
     *  1 - Test Addition Operation
     *  2 - Test Subtraction Operation
     *  3 - Test Multiplication Operation
     *  4 - Test Division Operation
     *  5 - Test Division Operation for Exception (Zero Dividend)
     *  6 - Test Power Operation
     *  7 - Test Power Operation for Exception (Zero Dividend)
     *  8 - Test Square Root Operation
     *  9 - Test Square Root Operation for Exception (Zero Dividend)
     */

    [TestCase(0, 0, 0)]
    [TestCase(1, 1, 2)]
    [TestCase(-1, -4, -5)]
    [TestCase(5, -4, 1)]
    [TestCase(0.1, 0.19, 0.29)]
    public void Addition_ReturnsCorrectResult(decimal num1, decimal num2, decimal expected)
    {
        Assert.That(SG_8.Addition(num1, num2), Is.EqualTo(expected));
    }

    [TestCase(0, 0, 0)]
    [TestCase(1, 5, -4)]
    [TestCase(-1, -4, 3)]
    [TestCase(5, -4, 9)]
    [TestCase(0.1, 0.19, -0.09)]
    public void Subtraction_ReturnsCorrectResult(decimal num1, decimal num2, decimal expected)
    {
        Assert.That(SG_8.Subtraction(num1, num2), Is.EqualTo(expected));
    }

    [TestCase(0, 0, 0)]
    [TestCase(1, 5, 5)]
    [TestCase(-1, -4, 4)]
    [TestCase(5, -4, -20)]
    [TestCase(0.1, 0.19, 0.019)]
    public void Multiplication_ReturnsCorrectResult(decimal num1, decimal num2, decimal expected)
    {
        Assert.That(SG_8.Multiplication(num1, num2), Is.EqualTo(expected));
    }

    [TestCase(1, 5, .2)]
    [TestCase(-1, -4, 0.25)]
    [TestCase(5, -4, -1.25)]
    [TestCase(0.1, 0.5, 0.2)]
    public void Division_ReturnsCorrectResult(decimal num1, decimal num2, decimal expected)
    {
        Assert.That(SG_8.Division(num1, num2), Is.EqualTo(expected));
    }

    [TestCase(0.1, 0)]
    public void Division_ThrowsAnException(decimal num1, decimal num2)
    {
        Assert.That(() => SG_8.Division(num1, num2), Throws.TypeOf<Exception>()
            .With.Message.Contains("Cannot divide by Zero!"));
    }

    [TestCase(0, 2, 0)]
    [TestCase(12, 0, 1)]
    [TestCase(5, 2, 25)]
    [TestCase(-5, -2, 0.04)]
    [TestCase(10, -2, 0.01)]
    [TestCase(0.25, 0.25, 0.7071067812)]
    public void Power_ReturnsCorrectResult(double num1, double num2, double expected)
    {
        var result = Math.Round(SG_8.Power(num1, num2), 2);
        var expectedResult = Math.Round(expected, 2);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(0, 0)]
    [TestCase(0, -2)]
    public void Power_ThrowsAnException(double num1, double num2)
    {
        Assert.That(() => SG_8.Power(num1, num2), Throws.TypeOf<Exception>()
            .With.Message.Contains("Cannot divide by Zero!"));
    }

    [TestCase(0, 0)]
    [TestCase(25, 5)]
    [TestCase(0.25, 0.5)]
    public void SquareRoot_ReturnsCorrectResult(double num1, double expected)
    {
        Assert.That(Math.Round(SG_8.Sqrt(num1), 5), Is.EqualTo(Math.Round(expected, 5)));
    }

    [TestCase(-1)]
    [TestCase(-10)]
    public void SquareRoot_ThrowsAnException(double num1)
    {
        Assert.That(() => SG_8.Sqrt(num1), Throws.TypeOf<Exception>()
            .With.Message.Contains("Cannot Square Root a negative number!"));
    }
}
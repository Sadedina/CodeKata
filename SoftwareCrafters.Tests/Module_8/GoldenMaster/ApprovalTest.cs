﻿using System.Text;

namespace SoftwareCrafters.Tests.Module_8.GoldenMaster;

#region Original
//namespace SoftwareCrafters.Tests.Module_8
//{
//    [TestFixture]
//    public class ApprovalTest
//    {
//        [Test]
//        public void ThirtyDays()
//        {
//            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ThirtyDays.txt");

//            var referenceLines = File.ReadAllLines(filePath);

//            var fakeoutput = new StringBuilder();
//            Console.SetOut(new StringWriter(fakeoutput));
//            Console.SetIn(new StringReader("\n"));

//            Program.Main(new string[] { });
//            var output = fakeoutput.ToString();

//            var outputLines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

//            for (var i = 0; i < Math.Min(referenceLines.Length, outputLines.Length); i++)
//            {
//                Assert.That(referenceLines[i], Is.EqualTo(outputLines[i]));
//            }
//        }
//    }
//}
#endregion
public class ApprovalTest
{
    [Test]
    public void ThirtyDays()
    {
        var directory = Environment.CurrentDirectory.Split("bin").First();
        var filePath = Path.Combine(directory, "Module_8\\GoldenMaster", "ThirtyDays.txt");

        var referenceLines = File.ReadAllLines(filePath);

        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));
        Console.SetIn(new StringReader("\n"));

        Program.Print();
        var output = fakeoutput.ToString();

        var outputLines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        for (var i = 0; i < Math.Min(referenceLines.Length, outputLines.Length); i++)
        {
            Assert.That(referenceLines[i], Is.EqualTo(outputLines[i]));
        }
    }
}
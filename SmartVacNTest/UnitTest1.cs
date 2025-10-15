using RobotCleaner;
using NUnit.Framework;
namespace SmartVacNTest;

public class SmartVacuumTest
{
    [Test]
    public void SpiralTest()
    {
        {
            // ### 1. ARRANGE ###
            var map = new Map(5, 5);
            var strategy = new SpiralStrategy();
            var robot = new Robot(map, strategy);

            robot.X = 2;
            robot.Y = 2;

            map.AddDirt(2, 2);
            map.AddDirt(3, 2);
            map.AddDirt(1, 1);
            map.AddDirt(0, 0);
            map.AddDirt(4, 4);

            // ### 2. ACT ###
            robot.StartCleaning();

            // ### 3. ASSERT (Using NUnit Constraint Syntax) ###
            Assert.That(map.IsDirt(2, 2), Is.False);
            Assert.That(map.IsDirt(3, 2), Is.False);
            Assert.That(map.IsDirt(1, 1), Is.False);
            Assert.That(map.IsDirt(0, 0), Is.False);
            Assert.That(map.IsDirt(4, 4), Is.False);

            Assert.That(robot.X, Is.EqualTo(4));
            Assert.That(robot.Y, Is.EqualTo(0));
        }
    }
}

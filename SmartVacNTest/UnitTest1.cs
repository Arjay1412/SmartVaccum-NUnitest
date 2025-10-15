using RobotCleaner;

namespace SmartVacNTest;

public class SmartVacuumTest
{
    [Test]
    public void SpiralTest()
    {
            {
            // ### 1. ARRANGE ###
            var map = new Map(5, 5);
            var strategy = new SpriralStrategy();
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
            Assert.That(map.IsDirt(2, 2), Is.False, "Center dirt at (2,2) should be cleaned.");
            Assert.That(map.IsDirt(3, 2), Is.False, "Inner spiral dirt at (3,2) should be cleaned.");
            Assert.That(map.IsDirt(1, 1), Is.False, "Inner spiral dirt at (1,1) should be cleaned.");
            Assert.That(map.IsDirt(0, 0), Is.False, "Corner dirt at (0,0) should be cleaned.");
            Assert.That(map.IsDirt(4, 4), Is.False, "Corner dirt at (4,4) should be cleaned.");

            Assert.That(robot.X, Is.EqualTo(4), "Robot's final X position should be 4.");
            Assert.That(robot.Y, Is.EqualTo(0), "Robot's final Y position should be 0.");
        }
    }
}

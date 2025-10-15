using RobotCleaner;

namespace SmartVacNTest;

public class SmartVacuumTest
{

    [Test]
    public void Test1()
    {
            // ### 1. ARRANGE ###
            // CreateD a small, predictable map and the strategy to be tested.
            var map = new Map(5, 5);
            var strategy = new PerimeterHuggerStrategy();
            var robot = new Robot(map, strategy);

            // Place dirt on the path the robot will travel (the perimeter).
            map.AddDirt(2, 0); // Top edge
            map.AddDirt(4, 3); // Right edge
            map.AddDirt(1, 4); // Bottom edge
            map.AddDirt(0, 2); // Left edge

            // Place dirt in the center, which this strategy should NOT clean.
            map.AddDirt(2, 2);

            // ### 2. ACT ###

            robot.StartCleaning();

            // ### 3. ASSERT ###
            // Verify that the outcome is what we expect.

            // Check that all the dirt on the perimeter has been cleaned.
            Assert.That(map.IsDirt(2, 0), Is.False);
            Assert.That(map.IsDirt(4, 3),  Is.False);
            Assert.That(map.IsDirt(1, 4),  Is.False);
            Assert.That(map.IsDirt(0, 2),  Is.False);

            // Crucially, check that the dirt in the middle was IGNORED.
            Assert.That(map.IsDirt(2, 2),  Is.True);
        }
}

using RobotCleaner;
namespace SmartVacNTest;

public class SmartVacuumTests
{

    [Test]
        public void SomeStrategy_SnakePattern()
        {
            // ### 1. ARRANGE ###

            // Create a small 3x3 map to test the snake-like path.
            var map = new Map(3, 3);
            var strategy = new SomeStrategy();
            var robot = new Robot(map, strategy);

            // Place dirt in a few key locations to verify they are cleaned.
            map.AddDirt(0, 0); // Starting point
            map.AddDirt(2, 0); // End of the first row (rightward)
            map.AddDirt(2, 1); // Start of the second row (leftward)
            map.AddDirt(0, 2); // End of the third row (rightward)

            // ### 2. ACT ###

            // Run the cleaning process.
            robot.StartCleaning();

            // ### 3. ASSERT ###

            // Assert that all the dirt spots have been cleaned.
            Assert.That(map.IsDirt(0, 0), Is.False, "Dirt at (0,0) should be cleaned.");
            Assert.That(map.IsDirt(2, 0), Is.False, "Dirt at (2,0) should be cleaned.");
            Assert.That(map.IsDirt(2, 1), Is.False, "Dirt at (2,1) should be cleaned.");
            Assert.That(map.IsDirt(0, 2), Is.False, "Dirt at (0,2) should be cleaned.");

            // Assert the robot's final position.
            // The final position should be (2, 2).
            Assert.That(robot.X, Is.EqualTo(2), "Final X position should be 2.");
            Assert.That(robot.Y, Is.EqualTo(2), "Final Y position should be 2.");
        }

        [Test]
        public void SomeStrategy_AvoidsObstacles()
        {
            // ### 1. ARRANGE ###
            var map = new Map(3, 3);
            var strategy = new SomeStrategy();
            var robot = new Robot(map, strategy);

            // Place an obstacle in the middle of the path.
            map.AddObstacle(1, 1);
            // Place dirt before and after the obstacle.
            map.AddDirt(0, 1);
            map.AddDirt(2, 1);


            // ### 2. ACT ###
            robot.StartCleaning();

            // ### 3. ASSERT ###

            // The robot should clean the dirt but the obstacle remains.
            Assert.That(map.IsDirt(0, 1), Is.False, "Dirt before obstacle should be cleaned.");
            Assert.That(map.IsDirt(2, 1), Is.False, "Dirt after obstacle should be cleaned.");
            Assert.That(map.IsObstacle(1, 1), Is.True, "Obstacle should still be present.");
            
            // The robot's final position should be (2,2) as it completes the path.
            Assert.That(robot.X, Is.EqualTo(2));
            Assert.That(robot.Y, Is.EqualTo(2));
    }
}

# Running and Testing the Smart Vacuum Program
## 1. To Run the Visual Simulation

In this mode, you want to see the robot's movement. You must **enable** the console display methods.

### Steps:

1.  Open the `Program.cs` file.
2.  Navigate to the `Robot` class.
3.  Ensure the `_map.Display(X, Y);` lines inside `Move()` and `CleanCurrentSpot()` are **uncommented**.

    ```csharp
    // File: Program.cs (inside the Robot class)

    public bool Move(int newX, int newY)
    {
      if( _map.IsInBounds(newX, newY) && !_map.IsObstacle(newX, newY) )
      {
        X = newX;
        Y = newY;
        _map.Display(X, Y); // <--- MUST BE UNCOMMENTED
          return true;
      }
      return false;
    }

    public void CleanCurrentSpot()
    {
      if(_map.IsDirt(X, Y))
      {
        _map.Clean(X, Y);
        _map.Display(X, Y); // <--- MUST BE UNCOMMENTED
      }
    }
    ```

4.  Execute the program from your terminal:

    ```bash
    dotnet run
    ```

---

## 2. To Run the NUnit Tests

In this mode, you are only testing logic, not visuals. You must **disable** the console display methods to prevent crashes.

### Steps:

1.  Open the `Program.cs` file.
2.  Navigate to the `Robot` class.
3.  Ensure the `_map.Display(X, Y);` lines inside `Move()` and `CleanCurrentSpot()` are **commented out**.

    ```csharp
    // File: Program.cs (inside the Robot class)

    public bool Move(int newX, int newY)
    {
      if( _map.IsInBounds(newX, newY) && !_map.IsObstacle(newX, newY) )
      {
        X = newX;
        Y = newY;
        //_map.Display(X, Y); // <--- MUST BE COMMENTED OUT
          return true;
      }
      return false;
    }

    public void CleanCurrentSpot()
    {
      if(_map.IsDirt(X, Y))
      {
        _map.Clean(X, Y);
        //_map.Display(X, Y); // <--- MUST BE COMMENTED OUT
      }
    }
    ```

4.  Execute the tests from your terminal:

    ```bash
    dotnet test
    ```

---


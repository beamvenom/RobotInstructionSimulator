# RobotInstructionSimulator

In this project you can control a robot on a field using specific robot instructions. Once you are done, you get a result whether your robot is inside the field or not.

The project is formed like this:
A simulation has requires a robot and a field. Both of these have their own respective Factory class that produces them. However, the FieldFactory also inherits from an abstract class called CachedFactory. The point of this CachedFactory class, is to cache the products that FieldFactory creates. This will be needed in the future as FieldFactory creates products that will be both money and time costly since it will need to connect to a service from a cloud service provider.(e.g. AWS Lambda or DynamoDB).

The reason for using an abstract factory pattern to create this project is to potentially expand on it by connecting it to the cloud and also creating an API to control a simulation. By using an abstract factory pattern, it makes implementing new robots or fields easier since they are loosely coupled. Testing becomes easier as you can single out specific functions since parts can be swapped out for mocks. Although it takes a bit of time to set up the infrastructure, the end result is a project where you could easily add new features. For example: 

Adding a new robot is just to add another class and make the factory class use it. The same goes with the Field class.

Add more commands like rotating the field instead of the robot by modifying or creating a new class that inherits from the abstract Field class. 

Change the binary form of the commands to JSON(for example when controlling it through an API) by just changing the robot class. 

There are of course negatives of using the abstract factory pattern, and one obvious one is if not done correctly, could make the project very complicated and hard to follow. Although this pattern makes it possible to mock things you couldn't before(mocking factories to save time), that in itself requires complex understanding of testing as the project becomes more complicated. 

## Built With

* [C# (.NET 6)](https://visualstudio.microsoft.com)

## Installation

Download [Visual studio 2022](https://visualstudio.microsoft.com/downloads)

## Usage

Open the .sln file with [Visual studio 2022](https://visualstudio.microsoft.com/downloads) and run program.cs.
There are currently 2 Robots(Robot90 and Robot45) and 2 Fields(Rectangle and RightTriangle).

## Running the tests 

Run the simulation tests. However, the "CachedFactoryTests" should be run separately and individually. This is because it is testing the static cache which can affected the result as it is not isolated.

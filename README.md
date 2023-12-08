# SOLID Principles Reference

## 1. Single Responsibility Principle (SRP)

**Definition:**
A class should have only one reason to change, focusing on a single responsibility or job.

**Guidelines:**
- Each class should represent a single concept or responsibility.

**Real-life Example:**
Consider a class managing employee information and file operations. Following SRP, separate them into two classes: one for employee management and another for file operations.

## 2. Open/Closed Principle (OCP)

**Definition:**
Software entities should be open for extension but closed for modification, allowing new functionality without altering existing code.

**Guidelines:**
- Use abstractions and interfaces to allow extension.
- Create new classes for adding features instead of modifying existing ones.

**Real-life Example:**
Extend a class through inheritance or implement new interfaces to introduce additional functionality without changing the original code.

## 3. Liskov Substitution Principle (LSP)

**Definition:**
Objects of a superclass should be replaceable with objects of a subclass without affecting program correctness.

**Guidelines:**
- Ensure subclasses can be used interchangeably with their base class.

**Real-life Example:**
In a shape class hierarchy, any subclass (e.g., Circle, Square) should be substitutable without causing issues in the program's logic.

## 4. Interface Segregation Principle (ISP)

**Definition:**
A class should not be forced to implement interfaces it does not use, and clients should not depend on interfaces they do not use.

**Guidelines:**
- Split large interfaces into smaller ones based on functionality.

**Real-life Example:**
If not all printer classes need to support color printing, separate the printer interface into one for basic printing and another for color printing.

## 5. Dependency Inversion Principle (DIP)

**Definition:**
High-level modules should not depend on low-level modules. Both should depend on abstractions, and abstractions should not depend on details.

**Guidelines:**
- Depend on abstractions (interfaces) rather than concrete implementations.

**Real-life Example:**
Instead of a high-level module depending on specific database details, depend on an abstraction (database interface) to allow flexibility in using different database implementations.

===================================================================================================
# Design Patterns
Design patterns are solutions to recurring problems; guidelines on how to tackle certain problems.
I have included implementations of some design patterns in C# to help beginners like me get their feet wet.
There are better alternatives available for some of them in the .NET Framework, so this is by no means a comprehensive tutorial.

Any comments and suggestions are welcome. If you want to add a new design pattern implementation, just follow the naming convention, fork my repo and submit a pull request. Same goes for any improvements and modifications.


## Types of Design Patterns
---------------------------
There are three kinds of Design Patterns:

* Creational
* Structural
* Behavioral

## List of Design Pattern Implementations
-----------------------------------------

* [SOLID](/DesignPatterns/SOLID)
* Creational - [Builder](/DesignPatterns/CreationalPatterns/Builder)
* Creational - [Factory](/DesignPatterns/CreationalPatterns/Factory)

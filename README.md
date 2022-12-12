# DesignPatterns

Notes for different design patterns in programming. This aplies to almost any language but I am focusing on C# and .NET.

## SOLID Design Principles

- Introduced by Robert C. Martin (aka: Uncle Bob)

> See Projects with related names for a code example. I am keeping all code in one file on purpose. To keep projects in groups and keep things simple for demonstration.

1. Single Responsibility

	- A single class should have one reason to change

2. Open-Closed Principle

	- Open for extension closed for modification
	- we shouldn't need to modify existing code. we can use inheritence, with interfaces
	- in our code we get asked to add more filters on a products page. We are going to use the "Specification Pattern" (not gang of four but considered an enterprise pattern).

3. Liskov Substitution Principle

	- which describes the fundamental nature of data abstraction, and is used in type theory (see subtyping) and in object-oriented programming (see inheritance).
	Her work was recognized with the 2008 Turing Award, the highest distinction in computer science. (named after [Barbara Liskov](https://en.wikipedia.org/wiki/Barbara_Liskov))

	- we should be able to substitute a base type for a sub type.

4. Interface Segregation Principle

5. Dependency Inversion Principle

### Creational

	- Builder

	- Factories

		a. Abstract Factory

		b. Factory Method

	- Prototype

	- Singleton

### Structual

	- Adapter

	- Bridge

	- Composite

	- Decorator

	- Facade

	- Flyweight

	- Proxy

### Behavioral

	- Chain of Responsibility

	- Command

	- Interpreter

	- Iterator

	- Mediator

	- Memento

	- Null Object

	- Observer

	- State

	- Strategy

	- Template Method

	- Visitor
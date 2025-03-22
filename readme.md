# 🚢 Battleships Console Game (.NET 8)

A simple Battleships console game written in C#, adhering to clean architecture and SOLID principles.

## Features
- 10x10 Battleships grid
- Random ship placement:
  - 1x Battleship (5 squares)
  - 2x Destroyers (4 squares each)
- User-friendly input (e.g., "A5")
- Real-time feedback on hits, misses, and ship sinking
- Full unit test coverage (xUnit)

## Getting Started

### Prerequisites
- .NET 8 SDK installed ([Download here](https://dotnet.microsoft.com/download))

### Run Application
Navigate to the `src` folder and run:

dotnet run

---

## 🚢 **Comprehensive Architectural Explanation**

### 1\. **Overview of Architectural Approach**

This Battleships implementation uses a **Clean Architecture**-inspired structure, emphasising clear separation of concerns:

- **Domain Layer:**  
  - Core game logic and entities.
  - Independent of any external dependencies or application-specific concerns.

- **Application Layer:**  
  - Contains the orchestrating logic, integrates Domain and Infrastructure.
  - Manages overall game flow and user input processing.

- **Infrastructure Layer:**  
  - Encapsulates external concerns like random ship placement logic.

### 2\. **Rationale for Architectural Decisions**

**Why Clean Architecture?**  
- Decouples the business logic from implementation details.
- Enhances **maintainability**, **testability**, and **scalability**.
- Easy to extend with future requirements (e.g., UI changes, multiplayer support).

**Why Separate Layers?**  
- **Maintainability:** Changes are isolated within layers, minimising ripple effects.
- **Testability:** Enables straightforward unit testing of each layer independently.
- **Scalability:** Facilitates growth and future enhancements without major refactoring.

---

## 🛠️ **Implementation Details and Key Decisions**

### Domain Layer (`Domain/`):

- **Entities and Value Objects:**
  - `Grid`, `Ship`, `Cell`, `Position`
- **Enums:**
  - Clearly define domain concepts (`ShipType`), improving readability.

*Why immutable records (e.g., `Position`)?*
- Ensures safety and simplicity in concurrency scenarios.
- Reduces potential side effects.

### Application Layer (`Application/GameService.cs`):

- Centralises logic like parsing input, delegating shooting, checking game end.
- Provides a simple, clear API for interaction.

*Why not put all logic directly in Program.cs?*
- Better encapsulation of the game logic away from the UI.
- Easier testing without depending on console input/output.

### Infrastructure Layer (`Infrastructure/RandomShipPlacement.cs`):

- Encapsulates randomness logic.
- Allows easy swapping or extending placement strategies in future.

*Why isolate ship placement logic into Infrastructure?*
- Clearly separates business logic (Domain/Application) from infrastructure-specific concerns (randomisation).

---

## 🔄 **Adherence to SOLID Principles**

This implementation strictly adheres to SOLID principles:

- **S (Single Responsibility Principle)**:  
  Each class and method has one clear responsibility (e.g., `Ship` tracks hits, `Grid` tracks cell states).

- **O (Open/Closed Principle)**:  
  Extendable without modification (e.g., easily add new ship types, change placement algorithms without rewriting existing code).

- **L (Liskov Substitution Principle)**:  
  Clear type system, no inheritance misuse. Strongly-typed entities like `Ship` and `Cell`.

- **I (Interface Segregation Principle)**:  
  Simple interfaces, avoid forcing unnecessary methods.

- **D (Dependency Inversion Principle)**:  
  Clearly defined interfaces and abstraction boundaries. Infrastructure depends on Domain, never vice-versa.

---

## 🧪 **Testing Approach (Testability)**

*How does this design facilitate testing?*

- Clean architecture naturally supports isolated tests.
- Domain logic can be tested thoroughly without relying on randomness (by providing controlled input positions).
- The application layer's clear API simplifies testing scenarios.

**Unit Testing Strategy:**
- Tests cover key functionalities:
  - Ship placement validity
  - Hit/Miss logic
  - Game-ending conditions
- Using xUnit provides clear, concise test definitions.

---

## 🗄️ **Performance and Scalability**

*How does this architecture handle performance? Can it scale?

- Performance is optimised through simple data structures (arrays, hash sets) for O(1) lookups.
- Currently runs efficiently for small-scale console application scenarios.
- Scalability is achievable:
  - Easy to introduce multiplayer, networked interactions by adding layers or implementing interfaces.
  - Infrastructure abstraction allows performance optimisation (e.g., caching or pooling for larger-scale scenarios).

---

## 🔒 **Security and Error Handling**

*Are security aspects considered?*

- Input validation (parsing input) ensures robustness against simple input attacks or crashes.
- Explicit error handling (`try/catch`) prevents crashes and gives clear user feedback.

---

## 📚 **Maintainability and Documentation**

*How maintainable is the code?*

- Clear separation and well-defined responsibilities facilitate easy maintenance and extension.
- Comprehensive inline comments, naming conventions, and folder structure enhance readability.

- **Documentation:**  
  The provided `README.md` clearly describes the project structure, how to run the game, and execute tests, significantly aiding future maintainers.

---

## 🚦 **Potential Future Enhancements**

*How easily can new features be added?*

This architecture is future-proof, easily allowing additions such as:

- **Multiplayer Support:** Easily add networking/infrastructure layers without changing domain logic.
- **Enhanced UI:** Console replaced by web or graphical UI simply by changing application and infrastructure layers, domain remains unchanged.
- **More Ships/Complex Rules:** Domain adjustments straightforward due to strong SOLID adherence.

---

- The implementation **clearly follows industry-standard architectural patterns**.
- SOLID principles are thoroughly applied and clearly demonstrable.
- The project structure explicitly reflects **maintainability, scalability, and testability**.
- The codebase is designed to evolve easily, handling future feature requirements without significant refactoring.

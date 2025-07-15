# 🛣️ dotnet-journey

A curated playground for mastering **C#** and **.NET**, focused on real-world challenges, performance patterns, modern language features, and advanced developer techniques.

> LINQ is just the beginning. This project evolves with the latest and most powerful features in the .NET ecosystem.

---

## 🚀 Overview

This is not just another beginner repo. It's a **living lab** for sharpening your .NET skills with hands-on challenges.

### ✅ Core Goals:
- Practice and master **LINQ**, **Span<T>**, **pattern matching**, and more
- Explore modern **C# features** with real usage examples
- Learn **under-the-hood behavior** like memory allocation and stack vs heap
- Sharpen performance with **.NET runtime tricks**
- Solve **real-world scenarios**: analytics, recommendation engines, groupings, etc.

---

## 📦 Project Structure

```

dotnet-journey/
├── dotnet\_journey/
│   ├── Data/        # Sample datasets (e.g., Marvel characters)
│   ├── Models/      # C# POCOs used in examples
│   ├── Utils/       # LINQ playgrounds and future utilities
│   └── Program.cs   # Entry point to run exercises
└── README.md

````

---

## 🧠 Topics Covered

### 🔍 LINQ (Deep Dive)
- Filtering, projection, joins, grouping
- Cartesian products, complex aggregations
- Median, mode, "power couples", social networks
- Performance tips: `ToLookup`, `First() vs Where().First()`, `Aggregate()`, etc.

### 🧪 C# Language Features
- `record`, `record struct`, `init` properties
- `switch` expressions and pattern matching (`is`, `not`, `when`)
- `Span<T>`, `Memory<T>`, `ref struct`, stackalloc
- `Index`, `Range`, target-typed `new()`, discard `_`
- Interpolated strings, null-coalescing assignment (`??=`)
- Static lambdas, lambda attributes, improved lambdas in C# 11+

### ⚙️ Performance & Under-the-Hood
- Avoiding allocations
- Stack vs heap analysis
- Immutable vs mutable data
- Deferred vs immediate LINQ evaluation
- Efficient string and memory processing

### 📊 Real-World Scenarios
- Recommendation systems by age similarity
- Census reports (city stats, age gaps, social graphs)
- Data validators for missing or invalid values
- Custom search engine with `Contains()` and fuzzy logic
- Birthday calendars and groupings (e.g. Chinese zodiac via `Age % 12`)
- Power user filters (complex multi-condition filters)

---

## 🧪 Quick Start

```bash
git clone https://github.com/your-username/dotnet-journey.git
cd dotnet-journey
dotnet run
````

The console will walk through categorized exercises and challenges.
You can freely extend or comment/uncomment sections to focus your learning.

---

## 🤝 Contributing

If you're passionate about .NET internals, modern C#, or have LINQ challenges you want to see, **PRs and ideas are welcome**!

Just open an issue or fork and go 🔥

---

## 📜 License

[MIT License](./LICENSE)

---

# SauceDemo E-Commerce Test Automation Framework

[![.NET](https://img.shields.io/badge/.NET-10.0-blue)](https://dotnet.microsoft.com/)
[![Selenium](https://img.shields.io/badge/Selenium-4.15-green)](https://www.selenium.dev/)
[![SpecFlow](https://img.shields.io/badge/SpecFlow-3.9-orange)](https://specflow.org/)
[![Tests](https://img.shields.io/badge/tests-7%2F7%20passing-brightgreen)](https://github.com/yourusername/SauceDemo-Selenium-SpecFlow)

## 🎯 Overview

A comprehensive **BDD test automation framework** built with **Selenium WebDriver**, **SpecFlow**, and **C#** to test the SauceDemo e-commerce application. This framework demonstrates industry best practices including Page Object Model, Behavior-Driven Development, and automated HTML reporting with screenshots.

**Live Application:** [https://www.saucedemo.com](https://www.saucedemo.com)

## 🚀 Technologies & Tools

- **Language:** C# (.NET 10.0)
- **Test Framework:** NUnit 3.13
- **BDD Framework:** SpecFlow 3.9
- **Automation Tool:** Selenium WebDriver 4.15
- **Design Pattern:** Page Object Model (POM)
- **Reporting:** ExtentReports 5.0 with screenshots
- **Browser:** Chrome (ChromeDriver 141)

## 📁 Project Structure
```
ECommerceTests/
├── Drivers/                 # WebDriver management (Singleton pattern)
│   └── DriverManager.cs
├── Features/                # Gherkin feature files (BDD scenarios)
│   ├── Login.feature
│   └── ShoppingCart.feature
├── Hooks/                   # Test lifecycle hooks
│   └── TestHooks.cs
├── Pages/                   # Page Object Model classes
│   ├── LoginPage.cs
│   ├── ProductsPage.cs
│   └── CartPage.cs
├── Reports/                 # Test execution reports
│   ├── TestReport.html
│   └── Screenshots/
├── StepDefinitions/         # Step implementation (Glue code)
│   ├── LoginSteps.cs
│   └── ShoppingCartSteps.cs
└── Utilities/               # Helper classes
    └── ExtentReportManager.cs
```

## ⚙️ Prerequisites

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Google Chrome](https://www.google.com/chrome/) browser
- IDE: [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

## 🔧 Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/SauceDemo-Selenium-SpecFlow.git
cd SauceDemo-Selenium-SpecFlow/ECommerceTests
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Build the Project
```bash
dotnet build
```

### 4. Run Tests
```bash
# Run all tests
dotnet test

# Run with detailed output
dotnet test --logger "console;verbosity=detailed"

# Run specific tests by tag
dotnet test --filter "TestCategory=smoke"
```

## 🎭 Test Scenarios Covered

### Login Feature (3 scenarios)
- ✅ Successful login with valid credentials
- ✅ Failed login with invalid credentials  
- ✅ Failed login with locked out user

### Shopping Cart Feature (4 scenarios)
- ✅ Add single item to cart
- ✅ Add multiple items to cart
- ✅ Verify cart page navigation
- ✅ Verify cart contains added items

**Test Results: 7/7 Passing** ✅

## 🏷️ Running Tests by Tags

Tests are organized with tags for targeted execution:
```bash
# Run smoke tests only
dotnet test --filter "TestCategory=smoke"

# Run positive test scenarios
dotnet test --filter "TestCategory=positive"

# Run cart-related tests
dotnet test --filter "TestCategory=cart"

# Run negative test scenarios
dotnet test --filter "TestCategory=negative"
```

## 📊 Test Reports

After test execution, comprehensive reports are auto-generated:

- **HTML Report:** `bin/Debug/net10.0/Reports/TestReport.html`
- **Screenshots (on failure):** `bin/Debug/net10.0/Reports/Screenshots/`

### Report Features:
- 📊 Dashboard with pass/fail statistics and pie charts
- ✅ Step-by-step execution logs
- 📷 Automatic screenshots on test failures
- ⏱️ Execution time tracking
- 🖥️ System and environment information

## 🎨 Key Features

### ✨ Framework Highlights

- **BDD with Gherkin:** Human-readable test scenarios using Given-When-Then syntax
- **Page Object Model:** Maintainable and reusable page components with clear separation of concerns
- **Automatic Screenshots:** Captured and embedded in reports on test failures
- **ExtentReports:** Beautiful HTML reports with interactive dashboards
- **Tag-based Execution:** Run specific test suites (smoke, regression, positive, negative)
- **JavaScript Execution:** Bypasses UI overlays for reliable test execution
- **Robust Waits:** Explicit waits and synchronization handling
- **Clean Architecture:** Clear separation between pages, steps, and test data

### 🔍 Design Patterns Used

1. **Page Object Model (POM)** - Encapsulates page elements and actions
2. **Singleton Pattern** - WebDriver lifecycle management
3. **Factory Pattern** - Driver initialization with configuration
4. **Hook Pattern** - Before/After scenario lifecycle management

## 🛠️ Browser Configuration

The framework includes Chrome-specific configurations in `DriverManager.cs`:
```csharp
// Disable password manager popups
options.AddUserProfilePreference("credentials_enable_service", false);
options.AddUserProfilePreference("profile.password_manager_enabled", false);

// Incognito mode for clean test sessions
options.AddArgument("--incognito");

// Additional stability options
options.AddArgument("--disable-notifications");
options.AddArgument("--disable-infobars");
```

To enable **headless mode**, uncomment in `DriverManager.cs`:
```csharp
// options.AddArgument("--headless");
```

## 🧪 Sample Test Scenario
```gherkin
Feature: Login Functionality

  @smoke @positive
  Scenario: Successful login with valid credentials
    Given I navigate to the SauceDemo Login page
    When I enter username "standard_user"
    And I enter password "secret_sauce"
    And I click the login button
    Then I should see the products page
```

## 🐛 Troubleshooting

### Common Issues

**Issue:** `dotnet` command not recognized
```bash
# Solution: Install .NET SDK and add to PATH
# Download from: https://dotnet.microsoft.com/download
```

**Issue:** ChromeDriver version mismatch
```bash
# Solution: Update ChromeDriver package
dotnet add package Selenium.WebDriver.ChromeDriver --version [latest]
```

**Issue:** Tests timeout or fail intermittently
```bash
# Solution: Increase wait times in DriverManager.cs
_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
```

## 📚 Learning Resources

- [SpecFlow Documentation](https://docs.specflow.org/)
- [Selenium Documentation](https://www.selenium.dev/documentation/)
- [Page Object Model Pattern](https://www.selenium.dev/documentation/test_practices/encouraged/page_object_models/)
- [BDD Best Practices](https://cucumber.io/docs/bdd/)

## 👨‍💻 Author

**Vijay**
- 🎓 MS Information Systems @ Northeastern University (May 2025)
- 💼 Software Engineering Trainee @ Wipro
- 🔧 Skills: Java, Spring Boot, Selenium, C#, Python
- 🔗 [LinkedIn](https://linkedin.com/in/vijayramaraopothuganti)
- 📧 Email: pothuganti.v@northeastern.edu

## 🤝 Contributing

Contributions, issues, and feature requests are welcome! Feel free to check the issues page.

## 📝 License

This project is created for educational and portfolio purposes.

---

⭐ **If you found this helpful, please give it a star!**

## 📊 Sample Test Execution Results
```
✅ Test Run Summary: 7/7 Passing (100%)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
📋 Feature: Login Functionality
   ✓ Successful login with valid credentials
   ✓ Failed login with invalid credentials
   ✓ Failed login with locked out user
   Status: 3/3 passed

🛒 Feature: Shopping Cart
   ✓ Add single item to cart
   ✓ Add multiple items to cart
   ✓ Verify cart page navigation
   ✓ Verify cart contains added items
   Status: 4/4 passed

⏱️  Total Execution Time: ~45 seconds
📅 Environment: Chrome 141 | Windows 11
🎯 Pass Rate: 100%
```

### ExtentReports Dashboard Features:
- 📊 Interactive pie charts showing pass/fail distribution
- 📈 Timeline view of test execution
- ✅ Step-by-step logs with Given-When-Then breakdown
- 📷 Automatic screenshot capture on failures
- 🏷️ Tag-based test filtering (smoke, cart, positive, negative)
- 💻 System information (OS, Browser, .NET version)
- ⚡ Individual test duration metrics

**To view the report:** Run `dotnet test` and open `ECommerceTests/bin/Debug/net10.0/Reports/TestReport.html` in your browser.

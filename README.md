# 🔐 CipherVault Security System

> A secure desktop-based cybersecurity simulation platform built with **C# (Windows Forms)** and **SQL Server**, designed to demonstrate real-world principles of data protection, encryption, authentication, and cyber attack simulation in a controlled educational environment.

---

## 📌 Project Overview

**CipherVault Security System** is a comprehensive security-focused desktop application that simulates the core components of modern secure systems. It integrates encryption, authentication, secure storage, and attack simulation into a single unified platform.

The system is designed to replicate real-world cybersecurity concepts in a simplified but structured way, making it suitable for academic demonstration as well as portfolio presentation for internships.

The core goal of this project is to demonstrate how sensitive data can be securely managed, analyzed, and protected using standard cryptographic techniques and secure software design principles.

---

## 🎯 Objectives

- Implement secure user authentication mechanisms  
- Demonstrate file encryption and secure storage techniques  
- Analyze password strength and security levels  
- Simulate common cyber attack techniques for educational purposes  
- Maintain a structured, modular, and scalable software architecture  
- Apply real-world information security principles in a desktop environment  

---

## 🧠 Core Features

### 🔐 1. Secure Authentication System
The system includes a fully functional authentication module that ensures secure user access.

- User registration and login functionality  
- Password hashing using **SHA-256 cryptographic algorithm**  
- Prevention of plain-text password storage  
- Secure validation of user credentials against SQL Server database  
- Protection against unauthorized access attempts  

---

### 📁 2. Encrypted File Vault System
A secure digital vault that allows users to store sensitive files safely.

- File upload and secure storage system  
- AES-based encryption applied before storing files  
- Decryption only upon valid user authentication  
- Ensures files are never stored in readable/plain-text format  
- Secure retrieval of encrypted data from database or local storage  

This module simulates real-world secure file storage systems used in enterprise environments.

---

### 🔑 3. Key Management System
Handles secure generation and management of encryption keys.

- Dynamic encryption key generation at runtime  
- Secure association of keys with user sessions  
- Prevents hardcoded or static key usage  
- Ensures separation of encryption logic from UI layer  

This module strengthens the overall cryptographic structure of the system.

---

### 🔍 4. Password Strength Analyzer
A security evaluation tool that analyzes password quality and strength.

- Evaluates passwords based on multiple security factors:
  - Length of password  
  - Use of uppercase and lowercase characters  
  - Inclusion of numbers  
  - Use of special characters  
- Classifies passwords into:
  - Weak  
  - Medium  
  - Strong  
- Provides estimated password cracking difficulty level  
- Encourages users to create stronger passwords  

---

### 💣 5. Cyber Attack Simulation Module
An educational security module that demonstrates how passwords can be attacked.

Includes simulation of:

#### 🔸 Brute Force Attack
- Attempts all possible combinations systematically  
- Displays attempt counter and progress visualization  
- Demonstrates computational complexity of weak passwords  

#### 🔸 Dictionary Attack
- Uses predefined wordlists to attempt password guessing  
- Shows how common passwords are easily compromised  

#### 🔸 Hybrid Attack Simulation
- Combines brute force and dictionary-based strategies  
- Demonstrates real-world attack techniques in a controlled environment  

This module is strictly educational and does not perform real external attacks.

---

### 📊 6. Security Logging System
A centralized logging mechanism that tracks system activity.

- Records user login attempts (successful and failed)  
- Logs file access and encryption/decryption events  
- Tracks attack simulation activities  
- Stores logs securely in SQL Server  
- Helps in identifying suspicious behavior patterns  

---

## 🏗️ System Architecture

The application follows a strict **3-tier architecture model**:
📦 Presentation Layer (Windows Forms UI)
Handles all user interactions, forms, and UI events.

📦 Business Logic Layer
Contains encryption, authentication, analysis, and simulation logic.

📦 Data Access Layer
Handles all communication with SQL Server database.

This architecture ensures:
- Clean separation of concerns  
- High maintainability  
- Scalability for future enhancements  
- Professional software design structure  

---

## 🛠️ Technologies Used

- **Programming Language:** C#  
- **Framework:** Windows Forms (.NET)  
- **Database:** SQL Server (SSMS)  
- **Data Access Technology:** ADO.NET  
- **Cryptography:**  
  - AES (Advanced Encryption Standard)  
  - SHA-256 Hashing Algorithm  

---

## 🗄️ Database Design

### 👤 Users Table
- UserID (Primary Key)  
- Username  
- PasswordHash  
- CreatedAt  

### 📁 Files Table
- FileID (Primary Key)  
- UserID (Foreign Key)  
- FileName  
- EncryptedData  
- UploadDate  

### 📊 Logs Table
- LogID (Primary Key)  
- UserID  
- EventType  
- Description  
- Timestamp  

---

## 🧩 Key Design Principles

This project strictly follows professional software engineering practices:

- Object-Oriented Programming (OOP)  
- Encapsulation of sensitive logic  
- Separation of UI and business logic  
- Modular class-based design  
- Secure coding practices for authentication and encryption  
- Scalable system architecture  

---

## 🎓 Educational Value

This project demonstrates practical implementation of:

- Information Security Fundamentals  
- Cryptographic Techniques (AES, SHA-256)  
- Secure Authentication Systems  
- Attack Simulation Methodologies  
- Database Security and Logging Systems  
- Layered Software Architecture Design  

It provides a strong foundation for understanding how real-world security systems are structured and implemented.

---

## ⚠️ Disclaimer

This project is developed strictly for **educational and demonstration purposes only**.  
The attack simulation modules are designed to illustrate security vulnerabilities in a controlled environment and do not perform any real malicious operations.

---

## 🚀 Future Enhancements

- Role-based access control (Admin/User separation)  
- Cloud-based secure storage integration  
- Real-time encrypted communication module  
- Advanced threat detection using AI-based analysis  
- Biometric authentication simulation  
- Enhanced UI using WPF or modern UI frameworks  

---

## 👨‍💻 Author

Developed as an Information security focused semester final project demonstrating secure software design, encryption principles, and real-world system simulation using modern development practices.

---

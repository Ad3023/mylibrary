-- MyLibrary Database Creation Script for SQL Server LocalDB

-- Create the database if it doesn't exist
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'MyLibraryDB')
BEGIN
    CREATE DATABASE MyLibraryDB;
END
GO

-- Use the newly created database
USE MyLibraryDB;
GO

-- Drop tables if they already exist to ensure a clean slate
IF OBJECT_ID('IssuedBooks', 'U') IS NOT NULL DROP TABLE IssuedBooks;
IF OBJECT_ID('Books', 'U') IS NOT NULL DROP TABLE Books;
IF OBJECT_ID('Borrowers', 'U') IS NOT NULL DROP TABLE Borrowers;
IF OBJECT_ID('Users', 'U') IS NOT NULL DROP TABLE Users;
GO

-- 1. Users Table
-- Stores user credentials for login
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL -- Store hashed passwords in a real application
);

-- 2. Books Table
-- Stores book inventory details
CREATE TABLE Books (
    BookID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(255) NOT NULL,
    YearPublished INT NOT NULL,
    TotalCopies INT NOT NULL,      -- Total number of copies owned by the library
    AvailableCopies INT NOT NULL   -- Number of copies currently available for borrowing
);

-- 3. Borrowers Table
-- Stores library member details
CREATE TABLE Borrowers (
    BorrowerID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) UNIQUE,
    Phone NVARCHAR(20)
);

-- 4. IssuedBooks Table
-- Stores records of books issued to borrowers
CREATE TABLE IssuedBooks (
    IssueID INT PRIMARY KEY IDENTITY(1,1),
    BookID INT NOT NULL,
    BorrowerID INT NOT NULL,
    IssueDate DATE NOT NULL,
    DueDate DATE NOT NULL,
    ReturnDate DATE, -- Nullable: NULL if not yet returned, date if returned
    FOREIGN KEY (BookID) REFERENCES Books(BookID),
    FOREIGN KEY (BorrowerID) REFERENCES Borrowers(BorrowerID)
);

-- Seed Data (Initial Data)

-- Default login credentials
INSERT INTO Users (Username, Password) VALUES
('admin', 'password123'), -- In a real app, hash this password!
('user', 'userpass');

-- Sample Books
INSERT INTO Books (Title, Author, YearPublished, TotalCopies, AvailableCopies) VALUES
('The Hitchhiker''s Guide to the Galaxy', 'Douglas Adams', 1979, 5, 5),
('1984', 'George Orwell', 1949, 3, 3),
('Pride and Prejudice', 'Jane Austen', 1813, 4, 4),
('To Kill a Mockingbird', 'Harper Lee', 1960, 2, 2),
('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 6, 6);

-- Sample Borrowers
INSERT INTO Borrowers (Name, Email, Phone) VALUES
('Alice Wonderland', 'alice@example.com', '111-222-3333'),
('Bob The Builder', 'bob@example.com', '444-555-6666'),
('Charlie Chaplin', 'charlie@example.com', '777-888-9999');

-- Sample Issued Books (some might be overdue for testing reports)
INSERT INTO IssuedBooks (BookID, BorrowerID, IssueDate, DueDate, ReturnDate) VALUES
(1, 1, '2025-05-01', '2025-05-15', NULL), -- Overdue (assuming current date > May 15)
(2, 2, '2025-05-10', '2025-05-24', NULL),
(3, 1, '2025-04-20', '2025-05-04', '2025-05-03'), -- Returned
(4, 3, '2025-05-25', '2025-06-08', NULL);

-- Update available copies for issued books
UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE BookID IN (1, 2, 4);
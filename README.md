# SHA Task - Invoice Management System

A comprehensive invoice management system built with Clean Architecture principles, featuring full CRUD operations, pagination, filtering, and advanced business logic for managing invoices, cashiers, branches, and cities.

## 🏗️ Architecture

This project follows **Clean Architecture** principles with clear separation of concerns across multiple layers:

- **Presentation Layer**: RESTful Web API controllers [1](#0-0) 
- **Application Layer**: Business logic services and DTOs [2](#0-1) 
- **Infrastructure Layer**: Data access repositories and Unit of Work [3](#0-2) 
- **Domain Layer**: Core business entities and interfaces

## 🚀 Technology Stack

- **.NET Core 8**: Modern, cross-platform framework
- **Entity Framework Core**: ORM for data access with SQL Server
- **AutoMapper**: Object-to-object mapping
- **Unit of Work Pattern**: Transaction management and repository coordination [4](#0-3) 
- **Clean Code**: SOLID principles and maintainable architecture
- **SQL Server**: Database hosted on MonsterASP.Net

## 📋 Features

### Core Business Domains

1. **Invoice Management** - Complete invoice lifecycle with header-detail pattern [5](#0-4) 
2. **Cashier Management** - Employee management with branch associations [6](#0-5) 
3. **Branch Management** - Business location management [7](#0-6) 
4. **City Management** - Geographic reference data

### Advanced Features

- **Pagination**: Server-side pagination for large datasets [8](#0-7) 
- **Filtering**: Text-based search with SQL LIKE operations [9](#0-8) 
- **Complex Business Rules**: Cascade deletion and referential integrity [10](#0-9) 
- **Comprehensive Error Handling**: Standardized response wrappers
- **Entity Relationships**: Full object graph loading with navigation properties [11](#0-10) 

## 🔧 API Endpoints

### Invoice Management
```
GET    /api/Invoice                                    # Get all invoices
GET    /api/Invoice/{id}                              # Get invoice by ID
POST   /api/Invoice                                   # Create new invoice
PUT    /api/Invoice                                   # Update invoice
DELETE /api/Invoice/{id}                              # Delete invoice
GET    /api/Invoice/Pagination/{pgSize}/{pgNumber}    # Paginated invoices
GET    /api/Invoice/PagFilter/{pgSize}/{pgNumber}/{filterText} # Filtered pagination
```

### Cashier Management
```
GET    /api/Cashier                                   # Get all cashiers
POST   /api/Cashier                                   # Create cashier
PUT    /api/Cashier                                   # Update cashier
DELETE /api/Cashier/{id}                              # Delete cashier
```

### Branch Management
```
GET    /api/Branch                                    # Get all branches
GET    /api/Branch/{id}                               # Get branch by ID
GET    /api/Branch/ByCity/{id}                        # Get branches by city
```

## 🗄️ Database Schema

The system uses a relational database with the following key relationships:

- **Cities** → **Branches** (One-to-Many)
- **Branches** → **Cashiers** (One-to-Many)
- **Cashiers** → **InvoiceHeaders** (One-to-Many)
- **InvoiceHeaders** → **InvoiceDetails** (One-to-Many)

## 🛠️ Development Patterns

### Unit of Work Pattern
Ensures transaction consistency across multiple repository operations [12](#0-11) 

### Repository Pattern
Abstracts data access logic with comprehensive error handling [13](#0-12) 

### DTO Pattern
Separate data transfer objects for different operations:
- `InsertInvoiceDTO` for creation
- `UpdateInvoiceDTO` for modifications  
- `ReadInvoiceDTO` for responses

### Response Wrapper Pattern
Standardized API responses with success/failure states and error messages

## 🌐 Deployment

- **Database**: SQL Server hosted on MonsterASP.Net
- **Architecture**: Scalable multi-layer design
- **Performance**: Optimized queries with eager loading and pagination

## 📝 Business Logic Highlights

- **Invoice Updates**: Complete replacement of invoice details for data consistency [14](#0-13) 
- **Cascade Deletion**: Manual cascade handling for referential integrity
- **Validation**: Multi-layer validation from model state to business rules
- **Mapping**: Automated object mapping with AutoMapper

## Notes

This system demonstrates enterprise-level .NET development practices with Clean Architecture, comprehensive error handling, and advanced querying capabilities. The codebase follows SOLID principles and maintains clear separation between presentation, business logic, and data access layers. <cite/>

Wiki pages you might want to explore:
- [Core Business Domains (proGamalSherif/Sha_Task)](/wiki/proGamalSherif/Sha_Task#3)
- [Invoice Management System (proGamalSherif/Sha_Task)](/wiki/proGamalSherif/Sha_Task#3.1)
- [Cashier Management System (proGamalSherif/Sha_Task)](/wiki/proGamalSherif/Sha_Task#3.2)

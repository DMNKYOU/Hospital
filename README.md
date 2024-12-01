# Hospital
The system designed for managing and interacting with hospital patients, streamlining processes such as patient information tracking and medical history management

## Resources

Examples of the application’s functionality, including **screenshots** and a **Postman collection**, are available in the folder:  
**Application_Screenshots_and_Postman_Collection**.


## Development Time

**1.5 days**, implementation of the requirements.

# Application Overview

This application was developed to meet the provided requirements with a focus on scalability, performance, and maintainability. It features two controllers:

1. **Person Controller** – Handles the creation of a person.
2. **Patient Controller** – Allows assigning a person as a patient to a specific department, enabling future system enhancements with ease.

## Key Features

- **Multi-Layered Architecture**: Clean separation of concerns ensures maintainability and extensibility.
- **Repository**: Efficient data access with clear separation of business logic and data handling.
- **Index Optimization**: An index on the `birthday` field has been added to optimize frequent searches, improving query performance.
- **Pagination-Ready**: The system is designed for potential future enhancements like pagination to handle large datasets efficiently.
- **Extensibility**: Supports additional data validation mechanisms if needed.
- **Docker**: Includes support for running the application and its database using Docker.
- **Swagger**: Provides Swagger for clear and easy API usage.


This application is built with scalability in mind, ensuring it can be easily extended and optimized to meet evolving requirements.

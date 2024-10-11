namespace DAL.Entities.Enums;

public enum DatabaseType
{
    Aws,        // AWS databases (e.g., RDS, DynamoDB)
    MySql,      // MySQL database
    PostgreSql, // PostgreSQL database
    SqlServer,  // Microsoft SQL Server
    Oracle,     // Oracle database
    MongoDb,    // MongoDB
    Other       // Any other database type
}
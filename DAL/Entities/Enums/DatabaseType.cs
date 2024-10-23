namespace DAL.Entities.Enums;

public enum DatabaseType
{
    MongoDb,    // MongoDB database
    Aws,        // AWS databases (e.g., RDS, DynamoDB)
    MySql,      // MySQL database
    PostgreSql, // PostgreSQL database
    SqlServer,  // Microsoft SQL Server
    Other       // Any other database type
}
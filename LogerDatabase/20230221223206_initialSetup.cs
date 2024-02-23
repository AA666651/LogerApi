using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogerDatabase.Migrations
{
    public partial class initialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string Sql = @"
                 CREATE TABLE LogType
                (
                  Id int IDENTITY CONSTRAINT PK_LogType_Id PRIMARY KEY CLUSTERED,
                  Name varchar(MAX) NOT NULL,
                ) 
                GO
                CREATE TABLE Log
                (
                  Id int IDENTITY CONSTRAINT PK_Log_Id PRIMARY KEY CLUSTERED,
                  GuidData uniqueidentifier NOT NULL CONSTRAINT CK_Log_GuidData DEFAULT (NEWID()),
                  TypeId int DEFAULT (NULL),
                  Value varchar(MAX) NOT NULL,
                  CreateDate datetime NOT NULL CONSTRAINT CK_Log_TimeCreated DEFAULT (GETDATE()),
                ) 
                GO
                ALTER TABLE Log
                ADD CONSTRAINT FK_Log_LogType_Id FOREIGN KEY (TypeId)
                REFERENCES LogType (Id)
                            ";

            migrationBuilder.Sql(Sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "LogTypes");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Backend.Migrations
{
    public partial class AddedPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.Sql(
                @"
                PRAGMA foreign_keys = 0;

                CREATE TABLE Comments_temp AS SELECT *
                                            FROM Comments;
                DROP TABLE Comments;

                CREATE TABLE Comments (
                    Id INTEGER PRIMARY KEY,  
                    Date TEXT,
                    Email TEXT,
                    Text TEXT
                );
            
                ALTER TABLE Comments ADD COLUMN PostId INTEGER REFERENCES Posts(Id);
                INSERT INTO Comments 
                (
                  Id,
                  Date,
                  Email,
                  Text
                )
                SELECT Id,
                     Date,
                     Email,
                     Text
                FROM Comments_temp;
                DROP TABLE Comments_temp;
                
                PRAGMA foreign_keys = 1;"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Comments_Posts_PostId",
            //    table: "Comments",
            //    column: "PostId",
            //    principalTable: "Posts",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
                PRAGMA foreign_keys = 0;

                CREATE TABLE Comments_temp AS SELECT *
                                            FROM Comments;
                DROP TABLE Comments;
           
                PRAGMA foreign_keys = 1;"
            );

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comments_Posts_PostId",
            //    table: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.Sql(
                @"
                    PRAGMA foreign_keys = 0;

                    CREATE TABLE Comments(
                        Id INTEGER PRIMARY KEY,
                        Date TEXT,
                        Email TEXT,
                        Text TEXT
                        );

                    INSERT INTO Comments
                    (
                        Id,
                        Date,
                        Email,
                        Text
                    )
                    SELECT Id,
                        Date,
                        Email,
                        Text
                    FROM Comments_temp;

                    DROP TABLE Comments_temp;

                    PRAGMA foreign_keys = 1;"
            );

            //migrationBuilder.DropIndex(
            //    name: "IX_Comments_PostId",
            //    table: "Comments");

            //migrationBuilder.DropColumn(
            //    name: "PostId",
            //    table: "Comments");
        }
    }
}

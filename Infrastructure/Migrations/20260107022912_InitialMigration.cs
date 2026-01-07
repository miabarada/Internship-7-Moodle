using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ProfessorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_users_ProfessorId",
                        column: x => x.ProfessorId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateMessage",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    ReceiverId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateMessage_users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivateMessage_users_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Announcement",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    ProfessorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcement_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "public",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcement_users_ProfessorId",
                        column: x => x.ProfessorId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                schema: "public",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "public",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_users_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    ProfessorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "public",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Material_users_ProfessorId",
                        column: x => x.ProfessorId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "Role", "Surname" },
                values: new object[,]
                {
                    { 1, "mia.barada@gmail.com", "Mia", "12345678", "Admin", "Barada" },
                    { 2, "andrea.barada@gmail.com", "Andrea", "87654321", "Student", "Barada" },
                    { 3, "sara.cigler@gmail.com", "Sara", "11223344", "Student", "Cigler" },
                    { 4, "daria.pazanin@gmail.com", "Daria", "44332211", "Student", "Pazanin" },
                    { 5, "ana.bartulovic@gmail.com", "Ana", "12121212", "Student", "Bartulovic" },
                    { 6, "lea.zebic@gmail.com", "Lea", "34343434", "Student", "Zebic" },
                    { 7, "mia.milun@gmail.com", "Mia", "13131313", "Profesor", "Milun" },
                    { 8, "maja.milanovic@gmail.com", "Maja", "14141414", "Profesor", "Milanovic" },
                    { 9, "tomislav.buric@gmail.com", "Tomislav", "232323", "Profesor", "Buric" },
                    { 10, "predrag.pale@gmail.com", "Predrag", "24242424", "Profesor", "Pale" },
                    { 11, "ines.kezic@gmail.com", "Ines", "32323232", "Profesor", "Kezic" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Course",
                columns: new[] { "Id", "Name", "ProfessorId" },
                values: new object[,]
                {
                    { 1, "Matematika", 7 },
                    { 2, "Hrvatski jezik", 8 },
                    { 3, "Matematička analiza 2", 9 },
                    { 4, "Vještine komuniciranja", 10 },
                    { 5, "Glazbena kultura", 11 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "PrivateMessage",
                columns: new[] { "Id", "Content", "ReceiverId", "SenderId", "SentAt" },
                values: new object[,]
                {
                    { 1, "Profesorice, imam pitanje.", 7, 2, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Naravno, pitaj.", 2, 7, new DateTime(2024, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Kad je kolokvij", 8, 3, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Sljedeći tjedan.", 3, 8, new DateTime(2024, 10, 2, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Domaći mi nije jasnan", 9, 4, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Objasnit ću na predavanju.", 4, 9, new DateTime(2024, 10, 3, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Ima li dodatnih bodova?", 10, 5, new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Vidit ćemo.", 5, 10, new DateTime(2024, 10, 4, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Imam problema s materijalima.", 11, 6, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Pošalji screen.", 6, 11, new DateTime(2024, 10, 5, 16, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Announcement",
                columns: new[] { "Id", "Content", "CourseId", "CreatedAt", "ProfessorId", "Title" },
                values: new object[,]
                {
                    { 1, "Dobrodošli na kolegij Matan2", 3, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Dobrodošli" },
                    { 2, "Prvi kolokvij održat će se sljedeći tjedan.", 2, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Kolokvij" },
                    { 3, "Objavljena je prva zadaća.", 3, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Zadaća" },
                    { 4, "Sljedeće predavanje je online.", 4, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Predavanje" },
                    { 5, "Dodani su novi materijali.", 5, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Materijali" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Enrollment",
                columns: new[] { "CourseId", "StudentId", "Id" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 3, 2, 6 },
                    { 1, 3, 2 },
                    { 4, 3, 7 },
                    { 2, 4, 3 },
                    { 5, 4, 8 },
                    { 2, 5, 4 },
                    { 3, 6, 5 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Material",
                columns: new[] { "Id", "CourseId", "CreatedAt", "Name", "ProfessorId", "Url" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Algebarski izrazi", 7, "https://example.com/algebarskiizrazi" },
                    { 2, 2, new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lovac u zitu", 8, "https://example.com/lovacuzitu" },
                    { 3, 3, new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diferencijalne jednadzbe", 9, "https://example.com/difjedn" },
                    { 4, 4, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kako komunicirati", 10, "https://example.com/komuniciranje" },
                    { 5, 5, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Klasicizam", 11, "https://example.com/klasicizam" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcement_CourseId",
                schema: "public",
                table: "Announcement",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcement_ProfessorId",
                schema: "public",
                table: "Announcement",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_ProfessorId",
                schema: "public",
                table: "Course",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseId",
                schema: "public",
                table: "Enrollment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_CourseId",
                schema: "public",
                table: "Material",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_ProfessorId",
                schema: "public",
                table: "Material",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessage_ReceiverId",
                schema: "public",
                table: "PrivateMessage",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessage_SenderId",
                schema: "public",
                table: "PrivateMessage",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                schema: "public",
                table: "users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcement",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Enrollment",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Material",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PrivateMessage",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Course",
                schema: "public");

            migrationBuilder.DropTable(
                name: "users",
                schema: "public");
        }
    }
}

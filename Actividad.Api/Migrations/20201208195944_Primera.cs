using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Actividad.Api.Migrations
{
    public partial class Primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estacionamientos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Calificacion = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitud = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamientos", x => x.Id);
                },
                comment: "Producto del servicio");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creacion = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                },
                comment: "Administradores del servicio");

            migrationBuilder.InsertData(
                table: "Estacionamientos",
                columns: new[] { "Id", "Calificacion", "Calle", "CodigoPostal", "Colonia", "Costo", "Descripcion", "Latitud", "Longitud", "Municipio", "Nombre", "Numero" },
                values: new object[,]
                {
                    { "2a209976-f965-4850-8a5d-c5ebfc9887eb", 5m, "A", "28001", "Colonia A", 15m, "El más barato de revolución", "19.239937687163206", "-103.7237955329542", "Colima", "Revolucionario", "1" },
                    { "237216dc-cff4-492f-a0ac-68c65c74ced7", 5m, "B", "28002", "Colonia B", 15m, "Ecoestacionamiento reformado", "19.24303615160122", "-103.72825568830704", "Colima", "Libertad", "2" },
                    { "e24fd53a-37af-4beb-842d-61646bfb20f4", 4.8m, "C", "28003", "Colonia C", 10m, "Ecoestacionamiento constituido", "19.251725404009665", "-103.72085671842486", "Colima", "Marina", "3" },
                    { "428749df-9460-4760-9be6-3198adfbb628", 4.3m, "D", "28004", "Colonia D", 20m, "Estacionamiento comercial", "19.266306310173388", "-103.6974779386686", "Colima", "Zentralia", "4" },
                    { "26a36156-908e-4047-9541-326bb8dbed26", 4.3m, "E", "28005", "Colonia E", 7m, "Estacionamiento constructivo", "19.26394166716784", "-103.69400342671413", "Colima", "Homedepot", "5" },
                    { "fd0ef31a-eb34-4731-aee5-224138e8ef96", 4.3m, "E", "28005", "Colonia E", 7m, "Estacionamiento enfermeroso", "19.24753137463207", "-103.69879772258632", "Colima", "Ucol", "6" },
                    { "c28bc3bd-0b73-49a7-a00c-dd3f162bbdab", 4.6m, "F", "28006", "Colonia F", 9m, "Estacionamiento ecológico", "19.238138704563717", "-103.73356469917077", "Colima", "Ecoparque", "7" },
                    { "1aa8ffbf-7287-4c1a-9521-4f9618daca90", 4.6m, "F", "28006", "Colonia F", 9m, "Estacionamiento ecológico", "19.238138704563717", "-103.73356469917077", "Colima", "Piedra lis", "8" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Clave", "Correo", "Creacion", "Disponible", "Foto", "Nombre", "Rol" },
                values: new object[,]
                {
                    { "00bdec6b-5a24-4db7-83dd-0cc85ebf5c8f", "Escalera Pérez", "OGgFiKDvH7RfNOasdZLhfw==", "escalera@ucol.mx", new DateTime(2020, 12, 8, 13, 59, 43, 897, DateTimeKind.Local).AddTicks(8620), true, "img/avatares/soporte/1a2f09ab-db7a-4446-b5db-efe7f17cc56a.png", "Hernán Adalid", "Soporte" },
                    { "bd533f27-52d4-42dd-bfa4-a38e29b88a98", "Flores Ruelas", "OGgFiKDvH7RfNOasdZLhfw==", "flores@ucol.mx", new DateTime(2020, 12, 8, 13, 59, 43, 897, DateTimeKind.Local).AddTicks(8613), true, "img/avatares/soporte/881d8861-1de7-4d9f-b673-1a4d9bab0e19.png", "Fernando Alfonso", "Soporte" },
                    { "86a545ca-a358-45db-99ff-f4e1b7ea2736", "Serrano Ramos", "OGgFiKDvH7RfNOasdZLhfw==", "serrano@ucol.mx", new DateTime(2020, 12, 8, 13, 59, 43, 897, DateTimeKind.Local).AddTicks(8607), true, "img/avatares/soporte/49825771-326d-4a0b-bda3-97be7d8b1270.png", "Joel Alejandro", "Soporte" },
                    { "c6179eae-460b-4360-9005-f7bb837187a9", "Castellanos Berjan", "OGgFiKDvH7RfNOasdZLhfw==", "castellanos@ucol.mx", new DateTime(2020, 12, 8, 13, 59, 43, 897, DateTimeKind.Local).AddTicks(8599), true, "img/avatares/soporte/f6e8acca-7ecc-4df2-9653-dc470ea5296c.png", "Esli", "Soporte" },
                    { "7caa403f-3721-4db9-aafa-267ca941fa6a", "Negrete Borjas", "OGgFiKDvH7RfNOasdZLhfw==", "negrete@ucol.mx", new DateTime(2020, 12, 8, 13, 59, 43, 897, DateTimeKind.Local).AddTicks(8589), true, "img/avatares/soporte/eaccf94a-9c2e-423d-84f9-830a84fa191a.png", "Alejandro Ismael", "Soporte" },
                    { "40ee212d-b7cc-4c34-874b-a1a8eaf5960a", "Alvarez Negrete", "OGgFiKDvH7RfNOasdZLhfw==", "alvarez@ucol.mx", new DateTime(2020, 12, 8, 13, 59, 43, 897, DateTimeKind.Local).AddTicks(8547), true, "img/avatares/soporte/324dceaa-8d3a-4ea2-8730-025497c804bd.png", "María Guadalupe", "Soporte" },
                    { "ecb9b517-7aff-4c67-9e48-2b00a62728a9", "Montaño Araujo", "OGgFiKDvH7RfNOasdZLhfw==", "montano@ucol.mx", new DateTime(2020, 12, 8, 13, 59, 43, 897, DateTimeKind.Local).AddTicks(8575), true, "img/avatares/soporte/89b1b18a-ec53-43c8-95e0-e295101f63fd.png", "Sergio Adrían", "Soporte" },
                    { "22cba1fa-13f5-4562-aca0-8c8bfd091354", "Rego Rodriguez", "OGgFiKDvH7RfNOasdZLhfw==", "rego@ucol.mx", new DateTime(2020, 12, 8, 13, 59, 43, 897, DateTimeKind.Local).AddTicks(8567), true, "img/avatares/soporte/c124c27e-914d-4f41-a04d-835fdeca0651.png", "María Enriqueta", "Soporte" },
                    { "94bece73-ed62-482d-80d5-21ab2357ab18", "Bedolla Valencia", "OGgFiKDvH7RfNOasdZLhfw==", "bedolla@ucol.mx", new DateTime(2020, 12, 8, 13, 59, 43, 897, DateTimeKind.Local).AddTicks(8629), true, "img/avatares/administradores/b5d7ed9a-87ea-4dd6-ac21-e6eca4802387.png", "Fernando", "Administrador" },
                    { "faaab4f9-964e-40be-83af-fa6b61190fd7", "Galván Guerrero", "OGgFiKDvH7RfNOasdZLhfw==", "galvan@ucol.mx", new DateTime(2020, 12, 8, 13, 59, 43, 897, DateTimeKind.Local).AddTicks(8511), true, "img/avatares/soporte/aca9b8e5-831f-4efa-b1c2-f1422c0e26ca.png", "Francisco Javier", "Soporte" },
                    { "3bff040b-c31b-499c-a816-796820606ba5", "Flores Avalos", "OGgFiKDvH7RfNOasdZLhfw==", "flores@ucol.mx", new DateTime(2020, 12, 8, 13, 59, 43, 896, DateTimeKind.Local).AddTicks(1203), true, "img/avatares/soporte/b1de412c-0db7-42f7-928e-53456780e3fd.png", "Juan Carlos", "Soporte" },
                    { "8cf21c1e-c029-4682-b022-adc6b35f3229", "Carrasco García", "OGgFiKDvH7RfNOasdZLhfw==", "carrasco@ucol.mx", new DateTime(2020, 12, 8, 13, 59, 43, 897, DateTimeKind.Local).AddTicks(8582), true, "img/avatares/soporte/104ce503-8e80-46d6-8a14-198040b86828.png", "Edgar Ramón", "Soporte" },
                    { "5b98d7bd-d6fb-4f84-a752-4e7b6d66c587", "General", "OGgFiKDvH7RfNOasdZLhfw==", "a@ucol.mx", new DateTime(2020, 12, 8, 13, 59, 43, 897, DateTimeKind.Local).AddTicks(8636), true, "img/avatares/administradores/d023a119-e4e1-4de1-83f4-345eab34b93f.png", "Administrador", "Administrador" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estacionamientos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

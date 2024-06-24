using CICD.LIB.Entidad.Tabla;
using CICD.LIB.Logica;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using CICD.LIB.Datos;
using Dapper.Contrib.Extensions;
using Dapper;

namespace CICD.TEST
{
    [TestClass]
    public class GEmpleadosTest
    {

        [TestInitialize]
        public void Setup()
        {
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Conexion.Initialize(configBuilder.Build());
            using (var connection = Conexion.ConnectionFactory())
            {
                connection.Open();
                connection.Execute("CargarDatos", commandType:CommandType.StoredProcedure);
            }
        }

        [TestMethod]
        public void TraerEmpleadosTest()
        {
            GEmpleados empleados = new GEmpleados();
            Assert.IsTrue(empleados.TraerEmpleados().Count() == 3);
        }

        [TestMethod]
        public void RegistrarTest()
        {
            GEmpleados empleados = new GEmpleados();
            Empleado eEmpleado = new Empleado()
            {
                Nombre = "Juan",
                ApellidoPaterno = "Siles",
                ApellidoMaterno = "Aguirre",
                FechaNacimiento = new DateTime(1985, 05, 10),
                TipoDocumentoIdentidad = 1,
                DocumentoIdentidad = "545781521",
                Sexo = "M",
                EstadoCivil = 1,
                Telefono = "33214526",
                Correo  = "jsiles@gmail.com",
                Direccion = "Los lotes",
                HaberBasico = 3500m,
                IdCargo = 10
            };
            empleados.Guardar(eEmpleado);
            Assert.IsTrue(empleados.TraerEmpleados().Count() == 4);
        }
    }
}
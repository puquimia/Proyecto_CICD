using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CICD.LIB.Entidad.Tabla;
using System.Data.SqlClient;
using CICD.LIB.Datos;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Transactions;

namespace CICD.LIB.Logica
{
    public class GEmpleados 
    {
        private readonly string _connectionString;

        #region Consultas
        public List<Empleado> TraerEmpleados()
        {
            using (var connection = Conexion.ConnectionFactory())
            {
                connection.Open();
                return connection.GetAll<Empleado>().ToList();
            }
        }
        #endregion

        #region Verificaciones

        #endregion

        #region Transacciones
        public void Guardar(Empleado eEmpleado)
        {
            using (TransactionScope ts= new TransactionScope())
            {
                using (var connection = Conexion.ConnectionFactory())
                {
                    connection.Open();
                    connection.Insert(eEmpleado);
                }
                ts.Complete();
            }
        }
        public void Moificar(Empleado eEmpleado)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                using (var connection = Conexion.ConnectionFactory())
                {
                    connection.Open();
                    connection.Update(eEmpleado);
                }
                ts.Complete();
            }
        }
        public void Eliminar(int idEmpleado)
        {
            using (var connection = Conexion.ConnectionFactory())
            {
                connection.Open();
                connection.Execute($"DELETE FROM GEN.Empleado WHERE Id = {idEmpleado}");
            }
        }
        #endregion

        #region Procesos

        #endregion
    }
}

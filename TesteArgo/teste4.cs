using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TesteArgo.Models;

namespace TesteAgo
{
    /// <summary>
    /// Nessa classe deve ser feito o acesso a banco de dados SQL SERVER
    /// Dados de conexao do banco de dados
    /// host: den1.mssql6.gear.host
    /// base: testecore
    /// user:testecore
    /// senha : Dz2iI~!U1Edq
    /// 
    /// Tabela Destino
    /// 
    /// Colunas:
    /// DestinoId inteiro 
    /// Nome texto nulavel
    /// Dia data nulavel
    /// 
    /// </summary>
    
    public class teste4
    {
        public class Conexao
        {
            public SqlConnection ConectarSql(ref SqlConnection con)
            {
                con?.Dispose();
                con = new SqlConnection("Server=den1.mssql6.gear.host;Database=testecore;User Id=testecore;Password = Dz2iI~!U1Edq; ");
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return con;
            }
        }

        private SqlConnection conn;

        private void ConectarSql()
        {
            Conexao con = new Conexao();
            conn = con.ConectarSql(ref conn);
        }

        public List<Destino> ListarDestino()
        {
            var listaDestinos = new List<Destino>();

            ConectarSql();
            var query = "SELECT * FROM Destino";

            var cmd = new SqlCommand(query, conn);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var destino = new Destino()
                {
                    Nome = Convert.ToString(reader["Nome"]),
                    Dia = Convert.ToDateTime(reader["Dia"])
                };

                listaDestinos.Add(destino);
            }

            return listaDestinos;
        }

        public Destino buscarPorId(int id)
        {
            var destino = new Destino();
            ConectarSql();
            var query = "SELECT * FROM Destino WHERE DestinoId = @id";

            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                var reader = cmd.ExecuteReader();
                if (reader.HasRows == false)
                {
                    throw new Exception("Destino não encontrado");
                }

                reader.Read();
                destino.Nome = Convert.ToString(reader["Nome"]);
                destino.Dia = Convert.ToDateTime(reader["Dia"]);

                return destino;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn?.Dispose();
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagamentCustomer.Database.DAO
{
    public class HelperDAO
    {

        public static void ExecutaProc(string nomeProc, SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection conexao = GetConexao())
                {
                    using (SqlCommand comando = new SqlCommand(nomeProc, conexao))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        if (parametros != null)
                            comando.Parameters.AddRange(parametros);
                        comando.ExecuteNonQuery();
                    }
                    conexao.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static SqlConnection GetConexao()
        {
            try
            {
                string strCon = @"Server=(localdb)\MSSQLLocalDB; Database=ManagamentCustomer; User Id = sa; Password=123456";
                SqlConnection conexao = new SqlConnection(strCon);
                conexao.Open();
                return conexao;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static DataTable ExecutaProcSelect(string nomeProc, SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection conexao = GetConexao())
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(nomeProc, conexao))
                    {
                        if (parametros != null)
                            adapter.SelectCommand.Parameters.AddRange(parametros);
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        DataTable tabela = new DataTable();
                        adapter.Fill(tabela);
                        conexao.Close();
                        return tabela;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable ExecutaSelect(string sql)
        {
            try
            {
                using (SqlConnection conexao = GetConexao())
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conexao))
                    {
                        DataTable tabelaTemp = new DataTable();
                        adapter.Fill(tabelaTemp);
                        conexao.Close();
                        return tabelaTemp;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}

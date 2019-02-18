using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private string StringConexao = @"Data Source=.\SqlExpress; initial catalog=SENAI_SVIGUFO_MANHA; user id=sa; pwd = 132";

        public void Cadastrar(InstituicaoDomain instituicao)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string cadastrar = "INSERT INTO INSTITUICOES(NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO, CEP, CIDADE, UF) VALUES (@NOME_FANTASIA, @RAZAO_SOCIAL, @CNPJ, @LOGRADOURO, @CEP, @CIDADE, @UF)";
                SqlCommand cmd = new SqlCommand(cadastrar, con);

                cmd.Parameters.AddWithValue("@NOME_FANTASIA", instituicao.NomeFantasia);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                cmd.Parameters.AddWithValue("@CNPJ", instituicao.Cnpj);
                cmd.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", instituicao.Cep);
                cmd.Parameters.AddWithValue("@UF", instituicao.Uf);
                cmd.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int ID)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string deletar = "DELETE FROM INSTITUICOES WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(deletar, con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", ID);
                //con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Editar(InstituicaoDomain instituicao)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string editar = "UPDATE INSTITUICOES SET " +
                                "NOME_FANTASIA = @A," +
                                "RAZAO_SOCIAL = @RAZAO_SOCIAL, " +
                                "CNPJ = @CNPJ, " +
                                "LOGRADOURO = @LOGRADOURO, " +
                                "CEP = @CEP, " +
                                "CIDADE = @CIDADE, " +
                                "UF = @UF " +
                                "WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(editar, con);
                //, RAZAO_SOCIAL = @RAZAO_SOCIAL, CNPJ = @CNPJ, LOGRADOURO = @LOGRADOURO, CEP = @CEP, CIDADE = @CIDADE, UF = @UF
                //con.Open();
                //cmd.Parameters.AddWithValue("@ID", instituicao.Id);
                cmd.Parameters.AddWithValue("@A", instituicao.NomeFantasia);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                cmd.Parameters.AddWithValue("@CNPJ", instituicao.Cnpj);
                cmd.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", instituicao.Cep);
                cmd.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);
                cmd.Parameters.AddWithValue("@UF", instituicao.Uf);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public InstituicaoDomain GetById(int id)
        {
            InstituicaoDomain instituicao = new InstituicaoDomain();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT ID, NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO, CEP, CIDADE, UF FROM INSTITUICOES WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ID", id);
                //InstituicaoDomain instituicao = new InstituicaoDomain();

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                        instituicao.Id = Convert.ToInt32(rdr["ID"]);
                        instituicao.NomeFantasia = rdr["NOME_FANTASIA"].ToString();
                        instituicao.RazaoSocial = rdr["RAZAO_SOCIAL"].ToString();
                        instituicao.Cnpj = rdr["CNPJ"].ToString();
                        instituicao.Logradouro = rdr["LOGRADOURO"].ToString();
                        instituicao.Cep = rdr["CEP"].ToString();
                        instituicao.Cidade = rdr["CIDADE"].ToString();
                        instituicao.Uf = rdr["UF"].ToString();
                }

                return instituicao;
            }
        }

        //public void Editar(InstituicaoDomain instituicao)
        //{
        //    using (SqlConnection con = new SqlConnection(StringConexao))
        //    {
        //        string editar = "UPDATE INSTITUICOES SET " +
        //                        "NOME_FANTASIA = @A," +
        //                        "RAZAO_SOCIAL = @RAZAO_SOCIAL, " +
        //                        "CNPJ = @CNPJ, " +
        //                        "LOGRADOURO = @LOGRADOURO, " +
        //                        "CEP = @CEP, " +
        //                        "CIDADE = @CIDADE, " +
        //                        "UF = @UF " +
        //                        "WHERE ID = @ID";
        //        SqlCommand cmd = new SqlCommand(editar, con);
        //        //, RAZAO_SOCIAL = @RAZAO_SOCIAL, CNPJ = @CNPJ, LOGRADOURO = @LOGRADOURO, CEP = @CEP, CIDADE = @CIDADE, UF = @UF
        //        //con.Open();
        //        //cmd.Parameters.AddWithValue("@ID", instituicao.Id);
        //        cmd.Parameters.AddWithValue("@A", instituicao.NomeFantasia);
        //        cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
        //        cmd.Parameters.AddWithValue("@CNPJ", instituicao.Cnpj);
        //        cmd.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
        //        cmd.Parameters.AddWithValue("@CEP", instituicao.Cep);
        //        cmd.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);
        //        cmd.Parameters.AddWithValue("@UF", instituicao.Uf);

        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        public List<InstituicaoDomain> Listar()
        {
            List<InstituicaoDomain> instituicoes = new List<InstituicaoDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string listar = "SELECT ID, NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO, CEP, CIDADE, UF FROM INSTITUICOES";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(listar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        InstituicaoDomain instituicao = new InstituicaoDomain()
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            NomeFantasia = rdr["NOME_FANTASIA"].ToString(),
                            RazaoSocial = rdr["RAZAO_SOCIAL"].ToString(),
                            Cnpj = rdr["CNPJ"].ToString(),
                            Logradouro = rdr["LOGRADOURO"].ToString(),
                            Cep = rdr["CEP"].ToString(),
                            Cidade = rdr["CIDADE"].ToString(),
                            Uf = rdr["UF"].ToString(),

                        };

                        instituicoes.Add(instituicao);

                    }
                }
            }
            return instituicoes;
        }
    }
}

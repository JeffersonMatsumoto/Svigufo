using Senai.SviGufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<InstituicaoDomain> Listar();

        void Cadastrar(InstituicaoDomain instituicao);

        void Editar(InstituicaoDomain instituicao);

        InstituicaoDomain GetById(int id);

        void Deletar(int ID);
    }
}

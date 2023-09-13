using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;

namespace webapi.inlock.tarde.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(Guid Id, Estudio estudio)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(Id)!;
            if(estudioBuscado != null)
            {
                estudioBuscado.Nome = estudio.Nome;
            }

            ctx.Estudios.Update(estudioBuscado!);

            ctx.SaveChanges();

        }

        public Estudio BuscarPorId(Guid Id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == Id)!;
        }

        public void Cadastrar(Estudio estudio)
        {
            ctx.Estudios.Add(estudio);
            ctx.SaveChanges();
        }

        public void Deletar(Guid Id)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(Id)!;

            if(estudioBuscado != null)
            {
                ctx.Estudios.Remove(estudioBuscado);
            }

            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList(); 
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();

           
        }
    }
}

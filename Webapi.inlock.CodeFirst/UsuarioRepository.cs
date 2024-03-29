﻿using Webapi.inlock.CodeFirst.Contexts;
using Webapi.inlock.CodeFirst.Domains;
using Webapi.inlock.CodeFirst.Interfaces;
using Webapi.inlock.CodeFirst.Utils;

namespace Webapi.inlock.CodeFirst
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InlockContext ctx;

        public UsuarioRepository()
        { 
            ctx= new InlockContext();
        } 
        public Usuario BuscarUsuario(string email, string senha)
        {
            try
            {
                var usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email);

                if (usuarioBuscado != null) 
                {
                    bool confere =  Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere) 
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);
                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

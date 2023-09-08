﻿using Microsoft.EntityFrameworkCore;
using ApiTechOil.DataAccess;
using ApiTechOil.Repository;
using ApiTechOil.Entities;

namespace ApiTechOil.Services
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _dbContext;

        public UsuarioRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return _dbContext.Usuarios.ToList();
        }
        public Usuario GetUsuarioById(int codUsuario)
        {
            return _dbContext.Usuarios.FirstOrDefault(p => p.CodUsuario == codUsuario);
        }
        public void AddUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();
        }
        public void UpdateUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Update(usuario);
            _dbContext.SaveChanges();
        }
        public void DeleteUsuario(int codUsuario)
        {
            var usuario = _dbContext.Usuarios.FirstOrDefault(p => p.CodUsuario == codUsuario);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                _dbContext.SaveChanges();
            }
        }
    }
}

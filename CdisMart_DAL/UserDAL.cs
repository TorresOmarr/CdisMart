using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdisMart_DAL
{
    public class UserDAL
    {
        CdisMartEntities modelo;
         
        public UserDAL()
        {
            modelo = new CdisMartEntities();
        }
            
        public List<User> CargarUsuarios()
        {
            var usuarios = from mUsuarios in modelo.User
                           select mUsuarios;

            return usuarios.ToList();


        }

        public User ConsultarUsuario(string userName, string password)
        {
            var usuario = (from mUsuario in modelo.User
                          where mUsuario.UserName == userName && mUsuario.Password == password
                          select mUsuario).FirstOrDefault();

            return usuario;
        }
        public string ConsultarUsuario(string userName)
        {
            var usuario = (from mUsuario in modelo.User
                           where mUsuario.UserName == userName 
                           select mUsuario.UserName).FirstOrDefault();

            return usuario;
        }

        

        public void RegistrarUsuario(User usuario)
        {
            modelo.User.Add(usuario);
            modelo.SaveChanges();

        }
        

        public List<Object> usuariosSubasta(string descripcion)
        {
            var usuarios = from mUsuarios in modelo.AuctionRecord
                            where mUsuarios.Auction.ProductName == descripcion
                            select new
                            {
                                idUsuario = mUsuarios.User.UserId,
                                Nombre = mUsuarios.User.Name,
                            };

            return usuarios.AsEnumerable<object>().ToList();
        }

    }
}

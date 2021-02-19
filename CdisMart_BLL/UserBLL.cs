using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMart_DAL;

namespace CdisMart_BLL
{
    public class UserBLL
    {
        CdisMartEntities modelo = new CdisMartEntities();

        public List<User> CargarUsuarios()
        {

            UserDAL usuario = new UserDAL();

            return usuario.CargarUsuarios();

        }

        public User ConsultarUsuario(string userName, string password)
        {
            UserDAL usuario = new UserDAL();
            return usuario.ConsultarUsuario(userName, password);
        }

        public void RegistrarUsuario(User usuarioParam)
        {
            UserDAL usuario = new UserDAL();

            usuario.RegistrarUsuario(usuarioParam);
        }

       

        public List<Object> usuariosSubasta(string descripcion)
        {
            UserDAL usuario = new UserDAL();

            return usuario.usuariosSubasta(descripcion);
        }

    }
}

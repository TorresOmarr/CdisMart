using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdisMart_DAL
{
    public class AuctionDAL
    {
        CdisMartEntities modelo;

        public AuctionDAL()
        {
            modelo = new CdisMartEntities();
        }

        public List<Auction> CargarSubastas()
        {
            var subastas = from mSubastas in modelo.Auction
                           select mSubastas;

            return subastas.ToList();
        }

        public Auction CargarSubasta(string nombreProducto)
        {
            var subasta = (from mSubasta in modelo.Auction
                           where mSubasta.ProductName == nombreProducto
                           select mSubasta).FirstOrDefault();

            return subasta;
        }
        public Auction CargarSubasta(int idSubasta)
        {
            var subasta = (from mSubasta in modelo.Auction
                           where mSubasta.AuctionId == idSubasta
                           select mSubasta).FirstOrDefault();

            return subasta;
        }

        public List<Auction> filtrarSubastas(string descripcion)
        {
            var subasta = from mSubasta in modelo.Auction
                          where mSubasta.Description.Contains(descripcion)
                          select mSubasta;

            return subasta.ToList();
                          
        }
        public List<Auction> cargarSubastasPorUsuario(int idUser)
        {
            var subastas = from mSubasta in modelo.Auction
                           where mSubasta.UserId == idUser 
                           select mSubasta;

            return subastas.ToList();
        }

        




        public void CrearSubasta(Auction subastaParam)
        {
            modelo.Auction.Add(subastaParam);
            modelo.SaveChanges();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMart_DAL;

namespace CdisMart_BLL
{
    public class AuctionBLL
    {
        public List<Auction> CargarSubastas()
        {
            AuctionDAL subastas = new AuctionDAL();
            return subastas.CargarSubastas();

        }

        public Auction CargarSubasta(string nombreProducto)
        {
            AuctionDAL subasta = new AuctionDAL();
            return subasta.CargarSubasta(nombreProducto);
        }

        public Auction CargarSubasta(int idSubasta)
        {
            AuctionDAL subasta = new AuctionDAL();
            return subasta.CargarSubasta(idSubasta);
        }

        public void CrearSubasta(Auction subastaParam)
        {
            AuctionDAL subasta = new AuctionDAL();
            List<Auction> subastasUsuario = subasta.cargarSubastasPorUsuario(subastaParam.UserId);

            if (subastasUsuario.Count() > 2)
            {
                throw new Exception("El usuario no puede tener mas de tres subastas activas simultaneamente");
            }
            else
            {
                if(DateTime.Now > subastaParam.StartDate)
                {
                    throw new Exception("La fecha de inicio debe ser mayor o igual a la fecha actual");
                }
                else
                {
                    if (subastaParam.StartDate>subastaParam.EndDate)
                    {
                        throw new Exception("La fecha de fin no puede ser mayor que la fecha de inicio");
                    }
                    else
                    {
                        subasta.CrearSubasta(subastaParam);
                    }
                }                

            }           

        }

        public List<Auction> filtrarSubastas(string descripcion)
        {
            AuctionDAL subasta = new AuctionDAL();
            return subasta.filtrarSubastas(descripcion);
        }

    }
}

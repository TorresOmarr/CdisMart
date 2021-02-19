using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMart_DAL;



namespace CdisMart_BLL
{
    public class AuctionRecordBLL
    {
        public List<Object> cargarHistorialesPorProducto(string productName) 
        {
            AuctionRecordDAL historial = new AuctionRecordDAL();
            return historial.CargarHistorialesPorProducto(productName);
        }

        public AuctionRecord cargarHistorialPorProducto(string productName)
        {
            AuctionRecordDAL historial = new AuctionRecordDAL();
            return historial.CargarHistorialPorProducto(productName);
        }

        public List<Object> cargarOfertasdeUsuario(string nombreProducto, int idUsuario)
        {
            AuctionRecordDAL ofertas = new AuctionRecordDAL();
            return ofertas.cargarOfertasdeUsuario(nombreProducto, idUsuario);
        }
        public void OfertaMasAlta(AuctionRecord ofertaParam)
        {            
            AuctionRecordDAL ofertaHistorial = new AuctionRecordDAL();
            Auction oferta;
            AuctionBLL subastaBLL = new AuctionBLL();
            int idSubasta = ofertaParam.AuctionId;



            oferta = subastaBLL.CargarSubasta(idSubasta);

            if(oferta.UserId == ofertaParam.UserId)
            {
                throw new Exception("No se le permite ofertar en esta subasta");
            }
            else
            {
                if (ofertaParam.Amount <= oferta.HighestBid)
                {
                    throw new Exception("La cantidad ingresada debe ser mayor que la oferta actual");
                }
                else
                {
                    if (oferta.EndDate < ofertaParam.BidDate )
                    {
                        throw new Exception("La subasta ha finalizado");
                    }
                    else
                    {
                        if (ofertaParam.Amount>1000000)
                        {
                            throw new Exception("La cantidad debe ser menor a 1,000,000");
                        }
                        else
                        {

                            ofertaHistorial.nuevaOferta(ofertaParam);
                            ofertaHistorial.OfertaMasAlta(ofertaParam);
                            
                        }
                        

                        
                    }
                }            
            }         

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdisMart_DAL
{
    public class AuctionRecordDAL
    {
        CdisMartEntities modelo;

        public AuctionRecordDAL()
        {
            modelo = new CdisMartEntities();
        }

        public List<Object> CargarHistorialesPorProducto(string productName)
        {

            var historial = from mhistorial in modelo.AuctionRecord
                             where mhistorial.Auction.ProductName == productName
                             select new
                             {
                                 Name = mhistorial.User.Name,
                                 Amount = mhistorial.Amount,
                                 BidDate = mhistorial.BidDate,

                             };

            return historial.AsEnumerable<Object>().ToList();
        }

        public AuctionRecord CargarHistorialPorProducto(string productName)
        {

            var historial = (from mhistorial in modelo.AuctionRecord
                             where mhistorial.Auction.ProductName == productName
                             orderby mhistorial.RecordId descending
                             select mhistorial).FirstOrDefault();

            return historial;
        }

        public void nuevaOferta(AuctionRecord oferta)
        {
            modelo.AuctionRecord.Add(oferta);
            modelo.SaveChanges();
        }

        public void OfertaMasAlta(AuctionRecord oferta)
        {
            var subasta = (from mSubasta in modelo.Auction
                           where mSubasta.AuctionId == oferta.AuctionId
                           select mSubasta).FirstOrDefault();

            subasta.HighestBid = oferta.Amount;
            subasta.Winner = oferta.UserId;

            modelo.SaveChanges();
        }

        public List<Object> cargarOfertasdeUsuario(string nombreProducto, int idUsuario)
        {
            var historial = from mhistorial in modelo.AuctionRecord
                            where mhistorial.Auction.ProductName == nombreProducto && mhistorial.UserId == idUsuario
                            select new
                            {
                                Name = mhistorial.User.Name,
                                Amount = mhistorial.Amount,
                                BidDate = mhistorial.BidDate,

                            };

            return historial.AsEnumerable<Object>().ToList();
        }

    }
}

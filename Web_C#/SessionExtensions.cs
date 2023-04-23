using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Web_C_.BL.Implementations.Order;

namespace Web_C_
{
    public static class SessionExtensions
    {
        private const string keyCar = "car";

        public static void SetCart(this ISession session, Cart cart)
        {
            if (cart == null)
                return;
            
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(cart.CartId);
                writer.Write(cart.TotalCount);
                writer.Write(cart.TotalPrice);
                session.Set(keyCar,stream.ToArray());
                

            }

        }
        public static bool TryGetCart(this ISession session, out Cart cart)
        {

            if (session.TryGetValue(keyCar, out byte[] value))
            {
                using (MemoryStream stream = new MemoryStream(value))
                using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    var orderId = reader.ReadInt32();
                    var totalCount = reader.ReadInt32();
                    var tetalPrice = reader.ReadDecimal();
                    cart = new Cart(orderId)
                    {
                        TotalCount = totalCount,
                        TotalPrice = tetalPrice,

                    };
                    
                }
                return true;
            }
            cart = null;
            return false;
            
        }
        public static void RemoveCart(this ISession session)
        {
            if (session.TryGetValue(keyCar, out byte[] value))
                session.Remove(keyCar);
        }



    }
}

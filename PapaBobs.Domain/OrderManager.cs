using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Domain
{
    public class OrderManager
    {
        // Makes a call to the Persistence layer's CreateOrder() method.
        public static void CreateOrder(DTO.OrderDTO orderDTO)
        {
            orderDTO.OrderId = Guid.NewGuid();
            Persistence.OrderRepository.CreateOrder(orderDTO);
        }
    }
}

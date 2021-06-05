using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtCommsOrderer
{
    abstract class Order
    {
        abstract public void CreateNewOrder();
        abstract public void ViewOrders();
        abstract public void ClearFile();
    }
}

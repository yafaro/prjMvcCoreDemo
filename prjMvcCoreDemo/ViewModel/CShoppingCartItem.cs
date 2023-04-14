using prjMvcCoreDemo.Models;
using System.ComponentModel;

namespace prjMvcCoreDemo.ViewModel
{
    public class CShoppingCartItem
    {
        public int productId { get; set; }
        [DisplayName("品名")]
        public int count { get; set; }
        [DisplayName("數量")]
        public decimal price { get; set; }
        [DisplayName("金額")]
        public decimal 小計 { get { return this.count * this.price; } }
        public TProduct product { get; set; }
    }
}

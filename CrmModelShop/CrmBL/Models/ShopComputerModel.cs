namespace CrmBL.Models
{
    public class ShopComputerModel
    {
        /// <summary>
        /// Рандомайзер
        /// </summary>
        Random rnd = new Random();

        /// <summary>
        /// Генератор
        /// </summary>
        public Generator Generator { get; set; }

        /// <summary>
        /// Коллекция касс
        /// </summary>
        public List<CashBox> CashBoxes { get; set; }

        /// <summary>
        /// Коллекция корзин
        /// </summary>
        public Queue<Cart> Carts { get; set; }

        /// <summary>
        /// Коллекция заказов
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Коллекция продаж
        /// </summary>
        public List<Sell> Sells { get; set; }

        /// <summary>
        /// Коллекция - очередь продавцов
        /// </summary>
        public Queue<Seller> SellersQueue { get; set; }

        /// <summary>
        /// Количество касс
        /// </summary>
        public int CashBoxCount => Carts.Count;

        /// <summary>
        /// Конструктор инициализирующий свойства
        /// </summary>
        public ShopComputerModel() 
        { 
            Generator = new Generator();
            CashBoxes = new List<CashBox>();
            Carts = new Queue<Cart>();
            Orders = new List<Order>();
            Sells = new List<Sell>();
            SellersQueue = new Queue<Seller>();
            
            List<Seller> sellers = Generator.GetNewSellers(20);
            foreach(Seller seller in sellers)
            {
                SellersQueue.Enqueue(seller);
            }

            for(int i = 0; i < 3; i++)
            {
                CashBox newCashBox = new CashBox(i + 1, SellersQueue.Dequeue());
                CashBoxes.Add(newCashBox);
            }
        }

        /// <summary>
        /// Метод запуска компьютерной модели
        /// </summary>
        public void Start()
        {
            List<Customer> customers = Generator.GetNewCustomers(10);
            Generator.GetNewProducts(30);
            List<Cart> carts = new List<Cart>();


            foreach(Customer customer in customers)
            {
                Cart customerCart = new Cart(customer);
                foreach(Product product in Generator.GetRandomProducts(10, 30))
                {
                    customerCart.AddToCart(product);
                    carts.Add(customerCart);
                }
            }

            foreach (Cart cart in carts)
            {
                CashBox cashBox = CashBoxes[rnd.Next(CashBoxes.Count)];
                cashBox.Enqueue(cart);
            }

            List<decimal> allMoney = new List<decimal>();
            while(true)
            {
                CashBox cashBox = CashBoxes[rnd.Next(CashBoxes.Count)];
                var money = cashBox.Dequeue();
                allMoney.Add(money);
                if (money == 0) break;
            }
            foreach(decimal money in allMoney)
            {
                Console.WriteLine(money);
            }
        }
    }
}

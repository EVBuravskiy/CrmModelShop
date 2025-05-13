namespace CrmBL.Models
{
    public class ShopComputerModel
    {
        /// <summary>
        /// Random
        /// </summary>
        Random rnd = new Random();

        /// <summary>
        /// Generator
        /// </summary>
        public Generator Generator { get; set; }

        /// <summary>
        /// Collection of cashboxes
        /// </summary>
        public List<CashBox> CashBoxes { get; set; }

        /// <summary>
        /// Collection of carts
        /// </summary>
        public List<Cart> Carts { get; set; }

        /// <summary>
        /// Collection of orders
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Collection of sells
        /// </summary>
        public List<Sell> Sells { get; set; }

        /// <summary>
        /// Collection - sellers queue
        /// </summary>
        public Queue<Seller> SellersQueue { get; set; }

        /// <summary>
        /// Counter of cashboxes
        /// </summary>
        public int CashBoxCount { get; set; }

        /// <summary>
        /// Stop sign for creating customer carts
        /// </summary>
        public bool isWorking = false;

        /// <summary>
        /// Count of customer's products
        /// </summary>
        public int CustomersProductCount { get; set; }


        /// <summary>
        /// Count of customers
        /// </summary>
        public int CustomersCount { get; set; }

        /// <summary>
        /// Speed ​​of customer service
        /// </summary>
        public int CustomersSpeed { get; set; }

        /// <summary>
        /// Cashbox speed
        /// </summary>
        public int CashBoxSpeed { get; set; }

        /// <summary>
        /// Computer model constructor
        /// </summary>
        public ShopComputerModel() 
        { 
            Generator = new Generator();
            CashBoxes = new List<CashBox>();
            Carts = new List<Cart>();
            Orders = new List<Order>();
            Sells = new List<Sell>();
            SellersQueue = new Queue<Seller>();
            CashBoxCount = 0;
            CustomersProductCount = 30;
            CustomersCount = 10;
            CustomersSpeed = 100;
            CashBoxSpeed = 100;


            List<Seller> sellers = Generator.GetNewSellers(20);
            foreach(Seller seller in sellers)
            {
                SellersQueue.Enqueue(seller);
            }

            for(int i = 0; i < CashBoxCount; i++)
            {
                CashBox newCashBox = new CashBox(i + 1, SellersQueue.Dequeue());
                CashBoxes.Add(newCashBox);
            }
        }

        /// <summary>
        /// Start computer model
        /// </summary>
        public void Start() 
        {
            isWorking = true;
            for (int i = 0; i < CashBoxCount; i++)
            {
                CashBox newCashBox = new CashBox(i + 1, SellersQueue.Dequeue());
                CashBoxes.Add(newCashBox);
            }
            Task.Run(() => CreateRandomCarts());   
            var cashBoxTasks = CashBoxes.Select(cashBox => new Task(() => CashBoxWork(cashBox)));
            foreach(var task in cashBoxTasks)
            {
                task.Start();
            }
        }

        /// <summary>
        /// Create random customers, add random products to customer's cart, add into cashboxes queue
        /// </summary>
        private void CreateRandomCarts()
        {
            while (isWorking)
            {
                List<Customer> customers = Generator.GetNewCustomers(CustomersCount);
                Generator.GetNewProducts(CustomersProductCount);
                foreach (Customer customer in customers)
                {
                    Cart customerCart = new Cart(customer);
                    foreach (Product product in Generator.GetRandomProducts(CustomersCount, CustomersProductCount))
                    {
                        customerCart.AddToCart(product);
                        Carts.Add(customerCart);
                    }
                    CashBox cashBox = GetMinQueueInCashBox();
                    cashBox.Enqueue(customerCart);
                }
                Thread.Sleep(CustomersSpeed);
            }
        }

        /// <summary>
        /// Cashbox working
        /// </summary>
        /// <param name="cashBox"></param>
        private void CashBoxWork(CashBox cashBox)
        {
            while (isWorking)
            {
                if (cashBox.CartsQueue.Count > 0)
                {
                    cashBox.Dequeue();
                }
                Thread.Sleep(CashBoxSpeed);
            }
        }

        /// <summary>
        /// Метод останавливающий работу циклов и соответствующих потоков
        /// </summary>
        public void Stop()
        {
            isWorking = false;
        }

        /// <summary>
        /// Метод возвращающий кассу с минимальным значением очереди
        /// </summary>
        /// <returns></returns>
        private CashBox GetMinQueueInCashBox()
        {
            CashBox minQueue = CashBoxes[0];
            foreach(CashBox cashBox in CashBoxes)
            {
                if (cashBox.CurrentQueueLength < minQueue.CurrentQueueLength)
                {
                    minQueue = cashBox;
                }
            }
            return minQueue;
        }
    }
}

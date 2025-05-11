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
        public List<Cart> Carts { get; set; }

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
        /// Флаг для остановки работы метода CreateRandomCarts
        /// </summary>
        public bool isWorking = false;

        /// <summary>
        /// Конструктор инициализирующий свойства
        /// </summary>
        public ShopComputerModel() 
        { 
            Generator = new Generator();
            CashBoxes = new List<CashBox>();
            Carts = new List<Cart>();
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
        public void Start() //public async void Start() использование async и напротив метода await 

        {
            isWorking = true;
            int sleep = 1000;
            //запускаем метод в отдельном потоке с использованием Task, в который в лямбду-функцию передаем метод, который будет
            //запускаться в отдельной потоке
            Task.Run(() => CreateRandomCarts(sleep, 10, 30));   //await - будет заставлять основной поток ждать завершение метода
                                                                //это делается когда в дальнейшей работе программы нужны данные,
                                                                //получаемые из этого метода

            //Преобразуем каждый cashBox в отдельный поток с использованием Select
            var cashBoxTasks = CashBoxes.Select(cashBox => new Task(() => CashBoxWork(cashBox, 1000)));
            //Перебирая элементы cashBoxTasks 
            foreach(var task in cashBoxTasks)
            {
                //запускаем каждый элемент в отдельном потоке не ожидая их выполнение
                task.Start();
            }
        }

        /// <summary>
        /// Метод создающий рандомных покупателей, заполняющих их корзины рандомными товарами и ставящий
        /// их к рандомной кассе
        /// </summary>
        /// <param name="sleep"></param>
        /// <param name="customersCount"></param>
        /// <param name="productsCount"></param>
        private void CreateRandomCarts(int sleep, int customersCount = 10, int productsCount = 30)
        {
            while (isWorking)
            {
                List<Customer> customers = Generator.GetNewCustomers(customersCount);
                Generator.GetNewProducts(productsCount);
                foreach (Customer customer in customers)
                {
                    Cart customerCart = new Cart(customer);
                    foreach (Product product in Generator.GetRandomProducts(customersCount, productsCount))
                    {
                        customerCart.AddToCart(product);
                        Carts.Add(customerCart);
                    }
                    CashBox cashBox = CashBoxes[rnd.Next(CashBoxes.Count)];
                    cashBox.Enqueue(customerCart);
                }
                Thread.Sleep(sleep);
            }
        }

        /// <summary>
        /// Метод работы кассы, если очередь кассы есть, то извлекает из нее элемент
        /// </summary>
        /// <param name="cashBox"></param>
        /// <param name="sleep"></param>
        private void CashBoxWork(CashBox cashBox, int sleep)
        {
            while (isWorking)
            {
                if (cashBox.CartsQueue.Count > 0)
                {
                    cashBox.Dequeue();
                }
                Thread.Sleep(sleep);
            }
        }

        /// <summary>
        /// Метод останавливающий работу циклов и соответствующих потоков
        /// </summary>
        public void Stop()
        {
            isWorking = false;
        }
    }
}

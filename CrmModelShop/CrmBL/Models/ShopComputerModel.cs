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
        public int CashBoxCount { get; set; }

        /// <summary>
        /// Флаг для остановки работы метода CreateRandomCarts
        /// </summary>
        public bool isWorking = false;

        /// <summary>
        /// Количество продуктов покупателя
        /// </summary>
        public int CustomersProductCount { get; set; }


        /// <summary>
        /// Количество покупателей
        /// </summary>
        public int CustomersCount { get; set; }

        /// <summary>
        /// Таймаут формирования покупателей и их корзин
        /// </summary>
        public int CustomersSpeed { get; set; }

        /// <summary>
        /// Таймаут работы кассы
        /// </summary>
        public int CashBoxSpeed { get; set; }

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
            CashBoxCount = 5;
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
        /// Метод запуска компьютерной модели
        /// </summary>
        public void Start() //public async void Start() использование async и напротив метода await 
        {
            isWorking = true;
            for (int i = 0; i < CashBoxCount; i++)
            {
                CashBox newCashBox = new CashBox(i + 1, SellersQueue.Dequeue());
                CashBoxes.Add(newCashBox);
            }
            //запускаем метод в отдельном потоке с использованием Task, в который в лямбду-функцию передаем метод, который будет
            //запускаться в отдельной потоке
            Task.Run(() => CreateRandomCarts(CustomersSpeed, CustomersCount, CustomersProductCount));   //await - будет заставлять основной поток ждать завершение метода
                                                                //это делается когда в дальнейшей работе программы нужны данные,
                                                                //получаемые из этого метода

            //Преобразуем каждый cashBox в отдельный поток с использованием Select
            var cashBoxTasks = CashBoxes.Select(cashBox => new Task(() => CashBoxWork(cashBox, CashBoxSpeed)));
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
        /// <param name="customersSpeed"></param>
        /// <param name="customersCount"></param>
        /// <param name="productsCount"></param>
        private void CreateRandomCarts(int customersSpeed, int customersCount = 10, int productsCount = 30)
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
                    //CashBox cashBox = CashBoxes[rnd.Next(CashBoxCount)];
                    CashBox cashBox = GetMinQueueInCashBox();
                    cashBox.Enqueue(customerCart);
                }
                Thread.Sleep(customersSpeed);
            }
        }

        /// <summary>
        /// Метод работы кассы, если очередь кассы есть, то извлекает из нее элемент
        /// </summary>
        /// <param name="cashBox"></param>
        /// <param name="cashBoxSpeed"></param>
        private void CashBoxWork(CashBox cashBox, int cashBoxSpeed)
        {
            while (isWorking)
            {
                if (cashBox.CartsQueue.Count > 0)
                {
                    cashBox.Dequeue();
                }
                Thread.Sleep(cashBoxSpeed);
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

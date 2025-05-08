using CrmBL.Models;

namespace CrmUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());

            //добавление элементов в базу данных
            //using (CrmContext context = new CrmContext())
            //{
            //    //Создаем экземпляры класса User
            //    Product product1 = new Product() { ProductName = "Хлеб", ProductPrice = 100, ProductCount = 1 };
            //    Product product2 = new Product() { ProductName = "Колбаса", ProductPrice = 300, ProductCount = 1 };
            //    //Добавляем экземпляры класса в кешированное хранилище
            //    context.Add(product1);
            //    context.Add(product2);
            //    //Сохраняем добавленные данные в таблицу
            //    context.SaveChanges();
            //}

            ////получение всех элементов из базы данных
            //using (CrmContext crmContext = new CrmContext())
            //{
            //    List<Product> products = crmContext.Products.ToList();
            //    Console.WriteLine("Список объектов в базе данных");
            //    foreach (Product product in products)
            //    {
            //        Console.WriteLine(product);
            //    }
            //}
            //Console.ReadLine();
        }
    }
}
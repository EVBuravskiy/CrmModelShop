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

            //���������� ��������� � ���� ������
            //using (CrmContext context = new CrmContext())
            //{
            //    //������� ���������� ������ User
            //    Product product1 = new Product() { ProductName = "����", ProductPrice = 100, ProductCount = 1 };
            //    Product product2 = new Product() { ProductName = "�������", ProductPrice = 300, ProductCount = 1 };
            //    //��������� ���������� ������ � ������������ ���������
            //    context.Add(product1);
            //    context.Add(product2);
            //    //��������� ����������� ������ � �������
            //    context.SaveChanges();
            //}

            ////��������� ���� ��������� �� ���� ������
            //using (CrmContext crmContext = new CrmContext())
            //{
            //    List<Product> products = crmContext.Products.ToList();
            //    Console.WriteLine("������ �������� � ���� ������");
            //    foreach (Product product in products)
            //    {
            //        Console.WriteLine(product);
            //    }
            //}
            //Console.ReadLine();
        }
    }
}
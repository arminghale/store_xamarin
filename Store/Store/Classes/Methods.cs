using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Store
{
    public static class Methods
    {
        public static bool SetCategory(Category category)
        {
            string GetProductsQuery = "INSERT INTO Category (Title)" +
               " VALUES( N'" + category.Title + "')";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool UpdateCategory(Category category)
        {
            string GetProductsQuery = "UPDATE  Category" +
               " SET Title= N'" + category.Title + "' WHERE (ID="+category.ID+")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool DeleteCategory(int id)
        {
            string GetProductsQuery = "DELETE FROM Category" +
               " WHERE(ID =" + id + ")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static ObservableCollection<Category> GetCategory()
        {
            const string GetProductsQuery = "select ID, Title" +
               " from Category";

            var categorys = new ObservableCollection<Category>();
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var category = new Category();
                                category.ID = reader.GetInt32(0);
                                category.Title = reader.GetString(1);
                                categorys.Add(category);
                            }
                        }
                    }
                }
            }
            return categorys;
        }


        public static bool SetProduct(Product product)
        {
            string GetProductsQuery = "INSERT INTO Product" +
               " VALUES(" + product.ID + ", N'" + product.Name + "'," + product.Count + "," +
               " N'" + product.Company + "'," + product.Price + "," + product.CategoryID + ")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool UpdateProduct(Product product)
        {
            string GetProductsQuery = "UPDATE Product" +
               " SET Name= N'" + product.Name + "', Count=" + product.Count + "," +
               "Company= N'" + product.Company + "',Price=" + product.Price + ",CategoryID=" + product.CategoryID + "  WHERE" +
               "(ID="+product.ID+")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool DeleteProduct(int id)
        {
            string GetProductsQuery = "DELETE FROM Product" +
               " WHERE(ID ="+id+")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static ObservableCollection<Product> GetProduct()
        {
            const string GetProductsQuery = "select Product.ID, Name, Company," +
               " Count, Price, CategoryID " +
               " from Product inner join Category on Product.CategoryID = Category.ID ";

            var products = new ObservableCollection<Product>();
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var product = new Product();
                                product.ID = reader.GetInt32(0);
                                product.Name = reader.GetString(1);
                                product.Company = reader.GetString(2);
                                product.Count = reader.GetInt32(3);
                                product.Price = reader.GetInt32(4);
                                product.CategoryID = reader.GetInt32(5);
                                products.Add(product);
                            }
                        }
                    }
                }
            }
            return products;
        }
        public static ObservableCollection<Product> GetProductWithCatID(int id)
        {
             string GetProductsQuery = "select Product.ID, Name, Company," +
               " Count, Price, CategoryID " +
               " from Product inner join Category on Product.CategoryID = Category.ID " +
               " where Product.CategoryID = "+id;

            var products = new ObservableCollection<Product>();
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var product = new Product();
                                product.ID = reader.GetInt32(0);
                                product.Name = reader.GetString(1);
                                product.Company = reader.GetString(2);
                                product.Count = reader.GetInt32(3);
                                product.Price = reader.GetInt32(4);
                                product.CategoryID = reader.GetInt32(5);
                                products.Add(product);
                            }
                        }
                    }
                }
            }
            return products;
        }
        public static int MablaghBaTakhfif(Product product)
        {
            List<Takhfif> takhfifs = GetTakhfifWithPrID(product.ID).ToList();
            Takhfif last = takhfifs.OrderByDescending(w => w.EndTime).FirstOrDefault();
            if (last != null)
            {
                if (System.DateTime.Now < last.EndTime && System.DateTime.Now > last.StartTime)
                {
                    double first = ((100.0 - last.Darsad) / 100.0);
                    double mablagh = first * (product.Price);
                    return int.Parse(mablagh.ToString());
                }
            }
            return product.Price;
        }


        public static bool SetTakhfif(Takhfif takhfif)
        {
            string GetProductsQuery = "INSERT INTO Takhfif" +
               " VALUES( '" + takhfif.StartTime + "','" + takhfif.EndTime + "'," +
               "" + takhfif.Darsad + "," + takhfif.ProductID + ")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool UpdateTakhfif(Takhfif takhfif)
        {
            string GetProductsQuery = "UPDATE Takhfif" +
               " SET StartTime=" + takhfif.StartTime + ", EndTime=" + takhfif.EndTime + "," +
               "Darsad=" + takhfif.Darsad + ",ProductID=" + takhfif.ProductID + "  WHERE" +
               "(ID=" + takhfif.ID + ")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool DeleteTakhfif(int id)
        {
            string GetProductsQuery = "DELETE FROM Takhfif" +
               " WHERE(ID =" + id + ")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static ObservableCollection<Takhfif> GetTakhfif()
        {
            const string GetProductsQuery = "select Takhfif.ID, StartTime, EndTime," +
              " Darsad, ProductID " +
              " from Takhfif inner join Product on Takhfif.ProductID = Product.ID ";

            var takhfifs = new ObservableCollection<Takhfif>();
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var takhfif = new Takhfif();
                                takhfif.ID = reader.GetInt32(0);
                                takhfif.StartTime = reader.GetDateTime(1);
                                takhfif.EndTime = reader.GetDateTime(2);
                                takhfif.Darsad = reader.GetInt32(3);
                                takhfif.ProductID = reader.GetInt32(4);
                                takhfifs.Add(takhfif);
                            }
                        }
                    }
                }
            }
            return takhfifs;
        }
        public static ObservableCollection<Takhfif> GetTakhfifWithPrID(int id)
        {
            string GetProductsQuery = "select Takhfif.ID, StartTime, EndTime," +
              " Darsad, ProductID " +
              " from Takhfif inner join Product on Takhfif.ProductID = Product.ID " +
              " where Takhfif.ProductID = " + id;

            var takhfifs = new ObservableCollection<Takhfif>();
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var takhfif = new Takhfif();
                                takhfif.ID = reader.GetInt32(0);
                                takhfif.StartTime = reader.GetDateTime(1);
                                takhfif.EndTime = reader.GetDateTime(2);
                                takhfif.Darsad = reader.GetInt32(3);
                                takhfif.ProductID = reader.GetInt32(4);
                                takhfifs.Add(takhfif);
                            }
                        }
                    }
                }
            }
            return takhfifs;
        }



        public static bool SetOrder(Order order)
        {
            string GetProductsQuery = "INSERT INTO [Order] (Total, TotalWithoutTakhfif, PhoneNumber, IsComplete, IsCansel)" +
               " VALUES(" + order.Total + "," + order.TotalWithoutTakhfif + ",'" + order.PhoneNumber + "'," +
               " '" + order.IsComplete + "', '" + order.ISCansel + "')";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool UpdateOrder(Order order)
        {
            string GetProductsQuery = "UPDATE  [Order]" +
               " SET Total=" + order.Total + ", TotalWithoutTakhfif=" + order.TotalWithoutTakhfif + "," +
               "PhoneNumber='" + order.PhoneNumber + "',IsComplete='" + order.IsComplete + "'" +
               ",IsCansel='" + order.ISCansel + "'  WHERE (ID=" + order.ID + ")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool DeleteOrder(int id)
        {
            string GetProductsQuery = "DELETE FROM [Order]" +
               " WHERE(ID =" + id + ")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static ObservableCollection<Order> GetOrder()
        {
            const string GetProductsQuery = "select ID, Total, TotalWithoutTakhfif, PhoneNumber, IsComplete, IsCansel" +
               " from [Order]";

            var orders = new ObservableCollection<Order>();
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var order = new Order();
                                order.ID = reader.GetInt32(0);
                                order.Total = reader.GetInt32(1);
                                order.TotalWithoutTakhfif = reader.GetInt32(2);
                                order.PhoneNumber = reader.GetString(3);
                                order.IsComplete = reader.GetBoolean(4);
                                order.ISCansel = reader.GetBoolean(5);
                                orders.Add(order);
                            }
                        }
                    }
                }
            }
            return orders;
        }
        public static ObservableCollection<Order> GetOrderWithPhNumber(string PhoneNumber)
        {
             string GetProductsQuery = "select ID, Total, TotalWithoutTakhfif, PhoneNumber, IsComplete, IsCansel" +
               " from [Order] Where(PhoneNumber='" + PhoneNumber + "')";

            var orders = new ObservableCollection<Order>();
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var order = new Order();
                                order.ID = reader.GetInt32(0);
                                order.Total = reader.GetInt32(1);
                                order.TotalWithoutTakhfif = reader.GetInt32(2);
                                order.PhoneNumber = reader.GetString(3);
                                order.IsComplete = reader.GetBoolean(4);
                                order.ISCansel = reader.GetBoolean(5);
                                orders.Add(order);
                            }
                        }
                    }
                }
            }
            return orders;
        }


        public static bool SetOrderItem(OrderItem orderItem)
        {
            string GetProductsQuery = "INSERT INTO OrderItem (OrderID, ProductID, Count, Total)" +
               " VALUES(" + orderItem.OrderID + "," + orderItem.ProductID + "," + orderItem.Count + "," +
               "" + orderItem.Total + ")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool UpdateOrderItem(OrderItem orderItem)
        {
            string GetProductsQuery = "UPDATE OrderItem" +
               " SET OrderID=" + orderItem.OrderID + ", ProductID=" + orderItem.ProductID + "," +
               "Count=" + orderItem.Count + ",Total=" + orderItem.Total + " WHERE" +
               "(ID=" + orderItem.ID + ")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool DeleteOrderItem(int id)
        {
            string GetProductsQuery = "DELETE FROM OrderItem" +
               " WHERE(ID =" + id + ")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static ObservableCollection<OrderItem> GetOrderItem()
        {
            const string GetProductsQuery = "select OrderItem.ID, OrderID, ProductID," +
              " Count, OrderItem.Total " +
              " from OrderItem inner join [Order] on OrderItem.OrderID = [Order].ID ";

            var orderItems = new ObservableCollection<OrderItem>();
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var orderItem = new OrderItem();
                                orderItem.ID = reader.GetInt32(0);
                                orderItem.OrderID = reader.GetInt32(1);
                                orderItem.ProductID = reader.GetInt32(2);
                                orderItem.Count = reader.GetInt32(3);
                                orderItem.Total = reader.GetInt32(4);
                                orderItems.Add(orderItem);
                            }
                        }
                    }
                }
            }
            return orderItems;
        }
        public static ObservableCollection<OrderItem> GetOrderItemWithOID(int id)
        {
            string GetProductsQuery = "select OrderItem.ID, OrderID, ProductID," +
              " Count, OrderItem.Total " +
              " from OrderItem inner join [Order] on OrderItem.OrderID = [Order].ID " +
              " where OrderItem.OrderID = " + id;

            var orderItems = new ObservableCollection<OrderItem>();
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var orderItem = new OrderItem();
                                orderItem.ID = reader.GetInt32(0);
                                orderItem.OrderID = reader.GetInt32(1);
                                orderItem.ProductID = reader.GetInt32(2);
                                orderItem.Count = reader.GetInt32(3);
                                orderItem.Total = reader.GetInt32(4);
                                orderItems.Add(orderItem);
                            }
                        }
                    }
                }
            }
            return orderItems;
        }


        public static bool SetEmployee(Employee employee)
        {
            string GetProductsQuery = "INSERT INTO Employee" +
               " VALUES('" + employee.ID + "', N'" + employee.Name + "', N'" + employee.Lastname + "', " +
               "'" + employee.Number + "', '" + employee.BimeNumber + "', N'" + employee.Address + "')";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool UpdateEmployee(Employee employee)
        {
            string GetProductsQuery = "UPDATE  Employee" +
               " SET Name= N'" + employee.Name + "'," +
               "Lastname= N'" + employee.Lastname + "', Number='" + employee.Number + "'," +
               "BimeNumber='" + employee.BimeNumber + "', Address= N'" + employee.Address + "' WHERE (ID='" + employee.ID + "')";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool DeleteEmployee(string id)
        {
            string GetProductsQuery = "DELETE FROM Employee" +
               " WHERE(ID = '" + id + "')";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static ObservableCollection<Employee> GetEmployee()
        {
            const string GetProductsQuery = "select ID, Name, Lastname, Number, BimeNumber, Address" +
               " from Employee";

            var employees = new ObservableCollection<Employee>();
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var employee = new Employee();
                                employee.ID = reader.GetString(0);
                                employee.Name = reader.GetString(1);
                                employee.Lastname = reader.GetString(2);
                                employee.Number = reader.GetString(3);
                                employee.BimeNumber = reader.GetString(4);
                                employee.Address = reader.GetString(5);
                                employees.Add(employee);
                            }
                        }
                    }
                }
            }
            return employees;
        }


        public static bool SetPayment(Payment payment)
        {
            string GetProductsQuery = "INSERT INTO Payment" +
               " VALUES( '" + payment.ID + "','" + payment.StartTime + "' ,'" + payment.EndTime + "' ," +
               "'" + payment.Price + "' ," + payment.EmployeeID + ")";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool UpdatePayment(Payment payment)
        {
            string GetProductsQuery = "UPDATE Payment" +
               " SET StartTime=" + payment.StartTime + ", EndTime=" + payment.EndTime + "," +
               "Price=" + payment.Price + ",EmployeeID=" + payment.EmployeeID + " WHERE" +
               "(ID='" + payment.ID + "')";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool DeletePayment(string id)
        {
            string GetProductsQuery = "DELETE FROM Payment" +
               " WHERE(ID ='" + id + "')";
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static ObservableCollection<Payment> GetPayment()
        {
            const string GetProductsQuery = "select ID, StartTime, EndTime," +
              " Price, EmployeeID " +
              " from Payment inner join Employee on Payment.EmployeeID = Employee.ID " +
               " where Discontinued = 0";

            var payments = new ObservableCollection<Payment>();
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var payment = new Payment();
                                payment.ID = reader.GetString(0);
                                payment.StartTime = reader.GetDateTime(1);
                                payment.EndTime = reader.GetDateTime(2);
                                payment.Price = reader.GetString(3);
                                payment.EmployeeID = reader.GetString(4);
                                payments.Add(payment);
                            }
                        }
                    }
                }
            }
            return payments;
        }
        public static ObservableCollection<Payment> GetPaymentWithEmID(string id)
        {
            string GetProductsQuery = "select Payment.ID, StartTime, EndTime," +
              " Price, EmployeeID " +
              " from Payment inner join Employee on Payment.EmployeeID = Employee.ID " +
              " where Payment.EmployeeID = '" + id+"'";

            var payments = new ObservableCollection<Payment>();
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = GetProductsQuery;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var payment = new Payment();
                                payment.ID = reader.GetString(0);
                                payment.StartTime = reader.GetDateTime(1);
                                payment.EndTime = reader.GetDateTime(2);
                                payment.Price = reader.GetString(3);
                                payment.EmployeeID = reader.GetString(4);
                                payments.Add(payment);
                            }
                        }
                    }
                }
            }
            return payments;
        }
    }
}

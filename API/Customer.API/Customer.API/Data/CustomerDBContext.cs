using Customer.API.Business.Interfaces;
using Customer.API.Models;
using System.Text;

namespace Customer.API.Data
{
    public class CustomerDBContext
    {
        private const string fileName = "..\\..\\..\\Data\\Customer.csv";//TODO: this path can be configurable from Appsettings.json
        public CustomerDBContext() { 
            // DB context like connection string can assign here
        }

        public IList<ICustomer> LoadCustomersData()
        {
            return GetCustomerList();
        }

        public void AddCustomerData(ICustomer customer)
        {
            AddCustomerInList(customer);
        }

        public ICustomer GetCustomerData(Guid id)
        {
             return GetCustomer(id);
        }

        public void UpdateCustomerData(ICustomer customer)
        {
            UpdateCustomer(customer);
        }

        public void DeleteCustomerData(Guid id)
        {
            DeleteCustomer(id);
        }

        private static IList<ICustomer> GetCustomerList()
        {
            var customerLines = GetCustomerLinesFromFile();
            if (customerLines.Count > 0)
            {
                IList<ICustomer> customers = new List<ICustomer>();
                ICustomer customer = null;
                foreach (var item in customerLines)
                {
                    List<string> customerFields = item.Split(',').ToList<string>();
                    if (customerFields.Count > 5)
                    {
                        customer = new CustomerModel();
                        customer.Id = customerFields[0];
                        customer.FirstName = customerFields[1];
                        customer.LastName = customerFields[2];
                        customer.Email = customerFields[3];
                        customer.CreatedDateTime = DateTime.Parse(customerFields[4]);
                        customer.UpdatedDateTime = DateTime.Parse(customerFields[5]);
                        customers.Add(customer);
                    }

                }
                return customers;
            }
            else
            {
                return new List<ICustomer>();
            }
        }

        private static void AddCustomerInList(ICustomer customer)
        {
            StringBuilder customerSB = new StringBuilder();
            var comma = ",";
            customerSB.Append("\r");
            customerSB.Append(customer.Id.ToString());
            customerSB.Append(comma);
            customerSB.Append(customer.FirstName);
            customerSB.Append(comma);
            customerSB.Append(customer.LastName);
            customerSB.Append(comma);
            customerSB.Append(customer.Email);
            customerSB.Append(comma);
            customerSB.Append(customer.CreatedDateTime.ToString());
            customerSB.Append(comma);
            customerSB.Append(customer.UpdatedDateTime.ToString());

            using (FileStream aFile = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(aFile))
            {
                sw.WriteLine(customerSB.ToString());
            }
        }

        private static ICustomer GetCustomer(Guid id)
        {
            var customerLines = GetCustomerLinesFromFile();
            ICustomer customer = null;
            if (customerLines.Count > 0)
            {

                foreach (var item in customerLines)
                {
                    List<string> customerFields = item.Split(',').ToList<string>();
                    if (customerFields.Count > 5 && customerFields[0] == id.ToString())
                    {
                        customer = new CustomerModel();
                        customer.Id = customerFields[0];
                        customer.FirstName = customerFields[1];
                        customer.LastName = customerFields[2];
                        customer.Email = customerFields[3];
                        customer.CreatedDateTime = DateTime.Parse(customerFields[4]);
                        customer.UpdatedDateTime = DateTime.Parse(customerFields[5]);
                    }
                }
            }
            return customer;
        }

        private static void UpdateCustomer(ICustomer customer)
        {
            var customerLines = GetCustomerLinesFromFile();
            if (customerLines.Count > 0)
            {
                StringBuilder customerSB = new StringBuilder();
                var comma = ",";
                foreach (var item in customerLines)
                {
                    List<string> customerFields = item.Split(',').ToList<string>();
                    if (customerFields.Count > 5)
                    {
                        customerSB.Append("\r");
                        if (customerFields[0] == customer.Id.ToString())
                        {
                            customerSB.Append(customer.Id.ToString());
                            customerSB.Append(comma);
                            customerSB.Append(customer.FirstName);
                            customerSB.Append(comma);
                            customerSB.Append(customer.LastName);
                            customerSB.Append(comma);
                            customerSB.Append(customer.Email);
                            customerSB.Append(comma);
                            customerSB.Append(customer.CreatedDateTime.ToString());
                            customerSB.Append(comma);
                            customerSB.Append(customer.UpdatedDateTime.ToString());
                        }
                        else
                        {
                            customerSB.Append(customerFields[0]);
                            customerSB.Append(comma);
                            customerSB.Append(customerFields[1]);
                            customerSB.Append(comma);
                            customerSB.Append(customerFields[2]);
                            customerSB.Append(comma);
                            customerSB.Append(customerFields[3]);
                            customerSB.Append(comma);
                            customerSB.Append(customerFields[4]);
                            customerSB.Append(comma);
                            customerSB.Append(customerFields[5]);
                        }
                        
                        
                    }

                }
                using (FileStream aFile = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(aFile))
                {
                    sw.WriteLine(customerSB.ToString());
                }
            }
        }

        private static void DeleteCustomer(Guid id)
        {
            var customerLines = GetCustomerLinesFromFile();
            if (customerLines.Count > 0)
            {
                StringBuilder customerSB = new StringBuilder();
                var comma = ",";
                foreach (var item in customerLines)
                {
                    List<string> customerFields = item.Split(',').ToList<string>();
                    if (customerFields.Count > 5 && customerFields[0] != id.ToString())
                    {
                        customerSB.Append("\r");
                        customerSB.Append(customerFields[0]);
                        customerSB.Append(comma);
                        customerSB.Append(customerFields[1]);
                        customerSB.Append(comma);
                        customerSB.Append(customerFields[2]);
                        customerSB.Append(comma);
                        customerSB.Append(customerFields[3]);
                        customerSB.Append(comma);
                        customerSB.Append(customerFields[4]);
                        customerSB.Append(comma);
                        customerSB.Append(customerFields[5]);
                    }
                }
                using (FileStream aFile = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(aFile))
                {
                    sw.WriteLine(customerSB.ToString());
                }
            }
        }
        private static IList<string> GetCustomerLinesFromFile()
        {
            var customerLines = new List<string>();
            if (File.Exists(fileName))
            {
                using (var sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        customerLines.Add(line);
                }
            }
            return customerLines;
        }

    }
}

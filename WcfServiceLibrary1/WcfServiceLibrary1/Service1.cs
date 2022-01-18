using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public double Deposit(string accno, double amount)
        {
            Bankc2009eEntities context = new Bankc2009eEntities();

            var result = context.BankAccounts.SingleOrDefault(b => b.accno == accno);

            if (result != null)
            {
                try
                {
                    result.accamount = result.accamount + amount;
                    context.SaveChanges();

                    return amount;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return 0;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier.Entities;
using NHibernate;

namespace DataTier.DAO
{
    public abstract class DAO
    {
        // Get type of Object base on string
        private static Type getType(string objectType)
        {
            switch (objectType)
            {
                case Entity.ADDRESS:
                    return typeof(Address);
                    
                case Entity.CATEGORY:
                    return typeof(Categories);
                    
                case Entity.CATEGORYRELATION:
                    return typeof(CategoryRelations);
                    
                case Entity.CUSTOMER:
                    return typeof(Customers);
                   
                case Entity.FAQ:
                    return typeof(FAQs);
                    
                case Entity.INVOICE:
                    return typeof(Invoices);
                    
                case Entity.MESSAGE:
                    return typeof(Messages);
                    
                case Entity.MESSAGERECEIVER:
                    return typeof(MessageReceivers);
                    
                case Entity.NEWS:
                    return typeof(News);
                   
                case Entity.ORDER:
                    return typeof(Orders);

                case Entity.PRODUCT:
                    return typeof(Products);
                    
                case Entity.PRODUCTDETAIL:
                    return typeof(ProductDetails);
                    
                case Entity.PRODUCTSUPPLIER:
                    return typeof(ProductSuppliers);
                    
                case Entity.ROLE:
                    return typeof(Roles);
                    
                case Entity.SHIPPINGMETHOD:
                    return typeof(ShippingMethods);
                    
                case Entity.STATUS:
                    return typeof(Status);
                    
                case Entity.SUPPLIER:
                    return typeof(Supplies);
                    
                case Entity.UNIT:
                    return typeof(Units);
                    
                case Entity.USER:
                    return typeof(Users);
                    
            }
            return typeof(Object);

        }

        // Execute
        public static void Execute(Object obj, string objectType, string executeType)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    switch (executeType)
                    {
                        case ExecuteType.ADD:
                            session.SaveOrUpdate(Convert.ChangeType(obj, getType(objectType)));
                            break;
                        case ExecuteType.REMOVE:
                            session.Delete(Convert.ChangeType(obj, getType(objectType)));
                            break;
                        case ExecuteType.UPDATE:
                            session.Update(Convert.ChangeType(obj, getType(objectType)));
                            break;
                    }

                    transaction.Commit();
                    
                }
                catch (Exception e)
                {
                    // e.ToString();
                }
            }
        }

        public static List<Object> getAll()
        {
            return null;
        }
    }
}

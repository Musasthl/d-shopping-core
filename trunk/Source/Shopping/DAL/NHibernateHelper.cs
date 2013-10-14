using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using System.Reflection;
using NHibernate;

namespace DAL
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static string connectionXML = "<?xml version='1.0' encoding='utf-8' ?>"
            + "<hibernate-configuration>"
            + "<session-factory>"
            + "<property name='connection.provider'>NHibernate.Connection.DriverConnectionProvider</property>"
            + "<property name='dialect'>NHibernate.Dialect.MsSql2008Dialect</property>"
            + "<property name='connection.driver_class'>NHibernate.Driver.SqlClientDriver</property>"
            + @"<property name='connection.connection_string'>Data Source=DANGDH2\MSSQLSERVER2008;uid=sa;pwd=123456;Initial Catalog=Shopping</property>"
            + "<property name='show_sql'>true</property>"
            + "</session-factory>"
            + "</hibernate-configuration>";
        private static ISessionFactory SessionFactory
        {

            get
            {

                if (_sessionFactory == null)
                {

                    var configuration = new Configuration();
                    configuration.Configure();
                    
                    // configuration.AddXmlString(connectionXML);
                    configuration.AddAssembly(Assembly.GetCallingAssembly());

                    _sessionFactory = configuration.BuildSessionFactory();

                }

                return _sessionFactory;

            }

        }



        public static ISession OpenSession()
        {

            return SessionFactory.OpenSession();

        }
    }
}

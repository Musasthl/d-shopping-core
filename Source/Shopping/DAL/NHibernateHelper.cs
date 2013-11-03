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

        private static ISessionFactory SessionFactory
        {

            get
            {

                if (_sessionFactory == null)
                {

                    var configuration = new Configuration();
                    configuration.Configure();

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

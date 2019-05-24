using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapif.Models;

namespace webapif.helper
{
    public class NHibernateHelper
    {
        private static string ConnectionString = "Server=localhost; Port=5432; User Id=postgres; Password=cs2019; Database=crudwepapi";
        //private static ISessionFactory session;
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    CreateSessionFactory();

                return _sessionFactory;
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            //IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
            //_sessionFactory = Fluently.Configure()
            //    .Database(configDB)
            //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ServerData>())
            //   .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
            //.BuildSessionFactory();
            if (_sessionFactory != null)
                return _sessionFactory;
            IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
            var configMap = Fluently
                    .Configure()
                    .Database(configDB).Mappings(c => c.FluentMappings.AddFromAssemblyOf<ServerData>());


            _sessionFactory = configMap.BuildSessionFactory();
            return _sessionFactory;
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();

        }


    }
}
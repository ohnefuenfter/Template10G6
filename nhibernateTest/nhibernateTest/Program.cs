using System;
using System.Collections.Generic;
using System.Reflection;
using nhibernateTest.Test;
using NHibernate.Cfg;

namespace nhibernateTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var configuration = new Configuration();
                configuration.Configure();

                ReadConfiguration(configuration);

                var sessionFactory = configuration.BuildSessionFactory();
                Console.Out.WriteLineAsync("Session initialized");

                var session = sessionFactory.OpenSession();
                // https://stackoverflow.com/questions/20829531/nhibernate-query-for-items-that-have-a-dictionary-property-containing-value
                using (var t = session.BeginTransaction())
                {
                    /* var query =
                        session.CreateQuery(
                            "select a from ClassA a join a.WrapDict w join w.ClassB b where w.Factor = 1 order by b.CreateDate"); */
                    var classA = session.Load<ClassA>(2);

                    var query =
                        session.CreateFilter(classA.WrapDict,
                            "where this.Factor = :factor order by this.ClassB.CreateDate").SetParameter("factor", 1);
                    var results = query.List<WrapDictAB>() ?? new List<WrapDictAB>();
                    foreach (var r in results)
                            Console.Out.WriteLine(r.ToString());
                    t.Commit();
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e);
            }
        }

        private static void ReadConfiguration(Configuration configuration)
        {
            configuration.AddAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
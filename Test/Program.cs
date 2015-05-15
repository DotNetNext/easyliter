using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easyliter
{
    class Program
    {
        static void Main(string[] args)
        {
            var connstr = "DataSource=" + System.AppDomain.CurrentDomain.BaseDirectory + "mapping.sqllite";

            //依赖于 System.Data.SQLite
            Easyliter e = new Easyliter(connstr);

            //从数据库创建类
            var createCalss1 = e.CreateClass("Sqlite.Model"/*命名空间*/, @"D:\TFS\EmailBackup\Easyliter\Test\model"/*路径*/);

            ////根据SQL语句创建类,多表查询会用到
            //var createCalss2 = e.CreateClassBySql("Sqlite.Model", @"D:\TFS\EmailBackup\Easyliter\Test\model1", "viewproduct", "select id,sku from product ");

            ////删除
            //// e.Delete<Product>(100);
            //// e.Delete<Product>(new int [] {1,2,3});

            ////更新
            ////e.Update<Product>(new { sku = "x2",category_id=1 }, new { id=434 });


            //////添加
            ////Product p = new Product()
            ////{
            ////    category_id = 2,
            ////    sku = "sku",
            ////    title = "title"
            ////};
            ////e.Insert<Product>(p);

            //////根据sql查询
            //List<Product> list = e.Select<Product>("select * from product where  id>@num", new { num = 100 });

            ////无条件
            //List<Category> list2 = e.Select<Category>();

            ////单条件
            //List<Product> list3 = e.Select<Product>(x => x.id > 200);

            ////多条件
            //List<Product> list4 = e.Select<Product>(x => x.id > 200,
            //                                        x => x.sku == "skx" || x.sku == null);
            ////多条件分页
            //int count = 0;
            //List<Product> list5 = e.SelectPage<Product>(1, 10, ref count, " id  desc",
            //                                x => x.id > 10,//条件1
            //                                x => true);//条件2 ...条件N


            ////linq语法生成集合
            //var queryable = e.Query<Product>().Where(x => x.id > 10).Where(x => x.id > 2).Select("id,sku")
            //    .OrderBy(El_Sort.asc, "id")
            //    .OrderBy(El_Sort.desc, "sku").Take(100);

            ////获取集合
            //var list6 = queryable.ToList();
            ////获取SQL
            //string sql = queryable.ToSql();



            ////原始操作
            //var dt = e.GetDataTable("select * from product");
            //var intVal = e.GetInt("select count(*) from product");
            //var stringVal = e.GetString("select sku from product where id=500 ");
            ////e.ExecuteNonQuery("inset into ..");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace  Sqlite.Model{

 public class Product{
           public System.Int64 id {get;set;}
           public System.String sku {get;set;}
           public System.Int64 category_id {get;set;}
           public System.String title {get;set;}

  }
 public class V_Product
 {
     public System.Int64 id { get; set; }
     public System.String sku { get; set; }
     public System.Int64 category_id { get; set; }
     public System.String category_name { get; set; }
     public System.String title { get; set; }

 }
} 
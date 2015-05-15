using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace  Sqlite.Model{

 public class Category{
           public System.Int64 id {get;set;}
           public System.String name {get;set;}
           public System.Int64 mapping_id {get;set;}
           public System.Int64 parent_id {get;set;}
           public System.String avatar {get;set;}
           public System.String keyword {get;set;}
           public System.String description {get;set;}
           public System.Int64 is_flag {get;set;}
           public System.Int64 sort_id {get;set;}
           public System.String sku {get;set;}
           public System.String pdf {get;set;}

  }
} 
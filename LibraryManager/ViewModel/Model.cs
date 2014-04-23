using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections;

namespace LibraryManager.ViewModel
{
    public class Model
    {
        public string bookID { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "{0} cannot empty")]
        public string Content { get; set; }

        [Display(Name = "Full name")]
        [Required(ErrorMessage = "{0} cannot empty")]
        public string FullName { get; set; }

        public List<Model> ListComment { get; set; }
    }
    public class MyListComment
    {
        public  Dictionary<string, List<Model>> table;
        public MyListComment()
        {
            if (table == null)
                table = new Dictionary<string, List<Model>>();
        }
        public  Dictionary<string, List<Model>> TakeAll()
        {
            if (table == null)
                table = new Dictionary<string, List<Model>>();
            return table;
        }
        public List<Model> TakeCommentByBookId(string IdSP)
        {
            List<Model> list = new List<Model>(); 
            if (table == null) return list;
            table.TryGetValue(IdSP,out list);
            return list;
        }
        public void AddComment(Model model,string sanPhamId)
        {
            if (model != null&&sanPhamId!=null)
            {
                List<Model> list;
                if (table.TryGetValue(sanPhamId, out list))
                {
                    list.Add(model);
                    table[sanPhamId] = list;
                }
                else
                {
                    list=new List<Model>();
                    list.Add(model);
                    table.Add(sanPhamId, list);
                }
            }
        }
    }
}
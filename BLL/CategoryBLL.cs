using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
    public class CategoryBLL
    {
        CategoryDAO dao = new CategoryDAO();

        private string CategoryName;
        private DateTime AddDate;
        private DateTime LastUpdateDate;
        private int LastUpdateUserID;

        public bool AddCategory(CategoryDTO model)
        {
            DAL.Category category = new DAL.Category();

            category.CategoryName = model.CategoryName;
            category.AddDate = DateTime.Now;
            category.LastUpdateDate = DateTime.Now;
            category.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddCategory(category);
            LogDAO.AddLog(General.ProcessType.CategoryAdd, General.TableName.Category, ID);
            return true;

        }

        public static List<SelectListItem> GetCategoriesForDropdown()
        {
            return (List<SelectListItem>)CategoryDAO.GetCategoriesForDropdown();
        }

        

        public List<CategoryDTO> GetCatgories()
        { 
            return dao.GetCategories();
        }

        public CategoryDTO GetCatgoryWithID(int ID)
        {
            return dao.GetCategoryWithID(ID);
        }

        public bool UpdateCategory(CategoryDTO model)
        {
            dao.UpdateCategory(model); 
            LogDAO.AddLog(General.ProcessType.CategoryUpdate, General.TableName.Category, model.ID);
            return true;
        }
        PostBLL postbll=new PostBLL();
        public List<PostImageDTO> DeleteCategory(int ID)
        {
            List<Post> postlist = dao.DeleteCategory(ID);
            LogDAO.AddLog(General.ProcessType.CategoryDelete, General.TableName.Category, ID);
            List<PostImageDTO> imagelist = new List<PostImageDTO>();
            foreach(var item in postlist)
            {
                List<PostImageDTO> imagelist2 = postbll.DeletePost(item.ID);
                LogDAO.AddLog(General.ProcessType.PostDelete,General.TableName.post,item.ID);
                foreach (var item2 in imagelist2)
                {
                    imagelist.Add(item2);
                }
            }
            return imagelist;
        }
    }
}

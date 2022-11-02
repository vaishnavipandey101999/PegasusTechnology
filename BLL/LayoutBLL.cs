using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LayoutBLL
    {
        
        CategoryDAO category = new CategoryDAO();
        SocialMediaDAO socialdao=new SocialMediaDAO();
        FavDAO favdao=new FavDAO();
        MetaDAO metadao=new MetaDAO();
        AddressDAO addressdao = new AddressDAO();
        PostDAO postdao=new PostDAO();
        

        public HomeLayoutDTO GetLayoutData()
        {
            HomeLayoutDTO dto=new HomeLayoutDTO();
            dto.Categories = category.GetCategories();  /*daocategory*/

            List<SocialMediaDTO> socialmedialist = new List<SocialMediaDTO>();
            socialmedialist = socialdao.GetSocialMedias();
            dto.Facebook = socialmedialist.First(x => x.Name.Contains("facebook"));
            dto.Twitter = socialmedialist.First(x => x.Name.Contains("twitter"));
            dto.Instagram = socialmedialist.First(x => x.Name.Contains("Instagram"));
            dto.Youtube = socialmedialist.First(x => x.Name.Contains("youtube"));
            dto.Linkedin = socialmedialist.First(x => x.Name.Contains("linkedin"));
            dto.FavDTO = favdao.GetFav();
            dto.Metalist=metadao.GetMetaData();
            List<AddressDTO> addresslist = addressdao.GetAddresses();
            dto.Address = addresslist.First();
            dto.HotNews = postdao.GetHotNews();

            return dto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DTO;

namespace DAL
{
    public class MetaDAO : PostContext //Dao class must be inherit from PostContent class
    {
        public int AddMeta(Meta meta)
        {
            try
            {
                db.Metas.Add(meta);
                db.SaveChanges();
                return meta.ID;
            }
            catch (Exception ex)

            { 
             throw ex;

            }
        }

        public List<MetaDTO> GetMetaData()
        {
        List<MetaDTO> metalist = new List<MetaDTO>();
         List<Meta> list = db.Metas.Where(x=>x.isDeleted==false).OrderBy(x=>x.AddDate).ToList();
            foreach (var item in list)
            {
                MetaDTO dto = new MetaDTO();
                dto.MetaID = item.ID;
                dto.Name = item.Name;
                dto.MetaContent = item.MetaContent;
                metalist.Add(dto);
            }
        return metalist;
        }

        public MetaDTO GetMetaWithID(int ID)
        {
            Meta meta = db.Metas.First(x => x.ID == ID);
            MetaDTO dto = new MetaDTO();
            dto.MetaID = ID;
            dto.Name = meta.Name;
            dto.MetaContent = meta.MetaContent;
            return dto;
        }

        public void DeleteMeta(int ID)
        {
            try
            {
                Meta meta=db.Metas.First(x=>x.ID == ID);
                meta.isDeleted = true;
                meta.DeletedDate= DateTime.Now;
                meta.LastUpdateDate = DateTime.Now;
                meta.LastUpdateUserID=UserStatic.UserID;
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateMeta(MetaDTO model)
        {
            try
            {
                Meta meta = db.Metas.First(x => x.ID == model.MetaID);
                meta.Name = model.Name;
                meta.MetaContent = model.MetaContent;
                meta.LastUpdateDate = DateTime.Now;
                meta.LastUpdateUserID = UserStatic.UserID;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

}

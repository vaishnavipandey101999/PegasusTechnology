using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
    public class LogDAO:PostContext
    {
        public static void AddLog(int ProcessType,string Tablename,int ProcessID)
        {
            //Add log into our log table
            Log_Table log = new Log_Table();
            log.UserID = UserStatic.UserID;
            log.ProcessType = ProcessType;
            log.ProcessID= ProcessID;
            log.ProcessCategoryType = Tablename;
            log.ProcessDate = DateTime.Now;
            log.IPAddress = HttpContext.Current.Request.UserHostAddress;
            db.Log_Table.Add(log);
            db.SaveChanges();


        }

        public List<LogDTO> GetLogs()
        {
            List<LogDTO> dtolist = new List<LogDTO>();
            var list = (from l in db.Log_Table
                        join u in db.T_User on l.UserID equals u.ID
                        join p in db.ProcessTypes on l.ProcessType equals p.ID
                        select new
                        {
                            ID = l.ID,
                            UserName = u.Username,
                            TableName = l.ProcessCategoryType,
                            TableID = l.ProcessID,
                            ProcessName = p.ProcessName,
                            ProcessDate = l.ProcessDate,
                            ipAddress = l.IPAddress
                        }).OrderByDescending(XmlSiteMapProvider => XmlSiteMapProvider.ProcessDate).ToList();
                        foreach(var item in list)
                        {
                        LogDTO dto=new LogDTO();
                        dto.ID = item.ID;
                        dto.UserName= item.UserName;
                        dto.TableName = item.TableName;
                        dto.TableID= item.TableID;
                        dto.ProcessName = item.ProcessName;
                        dto.ProcessDate= item.ProcessDate;
                        dto.IpAddress = item.ipAddress;
                         dtolist.Add(dto);


                        }

                      return dtolist;

        }
    }
}

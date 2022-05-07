using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models;
using DAL.Entities;

namespace BLL.Repository
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<PhotoForApprovalDTO>> GetUnapprovedPhotos();
        Task<Photo> GetPhotoById(int id);
        void RemovePhoto(Photo photo);
    }
}
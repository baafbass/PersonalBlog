using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.AdminDtos;
using PersonalBlog.Services.Abstract;
using PersonalBlog.Shared.Utilities;
using PersonalBlog.Shared.Utilities.Abstract;
using PersonalBlog.Shared.Utilities.Complex_Types;
using PersonalBlog.Shared.Utilities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Services.Concrete
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<AdminDto>> Get(int adminId = 1)
        {
            var admin = await _unitOfWork.Admin.GetAsync(x => x.ID == adminId);
            return new DataResult<AdminDto>(ResultStatus.Success, new AdminDto
            {
                Admin = admin,
                ResultStatus = ResultStatus.Success,
                Info = "Operation Successed !"
            });
        }

        public async Task<IDataResult<AdminUpdateDto>> GetUpdateDto(int adminId)
        {
            var admin = await _unitOfWork.Admin.GetAsync(x => x.ID == adminId);
            if (admin != null)
            {
                var adminUpdateDto = _mapper.Map<AdminUpdateDto>(admin);
                return new DataResult<AdminUpdateDto>(ResultStatus.Success, adminUpdateDto);
            }
            return new DataResult<AdminUpdateDto>(ResultStatus.Error,null, "Hata, kayıt bulunamadı!");
        }

        public Task<IResult> HardDelete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<AdminDto>> Update(AdminUpdateDto adminUpdateDto, string modifiedByName)
        {
            var admin = _mapper.Map<Admin>(adminUpdateDto);
            admin.ModifiedByName = modifiedByName;
            admin.ModifiedTime = DateTime.Now;
            var updatedAdmin = await _unitOfWork.Admin.UpdateAsync(admin);
            await _unitOfWork.SaveAsync();
            return new DataResult<AdminDto>(ResultStatus.Success, new AdminDto
            {
                Admin = updatedAdmin,
                ResultStatus = ResultStatus.Success,
                Info = "Operation Successed !"
            });
        }
    }
}

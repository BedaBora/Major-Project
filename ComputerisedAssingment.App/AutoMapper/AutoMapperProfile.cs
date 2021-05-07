using AutoMapper;
using ComputerisedAssingment.ModelEntity;
using ComputerisedAssingment.ModelView;

namespace ComputerisedAssingment.App.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UsersVM>().ReverseMap();
            CreateMap<AssingStudents, AssingStudentsVM>().ReverseMap();
            CreateMap<TeacherUpload, TeacherUploadVM>().ReverseMap();
            CreateMap<StudentUpload, StudentUploadVM>().ReverseMap();
        }
    }
}

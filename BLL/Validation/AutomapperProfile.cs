
using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Validation;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Client, ClientModel>()
            .ForMember(cm => cm.RecommenderConfigurationIds, c => c.MapFrom(x => x.RecommenderConfigurations.Select(x => x.Id.ToString())))
            .ForMember(cm => cm.UploadedCsvIds, c => c.MapFrom(x => x.UploadedCSVs.Select(x => x.Id.ToString())));


        CreateMap<UploadedCSV, UploadedCsvModel>()
            .ForMember(ucm => ucm.RecommenderToUploadedCsvIds, uc => uc.MapFrom(x => x.RecommenderToUploadedCSVs.Select(x => x.Id.ToString())));


        CreateMap<RecommenderConfiguration, RecommenderConfigurationModel>()
            .ForMember(rcm => rcm.RecommenderToUploadedCsvIds, rc => rc.MapFrom(x => x.RecommenderToUploadedCSVs.Select(x => x.Id.ToString())));

        CreateMap<RecommenderConfigurationModel, RecommenderConfiguration>();

        CreateMap<LinkedDatabase, LinkedDatabaseModel>()
            .ReverseMap();


    }

}
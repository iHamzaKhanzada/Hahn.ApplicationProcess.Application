using AutoMapper;
using Hahn.ApplicationProcess.February2021.Domain.Entities;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Queries.Assets.GetAssetDetail
{
    public class AssetDetailVM : IMapFrom<Asset>
    {
        public int Id { get; set; }
        public string AssetName { get; set; }

        //public Department Department { get; set; }

        public string CountryOfDepartment { get; set; }
        public string EMailAdressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Broken { get; set; }

        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Asset, AssetDetailVM>()
                .ForMember(d => d.EditEnabled, opt => opt.Ignore())
                .ForMember(d => d.DeleteEnabled, opt => opt.Ignore());
        }
    }
}

using AutoMapper;
using Foodies.APIs.DTOs;
using Foodies.Core.Entities;
using Foodies.Core.Entities.IEntities;

namespace Foodies.APIs.Helpers
{
    public class GenericPicUrlResolver<TSrc, TDest> : IValueResolver<TSrc, TDest, string> where TSrc: IPicturable
    {
        private readonly IConfiguration configuration;
        public GenericPicUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(TSrc source, TDest destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{configuration["Host"]}/{source.PictureUrl}";

            return string.Empty;
        }
    }
}


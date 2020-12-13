using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using Revivevzw.Business.Repositories;
using Revivevzw.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
    public class MissionService : IMissionService
    {
        private readonly IMissionRepository missionRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public MissionService(IMissionRepository missionRepository, IMapper mapper, IConfiguration configuration)
        {
            this.missionRepository = missionRepository ?? throw new ArgumentNullException(nameof(missionRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<Mission> Get(int id)
        {
            var entity = await this.missionRepository.Get(id);
            var model = this.mapper.Map<Mission>(entity);

            var mediaUrls = GetMediaUrls(id);
            model.MediaUrls = mediaUrls;

            return model;
        }

        public async Task<ICollection<Mission>> Get()
        {
            var entities = await this.missionRepository.Get();
            return this.mapper.Map<ICollection<Mission>>(entities);
        }

        private IEnumerable<string> GetMediaUrls(int missionId)
        {
            var connectionString = this.configuration.GetConnectionString("BlobStorage");
            var container = new BlobContainerClient(connectionString, $"missionreports");
            var blobs = container.GetBlobs().Where(x => x.Name.Contains($"MISpic{missionId}d")).Select(x => $"{container.Uri}/{x.Name}");
            return blobs;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Otiport.API.Contract.Request.Common;
using Otiport.API.Contract.Response.Common;
using Otiport.API.Mappers;
using Otiport.API.Providers;
using Otiport.API.Repositories;

namespace Otiport.API.Services.Implementations
{
    public class AddressInformationService : IAddressInformationService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserMapper _userMapper;
        private readonly IAdressInformationRepository _adressInformationRepository;
        private readonly ITokenProvider _tokenProvider;
        private readonly IConfiguration _configuration;

        public AddressInformationService(ILogger<UserService> logger, IUserMapper userMapper,
            IAdressInformationRepository adressInformationRepository,
            ITokenProvider tokenProvider, IConfiguration configuration)
        {
            _logger = logger;
            _userMapper = userMapper;
            _adressInformationRepository = adressInformationRepository;
            _tokenProvider = tokenProvider;
            _configuration = configuration;
        }
        public async Task<GetCountriesResponse> GetCountriesAsync(GetCountriesRequest request)
        {
            var response = new GetCountriesResponse();
            response.ListOfCountries = _adressInformationRepository.GetCountries();
            return response;
        }
    }
}

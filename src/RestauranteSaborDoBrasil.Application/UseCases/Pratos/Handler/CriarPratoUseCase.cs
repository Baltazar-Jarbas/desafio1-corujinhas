﻿using AutoMapper;
using RestauranteSaborDoBrasil.Application.UseCases.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.UseCases.Pratos.Handler
{
    public class CriarPratoUseCase : UseCaseValidationBase<CriarPratoRequest, Prato, PratoResponse>
    {
        public CriarPratoUseCase(
            IHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork, 
            IBaseRepository<Prato> baseRepository, 
            IMapper mapper) : base(notifications, unitOfWork, baseRepository, mapper)
        {
        }

        public override async Task<PratoResponse> Handle(CriarPratoRequest request, CancellationToken cancellationToken)
            => await base.RegisterAsync(request);

    }
}

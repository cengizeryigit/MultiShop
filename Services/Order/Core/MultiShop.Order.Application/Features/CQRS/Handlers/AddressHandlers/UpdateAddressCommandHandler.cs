using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var address = await _repository.GetByIdAsync(updateAddressCommand.AddressID);
            if (address != null)
            {
                address.City = updateAddressCommand.City;
                address.District = updateAddressCommand.District;
                address.Detail = updateAddressCommand.Detail;
                address.UserID = updateAddressCommand.UserID;
                await _repository.UpdateAsync(address);
            }
            else
            {
                throw new Exception("Address not found");
            }
        }
    }
}
